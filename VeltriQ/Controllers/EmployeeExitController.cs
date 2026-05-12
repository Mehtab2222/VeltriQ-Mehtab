using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeExitController
        : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeExitController
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
            var exits =
                await _context.EmployeeExits

                    .Include(x => x.Employee)

                    .OrderByDescending(x => x.CreatedOn)

                    .ToListAsync();

            return View(exits);
        }

        // CREATE

        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
        (
            EmployeeExit model
        )
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn =
                    DateTime.Now;

                model.Status =
                    "Pending";

                _context.EmployeeExits
                    .Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }

        // COMPLETE EXIT

        public async Task<IActionResult> Complete(int id)
        {
            var exit =
                await _context.EmployeeExits

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeExitId == id);

            if (exit == null)
            {
                return NotFound();
            }

            var employee =
                await _context.Employees

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == exit.EmployeeId);

            if (employee == null)
            {
                return NotFound();
            }

            employee.IsActive = false;

            exit.Status =
                "Completed";

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // DROPDOWNS

        private void LoadDropdowns()
        {
            ViewBag.EmployeeList =
                new SelectList
                (
                    _context.Employees

                        .Where(x => x.IsActive)

                        .Select(x => new
                        {
                            x.EmployeeId,

                            FullName =
                                x.FirstName
                                + " "
                                + x.LastName
                        }),

                    "EmployeeId",

                    "FullName"
                );
        }
    }
}