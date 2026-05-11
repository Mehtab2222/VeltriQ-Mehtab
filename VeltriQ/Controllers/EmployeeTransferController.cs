using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeTransferController
        : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeTransferController
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
            var transfers =
                await _context.EmployeeTransfers

                    .Include(x => x.Employee)

                    .Include(x => x.CurrentBranch)

                    .Include(x => x.NewBranch)

                    .OrderByDescending(x => x.CreatedOn)

                    .ToListAsync();

            return View(transfers);
        }
        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create
(
    EmployeeTransfer model
)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn =
                    DateTime.Now;

                model.Status =
                    "Pending";

                _context.EmployeeTransfers
                    .Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }
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

            ViewBag.BranchList =
                new SelectList
                (
                    _context.Branches,
                    "BranchId",
                    "BranchName"
                );

            ViewBag.DepartmentList =
                new SelectList
                (
                    _context.Departments,
                    "DepartmentId",
                    "DepartmentName"
                );

            ViewBag.DesignationList =
                new SelectList
                (
                    _context.Designations,
                    "DesignationId",
                    "DesignationName"
                );
        }
    }
}