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

    }
}