using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.EmployeeAssets;

namespace VeltriQ.Controllers
{
    public class EmployeeAssetsController : BaseController
    {
        public EmployeeAssetsController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )

        : base(context, masterContext, userManager)
        {

        }

        #region Index

        public async Task<IActionResult> Index()
        {
            var model = await _context.EmployeeAssets

                .Include(x => x.Employee)
                    .ThenInclude(x => x.Department)

                .GroupBy(x => new
                {
                    x.EmployeeId,
                    x.Employee.EmployeeCode,
                    x.Employee.FirstName,
                    x.Employee.LastName,
                    DepartmentName = x.Employee.Department != null
                        ? x.Employee.Department.DepartmentName
                        : string.Empty
                })

                .Select(g => new EmployeeAssetsIndexViewModel
                {
                    EmployeeId = g.Key.EmployeeId,

                    EmployeeCode = g.Key.EmployeeCode,

                    EmployeeName = g.Key.FirstName + " " + g.Key.LastName,

                    Department = g.Key.DepartmentName,

                    ActiveAssets = g.Count(x =>
                        x.ReturnDate == null &&
                        x.IsActive),

                    TotalAssetsIssued = g.Count(),

                    LastAllocationDate = g.Max(x => x.IssueDate),

                    HasActiveAssets = g.Any(x =>
                        x.ReturnDate == null &&
                        x.IsActive)
                })

                .OrderBy(x => x.EmployeeName)

                .ToListAsync();

            return View(model);
        }
        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.EmployeeAssets

                .Include(x => x.Employee)
                    .ThenInclude(x => x.Department)

                .Where(x => x.EmployeeId == id)

                .Select(x => new EmployeeAssetsDetailsViewModel
                {
                    EmployeeId = x.Employee.EmployeeId,

                    EmployeeCode = x.Employee.EmployeeCode,

                    EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,

                    Department = x.Employee.Department != null
                        ? x.Employee.Department.DepartmentName
                        : string.Empty
                })

                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            employee.Assets = await _context.EmployeeAssets

                .Include(x => x.AssetInventory)
                    .ThenInclude(x => x.AssetMaster)

                .Where(x => x.EmployeeId == id)

                .OrderByDescending(x => x.IssueDate)

                .Select(x => new EmployeeAssetHistoryItemViewModel
                {
                    EmployeeAssetId = x.EmployeeAssetId,

                    AssetInventoryId = x.AssetInventoryId,

                    InventoryCode = x.AssetInventory.InventoryCode,

                    AssetCode = x.AssetInventory.AssetMaster.AssetCode,

                    AssetName = x.AssetInventory.AssetMaster.AssetName,

                    AssetCategory = x.AssetInventory.AssetMaster.AssetCategory,

                    BrandName = x.AssetInventory.AssetMaster.BrandName,

                    ModelName = x.AssetInventory.AssetMaster.ModelName,

                    SerialNumber = x.AssetInventory.SerialNumber,

                    IssueDate = x.IssueDate,

                    ReturnDate = x.ReturnDate,

                    AssetStatus = x.AssetStatus ?? string.Empty,

                    ConditionStatus = x.ConditionStatus ?? string.Empty,

                    InventoryStatus = x.AssetInventory.InventoryStatus ?? string.Empty,

                    Remarks = x.Remarks
                })

                .ToListAsync();

            employee.TotalAssetsIssued = employee.Assets.Count;

            employee.ActiveAssets = employee.Assets.Count(x => x.ReturnDate == null);

            employee.ReturnedAssets = employee.Assets.Count(x => x.ReturnDate != null);

