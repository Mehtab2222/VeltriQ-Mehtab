using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.AssetAllocation;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;


namespace VeltriQ.Controllers
{
    public class AssetAllocationController : BaseController
    {
        private readonly TenantDbContext _context;

        public AssetAllocationController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        //====================================================
        // INDEX
        //====================================================
        public async Task<IActionResult> Index()
        {
            var model = new AssetAllocationIndexViewModel();

            model.Items = await _context.Employees
                .Include(x => x.Department)
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.EmployeeId)
                .Select(x => new AssetAllocationListItemViewModel
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.EmployeeCode,
                    EmployeeName = x.FirstName + " " + x.LastName,
                    Department = x.Department != null ? x.Department.DepartmentName : "",
                    JoiningDate = x.JoiningDate,
                    TotalAssets = _context.EmployeeAssets
                        .Count(a => a.EmployeeId == x.EmployeeId && a.IsActive),
                    AllocationStatus = _context.EmployeeAssets.Any(a => a.EmployeeId == x.EmployeeId && a.IsActive)
                        ? "Allocated"
                        : "Pending"
                })
                .ToListAsync();

            return View(model);
        }

        //====================================================
        // CREATE (GET)
        //====================================================
        public async Task<IActionResult> Create()
        {
            var model = new AssetAllocationCreateViewModel();

            // EMPLOYEE DROPDOWN
            model.Employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.EmployeeCode)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                })
                .ToListAsync();

            model.Employees.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- Select Employee --"
            });

            // ASSET DROPDOWN
            model.Assets = await _context.AssetMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.AssetCode)
                .Select(x => new SelectListItem
                {
                    Value = x.AssetMasterId.ToString(),
                    Text = x.AssetCode + " - " + x.AssetName
                })
                .ToListAsync();

            model.Assets.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- Select Asset --"
            });

            return View(model);
        }

        //====================================================
        // VERIFY EXISTING ALLOCATION (AJAX GET)
        //====================================================
        [HttpGet]
        public async Task<IActionResult> VerifyExistingAllocation(int employeeId, int assetMasterId)
        {
            // Dynamically checks database state to eliminate live duplicate records
            bool exists = await _context.EmployeeAssets
                .AnyAsync(a => a.EmployeeId == employeeId && a.AssetMasterId == assetMasterId && a.IsActive);

            return Json(new { alreadyAllocated = exists });
        }

        //====================================================
        // CREATE (POST) - WITH ADVANCED INNER DIAGNOSTICS
        //====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetAllocationCreateViewModel model)
        {
            if (model.Items == null || !model.Items.Any())
            {
                ModelState.AddModelError("", "Please add at least one asset allocation row to the list matrix.");
                await RepopulateDropdownsAsync(model);
                return View(model);
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var row in model.Items)
                    {
                        bool absoluteDuplicate = await _context.EmployeeAssets
                            .AnyAsync(a => a.EmployeeId == row.EmployeeId && a.AssetMasterId == row.AssetMasterId && a.IsActive);

                        if (absoluteDuplicate) continue;

                        var currentUser = await _userManager.GetUserAsync(User);
                        var newAssignment = new EmployeeAsset
                        {
                            EmployeeId = row.EmployeeId,
                            AssetMasterId = row.AssetMasterId,
                            IsActive = true,
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = currentUser != null ? int.Parse(currentUser.Id) : (int?)null
                        };

                        await _context.EmployeeAssets.AddAsync(newAssignment);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbEx)
                {
                    await transaction.RollbackAsync();

                    // Extract the real underlying database constraint error message
                    var innerMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
                    ModelState.AddModelError("", $"Database Schema Rejection: {innerMessage}");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", $"System Transaction Failure: {ex.Message}");
                }
            }

            await RepopulateDropdownsAsync(model);
            return View(model);
        }
        // Private rebalancing utility handling input pipeline fallback flows
        private async Task RepopulateDropdownsAsync(AssetAllocationCreateViewModel model)
        {
            model.Employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.EmployeeCode)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                }).ToListAsync();
            model.Employees.Insert(0, new SelectListItem { Value = "", Text = "-- Select Employee --" });

            model.Assets = await _context.AssetMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.AssetCode)
                .Select(x => new SelectListItem
                {
                    Value = x.AssetMasterId.ToString(),
                    Text = x.AssetCode + " - " + x.AssetName
                }).ToListAsync();
            model.Assets.Insert(0, new SelectListItem { Value = "", Text = "-- Select Asset --" });
        }
    }
}
