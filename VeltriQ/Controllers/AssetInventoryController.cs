using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.AssetInventory;

namespace VeltriQ.Controllers
{
    public class AssetInventoryController : BaseController
    {
        private readonly TenantDbContext _context;

        public AssetInventoryController
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
            var model = await _context.AssetInventories

                .Include(x => x.AssetMaster)

                .OrderByDescending(x => x.AssetInventoryId)

                .ToListAsync();

            return View(model);
        }

        //====================================================
        // CREATE (GET)
        //====================================================

        //====================================================
        // CREATE
        //====================================================

        //====================================================
        // CREATE
        //====================================================

        public async Task<IActionResult> Create()
        {
            var model = new AssetInventoryCreateViewModel();

            model.Assets = await _context.AssetMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.AssetName)

                .Select(x => new SelectListItem
                {
                    Value = x.AssetMasterId.ToString(),

                    Text = x.AssetCode + " - " + x.AssetName
                })

                .ToListAsync();

            return View(model);
        }
        //====================================================
        // LOAD ASSET DETAILS
        //====================================================

        [HttpGet]
        public async Task<IActionResult> GetAssetDetails(int assetMasterId)
        {
            var asset = await _context.AssetMasters
                .Where(x => x.AssetMasterId == assetMasterId)
                .Select(x => new
                {
                    category = x.AssetCategory,
                    brand = x.BrandName,
                    model = x.ModelName,
                    serialRequired = x.SerialNumberRequired
                })
                .FirstOrDefaultAsync();

            if (asset == null)
            {
                return Json(null);
            }

            return Json(asset);
        }
        private async Task<string> GenerateInventoryCode()
        {
            int nextNumber = await _context.AssetInventories.CountAsync() + 1;

            return $"INV-{nextNumber:D5}";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetInventoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdown(model);
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                //====================================================
                // GET NEXT INVENTORY NUMBER
                //====================================================

                int nextNumber = 1;

                var lastInventory = await _context.AssetInventories
                    .OrderByDescending(x => x.AssetInventoryId)
                    .FirstOrDefaultAsync();

                if (lastInventory != null &&
                    !string.IsNullOrWhiteSpace(lastInventory.InventoryCode))
                {
                    var numberPart = lastInventory.InventoryCode.Replace("INV-", "");

                    if (int.TryParse(numberPart, out int currentNumber))
                    {
                        nextNumber = currentNumber + 1;
                    }
                }
                //====================================================
                // VALIDATE SERIAL NUMBERS
                //====================================================

                var asset = await _context.AssetMasters
                    .FirstOrDefaultAsync(x => x.AssetMasterId == model.AssetMasterId);

                if (asset == null)
                {
                    await LoadDropdown(model);

                    ModelState.AddModelError("", "Selected asset not found.");

                    return View(model);
                }

                if (asset.SerialNumberRequired)
                {
                    if (model.SerialNumbers == null ||
                        model.SerialNumbers.Count != model.Quantity)
                    {
                        await LoadDropdown(model);

                        ModelState.AddModelError("", "Please enter all manufacturer serial numbers.");

                        return View(model);
                    }

                    foreach (var serial in model.SerialNumbers)
                    {
                        if (string.IsNullOrWhiteSpace(serial))
                        {
                            await LoadDropdown(model);

                            ModelState.AddModelError("", "Manufacturer serial number cannot be blank.");

                            return View(model);
                        }

                        bool exists = await _context.AssetInventories
                            .AnyAsync(x => x.SerialNumber == serial);

                        if (exists)
                        {
                            await LoadDropdown(model);

                            ModelState.AddModelError("",
                                $"Manufacturer Serial Number '{serial}' already exists.");

                            return View(model);
                        }
                    }
                }
                //====================================================
                // CREATE INVENTORY RECORDS
                //====================================================

                for (int i = 0; i < model.Quantity; i++)
                {
                    var inventory = new AssetInventory
                    {
                        InventoryCode = $"INV-{nextNumber:D5}",

                        AssetMasterId = model.AssetMasterId,

                        InventoryStatus = "Available",

                        AssetCondition = model.AssetCondition,

                        PurchaseDate = model.PurchaseDate,

                        PurchaseCost = model.PurchaseCost,

                        VendorName = model.VendorName,

                        Remarks = model.Remarks,

                        CreatedOn = DateTime.Now,

                        CreatedBy = currentUser?.Id,

                        IsActive = true
                    };

                    //====================================================
                    // SERIAL NUMBER
                    //====================================================

                    if (model.SerialNumbers != null &&
                        i < model.SerialNumbers.Count)
                    {
                        inventory.SerialNumber = model.SerialNumbers[i];
                    }

                    _context.AssetInventories.Add(inventory);

                    // Generate next inventory code
                    nextNumber++;
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                await LoadDropdown(model);

                ModelState.AddModelError("", "Unable to save inventory.");

                return View(model);
            }
        }
        private async Task LoadDropdown(AssetInventoryCreateViewModel model)
        {
            model.Assets = await _context.AssetMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.AssetName)

                .Select(x => new SelectListItem
                {
                    Value = x.AssetMasterId.ToString(),

                    Text = x.AssetCode + " - " + x.AssetName
                })

                .ToListAsync();
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .GroupJoin(
                    _context.EmployeeAssets.Include(e => e.Employee),
                    inventory => inventory.AssetInventoryId,
                    allocation => allocation.AssetInventoryId,
                    (inventory, allocations) => new
                    {
                        Inventory = inventory,
                        Allocation = allocations
                            .Where(x => x.IsActive)
                            .OrderByDescending(x => x.IssueDate)
                            .FirstOrDefault()
                    })
                .Select(x => new AssetInventoryDetailsViewModel
                {
                    AssetInventoryId = x.Inventory.AssetInventoryId,

                    InventoryCode = x.Inventory.InventoryCode ?? string.Empty,

                    AssetCode = x.Inventory.AssetMaster != null
                        ? x.Inventory.AssetMaster.AssetCode
                        : string.Empty,

                    AssetName = x.Inventory.AssetMaster != null
                        ? x.Inventory.AssetMaster.AssetName
                        : string.Empty,

                    AssetCategory = x.Inventory.AssetMaster != null
                        ? x.Inventory.AssetMaster.AssetCategory
                        : string.Empty,

                    BrandName = x.Inventory.AssetMaster != null
                        ? x.Inventory.AssetMaster.BrandName
                        : string.Empty,

                    ModelName = x.Inventory.AssetMaster != null
                        ? x.Inventory.AssetMaster.ModelName
                        : string.Empty,

                    SerialNumber = x.Inventory.SerialNumber ?? string.Empty,

                    AssetCondition = x.Inventory.AssetCondition,

                    InventoryStatus = x.Inventory.InventoryStatus ?? string.Empty,

                    PurchaseDate = x.Inventory.PurchaseDate,

                    PurchaseCost = x.Inventory.PurchaseCost,

                    VendorName = x.Inventory.VendorName,

                    Remarks = x.Inventory.Remarks,

                    IsActive = x.Inventory.IsActive,

                    CreatedOn = x.Inventory.CreatedOn,

                    ModifiedOn = x.Inventory.ModifiedOn,

                    IsAllocated = x.Allocation != null,

                    EmployeeId = x.Allocation != null
                        ? x.Allocation.EmployeeId
                        : null,

                    EmployeeCode = x.Allocation != null && x.Allocation.Employee != null
                        ? x.Allocation.Employee.EmployeeCode
                        : null,

                    EmployeeName = x.Allocation != null && x.Allocation.Employee != null
                        ? $"{x.Allocation.Employee.FirstName} {x.Allocation.Employee.LastName}"
                        : null,

                    IssueDate = x.Allocation != null
                        ? x.Allocation.IssueDate
                        : null
                })
                .FirstOrDefaultAsync(x => x.AssetInventoryId == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.AssetInventories
                .Include(x => x.AssetMaster)
                .Where(x => x.AssetInventoryId == id)
                .Select(x => new AssetInventoryEditViewModel
                {
                    AssetInventoryId = x.AssetInventoryId,

                    InventoryCode = x.InventoryCode ?? string.Empty,

                    AssetMasterId = x.AssetMasterId,

                    AssetCode = x.AssetMaster!.AssetCode,

                    AssetName = x.AssetMaster.AssetName,

                    AssetCategory = x.AssetMaster.AssetCategory,

                    BrandName = x.AssetMaster.BrandName,

                    ModelName = x.AssetMaster.ModelName,

                    SerialNumber = x.SerialNumber ?? string.Empty,

                    AssetCondition = x.AssetCondition ?? string.Empty,

                    InventoryStatus = x.InventoryStatus ?? string.Empty,

                    PurchaseDate = x.PurchaseDate,

                    PurchaseCost = x.PurchaseCost,

                    VendorName = x.VendorName,

                    Remarks = x.Remarks,

                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();

            if (model == null)
                return NotFound();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AssetInventoryEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var inventory = await _context.AssetInventories
                .FirstOrDefaultAsync(x => x.AssetInventoryId == model.AssetInventoryId);

            if (inventory == null)
                return NotFound();

            bool serialExists = await _context.AssetInventories.AnyAsync(x =>
                x.AssetInventoryId != model.AssetInventoryId &&
                x.SerialNumber == model.SerialNumber &&
                x.IsActive);

            if (serialExists)
            {
                ModelState.AddModelError(nameof(model.SerialNumber),
                    "Serial number already exists.");

                return View(model);
            }

            inventory.SerialNumber = model.SerialNumber;
            inventory.AssetCondition = model.AssetCondition;
            inventory.InventoryStatus = model.InventoryStatus;
            inventory.PurchaseDate = model.PurchaseDate;
            inventory.PurchaseCost = model.PurchaseCost;
            inventory.VendorName = model.VendorName;
            inventory.Remarks = model.Remarks;

            inventory.ModifiedOn = DateTime.Now;
            inventory.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Asset inventory updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var inventory = await _context.AssetInventories
                .FirstOrDefaultAsync(x => x.AssetInventoryId == id);

            if (inventory == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Asset inventory record not found."
                });
            }

            // Prevent deactivation if the asset is currently allocated
            if (inventory.IsActive)
            {
                bool isAllocated = await _context.EmployeeAssets.AnyAsync(x =>
                    x.AssetInventoryId == id &&
                    x.IsActive &&
                    x.ReturnDate == null);

                if (isAllocated)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This inventory item is currently allocated to an employee. Return the asset before deactivating it."
                    });
                }
            }

            inventory.IsActive = !inventory.IsActive;
            inventory.ModifiedOn = DateTime.Now;
            inventory.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                isActive = inventory.IsActive,
                message = inventory.IsActive
                    ? "Asset inventory activated successfully."
                    : "Asset inventory deactivated successfully."
            });
        }
    }
}