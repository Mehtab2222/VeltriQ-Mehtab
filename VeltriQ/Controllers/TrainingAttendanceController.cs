using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;

namespace VeltriQ.Controllers
{
    public class TrainingAttendanceController : BaseController
    {
        public TrainingAttendanceController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
        : base(context, masterContext, userManager)
        {
        }

        public IActionResult Index()
        {
            return View(new TrainingAttendanceViewModel());
        }


        [HttpGet]
        public async Task<IActionResult> GetTrainingSchedulesForAttendance()
        {
            try
            {
                var schedulesFromDb = await _context.TrainingSchedules
                    .Include(x => x.TrainingMaster)
                    .Include(x => x.Department)
                    .Where(x => x.IsActive)
                    .OrderByDescending(x => x.StartDate)
                    .ToListAsync();

                var resultList = new List<object>();

                foreach (var x in schedulesFromDb)
                {
                    var totalEnrolled = await _context.TrainingEnrollments.CountAsync(e =>
                        e.TrainingScheduleId == x.TrainingScheduleId && e.IsActive && !e.IsCancelled);

                    // Generate all valid calendar dates between StartDate and EndDate
                    var dateList = new List<string>();
                    for (var dt = x.StartDate.Date; dt <= x.EndDate.Date; dt = dt.AddDays(1))
                    {
                        dateList.Add(dt.ToString("yyyy-MM-dd"));
                    }

                    // Default to the first day of the training
                    var defaultDate = dateList.FirstOrDefault() ?? x.StartDate.ToString("yyyy-MM-dd");

                    // Get counts for the default first day
                    var present = await _context.TrainingAttendances.CountAsync(a =>
                        a.TrainingScheduleId == x.TrainingScheduleId && a.IsActive &&
                        a.AttendanceStatus == "Present" && a.AttendanceDate.Date == DateTime.Parse(defaultDate).Date);

                    var absent = await _context.TrainingAttendances.CountAsync(a =>
                        a.TrainingScheduleId == x.TrainingScheduleId && a.IsActive &&
                        a.AttendanceStatus == "Absent" && a.AttendanceDate.Date == DateTime.Parse(defaultDate).Date);

                    var late = await _context.TrainingAttendances.CountAsync(a =>
                        a.TrainingScheduleId == x.TrainingScheduleId && a.IsActive &&
                        a.AttendanceStatus == "Late" && a.AttendanceDate.Date == DateTime.Parse(defaultDate).Date);

                    resultList.Add(new
                    {
                        x.TrainingScheduleId,
                        x.ScheduleCode,
                        TrainingName = x.TrainingMaster != null ? x.TrainingMaster.TrainingName : "",
                        DepartmentName = x.Department != null ? x.Department.DepartmentName : "All Departments",
                        StartDateStr = x.StartDate.ToString("dd MMM yyyy"),
                        EndDateStr = x.EndDate.ToString("dd MMM yyyy"),
                        Capacity = x.Capacity,
                        TotalEnrolled = totalEnrolled,
                        AvailableDates = dateList,
                        DefaultDate = defaultDate,
                        PresentCount = present,
                        AbsentCount = absent,
                        LateCount = late
                    });
                }

                return Json(new { success = true, data = resultList });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendance(int trainingScheduleId)
        {
            try
            {
                var schedule = await _context.TrainingSchedules
                    .Include(x => x.TrainingMaster)
                    .Include(x => x.Department)
                    .Include(x => x.TrainingTrainer).ThenInclude(t => t.Employee)
                    .Include(x => x.TrainingVenue)
                    .FirstOrDefaultAsync(x => x.TrainingScheduleId == trainingScheduleId && x.IsActive);

                if (schedule == null)
                    return Json(new { success = false, message = "Training schedule not found." });

                var totalEnrolled = await _context.TrainingEnrollments.CountAsync(x =>
                    x.TrainingScheduleId == trainingScheduleId && x.IsActive && !x.IsCancelled);

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        schedule.TrainingScheduleId,
                        schedule.ScheduleCode,
                        TrainingName = schedule.TrainingMaster?.TrainingName,
                        DepartmentName = schedule.Department?.DepartmentName,
                        TrainerName = schedule.TrainingTrainer != null
                            ? schedule.TrainingTrainer.TrainerType == 1
                                ? (schedule.TrainingTrainer.Employee!.FirstName + " " + (schedule.TrainingTrainer.Employee.LastName ?? "")).Trim()
                                : schedule.TrainingTrainer.TrainerName
                            : "",
                        VenueName = schedule.TrainingVenue?.VenueName,
                        StartDate = schedule.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = schedule.EndDate.ToString("yyyy-MM-dd"),
                        StartDateDisplay = schedule.StartDate.ToString("dd MMM yyyy"),
                        EndDateDisplay = schedule.EndDate.ToString("dd MMM yyyy"),
                        Capacity = schedule.Capacity,
                        TotalEnrolled = totalEnrolled
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrolledEmployeesForAttendance(int trainingScheduleId, DateTime attendanceDate)
        {
            try
            {
                var employees = await _context.TrainingEnrollments
                    .Include(x => x.Employee).ThenInclude(e => e.Department)
                    .Where(x => x.TrainingScheduleId == trainingScheduleId && x.IsActive && !x.IsCancelled)
                    .OrderBy(x => x.Employee!.FirstName)
                    .ThenBy(x => x.Employee!.LastName)
                    .Select(x => new
                    {
                        x.EmployeeId,
                        EmployeeCode = x.Employee!.EmployeeCode,
                        EmployeeName = (x.Employee.FirstName + " " + (x.Employee.LastName ?? "")).Trim(),
                        Department = x.Employee.Department != null ? x.Employee.Department.DepartmentName : "",

                        Attendance = _context.TrainingAttendances
                            .Where(a => a.TrainingScheduleId == trainingScheduleId &&
                                        a.EmployeeId == x.EmployeeId &&
                                        a.AttendanceDate.Date == attendanceDate.Date &&
                                        a.IsActive)
                            .Select(a => new
                            {
                                a.TrainingAttendanceId,
                                a.AttendanceStatus,
                                a.Remarks
                            })
                            .FirstOrDefault()
                    })
                    .ToListAsync();

                return Json(new { success = true, data = employees });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAttendance([FromBody] List<TrainingAttendanceViewModel> attendanceList)
        {
            if (attendanceList == null || attendanceList.Count == 0)
                return Json(new { success = false, message = "No attendance data received." });

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var employeeId = GetCurrentEmployeeId();

                foreach (var item in attendanceList)
                {
                    var targetDate = item.SelectedAttendanceDate.Date;

                    var attendance = await _context.TrainingAttendances
                        .FirstOrDefaultAsync(x =>
                            x.TrainingScheduleId == item.TrainingScheduleId &&
                            x.EmployeeId == item.EmployeeId &&
                            x.AttendanceDate.Date == targetDate);

                    if (attendance == null)
                    {
                        attendance = new TrainingAttendance
                        {
                            TrainingScheduleId = item.TrainingScheduleId,
                            EmployeeId = item.EmployeeId,
                            AttendanceDate = targetDate,
                            AttendanceStatus = item.AttendanceStatus,
                            Remarks = item.Remarks,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            CreatedBy = employeeId
                        };
                        _context.TrainingAttendances.Add(attendance);
                    }
                    else
                    {
                        attendance.AttendanceStatus = item.AttendanceStatus;
                        attendance.Remarks = item.Remarks;
                        attendance.ModifiedOn = DateTime.Now;
                        attendance.ModifiedBy = employeeId;
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, message = "Attendance saved successfully for the selected date." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAttendanceCountsForDate(int trainingScheduleId, DateTime attendanceDate)
        {
            try
            {
                var targetDate = attendanceDate.Date;

                var present = await _context.TrainingAttendances.CountAsync(a =>
                    a.TrainingScheduleId == trainingScheduleId && a.IsActive &&
                    a.AttendanceStatus == "Present" && a.AttendanceDate.Date == targetDate);

                var absent = await _context.TrainingAttendances.CountAsync(a =>
                    a.TrainingScheduleId == trainingScheduleId && a.IsActive &&
                    a.AttendanceStatus == "Absent" && a.AttendanceDate.Date == targetDate);

                var late = await _context.TrainingAttendances.CountAsync(a =>
                    a.TrainingScheduleId == trainingScheduleId && a.IsActive &&
                    a.AttendanceStatus == "Late" && a.AttendanceDate.Date == targetDate);

                return Json(new { success = true, present, absent, late });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}