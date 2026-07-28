using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.ViewModels.Recruitment;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class MyInterviewsController : BaseController
    {
        private readonly TenantDbContext _context;

        public MyInterviewsController(
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
        public async Task<IActionResult> GetMyScheduledInterviews()
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var data = await _context.ScheduledInterviews
                    .Include(x => x.Applicant).ThenInclude(a => a!.ManpowerRequest)
                    .Include(x => x.AvailabilitySlot)
                    .Include(x => x.RoundType)
                    .Where(x => x.IsActive
                             && x.InterviewerEmployeeId == employeeId.Value
                             && x.Status == ScheduledInterviewStatus.Scheduled)
                    .OrderBy(x => x.AvailabilitySlot!.SlotDateTime)
                    .Select(x => new MyScheduledInterviewViewModel
                    {
                        ScheduledInterviewId = x.ScheduledInterviewId,
                        CandidateName = x.Applicant != null ? (x.Applicant.FirstName + " " + (x.Applicant.LastName ?? "")).Trim() : "",
                        MprTitle = x.Applicant != null && x.Applicant.ManpowerRequest != null ? x.Applicant.ManpowerRequest.JobTitle : "",
                        RoundTypeName = x.RoundType != null ? x.RoundType.RoundTypeName : "",
                        SlotDateTime = x.AvailabilitySlot != null ? x.AvailabilitySlot.SlotDateTime : default,
                        MatchPercentage = x.Applicant != null ? x.Applicant.MatchPercentage : null
                    })
                    .ToListAsync();

                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyInterviewHistory()
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var data = await _context.InterviewFeedbacks
                    .Include(f => f.ScheduledInterview)!.ThenInclude(si => si!.Applicant).ThenInclude(a => a!.ManpowerRequest)
                    .Include(f => f.ScheduledInterview)!.ThenInclude(si => si!.AvailabilitySlot)
                    .Include(f => f.ScheduledInterview)!.ThenInclude(si => si!.RoundType)
                    .Where(f => f.IsActive
                             && f.ScheduledInterview != null
                             && f.ScheduledInterview.InterviewerEmployeeId == employeeId.Value)
                    .OrderByDescending(f => f.SubmittedOn)
                    .Select(f => new MyInterviewHistoryItemViewModel
                    {
                        ScheduledInterviewId = f.ScheduledInterviewId,
                        CandidateName = f.ScheduledInterview!.Applicant != null ? (f.ScheduledInterview.Applicant.FirstName + " " + (f.ScheduledInterview.Applicant.LastName ?? "")).Trim() : "",
                        MprTitle = f.ScheduledInterview.Applicant != null && f.ScheduledInterview.Applicant.ManpowerRequest != null ? f.ScheduledInterview.Applicant.ManpowerRequest.JobTitle : "",
                        RoundTypeName = f.ScheduledInterview.RoundType != null ? f.ScheduledInterview.RoundType.RoundTypeName : "",
                        SlotDateTime = f.ScheduledInterview.AvailabilitySlot != null ? f.ScheduledInterview.AvailabilitySlot.SlotDateTime : default,
                        SkillRating = f.SkillRating,
                        CommunicationRating = f.CommunicationRating,
                        CultureFitRating = f.CultureFitRating,
                        OverallRecommendation = f.OverallRecommendation,
                        Notes = f.Notes,
                        SubmittedOn = f.SubmittedOn
                    })
                    .ToListAsync();

                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitInterviewFeedback([FromBody] SubmitInterviewFeedbackDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                if (string.IsNullOrWhiteSpace(dto.Notes))
                    return Json(new { success = false, message = "Please provide notes explaining your recommendation." });

                var validRecs = new[] { RecommendationOptions.StrongYes, RecommendationOptions.Yes, RecommendationOptions.No, RecommendationOptions.StrongNo };
                if (!validRecs.Contains(dto.OverallRecommendation))
                    return Json(new { success = false, message = "Invalid recommendation." });

                var scheduled = await _context.ScheduledInterviews
                    .Include(x => x.Applicant)
                    .FirstOrDefaultAsync(x => x.ScheduledInterviewId == dto.ScheduledInterviewId
                                            && x.InterviewerEmployeeId == employeeId.Value
                                            && x.IsActive);

                if (scheduled == null)
                    return Json(new { success = false, message = "Scheduled interview not found." });

                if (scheduled.Status != ScheduledInterviewStatus.Scheduled)
                    return Json(new { success = false, message = "Feedback has already been submitted for this interview." });

                var alreadyExists = await _context.InterviewFeedbacks
                    .AnyAsync(f => f.ScheduledInterviewId == dto.ScheduledInterviewId && f.IsActive);

                if (alreadyExists)
                    return Json(new { success = false, message = "Feedback already submitted for this interview." });

                _context.InterviewFeedbacks.Add(new InterviewFeedback
                {
                    ScheduledInterviewId = dto.ScheduledInterviewId,
                    SkillRating = dto.SkillRating,
                    CommunicationRating = dto.CommunicationRating,
                    CultureFitRating = dto.CultureFitRating,
                    OverallRecommendation = dto.OverallRecommendation,
                    Notes = dto.Notes,
                    SubmittedOn = DateTime.Now,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = employeeId
                });

                scheduled.Status = ScheduledInterviewStatus.Completed;

                // A clear "No" is safe to auto-apply — reject immediately.
                // A "Yes" only marks the round complete; HR advances the stage manually.
                if (dto.OverallRecommendation == RecommendationOptions.No || dto.OverallRecommendation == RecommendationOptions.StrongNo)
                {
                    if (scheduled.Applicant != null)
                    {
                        scheduled.Applicant.CurrentStage = ApplicantStages.Rejected;
                        scheduled.Applicant.StageChangedOn = DateTime.Now;
                        scheduled.Applicant.RejectReason = "Failed interview";
                        scheduled.Applicant.RejectNotes = dto.Notes;
                        scheduled.Applicant.ModifiedOn = DateTime.Now;
                        scheduled.Applicant.ModifiedBy = employeeId;
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, message = "Feedback submitted successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}