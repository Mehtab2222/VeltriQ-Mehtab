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

            var inventoryItems = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .Where(x => x.IsActive && x.InventoryStatus == "Available")
                .OrderBy(x => x.InventoryCode)
                .ToListAsync();

            // 2. Assign them to ViewBag (which treats them as dynamic references)
            ViewBag.EmployeesList = employees;
            ViewBag.InventoryItemsList = inventoryItems;

            // 3. CRITICAL FIX: Cast the strongly-typed variables directly to avoid the dynamic lambda compiler breakdown
            model.Employees = employees.Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
            }).ToList();
            model.Employees.Insert(0, new SelectListItem { Value = "", Text = "-- Select Employee --" });

            model.InventoryItems = inventoryItems.Select(x => new SelectListItem
            {
                Value = x.AssetInventoryId.ToString(),
                Text = $"{x.InventoryCode} | {x.AssetMaster!.AssetName} | {(string.IsNullOrWhiteSpace(x.SerialNumber) ? "No Serial" : x.SerialNumber)}"
            }).ToList();

            model.InventoryItems.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- Select Inventory Item --"
            });

            return View(model);
        }

        //====================================================
        // VERIFY EXISTING ALLOCATION (AJAX GET)
        //====================================================
        [HttpGet]
        public async Task<IActionResult> VerifyExistingAllocation(int employeeId, int assetInventoryId)
        {
            // Check whether this inventory item is already allocated to the employee
            bool exists = await _context.EmployeeAssets
                .AnyAsync(a =>
                    a.EmployeeId == employeeId &&
                    a.AssetInventoryId == assetInventoryId &&
                    a.IsActive);

            // Get inventory item along with its Asset Master
            var inventory = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .FirstOrDefaultAsync(x => x.AssetInventoryId == assetInventoryId);

            string category = inventory?.AssetMaster?.AssetCategory ?? "Asset";

            return Json(new
            {
                alreadyAllocated = exists,
                assetCategory = category
            });
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
                return Json(new { success = false, message = "Please add at least one asset allocation row to the list." });
            }

            var currentUser = await _userManager.GetUserAsync(User);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var row in model.Items)
                    {
                        // Check if this inventory item is already allocated
                        bool alreadyAllocated = await _context.EmployeeAssets
                            .AnyAsync(a =>
                                a.EmployeeId == row.EmployeeId &&
                                a.AssetInventoryId == row.AssetInventoryId &&
                                a.IsActive);

                        if (alreadyAllocated)
                            continue;

                        // Fetch inventory item
                        var inventory = await _context.AssetInventories
                            .FirstOrDefaultAsync(x => x.AssetInventoryId == row.AssetInventoryId);

                        if (inventory == null)
                            continue;

                        if (inventory.InventoryStatus != "Available")
                            continue;

                        // Create allocation
                        var employeeAsset = new EmployeeAsset
                        {
                            EmployeeId = row.EmployeeId,
                            AssetInventoryId = row.AssetInventoryId,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            CreatedBy = currentUser?.Id
                        };

                        await _context.EmployeeAssets.AddAsync(employeeAsset);

                        // Update inventory status
                        inventory.InventoryStatus = "Allocated";
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Json(new
                    {
                        success = true,
                        message = "Assets allocated successfully."
                    });
                }
                catch (DbUpdateException dbEx)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        message = dbEx.InnerException?.Message ?? dbEx.Message
                    });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    return Json(new
                    {
                        success = false,
                        message = ex.Message
                    });
                }
            }
        }
        // Private rebalancing utility handling input pipeline fallback flows
        private async Task RepopulateDropdownsAsync(AssetAllocationCreateViewModel model)
        {
            //====================================================
            // EMPLOYEES
            //====================================================
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

            //====================================================
            // AVAILABLE INVENTORY ITEMS
            //====================================================
            model.InventoryItems = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .Where(x => x.IsActive && x.InventoryStatus == "Available")
                .OrderBy(x => x.InventoryCode)
                .Select(x => new SelectListItem
                {
                    Value = x.AssetInventoryId.ToString(),
                    Text = x.InventoryCode + " - " +
                           x.AssetMaster.AssetName +
                           (string.IsNullOrWhiteSpace(x.SerialNumber)
                                ? ""
                                : " (" + x.SerialNumber + ")")
                })
                .ToListAsync();

            model.InventoryItems.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- Select Inventory Item --"
            });
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

            //====================================================
            // LOAD ALLOCATED INVENTORY ITEMS
            //====================================================
            model.AllocatedAssets = await _context.EmployeeAssets
                .Include(x => x.AssetInventory)
                    .ThenInclude(x => x.AssetMaster)
                .Where(x => x.EmployeeId == id && x.IsActive)
                .OrderByDescending(x => x.EmployeeAssetId)
                .Select(x => new AllocatedAssetItemViewModel
                {
                    EmployeeAssetId = x.EmployeeAssetId,

                    AssetCode = x.AssetInventory != null && x.AssetInventory.AssetMaster != null
                        ? x.AssetInventory.AssetMaster.AssetCode
                        : "",

                    AssetName = x.AssetInventory != null && x.AssetInventory.AssetMaster != null
                        ? x.AssetInventory.AssetMaster.AssetName
                        : "",

                    AssetCategory = x.AssetInventory != null && x.AssetInventory.AssetMaster != null
                        ? x.AssetInventory.AssetMaster.AssetCategory
                        : "",

                    BrandName = x.AssetInventory != null && x.AssetInventory.AssetMaster != null
                        ? x.AssetInventory.AssetMaster.BrandName
                        : "",

                    ModelName = x.AssetInventory != null && x.AssetInventory.AssetMaster != null
                        ? x.AssetInventory.AssetMaster.ModelName
                        : "",

                    AllocatedOn = x.CreatedOn,

                    AllocatedBy = "System Admin"
                })
                .ToListAsync();

            return View(model);
        }
    }
}
