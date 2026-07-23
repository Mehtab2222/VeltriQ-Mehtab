using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.TransactionApproval; // TrainingApprovalViewModel / TrainingApprovalEmployeeViewModel live here per your existing controller

namespace VeltriQ.Controllers
{
    [Authorize]
    public class TrainingApprovalController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingApprovalController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
        }

        // GET /TrainingApproval/Index?id={transactionApprovalId}
        public IActionResult Index(int id)
        {
            ViewBag.TransactionApprovalId = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainingRequestForApproval(int transactionApprovalId)
        {
            try
            {
                var approval = await _context.TransactionApprovals
                    .FirstOrDefaultAsync(x =>
                        x.TransactionApprovalId == transactionApprovalId &&
                        x.IsActive);

                if (approval == null)
                    return Json(new { success = false, message = "Approval record not found." });

                var request = await _context.TrainingRequests
                    .FirstOrDefaultAsync(x =>
                        x.TrainingRequestId == approval.TransactionId &&
                        x.IsActive);

                if (request == null)
                    return Json(new { success = false, message = "Training request not found." });

                var schedule = await _context.TrainingSchedules
                    .Include(x => x.TrainingMaster)
                    .Include(x => x.TrainingVenue)
                    .Include(x => x.TrainingTrainer)
                        .ThenInclude(t => t.Employee)
                    .FirstOrDefaultAsync(x =>
                        x.TrainingScheduleId == request.TrainingScheduleId &&
                        x.IsActive);

                if (schedule == null)
                    return Json(new { success = false, message = "Training schedule not found." });

                var requestedBy = await _context.Employees
                    .FirstOrDefaultAsync(x => x.EmployeeId == request.RequestedBy);

                var employeeIds = string.IsNullOrWhiteSpace(request.RequestedEmployeeIds)
                    ? new List<int>()
                    : request.RequestedEmployeeIds
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                var employees = await _context.Employees
                    .Include(x => x.Department)
                    .Include(x => x.Designation)
                    .Where(x => employeeIds.Contains(x.EmployeeId))
                    .Select(x => new TrainingApprovalEmployeeViewModel
                    {
                        EmployeeId = x.EmployeeId,
                        EmployeeNo = x.EmployeeCode ?? "",
                        EmployeeName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                        DepartmentName = x.Department != null ? x.Department.DepartmentName : "",
                        DesignationName = x.Designation != null ? x.Designation.DesignationName : ""
                    })
                    .ToListAsync();

                var trainerName = schedule.TrainingTrainer != null
                    ? schedule.TrainingTrainer.TrainerType == 1
                        ? (schedule.TrainingTrainer.Employee!.FirstName + " " +
                           (schedule.TrainingTrainer.Employee.LastName ?? "")).Trim()
                        : schedule.TrainingTrainer.TrainerName
                    : "";

                var totalEnrolled = await _context.TrainingEnrollments
                    .CountAsync(x => x.TrainingScheduleId == schedule.TrainingScheduleId
                                   && x.IsActive && !x.IsCancelled);

                var model = new TrainingApprovalViewModel
                {
                    TransactionApprovalId = approval.TransactionApprovalId,
                    TrainingRequestId = request.TrainingRequestId,
                    RequestNo = request.RequestNo,
                    TrainingScheduleId = schedule.TrainingScheduleId,
                    TrainingCode = schedule.ScheduleCode,
                    TrainingName = schedule.TrainingMaster?.TrainingName ?? "",
                    TrainingDate = schedule.StartDate,
                    TrainerName = trainerName,
                    VenueName = schedule.TrainingVenue?.VenueName ?? "",
                    RequestedByName = requestedBy == null ? "" : (requestedBy.FirstName + " " + requestedBy.LastName).Trim(),
                    RequestDate = request.RequestDate,
                    Reason = request.Reason,
                    Status = approval.Status,
                    ApprovalRemarks = approval.Remarks,
                    Employees = employees
                };

                return Json(new
                {
                    success = true,
                    data = model,
                    startDate = schedule.StartDate,
                    endDate = schedule.EndDate,
                    startTime = schedule.StartTime.ToString(),
                    endTime = schedule.EndTime.ToString(),
                    capacity = schedule.Capacity,
                    totalEnrolled,
                    availableSeats = schedule.Capacity - totalEnrolled
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Employees eligible to be ADDED to this pending request
        // (active, in schedule's department scope if set, not already enrolled, not already on this request)
        [HttpGet]
        public async Task<IActionResult> GetAddableEmployees(int trainingScheduleId, string currentEmployeeIds)
        {
            try
            {
                var schedule = await _context.TrainingSchedules
                    .FirstOrDefaultAsync(x => x.TrainingScheduleId == trainingScheduleId);

                if (schedule == null)
                    return Json(new { success = false, message = "Training schedule not found." });

                var enrolledIds = await _context.TrainingEnrollments
                    .Where(x => x.TrainingScheduleId == trainingScheduleId && x.IsActive && !x.IsCancelled)
                    .Select(x => x.EmployeeId)
                    .ToListAsync();

                var currentIds = string.IsNullOrWhiteSpace(currentEmployeeIds)
                    ? new List<int>()
                    : currentEmployeeIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToList();

                IQueryable<Employee> query = _context.Employees.Where(x => x.IsActive);

                if (schedule.DepartmentId != 0)
                    query = query.Where(x => x.DepartmentId == schedule.DepartmentId);

                var employees = await query
                    .Where(x => !enrolledIds.Contains(x.EmployeeId) && !currentIds.Contains(x.EmployeeId))
                    .OrderBy(x => x.FirstName)
                    .Select(x => new
                    {
                        x.EmployeeId,
                        x.EmployeeCode,
                        EmployeeName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                        DepartmentName = x.Department != null ? x.Department.DepartmentName : ""
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
        public async Task<IActionResult> ApproveTrainingRequest([FromBody] ApproveTrainingRequestDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var currentEmployeeId = GetCurrentEmployeeId();
                if (currentEmployeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var approval = await _context.TransactionApprovals
                    .FirstOrDefaultAsync(x => x.TransactionApprovalId == dto.TransactionApprovalId && x.IsActive);

                if (approval == null)
                    return Json(new { success = false, message = "Approval record not found." });

                if (approval.Status != "Pending")
                    return Json(new { success = false, message = "This request has already been processed." });

                var request = await _context.TrainingRequests
                    .FirstOrDefaultAsync(x => x.TrainingRequestId == approval.TransactionId && x.IsActive);

                if (request == null)
                    return Json(new { success = false, message = "Training request not found." });

                if (dto.FinalEmployeeIds == null || !dto.FinalEmployeeIds.Any())
                    return Json(new { success = false, message = "At least one employee must remain on the request." });

                var schedule = await _context.TrainingSchedules
                    .FirstOrDefaultAsync(x => x.TrainingScheduleId == request.TrainingScheduleId);

                var totalEnrolled = await _context.TrainingEnrollments
                    .CountAsync(x => x.TrainingScheduleId == request.TrainingScheduleId && x.IsActive && !x.IsCancelled);

                var alreadyEnrolledOfSelected = await _context.TrainingEnrollments
                    .Where(x => x.TrainingScheduleId == request.TrainingScheduleId
                             && x.IsActive && !x.IsCancelled
                             && dto.FinalEmployeeIds.Contains(x.EmployeeId))
                    .CountAsync();

                var newEnrollmentsCount = dto.FinalEmployeeIds.Count - alreadyEnrolledOfSelected;
                if (schedule != null && (totalEnrolled + newEnrollmentsCount) > schedule.Capacity)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"Cannot approve — only {schedule.Capacity - totalEnrolled} seat(s) remaining."
                    });
                }

                // Persist the final (possibly edited) employee list back onto the request
                request.RequestedEmployeeIds = string.Join(",", dto.FinalEmployeeIds);
                request.Status = "Approved";
                request.ModifiedOn = DateTime.Now;
                request.ModifiedBy = currentEmployeeId.Value;

                foreach (var employeeId in dto.FinalEmployeeIds)
                {
                    var alreadyEnrolled = await _context.TrainingEnrollments.AnyAsync(x =>
                        x.TrainingScheduleId == request.TrainingScheduleId &&
                        x.EmployeeId == employeeId &&
                        x.IsActive && !x.IsCancelled);

                    if (alreadyEnrolled) continue;

                    _context.TrainingEnrollments.Add(new TrainingEnrollment
                    {
                        TrainingScheduleId = request.TrainingScheduleId,
                        EmployeeId = employeeId,
                        EnrollmentDate = DateTime.Now,
                        IsCancelled = false,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = currentEmployeeId.Value
                    });
                }

                approval.Status = "Approved";
                approval.Remarks = dto.Remarks;
                approval.ApproverId = currentEmployeeId.Value;
                approval.ActionDate = DateTime.Now;
                approval.ModifiedOn = DateTime.Now;
                approval.ModifiedBy = currentEmployeeId.Value;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, message = "Training request approved and employees enrolled successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectTrainingRequest([FromBody] RejectTrainingRequestDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var currentEmployeeId = GetCurrentEmployeeId();
                if (currentEmployeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var approval = await _context.TransactionApprovals
                    .FirstOrDefaultAsync(x => x.TransactionApprovalId == dto.TransactionApprovalId && x.IsActive);

                if (approval == null)
                    return Json(new { success = false, message = "Approval record not found." });

                if (approval.Status != "Pending")
                    return Json(new { success = false, message = "This request has already been processed." });

                var request = await _context.TrainingRequests
                    .FirstOrDefaultAsync(x => x.TrainingRequestId == approval.TransactionId && x.IsActive);

                if (request == null)
                    return Json(new { success = false, message = "Training request not found." });

                request.Status = "Rejected";
                request.ModifiedOn = DateTime.Now;
                request.ModifiedBy = currentEmployeeId.Value;

                approval.Status = "Rejected";
                approval.Remarks = dto.Remarks;
                approval.ApproverId = currentEmployeeId.Value;
                approval.ActionDate = DateTime.Now;
                approval.ModifiedOn = DateTime.Now;
                approval.ModifiedBy = currentEmployeeId.Value;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, message = "Training request rejected successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }
        public class ApproveTrainingRequestDto
        {
            public int TransactionApprovalId { get; set; }
            public List<int> FinalEmployeeIds { get; set; } = new();
            public string? Remarks { get; set; }
        }

        public class RejectTrainingRequestDto
        {
            public int TransactionApprovalId { get; set; }
            public string? Remarks { get; set; }
        }
    }
}