using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class DesignationController : BaseController
    {
        private readonly TenantDbContext _context;

        public DesignationController
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
            var designations = await _context.Designations
                .Include(x => x.Department)
                .ToListAsync();

            return View(designations);
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName"
            );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Designation model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                _context.Designations.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.DepartmentList = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName"
            );

            return View(model);
        }
    }
}