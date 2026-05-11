using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly TenantDbContext _context;

        public DepartmentController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .Include(x => x.Branch)
                .ToListAsync();

            return View(departments);
        }

        public IActionResult Create()
        {
            ViewBag.BranchList = new SelectList(
                _context.Branches,
                "BranchId",
                "BranchName"
            );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                _context.Departments.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.BranchList = new SelectList(
                _context.Branches,
                "BranchId",
                "BranchName"
            );

            return View(model);
        }
    }
}