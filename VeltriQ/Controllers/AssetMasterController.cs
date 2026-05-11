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

                _context.AssetMasters.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}