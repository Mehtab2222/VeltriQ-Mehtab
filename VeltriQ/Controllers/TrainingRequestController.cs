using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Controllers;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.TransactionApproval;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;
[Authorize]
public class TrainingRequestController : BaseController
{
    private readonly TenantDbContext _context;

    public TrainingRequestController(
        TenantDbContext context,
        MasterDbContext masterDbContext,
        UserManager<ApplicationUser> userManager)
        : base(context, masterDbContext, userManager)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetTrainingSchedules()
    {
        try
        {
            var schedules = await _context.TrainingSchedules
                .Include(x => x.TrainingMaster)
                .Include(x => x.Department)
                .Include(x => x.TrainingTrainer)
                    .ThenInclude(t => t.Employee)
                .Include(x => x.TrainingVenue)
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.StartDate)
                .Select(x => new
                {
                    x.TrainingScheduleId,
                    x.ScheduleCode,
                    TrainingName = x.TrainingMaster != null ? x.TrainingMaster.TrainingName : "",
                    DepartmentName = x.Department != null ? x.Department.DepartmentName : "",
                    TrainerName = x.TrainingTrainer != null
                        ? x.TrainingTrainer.TrainerType == 1
                            ? (x.TrainingTrainer.Employee!.FirstName + " " +
                               (x.TrainingTrainer.Employee.LastName ?? "")).Trim()
                            : x.TrainingTrainer.TrainerName
                        : "",
                    VenueName = x.TrainingVenue != null ? x.TrainingVenue.VenueName : "",
                    TrainingDate = x.StartDate,
                    Capacity = x.Capacity,

                    TotalEnrolled = _context.TrainingEnrollments.Count(e =>
                        e.TrainingScheduleId == x.TrainingScheduleId &&
                        e.IsActive &&
                        !e.IsCancelled)
                })
                .ToListAsync();

            var result = schedules.Select(x => new
            {
                x.TrainingScheduleId,
                x.ScheduleCode,
                x.TrainingName,
                x.DepartmentName,
                x.TrainerName,
                x.VenueName,
                x.TrainingDate,
                x.Capacity,
                x.TotalEnrolled,
                AvailableSeats = x.Capacity - x.TotalEnrolled
            });

            return Json(new
            {
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAvailableEmployees(int trainingScheduleId)
    {
        try
        {
            // Employees already enrolled
            var enrolledEmployeeIds = await _context.TrainingEnrollments
                .Where(x => x.TrainingScheduleId == trainingScheduleId
                         && x.IsActive
                         && !x.IsCancelled)
                .Select(x => x.EmployeeId)
                .ToListAsync();

            // Employees already requested (Pending/Approved)
            var requestedEmployeeIds = await _context.TrainingRequests
                .Where(x => x.TrainingScheduleId == trainingScheduleId
                         && x.IsActive
                         && (x.Status == "Pending" || x.Status == "Approved"))
                .Select(x => x.RequestedEmployeeIds)
                .ToListAsync();

            var requestEmployeeList = requestedEmployeeIds
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(x => int.Parse(x))
                .Distinct()
                .ToList();

            var employees = await _context.Employees
                .Include(x => x.Department)
                .Where(x => x.IsActive
                         && !enrolledEmployeeIds.Contains(x.EmployeeId)
                         && !requestEmployeeList.Contains(x.EmployeeId))
                .OrderBy(x => x.FirstName)
                .Select(x => new
                {
                    x.EmployeeId,
                    x.EmployeeCode,
                    EmployeeName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                    DepartmentName = x.Department != null
                        ? x.Department.DepartmentName
                        : ""
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data = employees
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveTrainingRequest([FromBody] TrainingRequestViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new
            {
                success = false,
                message = "Please fill all required fields."
            });
        }

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Check Training Schedule
            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x =>
                    x.TrainingScheduleId == model.TrainingScheduleId &&
                    x.IsActive);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training schedule not found."
                });
            }

            // Check Employees Selected
            if (model.SelectedEmployeeIds == null || !model.SelectedEmployeeIds.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "Please select at least one employee."
                });
            }

            // Check Already Enrolled
            var alreadyEnrolled = await _context.TrainingEnrollments
                .Where(x =>
                    x.TrainingScheduleId == model.TrainingScheduleId &&
                    x.IsActive &&
                    !x.IsCancelled &&
                    model.SelectedEmployeeIds.Contains(x.EmployeeId))
                .Select(x => x.EmployeeId)
                .ToListAsync();

