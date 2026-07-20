using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.EmployeeInductionAttendance;
using VeltriQ.ViewModels.EmployeeInductionAttendance;

namespace VeltriQ.Controllers
{
    public class EmployeeInductionAttendanceController : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeInductionAttendanceController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
        }
        private enum AttendanceStatusEnum
        {
            Present = 1,
            Absent = 2,
            Late = 3
        }
        public IActionResult Index()
        {
            var vm = new AttendanceRegisterViewModel();

            vm.Programs = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();

            vm.Programs.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- Select Program --"
            });

            vm.Sessions.Add(new SelectListItem
            {
                Value = "",
                Text = "-- Select Session --"
            });

            return View(vm);
        }
        [HttpGet]
        public IActionResult GetSessions(int programId)
        {
            var sessions = _context.InductionSessionMasters
                .Where(x => x.InductionProgramMasterId == programId && x.IsActive)
                .OrderBy(x => x.SessionOrder)
                .Select(x => new
                {
                    x.InductionSessionMasterId,
                    x.SessionTitle
                })
                .ToList();

            return Json(sessions);
        }
        [HttpGet]
        public IActionResult GetAttendanceRegister(int? programId, int? sessionId)
        {
            // Get Employee Induction Sessions
            var sessionQuery = _context.EmployeeInductionSessions
                .Include(x => x.EmployeeInduction)
                    .ThenInclude(x => x.InductionProgramMaster)
                .Include(x => x.InductionSessionMaster)
                .Where(x => x.IsActive &&
                            x.EmployeeInduction != null &&
                            x.EmployeeInduction.IsActive);

            if (programId.HasValue && programId.Value > 0)
            {
                sessionQuery = sessionQuery.Where(x =>
                    x.EmployeeInduction!.InductionProgramMasterId == programId.Value);
            }

            if (sessionId.HasValue && sessionId.Value > 0)
            {
                sessionQuery = sessionQuery.Where(x =>
                    x.InductionSessionMasterId == sessionId.Value);
            }

            // Group Sessions
            var groupedSessions = sessionQuery
            .GroupBy(x => new
            {
                x.EmployeeInduction!.InductionProgramMasterId,
                ProgramName = x.EmployeeInduction.InductionProgramMaster!.ProgramName,
                x.InductionSessionMasterId,
                SessionName = x.InductionSessionMaster!.SessionTitle
            })
            .Select(g => new
            {
                g.Key.InductionProgramMasterId,
                g.Key.ProgramName,
                g.Key.InductionSessionMasterId,
                g.Key.SessionName,
                TotalEmployees = g.Count()
            })
                .ToList();

            // Attendance Headers
            var attendanceHeaders = _context.EmployeeInductionAttendances
                .Include(x => x.AttendanceDetails)
                .ToList();

            var register = new List<AttendanceRegisterItemViewModel>();

            foreach (var item in groupedSessions)
            {
                var attendance = attendanceHeaders.FirstOrDefault(x =>
                    x.InductionProgramMasterId == item.InductionProgramMasterId &&
                    x.InductionSessionMasterId == item.InductionSessionMasterId);

                int present = 0;
                int absent = 0;
                int late = 0;

                if (attendance != null)
                {
                    present = attendance.AttendanceDetails.Count(x => x.AttendanceStatus == 1);
                    absent = attendance.AttendanceDetails.Count(x => x.AttendanceStatus == 2);
                    late = attendance.AttendanceDetails.Count(x => x.AttendanceStatus == 3);
                }

                int pending = item.TotalEmployees - (present + absent + late);

                if (pending < 0)
                    pending = 0;

                string status;
                string action;

                if (attendance == null)
                {
                    status = "Pending";
                    action = "Mark";
                }
                else
                {
                    if (pending == 0)
                    {
                        status = "Completed";
                    }
                    else
                    {
                        status = "In Progress";
                    }

                    action = attendance.IsLocked ? "View" : "Edit";
                }

                register.Add(new AttendanceRegisterItemViewModel
                {
                    EmployeeInductionAttendanceId = attendance?.EmployeeInductionAttendanceId ?? 0,
                    InductionProgramMasterId = item.InductionProgramMasterId,
                    ProgramName = item.ProgramName,
                    InductionSessionMasterId = item.InductionSessionMasterId,
                    SessionName = item.SessionName,
                    AttendanceDate = attendance?.AttendanceDate,
                    TotalEmployees = item.TotalEmployees,
                    PresentCount = present,
                    AbsentCount = absent,
                    LateCount = late,
                    PendingCount = pending,
                    Status = status,
                    Action = action,
                    IsLocked = attendance?.IsLocked ?? false
                });
            }

            register = register
                .OrderBy(x => x.ProgramName)
                .ThenBy(x => x.SessionName)
                .ToList();

            return Json(new
            {
                data = register
            });
        }
        [HttpGet]
        public IActionResult MarkAttendance(int programId, int sessionId)
        {
            var vm = BuildAttendanceViewModel(null, programId, sessionId, false);

            if (vm == null)
                return NotFound();

            return View("MarkAttendance", vm);
        }

        [HttpGet]
        public IActionResult EditAttendance(int attendanceId)
        {
            var vm = BuildAttendanceViewModel(attendanceId, null, null, false);

            if (vm == null)
                return NotFound();

            return View("MarkAttendance", vm);
        }

        [HttpGet]
        public IActionResult ViewAttendance(int attendanceId)
        {
            var vm = BuildAttendanceViewModel(attendanceId, null, null, true);

            if (vm == null)
                return NotFound();

            return View("MarkAttendance", vm);
        }
        private MarkAttendanceViewModel? BuildAttendanceViewModel(int? attendanceId, int? programId, int? sessionId, bool isViewMode)
        {
            //=========================================================
            // EXISTING ATTENDANCE (Edit / View)
            //=========================================================
            if (attendanceId.HasValue)
            {
                var attendance = _context.EmployeeInductionAttendances
                    .Include(x => x.InductionProgramMaster)
                    .Include(x => x.InductionSessionMaster)
                    .Include(x => x.AttendanceDetails)
                        .ThenInclude(x => x.EmployeeInduction)
                            .ThenInclude(x => x.Employee)
                                .ThenInclude(x => x.Department)
                    .Include(x => x.AttendanceDetails)
                        .ThenInclude(x => x.EmployeeInduction)
                            .ThenInclude(x => x.Employee)
                                .ThenInclude(x => x.Designation) // ✅ Include Designation
                    .FirstOrDefault(x => x.EmployeeInductionAttendanceId == attendanceId.Value && x.IsActive);

                if (attendance == null) return null;

                var vm = new MarkAttendanceViewModel
                {
                    EmployeeInductionAttendanceId = attendance.EmployeeInductionAttendanceId,
                    ProgramId = attendance.InductionProgramMasterId,
                    ProgramName = attendance.InductionProgramMaster?.ProgramName ?? "",
                    SessionId = attendance.InductionSessionMasterId,
                    SessionName = attendance.InductionSessionMaster?.SessionTitle ?? "",
                    AttendanceDate = attendance.AttendanceDate,
                    IsLocked = attendance.IsLocked,
                    IsEditMode = !isViewMode,
                    IsViewMode = isViewMode
                };

                vm.Employees = attendance.AttendanceDetails
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.EmployeeInduction.Employee!.EmployeeCode)
                    .Select(x => new MarkAttendanceEmployeeViewModel
                    {
                        EmployeeInductionId = x.EmployeeInductionId,
                        EmployeeInductionSessionId = x.EmployeeInductionSessionId,
                        EmployeeId = x.EmployeeInduction.EmployeeId,
                        EmployeeNo = x.EmployeeInduction.Employee!.EmployeeCode ?? "",
                        EmployeeName = $"{x.EmployeeInduction.Employee.FirstName} {x.EmployeeInduction.Employee.LastName}".Trim(),
                        DepartmentName = x.EmployeeInduction.Employee.Department?.DepartmentName ?? "",
                        Designation = x.EmployeeInduction.Employee.Designation?.DesignationName ?? "", // ✅ Populate Designation
                        AttendanceStatus = x.AttendanceStatus,
                        Remarks = x.Remarks
                    })
                    .ToList();

                return vm;
            }

            //=========================================================
            // NEW ATTENDANCE
            //=========================================================
            if (!programId.HasValue || !sessionId.HasValue) return null;

            var sessions = _context.EmployeeInductionSessions
                .Include(x => x.EmployeeInduction)
                    .ThenInclude(x => x.Employee)
                        .ThenInclude(x => x.Department)
                .Include(x => x.EmployeeInduction)
                    .ThenInclude(x => x.Employee)
                        .ThenInclude(x => x.Designation) // ✅ Include Designation
                .Include(x => x.EmployeeInduction)
                    .ThenInclude(x => x.InductionProgramMaster)
                .Include(x => x.InductionSessionMaster)
                .Where(x => x.IsActive &&
                            x.InductionSessionMasterId == sessionId.Value &&
                            x.EmployeeInduction != null &&
                            x.EmployeeInduction.IsActive &&
                            x.EmployeeInduction.InductionProgramMasterId == programId.Value)
                .ToList();

            if (!sessions.Any()) return null;
            var first = sessions.First();

            var vmNew = new MarkAttendanceViewModel
            {
                ProgramId = programId.Value,
                ProgramName = first.EmployeeInduction!.InductionProgramMaster!.ProgramName,
                SessionId = sessionId.Value,
                SessionName = first.InductionSessionMaster!.SessionTitle,
                AttendanceDate = DateTime.Today,
                IsLocked = false,
                IsEditMode = false,
                IsViewMode = false
            };

            vmNew.Employees = sessions
                .OrderBy(x => x.EmployeeInduction!.Employee!.EmployeeCode)
                .Select(x => new MarkAttendanceEmployeeViewModel
                {
                    EmployeeInductionId = x.EmployeeInductionId,
                    EmployeeInductionSessionId = x.EmployeeInductionSessionId,
                    EmployeeId = x.EmployeeInduction.EmployeeId,
                    EmployeeNo = x.EmployeeInduction.Employee!.EmployeeCode ?? "",
                    EmployeeName = $"{x.EmployeeInduction.Employee.FirstName} {x.EmployeeInduction.Employee.LastName}".Trim(),
                    DepartmentName = x.EmployeeInduction.Employee.Department?.DepartmentName ?? "",
                    Designation = x.EmployeeInduction.Employee.Designation?.DesignationName ?? "", // ✅ Populate Designation
                    AttendanceStatus = 1,
                    Remarks = ""
                })
                .ToList();

            return vmNew;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAttendance(MarkAttendanceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("MarkAttendance", model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (model.EmployeeInductionAttendanceId == 0)
                {
                    await CreateAttendance(model);
                }
                else
                {
                    await UpdateAttendance(model);
                }

                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "Attendance saved successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        private async Task CreateAttendance(MarkAttendanceViewModel model)
        {
            var attendance = new EmployeeInductionAttendance
            {
                InductionProgramMasterId = model.ProgramId,
                InductionSessionMasterId = model.SessionId,
                AttendanceDate = model.AttendanceDate,
                IsLocked = false,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.EmployeeInductionAttendances.Add(attendance);

            await _context.SaveChangesAsync();

            foreach (var employee in model.Employees)
            {
                _context.EmployeeInductionAttendanceDetails.Add(
                    new EmployeeInductionAttendanceDetail
                    {
                        EmployeeInductionAttendanceId = attendance.EmployeeInductionAttendanceId,
                        EmployeeInductionId = employee.EmployeeInductionId,
                        EmployeeInductionSessionId = employee.EmployeeInductionSessionId,
                        AttendanceStatus = employee.AttendanceStatus,
                        Remarks = employee.Remarks,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = GetCurrentEmployeeId()
                    });
            }

            await _context.SaveChangesAsync();
        }
        private async Task UpdateAttendance(MarkAttendanceViewModel model)
        {
            var attendance = await _context.EmployeeInductionAttendances
                .Include(x => x.AttendanceDetails)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeInductionAttendanceId == model.EmployeeInductionAttendanceId);

            if (attendance == null)
                throw new Exception("Attendance record not found.");

            attendance.AttendanceDate = model.AttendanceDate;
            attendance.ModifiedOn = DateTime.Now;
            attendance.ModifiedBy = GetCurrentEmployeeId();

            foreach (var employee in model.Employees)
            {
                var detail = attendance.AttendanceDetails.FirstOrDefault(x =>
                    x.EmployeeInductionId == employee.EmployeeInductionId);

                if (detail == null)
                    continue;

                detail.AttendanceStatus = employee.AttendanceStatus;
                detail.Remarks = employee.Remarks;
                detail.ModifiedOn = DateTime.Now;
                detail.ModifiedBy = GetCurrentEmployeeId();
            }

            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task<IActionResult> LockAttendance(int attendanceId)
        {
            var attendance = await _context.EmployeeInductionAttendances
                .FirstOrDefaultAsync(x => x.EmployeeInductionAttendanceId == attendanceId);

            if (attendance == null)
                return NotFound();

            attendance.IsLocked = true;
            attendance.ModifiedOn = DateTime.Now;
            attendance.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Attendance locked successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}
