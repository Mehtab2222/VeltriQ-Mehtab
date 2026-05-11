using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeController
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
            var employees = await _context.Employees
                               .Where(x => x.IsActive)
                .Include(x => x.Branch)
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Division)
                .Include(x => x.Nationality)
                .Include(x => x.Country)
                .Include(x => x.City)

                .ToListAsync();

            return View(employees);
        }
        public async Task<IActionResult> Inactive()
        {
            var employees = await _context.Employees

                .Where(x => !x.IsActive)

                .Include(x => x.Branch)
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Division)
                .Include(x => x.Nationality)
                .Include(x => x.Country)
                .Include(x => x.City)

                .ToListAsync();

            return View(employees);
        }
        public async Task<IActionResult> Reactivate(int id)
        {
            var employee =
                await _context.Employees
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.IsActive = true;

            employee.ModifiedOn =
                DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Inactive");
        }
        // CREATE

        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                model.IsActive = true;

                _context.Employees.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }

        // LOAD DROPDOWNS

        private void LoadDropdowns()
        {
            ViewBag.BranchList = new SelectList(
                _context.Branches,
                "BranchId",
                "BranchName"
            );

            ViewBag.DepartmentList = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName"
            );

            ViewBag.DesignationList = new SelectList(
                _context.Designations,
                "DesignationId",
                "DesignationName"
            );

            ViewBag.DivisionList = new SelectList(
                _context.Divisions,
                "DivisionId",
                "DivisionName"
            );

            ViewBag.NationalityList = new SelectList(
                _context.Nationalities,
                "NationalityId",
                "NationalityName"
            );

            ViewBag.CountryList = new SelectList(
                _context.Countries,
                "CountryId",
                "CountryName"
            );

            ViewBag.CityList = new SelectList(
                _context.Cities,
                "CityId",
                "CityName"
            );

            // REPORTING MANAGER

            ViewBag.ReportingManagerList = new SelectList(
                _context.Employees
                    .Select(x => new
                    {
                        x.EmployeeId,
                        FullName =
                            x.FirstName + " " + x.LastName
                    }),
                "EmployeeId",
                "FullName"
            );
        }
        public async Task<IActionResult> Profile(int id)
        {
            var employee = await _context.Employees

                .Include(x => x.Branch)
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Division)
                .Include(x => x.Nationality)
                .Include(x => x.Country)
                .Include(x => x.City)

                .FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // EDIT

        public async Task<IActionResult> Edit(int id)
        {
            var employee =
                await _context.Employees
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            LoadDropdowns();

            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee =
                    await _context.Employees
                        .FirstOrDefaultAsync(x =>
                            x.EmployeeId ==
                            model.EmployeeId);

                if (employee == null)
                {
                    return NotFound();
                }

                // =========================
                // UPDATE FIELDS
                // =========================

                employee.EmployeeCode =
                    model.EmployeeCode;

                employee.FirstName =
                    model.FirstName;

                employee.LastName =
                    model.LastName;

                employee.OfficialEmail =
                    model.OfficialEmail;

                employee.PhoneNumber =
                    model.PhoneNumber;

                employee.BranchId =
                    model.BranchId;

                employee.DepartmentId =
                    model.DepartmentId;

                employee.DesignationId =
                    model.DesignationId;

                employee.DivisionId =
                    model.DivisionId;

                employee.NationalityId =
                    model.NationalityId;

                employee.CountryId =
                    model.CountryId;

                employee.CityId =
                    model.CityId;

                employee.ReportingManagerId =
                    model.ReportingManagerId;

                employee.JoiningDate =
                    model.JoiningDate;

                employee.ModifiedOn =
                    DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var employee =
                await _context.Employees
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.IsActive = false;

            employee.ModifiedOn =
                DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}