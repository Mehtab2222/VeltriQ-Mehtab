using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeAssetController : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeAssetController
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

        public async Task<IActionResult> Index(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            var assets = await _context.EmployeeAssets

                .Include(x => x.AssetMaster)

                .Where(x => x.EmployeeId == employeeId)

                .ToListAsync();

            return PartialView
            (
                "_EmployeeAssetsPartial",
                assets
            );
        }

        // CREATE

        public IActionResult Create(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
        (
            EmployeeAsset model
        )
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                model.IsActive = true;

                _context.EmployeeAssets.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction
                (
                    "Profile",
                    "Employee",
                    new { id = model.EmployeeId }
                );
            }

            LoadDropdowns();

            return View(model);
        }

        // LOAD DROPDOWNS

        private void LoadDropdowns()
        {
            ViewBag.AssetList = new SelectList
            (
                _context.AssetMasters,
                "AssetMasterId",
                "AssetName"
            );
        }
    }
}