using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;

namespace VeltriQ.Controllers
{
    public class TrainingEnrollmentController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingEnrollmentController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Get Enrollment

        [HttpGet]
        public async Task<IActionResult> GetEnrollment(int trainingScheduleId)
        {
            var schedule = await _context.TrainingSchedules
                .Include(x => x.TrainingMaster)
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == trainingScheduleId);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training schedule not found."
                });
            }

            var totalEnrolled = await _context.TrainingEnrollments
                .CountAsync(x =>
                    x.TrainingScheduleId == trainingScheduleId &&
                    x.IsActive &&
                    !x.IsCancelled);

            var vm = new TrainingEnrollmentViewModel
            {
                TrainingScheduleId = schedule.TrainingScheduleId,
                ScheduleCode = schedule.ScheduleCode,
                TrainingName = schedule.TrainingMaster?.TrainingName,
                DepartmentName = schedule.Department?.DepartmentName,
                TrainingDate = schedule.StartDate,
                Capacity = schedule.Capacity,
                TotalEnrolled = totalEnrolled,
                EnrollmentDate = DateTime.Now
            };

            return Json(new
            {
                success = true,
                data = vm
            });
        }

        #endregion

        #region Enroll Employees

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollEmployees(TrainingEnrollmentViewModel vm)
        {
            if (vm.EmployeeIds == null || !vm.EmployeeIds.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "Please select at least one employee."
                });
            }

            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == vm.TrainingScheduleId);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training schedule not found."
                });
            }

            var currentEnrollment = await _context.TrainingEnrollments
                .CountAsync(x =>
                    x.TrainingScheduleId == vm.TrainingScheduleId &&
                    x.IsActive &&
                    !x.IsCancelled);

            var availableSeats = schedule.Capacity - currentEnrollment;

            if (vm.EmployeeIds.Count > availableSeats)
            {
                return Json(new
                {
                    success = false,
                    message = $"Only {availableSeats} seat(s) are available."
                });
            }

            var existingEmployeeIds = await _context.TrainingEnrollments
                .Where(x =>
                    x.TrainingScheduleId == vm.TrainingScheduleId &&
                    x.IsActive &&
                    !x.IsCancelled)
                .Select(x => x.EmployeeId)
                .ToListAsync();

            var employeeIdsToInsert = vm.EmployeeIds
                .Except(existingEmployeeIds)
                .ToList();

            if (!employeeIdsToInsert.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "Selected employees are already enrolled."
                });
            }

            foreach (var employeeId in employeeIdsToInsert)
            {
                _context.TrainingEnrollments.Add(new TrainingEnrollment
                {
                    TrainingScheduleId = vm.TrainingScheduleId,
                    EmployeeId = employeeId,
                    EnrollmentDate = vm.EnrollmentDate,
                    Remarks = vm.Remarks,
                    IsCancelled = false,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = GetCurrentEmployeeId()
                });
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Employees enrolled successfully."
            });
        }

        #endregion
        #region Update Enrollment

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEnrollment(TrainingEnrollmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Invalid data submitted."
                });
            }

            var enrollment = await _context.TrainingEnrollments
                .FirstOrDefaultAsync(x => x.TrainingEnrollmentId == vm.TrainingEnrollmentId);

            if (enrollment == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Enrollment not found."
                });
            }

            enrollment.Remarks = vm.Remarks;
            enrollment.IsCancelled = vm.IsCancelled;
            enrollment.ModifiedOn = DateTime.Now;
            enrollment.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Enrollment updated successfully."
            });
        }

        #endregion

        #region Toggle Status

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var enrollment = await _context.TrainingEnrollments
                .FirstOrDefaultAsync(x => x.TrainingEnrollmentId == id);

            if (enrollment == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Enrollment not found."
                });
            }

            enrollment.IsActive = !enrollment.IsActive;
            enrollment.ModifiedOn = DateTime.Now;
            enrollment.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = $"Enrollment has been {(enrollment.IsActive ? "activated" : "deactivated")} successfully."
            });
        }

        #endregion

        #region Get Training Schedules For Enrollment

        [HttpGet]
        public async Task<IActionResult> GetTrainingSchedulesForEnrollment()
        {
            var schedules = await _context.TrainingSchedules
                .Include(x => x.TrainingMaster)
                .Include(x => x.Department)
                .Where(x => x.IsActive && !x.IsCancelled)
                .OrderByDescending(x => x.StartDate)
                .Select(x => new TrainingEnrollmentViewModel
                {
                    TrainingScheduleId = x.TrainingScheduleId,
                    ScheduleCode = x.ScheduleCode,
                    TrainingName = x.TrainingMaster != null ? x.TrainingMaster.TrainingName : "",
                    DepartmentName = x.Department != null ? x.Department.DepartmentName : "",
                    TrainingDate = x.StartDate,
                    Capacity = x.Capacity,

                    TotalEnrolled = _context.TrainingEnrollments.Count(e =>
                        e.TrainingScheduleId == x.TrainingScheduleId &&
                        e.IsActive &&
                        !e.IsCancelled)
                })
                .ToListAsync();

            return Json(new
            {
                data = schedules.Select(x => new
                {
                    x.TrainingScheduleId,
                    x.ScheduleCode,
                    x.TrainingName,
                    x.DepartmentName,
                    TrainingDate = x.TrainingDate.ToString("dd-MMM-yyyy"),
                    x.Capacity,
                    x.TotalEnrolled,
                    AvailableSeats = x.Capacity - x.TotalEnrolled
                })
            });
        }

        #endregion
        #region Get Available Employees

        [HttpGet]
        public async Task<IActionResult> GetAvailableEmployees(int trainingScheduleId)
        {
            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == trainingScheduleId);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training schedule not found."
                });
            }

            // Employees already enrolled
            var enrolledEmployeeIds = await _context.TrainingEnrollments
                .Where(x =>
                    x.TrainingScheduleId == trainingScheduleId &&
                    x.IsActive &&
                    !x.IsCancelled)
                .Select(x => x.EmployeeId)
                .ToListAsync();

            IQueryable<Employee> employees = _context.Employees
                .Where(x => x.IsActive);

            // If not "All Departments", filter by department
            if (schedule.DepartmentId != 0)
            {
                employees = employees.Where(x => x.DepartmentId == schedule.DepartmentId);
            }

            var availableEmployees = await employees
                .Where(x => !enrolledEmployeeIds.Contains(x.EmployeeId))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.EmployeeCode,
                    EmployeeName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                    Department = x.Department != null ? x.Department.DepartmentName : ""
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data = availableEmployees
            });
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> GetEnrolledEmployees(int trainingScheduleId)
        {
            var enrolled = await _context.TrainingEnrollments
                .Include(x => x.Employee)
                .ThenInclude(x => x.Department)
                .Where(x => x.TrainingScheduleId == trainingScheduleId && x.IsActive && !x.IsCancelled)
                .Select(x => new
                {
                    TrainingEnrollmentId = x.TrainingEnrollmentId,
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.Employee != null ? x.Employee.EmployeeCode : "",
                    EmployeeName = x.Employee != null ? (x.Employee.FirstName + " " + (x.Employee.LastName ?? "")).Trim() : "",
                    Department = x.Employee != null && x.Employee.Department != null ? x.Employee.Department.DepartmentName : "",
                    Remarks = x.Remarks
                })
                .ToListAsync();

            return Json(new { success = true, data = enrolled });
        }
    }
}