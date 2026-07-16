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

            // 1. Fetch raw strongly-typed lists from the database context
            var employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.EmployeeCode)
                .ToListAsync();

            var assets = await _context.AssetMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.AssetCode)
                .ToListAsync();

            // 2. Assign them to ViewBag (which treats them as dynamic references)
            ViewBag.EmployeesList = employees;
            ViewBag.AssetsList = assets;

            // 3. CRITICAL FIX: Cast the strongly-typed variables directly to avoid the dynamic lambda compiler breakdown
            model.Employees = employees.Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
            }).ToList();
            model.Employees.Insert(0, new SelectListItem { Value = "", Text = "-- Select Employee --" });

            model.Assets = assets.Select(x => new SelectListItem
            {
                Value = x.AssetMasterId.ToString(),
                Text = x.AssetCode + " - " + x.AssetName
            }).ToList();
            model.Assets.Insert(0, new SelectListItem { Value = "", Text = "-- Select Asset --" });

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

            // Fetch the structural category string from asset masters
            var asset = await _context.AssetMasters.FindAsync(assetMasterId);
            string category = asset != null ? asset.AssetCategory : "Asset";

            return Json(new { alreadyAllocated = exists, assetCategory = category });
        }

        //====================================================
        // CREATE (AJAX POST)
        //====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJson([FromBody] AssetAllocationCreateViewModel model)
        {
            if (model == null || model.Items == null || !model.Items.Any())
            {
                return Json(new { success = false, message = "Please add at least one asset allocation row to the list matrix." });
            }

            var currentUser = await _userManager.GetUserAsync(User);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var row in model.Items)
                    {
                        bool absoluteDuplicate = await _context.EmployeeAssets
                            .AnyAsync(a => a.EmployeeId == row.EmployeeId && a.AssetMasterId == row.AssetMasterId && a.IsActive);

                        if (absoluteDuplicate) continue;

                        var newAssignment = new EmployeeAsset
                        {
                            EmployeeId = row.EmployeeId,
                            AssetMasterId = row.AssetMasterId,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            CreatedBy = currentUser?.Id
                        };

                        await _context.EmployeeAssets.AddAsync(newAssignment);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Json(new { success = true, message = "Allocation Completed Successfully." });
                }
                catch (DbUpdateException dbEx)
                {
                    await transaction.RollbackAsync();
                    var innerMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
                    return Json(new { success = false, message = $"Database Schema Rejection: {innerMessage}" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Json(new { success = false, message = $"System Transaction Failure: {ex.Message}" });
                }
            }
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
        //====================================================
        // DETAILS
        //====================================================
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Branch)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new AssetAllocationDetailsViewModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                EmployeeName = employee.FirstName + " " + employee.LastName,
                Department = employee.Department?.DepartmentName ?? "-",
                Designation = employee.Designation?.DesignationName ?? "-",
                Branch = employee.Branch?.BranchName ?? "-",
                JoiningDate = employee.JoiningDate
            };

            // Extracting all active allocated assets with contextual information logs
            model.AllocatedAssets = await _context.EmployeeAssets
                .Include(a => a.AssetMaster)
                .Where(a => a.EmployeeId == id && a.IsActive)
                .OrderByDescending(a => a.EmployeeAssetId)
                .Select(a => new AllocatedAssetItemViewModel
                {
                    EmployeeAssetId = a.EmployeeAssetId,
                    AssetCode = a.AssetMaster != null ? a.AssetMaster.AssetCode : "",
                    AssetName = a.AssetMaster != null ? a.AssetMaster.AssetName : "",
                    AssetCategory = a.AssetMaster != null ? a.AssetMaster.AssetCategory : "",
                    BrandName = a.AssetMaster != null ? a.AssetMaster.BrandName : "",
                    ModelName = a.AssetMaster != null ? a.AssetMaster.ModelName : "",
                    AllocatedOn = a.CreatedOn,
                    // Assuming your project links identity usernames or names via the Master/Tenant mappings:
                    AllocatedBy = "System Admin"
                })
                .ToListAsync();

            return View(model);
        }
    }
}
