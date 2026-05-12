using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeSuspensionController
        : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeSuspensionController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }

        // =========================
        // INDEX
        // =========================

        public async Task<IActionResult> Index()
        {
            var suspensions =
                await _context.EmployeeSuspensions

                    .Include(x => x.Employee)

                    .OrderByDescending(x => x.CreatedOn)

                    .ToListAsync();

            return View(suspensions);
        }

        // =========================
        // CREATE
        // =========================

        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
        (
            EmployeeSuspension model
        )
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn =
                    DateTime.Now;

                model.Status =
                    "Suspended";

                model.IsReinstated =
                    false;

                _context.EmployeeSuspensions
                    .Add(model);

                // =========================
                // UPDATE EMPLOYEE STATUS
                // =========================

                var employee =
                    await _context.Employees

                        .FirstOrDefaultAsync(x =>
                            x.EmployeeId ==
                            model.EmployeeId);

                if (employee != null)
                {
                    employee.IsSuspended =
                        true;
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }

        // =========================
        // REINSTATE
        // =========================

        public async Task<IActionResult> Reinstate(int id)
        {
            var suspension =
                await _context.EmployeeSuspensions

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeSuspensionId == id);

            if (suspension == null)
            {
                return NotFound();
            }

            var employee =
                await _context.Employees

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId ==
                        suspension.EmployeeId);

            if (employee != null)
            {
                employee.IsSuspended =
                    false;
            }

            suspension.IsReinstated =
                true;

            suspension.Status =
                "Reinstated";

            suspension.EndDate =
                DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // =========================
        // LOAD DROPDOWNS
        // =========================

        private void LoadDropdowns()
        {
            ViewBag.EmployeeList =
                new SelectList
                (
                    _context.Employees

                        .Where(x =>
                            x.IsActive
                            &&
                            !x.IsSuspended)

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