            return View(employee);
        }
        //====================================================
        // ALLOCATE (GET) - Safe for Option B Workflow
        //====================================================
        public async Task<IActionResult> Allocate(int? id)
        {
            var model = new EmployeeAssetAllocateViewModel
            {
                IssueDate = DateTime.Today
            };

            if (id.HasValue && id.Value > 0)
            {
                var employee = await _context.Employees
                    .Include(x => x.Department)
                    .FirstOrDefaultAsync(x => x.EmployeeId == id.Value);

                if (employee != null)
                {
                    model.EmployeeId = employee.EmployeeId;
                    model.EmployeeCode = employee.EmployeeCode;
                    model.EmployeeName = employee.FirstName + " " + employee.LastName;
                    model.Department = employee.Department?.DepartmentName ?? string.Empty;

                    // Rule 7: Pull active assets to preview on-screen
                    ViewBag.ActiveAssetsSummary = await _context.EmployeeAssets
                        .Include(x => x.AssetInventory).ThenInclude(x => x.AssetMaster)
                        .Where(x => x.EmployeeId == id.Value && x.IsActive && x.ReturnDate == null)
                        .Select(x => new {
                            AssetName = x.AssetInventory!.AssetMaster!.AssetName,
                            InventoryCode = x.AssetInventory.InventoryCode
                        })
                        .ToListAsync();
                }
            }
            else
            {
                // Global Entry Mode (Option B Flag Switch)
                ViewBag.IsGlobalMode = true;
                model.Employees = await _context.Employees
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.FirstName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.EmployeeId.ToString(),
                        Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                    })
                    .ToListAsync();

                model.Employees.Insert(0, new SelectListItem { Value = "", Text = "-- Select Employee --" });
            }

            await PopulateAvailableAssets(model);
            return View(model);
        }

        //====================================================
        // GET INVENTORY DETAILS (AJAX GET)
        //====================================================
        [HttpGet]
        public async Task<IActionResult> GetInventoryDetails(int assetInventoryId)
        {
            var item = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .Where(x => x.AssetInventoryId == assetInventoryId)
                .Select(x => new
                {
                    assetCode = x.AssetMaster!.AssetCode,
                    assetName = x.AssetMaster.AssetName,
                    category = x.AssetMaster.AssetCategory,
                    brand = x.AssetMaster.BrandName,
                    model = x.AssetMaster.ModelName,
                    serial = x.SerialNumber ?? "N/A",
                    condition = x.AssetCondition ?? "Good"
                })
                .FirstOrDefaultAsync();

            return Json(item);
        }

        //====================================================
        // ALLOCATE (POST)
        //====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Allocate(EmployeeAssetAllocateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await RebuildDropdownsOnError(model);
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var inventory = await _context.AssetInventories
                    .Include(x => x.AssetMaster)
                    .FirstOrDefaultAsync(x => x.AssetInventoryId == model.AssetInventoryId);

                if (inventory == null || !inventory.IsActive || inventory.InventoryStatus != "Available")
                {
                    ModelState.AddModelError("", "Selected stock asset does not exist or is unavailable.");
                    await RebuildDropdownsOnError(model);
                    return View(model);
                }

                // Rule 8: Prevent Duplicate Asset Category Business Rule
                bool categoryCollision = await _context.EmployeeAssets
                    .Include(x => x.AssetInventory).ThenInclude(x => x.AssetMaster)
                    .AnyAsync(x => x.EmployeeId == model.EmployeeId &&
                                   x.IsActive &&
                                   x.ReturnDate == null &&
                                   x.AssetInventory!.AssetMaster!.AssetCategory == inventory.AssetMaster!.AssetCategory);

                if (categoryCollision)
                {
                    ModelState.AddModelError("", $"Business Rule Rejection: This employee is already holding an active item under the '{inventory.AssetMaster!.AssetCategory}' category grouping.");
                    await RebuildDropdownsOnError(model);
                    return View(model);
                }

                var employeeAsset = new EmployeeAsset
                {
                    EmployeeId = model.EmployeeId!.Value,
                    AssetInventoryId = model.AssetInventoryId.Value,
                    AssetNumber = inventory.InventoryCode,
                    SerialNumber = inventory.SerialNumber,
                    IssueDate = model.IssueDate,
                    AssetStatus = "Allocated",
                    ConditionStatus = inventory.AssetCondition,
                    Remarks = model.Remarks,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = currentUser?.Id
                };

                _context.EmployeeAssets.Add(employeeAsset);
                inventory.InventoryStatus = "Allocated";
                inventory.ModifiedOn = DateTime.Now;
                inventory.ModifiedBy = currentUser?.Id;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "Asset allocated successfully.";
                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });
            }
            catch
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "An unexpected error occurred while allocating the asset.");
                await RebuildDropdownsOnError(model);
                return View(model);
            }
        }

        //====================================================
        // LOOKUP DROPDOWN PERSISTENCE HELPER
        //====================================================
        private async Task RebuildDropdownsOnError(EmployeeAssetAllocateViewModel model)
        {
            await PopulateAvailableAssets(model);

            // Check if the current context setup implies Option B collection reconstruction
            var employeeExists = await _context.Employees.AnyAsync(x => x.EmployeeId == model.EmployeeId);
            if (!employeeExists)
            {
                ViewBag.IsGlobalMode = true;
                model.Employees = await _context.Employees
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.FirstName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.EmployeeId.ToString(),
                        Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                    })
                    .ToListAsync();
                model.Employees.Insert(0, new SelectListItem { Value = "", Text = "-- Select Employee --" });
            }
        }
        private async Task PopulateAvailableAssets(EmployeeAssetAllocateViewModel model)
        {
            model.AvailableAssets = await _context.AssetInventories

                .Include(x => x.AssetMaster)

                .Where(x =>
                    x.IsActive &&
                    x.InventoryStatus == "Available")

                .OrderBy(x => x.InventoryCode)

                .Select(x => new SelectListItem
                {
                    Value = x.AssetInventoryId.ToString(),

                    Text = x.InventoryCode
                           + " | "
                           + x.AssetMaster.AssetName
                           + (string.IsNullOrWhiteSpace(x.SerialNumber)
                                ? ""
                                : " | " + x.SerialNumber)
                })

                .ToListAsync();

            model.AvailableAssets.Insert(0,
                new SelectListItem
                {
                    Value = "",

                    Text = "-- Select Asset --"
                });
        }

        #endregion
    }
}