            if (alreadyEnrolled.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "One or more selected employees are already enrolled."
                });
            }

            // Generate Request Number
            string requestNo = "TR0001";

            var lastRequest = await _context.TrainingRequests
                .OrderByDescending(x => x.TrainingRequestId)
                .FirstOrDefaultAsync();

            if (lastRequest != null)
            {
                var number = int.Parse(lastRequest.RequestNo.Substring(2));
                requestNo = "TR" + (number + 1).ToString("D4");
            }

            var requestedBy = GetCurrentEmployeeId();

            if (requestedBy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Unable to identify the current employee."
                });
            }

            // Save Training Request
            var request = new TrainingRequest
            {
                RequestNo = requestNo,
                TrainingScheduleId = model.TrainingScheduleId,
                RequestedEmployeeIds = string.Join(",", model.SelectedEmployeeIds),
                RequestedBy = requestedBy.Value,
                RequestDate = DateTime.Now,
                Reason = model.Reason,
                Status = "Pending",
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = requestedBy.Value
            };

            _context.TrainingRequests.Add(request);
            await _context.SaveChangesAsync();

            // Save Transaction Approval
            var approval = new TransactionApproval
            {
                ModuleName = "Training",
                TransactionId = request.TrainingRequestId,
                RequestedBy = requestedBy.Value,
                Status = "Pending",
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = requestedBy.Value
            };

            _context.TransactionApprovals.Add(approval);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Json(new
            {
                success = true,
                message = "Training request submitted successfully."
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetTrainingRequests()
    {
        try
        {
            var requests = await _context.TrainingRequests
                .Include(x => x.TrainingSchedule)
                    .ThenInclude(x => x.TrainingMaster)
                .Include(x => x.RequestedByEmployee)
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.TrainingRequestId)
                .Select(x => new
                {
                    x.TrainingRequestId,
                    x.RequestNo,
                    ScheduleCode = x.TrainingSchedule != null
                        ? x.TrainingSchedule.ScheduleCode
                        : "",

                    TrainingName = x.TrainingSchedule != null &&
                                   x.TrainingSchedule.TrainingMaster != null
                        ? x.TrainingSchedule.TrainingMaster.TrainingName
                        : "",

                    RequestedBy = x.RequestedByEmployee != null
                        ? (x.RequestedByEmployee.FirstName + " " +
                           (x.RequestedByEmployee.LastName ?? "")).Trim()
                        : "",

                    EmployeeCount = string.IsNullOrWhiteSpace(x.RequestedEmployeeIds)
                        ? 0
                        : x.RequestedEmployeeIds
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Length,

                    x.RequestDate,
                    x.Status
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data = requests
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetTrainingRequest(int trainingRequestId)
    {
        try
        {
            var request = await _context.TrainingRequests
                .Include(x => x.TrainingSchedule)
                    .ThenInclude(x => x.TrainingMaster)
                .Include(x => x.TrainingSchedule)
                    .ThenInclude(x => x.Department)
                .Include(x => x.TrainingSchedule)
                    .ThenInclude(x => x.TrainingTrainer)
                        .ThenInclude(t => t.Employee)
                .Include(x => x.TrainingSchedule)
                    .ThenInclude(x => x.TrainingVenue)
                .Include(x => x.RequestedByEmployee)
                .FirstOrDefaultAsync(x =>
                    x.TrainingRequestId == trainingRequestId &&
                    x.IsActive);

            if (request == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training request not found."
                });
            }

            List<int> employeeIds = new();

            if (!string.IsNullOrWhiteSpace(request.RequestedEmployeeIds))
            {
                employeeIds = request.RequestedEmployeeIds
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            var employees = await _context.Employees
                .Include(x => x.Department)
                .Where(x => employeeIds.Contains(x.EmployeeId))
                .Select(x => new
                {
                    x.EmployeeId,
                    x.EmployeeCode,
                    EmployeeName = (x.FirstName + " " +
                                   (x.LastName ?? "")).Trim(),
                    DepartmentName = x.Department != null
                        ? x.Department.DepartmentName
                        : ""
                })
                .ToListAsync();

            var result = new
            {
                request.TrainingRequestId,
                request.RequestNo,
                request.TrainingScheduleId,

                ScheduleCode = request.TrainingSchedule?.ScheduleCode,

                TrainingName = request.TrainingSchedule?.TrainingMaster?.TrainingName,

                DepartmentName = request.TrainingSchedule?.Department?.DepartmentName,

                TrainerName = request.TrainingSchedule?.TrainingTrainer != null
                    ? request.TrainingSchedule.TrainingTrainer.TrainerType == 1
                        ? (request.TrainingSchedule.TrainingTrainer.Employee!.FirstName + " " +
                           (request.TrainingSchedule.TrainingTrainer.Employee.LastName ?? "")).Trim()
                        : request.TrainingSchedule.TrainingTrainer.TrainerName
                    : "",

                VenueName = request.TrainingSchedule?.TrainingVenue?.VenueName,

                request.RequestDate,

                request.Reason,

                request.Status,

                RequestedBy = request.RequestedByEmployee != null
                    ? (request.RequestedByEmployee.FirstName + " " +
                       (request.RequestedByEmployee.LastName ?? "")).Trim()
                    : "",

                Employees = employees
            };

            return Json(new
            {
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CancelTrainingRequest(int trainingRequestId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var currentEmployeeId = GetCurrentEmployeeId();

            if (currentEmployeeId == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Unable to identify the current employee."
                });
            }

            var request = await _context.TrainingRequests
                .FirstOrDefaultAsync(x =>
                    x.TrainingRequestId == trainingRequestId &&
                    x.IsActive);

            if (request == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training request not found."
                });
            }

            if (request.Status != "Pending")
            {
                return Json(new
                {
                    success = false,
                    message = "Only pending requests can be cancelled."
                });
            }

            var approval = await _context.TransactionApprovals
                .FirstOrDefaultAsync(x =>
                    x.ModuleName == "Training" &&
                    x.TransactionId == trainingRequestId &&
                    x.IsActive);

            request.Status = "Cancelled";
            request.ModifiedOn = DateTime.Now;
            request.ModifiedBy = currentEmployeeId.Value;

            if (approval != null)
            {
                approval.Status = "Cancelled";
                approval.ActionDate = DateTime.Now;
                approval.ModifiedOn = DateTime.Now;
                approval.ModifiedBy = currentEmployeeId.Value;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Json(new
            {
                success = true,
                message = "Training request cancelled successfully."
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
}