using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class BranchController : BaseController
    {
        private readonly TenantDbContext _context;

        private readonly MasterDbContext _masterContext;

        public BranchController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;

            _masterContext = masterContext;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _context.Branches
                .ToListAsync();

            return View(branches);
        }

        public IActionResult Create()
        {
            ViewBag.CompanyList = new SelectList(
                _masterContext.Companies,
                "CompanyId",
                "CompanyName"
            );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Branch model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                _context.Branches.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.CompanyList = new SelectList(
                _masterContext.Companies,
                "CompanyId",
                "CompanyName"
            );

            return View(model);
        }
    }
}