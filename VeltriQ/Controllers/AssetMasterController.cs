using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class AssetMasterController : BaseController
    {
        private readonly TenantDbContext _context;

        public AssetMasterController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }
        // INDEX

        public async Task<IActionResult> Index()
        {
            var assets = await _context.AssetMasters
                .ToListAsync();

            return View(assets);
        }

        // CREATE

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetMaster model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                model.IsActive = true;   // <-- ADD THIS LINE

                _context.AssetMasters.Add(model);

                await _context.SaveChangesAsync();

                //====================================================
                // GENERATE ASSET CODE
                //====================================================

                string prefix = model.AssetCategory switch
                {
                    "IT Asset" => "ITA",
                    "Furniture" => "FUR",
                    "Office Asset" => "OFF",
                    "Security Asset" => "SEC",
                    _ => "AST"
                };

                model.AssetCode = $"{prefix}-{model.AssetMasterId:D4}";

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        //====================================================
        // EDIT
        //====================================================

        public async Task<IActionResult> Edit(int id)
        {
            var asset = await _context.AssetMasters
                .FirstOrDefaultAsync(x => x.AssetMasterId == id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AssetMaster model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var asset = await _context.AssetMasters
                .FirstOrDefaultAsync(x => x.AssetMasterId == model.AssetMasterId);

            if (asset == null)
            {
                return NotFound();
            }

            asset.AssetCode = model.AssetCode;
            asset.AssetName = model.AssetName;
            asset.AssetCategory = model.AssetCategory;
            asset.BrandName = model.BrandName;
            asset.ModelName = model.ModelName;
            asset.SerialNumberRequired = model.SerialNumberRequired;
            asset.IsReturnable = model.IsReturnable;
            asset.Description = model.Description;

            asset.ModifiedOn = DateTime.Now;

            var currentUser = await _userManager.GetUserAsync(User);

            asset.ModifiedBy = currentUser?.Id;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //====================================================
        // TOGGLE STATUS
        //====================================================

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var asset = await _context.AssetMasters
                .FirstOrDefaultAsync(x => x.AssetMasterId == id);

            if (asset == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Asset not found."
                });
            }

            //====================================================
            // CHECK WHETHER ANY INVENTORY OF THIS ASSET IS ALLOCATED
            //====================================================

            bool isAllocated = await _context.EmployeeAssets
                .Include(x => x.AssetInventory)
                .AnyAsync(x =>
                    x.IsActive &&
                    x.AssetInventory != null &&
                    x.AssetInventory.AssetMasterId == id);

            if (asset.IsActive && isAllocated)
            {
                return Json(new
                {
                    success = false,
                    message = "This asset is already allocated to employees and cannot be deactivated."
                });
            }

            asset.IsActive = !asset.IsActive;
            asset.ModifiedOn = DateTime.Now;

            var currentUser = await _userManager.GetUserAsync(User);
            asset.ModifiedBy = currentUser?.Id;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
        private async Task<string> GenerateAssetCode()
        {
            var lastAsset = await _context.AssetMasters
                .OrderByDescending(x => x.AssetMasterId)
                .FirstOrDefaultAsync();

            if (lastAsset == null)
                return "AST-001";

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastAsset.AssetCode))
            {
                var numericPart = lastAsset.AssetCode.Replace("AST-", "");

                if (int.TryParse(numericPart, out int currentNumber))
                {
                    nextNumber = currentNumber + 1;
                }
            }

            return $"AST-{nextNumber:D3}";
        }
    }
}