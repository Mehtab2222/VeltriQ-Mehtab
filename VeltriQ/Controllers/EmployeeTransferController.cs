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
        [HttpGet]
        public IActionResult GetEmployeeDetails(int employeeId)
        {
            var employee =
                _context.Employees

                    .FirstOrDefault(x =>
                        x.EmployeeId == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Json(new
            {
                branchId =
                    employee.BranchId,

                departmentId =
                    employee.DepartmentId,

                designationId =
                    employee.DesignationId
            });
        }
        public async Task<IActionResult> Approve(int id)
        {
            var transfer =
                await _context.EmployeeTransfers

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeTransferId == id);

            if (transfer == null)
            {
                return NotFound();
            }

            var employee =
                await _context.Employees

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == transfer.EmployeeId);

            if (employee == null)
            {
                return NotFound();
            }

            // UPDATE EMPLOYEE MASTER

            employee.BranchId =
                transfer.NewBranchId;

            employee.DepartmentId =
                transfer.NewDepartmentId ?? 0;

            employee.DesignationId =
                transfer.NewDesignationId ?? 0;

            // UPDATE TRANSFER STATUS

            transfer.Status =
                "Approved";

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Reject(int id)
        {
            var transfer =
                await _context.EmployeeTransfers

                    .FirstOrDefaultAsync(x =>
                        x.EmployeeTransferId == id);

            if (transfer == null)
            {
                return NotFound();
            }

            transfer.Status =
                "Rejected";

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}