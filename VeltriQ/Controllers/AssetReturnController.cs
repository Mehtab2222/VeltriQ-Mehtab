using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.ViewModels.AssetReturn;

namespace VeltriQ.Controllers
{
    public class AssetReturnController : BaseController
    {
        public AssetReturnController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )

        : base(context, masterContext, userManager)
        {

        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.EmployeeAssets

                .Include(x => x.Employee)

                .Include(x => x.AssetInventory)
                    .ThenInclude(x => x.AssetMaster)

                .Where(x =>
                    x.IsActive &&
                    x.ReturnDate == null)

                .OrderByDescending(x => x.IssueDate)

                .Select(x => new AssetReturnIndexViewModel
                {
                    EmployeeAssetId = x.EmployeeAssetId,

                    EmployeeId = x.EmployeeId,

                    EmployeeCode = x.Employee.EmployeeCode,

                    EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,

                    AssetInventoryId = x.AssetInventoryId,

                    InventoryCode = x.AssetInventory.InventoryCode,

                    AssetCode = x.AssetInventory.AssetMaster.AssetCode,

                    AssetName = x.AssetInventory.AssetMaster.AssetName,

                    SerialNumber = x.AssetInventory.SerialNumber,

                    IssueDate = x.IssueDate,

                    AssetCondition = x.AssetInventory.AssetCondition,

                    InventoryStatus = x.AssetInventory.InventoryStatus
                })

                .ToListAsync();

            return View(model);
        }
        public async Task<IActionResult> Return(int id)
        {
            var model = await _context.EmployeeAssets

                .Include(x => x.Employee)

                .Include(x => x.AssetInventory)
                    .ThenInclude(x => x.AssetMaster)

                .Where(x =>
                    x.EmployeeAssetId == id &&
                    x.IsActive &&
                    x.ReturnDate == null)

                .Select(x => new AssetReturnCreateViewModel
                {
                    EmployeeAssetId = x.EmployeeAssetId,

                    EmployeeId = x.EmployeeId,

                    AssetInventoryId = x.AssetInventoryId,

                    EmployeeCode = x.Employee.EmployeeCode,

                    EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,

                    InventoryCode = x.AssetInventory.InventoryCode,

                    AssetCode = x.AssetInventory.AssetMaster.AssetCode,

                    AssetName = x.AssetInventory.AssetMaster.AssetName,

                    SerialNumber = x.AssetInventory.SerialNumber,

                    IssueDate = x.IssueDate,

                    ReturnDate = DateTime.Today,

                    ConditionStatus = x.AssetInventory.AssetCondition ?? string.Empty,

                    Remarks = string.Empty
                })

                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(AssetReturnCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var employeeAsset = await _context.EmployeeAssets
                    .Include(x => x.AssetInventory)
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeAssetId == model.EmployeeAssetId &&
                        x.IsActive &&
                        x.ReturnDate == null);

                if (employeeAsset == null)
                {
                    await transaction.RollbackAsync();

                    TempData["ErrorMessage"] = "The selected asset allocation was not found or has already been returned.";

                    return RedirectToAction(nameof(Index));
                }

                // Update Employee Asset
                employeeAsset.ReturnDate = model.ReturnDate;
                employeeAsset.ConditionStatus = model.ConditionStatus;
                employeeAsset.Remarks = model.Remarks;
                employeeAsset.AssetStatus = "Returned";
                employeeAsset.ModifiedOn = DateTime.Now;
                employeeAsset.ModifiedBy = User.Identity?.Name;

                // Update Inventory
                employeeAsset.AssetInventory.AssetCondition = model.ConditionStatus;
                employeeAsset.AssetInventory.InventoryStatus = "Available";
                employeeAsset.AssetInventory.ModifiedOn = DateTime.Now;
                employeeAsset.AssetInventory.ModifiedBy = User.Identity?.Name;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "Asset returned successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                await transaction.RollbackAsync();

                TempData["ErrorMessage"] = "An error occurred while returning the asset.";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}