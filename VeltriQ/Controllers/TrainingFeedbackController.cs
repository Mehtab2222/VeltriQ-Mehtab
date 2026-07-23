using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class TrainingFeedbackController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingFeedbackController(
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
        public async Task<IActionResult> GetMyTrainingsForFeedback()
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var today = DateTime.Now.Date;

                var enrollments = await _context.TrainingEnrollments
                    .Include(x => x.TrainingSchedule)!.ThenInclude(s => s.TrainingMaster)
                    .Include(x => x.TrainingSchedule)!.ThenInclude(s => s.TrainingTrainer)!.ThenInclude(t => t.Employee)
                    .Include(x => x.TrainingSchedule)!.ThenInclude(s => s.TrainingVenue)
                    .Where(x => x.EmployeeId == employeeId.Value
                             && x.IsActive
                             && !x.IsCancelled
                             && x.TrainingSchedule != null
                             && x.TrainingSchedule.EndDate.Date <= today)
                    .OrderByDescending(x => x.TrainingSchedule!.EndDate)
                    .ToListAsync();

                var enrollmentIds = enrollments.Select(x => x.TrainingEnrollmentId).ToList();

                var feedbacks = await _context.TrainingFeedbacks
                    .Where(x => enrollmentIds.Contains(x.TrainingEnrollmentId) && x.IsActive)
                    .ToListAsync();

                var result = enrollments.Select(x =>
                {
                    var fb = feedbacks.FirstOrDefault(f => f.TrainingEnrollmentId == x.TrainingEnrollmentId);
                    var trainer = x.TrainingSchedule?.TrainingTrainer;
                    var trainerName = trainer != null
                        ? trainer.TrainerType == 1
                            ? (trainer.Employee!.FirstName + " " + (trainer.Employee.LastName ?? "")).Trim()
                            : trainer.TrainerName
                        : "";

                    return new TrainingFeedbackListItemViewModel
                    {
                        TrainingEnrollmentId = x.TrainingEnrollmentId,
                        TrainingScheduleId = x.TrainingScheduleId,
                        ScheduleCode = x.TrainingSchedule?.ScheduleCode ?? "",
                        TrainingName = x.TrainingSchedule?.TrainingMaster?.TrainingName ?? "",
                        TrainerName = trainerName,
                        VenueName = x.TrainingSchedule?.TrainingVenue?.VenueName ?? "",
                        StartDate = x.TrainingSchedule?.StartDate ?? default,
                        EndDate = x.TrainingSchedule?.EndDate ?? default,
                        IsSubmitted = fb != null,
                        TrainingFeedbackId = fb?.TrainingFeedbackId,
                        TrainerRating = fb?.TrainerRating,
                        ContentRating = fb?.ContentRating,
                        VenueRating = fb?.VenueRating,
                        OverallRating = fb?.OverallRating,
                        WouldRecommend = fb?.WouldRecommend,
                        Comments = fb?.Comments,
                        SubmittedOn = fb?.SubmittedOn
                    };
                }).ToList();

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveFeedback([FromBody] SaveFeedbackDto dto)
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var enrollment = await _context.TrainingEnrollments
                    .FirstOrDefaultAsync(x =>
                        x.TrainingEnrollmentId == dto.TrainingEnrollmentId &&
                        x.EmployeeId == employeeId.Value &&
                        x.IsActive && !x.IsCancelled);

                if (enrollment == null)
                    return Json(new { success = false, message = "Enrollment not found for the current employee." });

                var schedule = await _context.TrainingSchedules
                    .FirstOrDefaultAsync(x => x.TrainingScheduleId == enrollment.TrainingScheduleId);

                if (schedule == null || schedule.EndDate.Date > DateTime.Now.Date)
                    return Json(new { success = false, message = "Feedback can only be submitted after the training has ended." });

                var alreadyExists = await _context.TrainingFeedbacks
                    .AnyAsync(x => x.TrainingEnrollmentId == dto.TrainingEnrollmentId && x.IsActive);

                if (alreadyExists)
                    return Json(new { success = false, message = "Feedback has already been submitted for this training." });

                if (dto.TrainerRating is < 1 or > 5 ||
                    dto.ContentRating is < 1 or > 5 ||
                    dto.VenueRating is < 1 or > 5 ||
                    dto.OverallRating is < 1 or > 5)
                {
                    return Json(new { success = false, message = "Ratings must be between 1 and 5." });
                }

                _context.TrainingFeedbacks.Add(new TrainingFeedback
                {
                    TrainingEnrollmentId = dto.TrainingEnrollmentId,
                    TrainingScheduleId = enrollment.TrainingScheduleId,
                    EmployeeId = employeeId.Value,
                    TrainerRating = dto.TrainerRating,
                    ContentRating = dto.ContentRating,
                    VenueRating = dto.VenueRating,
                    OverallRating = dto.OverallRating,
                    WouldRecommend = dto.WouldRecommend,
                    Comments = dto.Comments,
                    SubmittedOn = DateTime.Now,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = employeeId.Value
                });

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Feedback submitted successfully. Thank you!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}