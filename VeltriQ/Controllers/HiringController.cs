using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.ViewModels.Recruitment;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class HiringController : BaseController
    {
        private readonly TenantDbContext _context;

        public HiringController(
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
        public async Task<IActionResult> GetStageCounts(int? manpowerRequestId)
        {
            try
            {
                var query = _context.Applicants.Where(x => x.IsActive).AsQueryable();
                if (manpowerRequestId.HasValue)
                    query = query.Where(x => x.ManpowerRequestId == manpowerRequestId.Value);

                var counts = await query
                    .GroupBy(x => x.CurrentStage)
                    .Select(g => new { Stage = g.Key, Count = g.Count() })
                    .ToListAsync();

                return Json(new { success = true, data = counts });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidatesByStage(string stage, int? manpowerRequestId, string? search)
        {
            try
            {
                var query = _context.Applicants
                    .Include(x => x.ManpowerRequest)
                    .Where(x => x.IsActive && x.CurrentStage == stage)
                    .AsQueryable();

                if (manpowerRequestId.HasValue)
                {
                    query = query.Where(x => x.ManpowerRequestId == manpowerRequestId.Value);
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var s = search.ToLower();

                    query = query.Where(x =>
                        x.FirstName.ToLower().Contains(s) ||
                        (x.LastName != null && x.LastName.ToLower().Contains(s)));
                }

                var today = DateTime.Now.Date;

                var rawList = await query
                    .OrderByDescending(x => x.StageChangedOn)
                    .ToListAsync();

                // Get Hiring Manager UserIds
                var managerUserIds = rawList
                    .Where(x => x.ManpowerRequest != null &&
                                !string.IsNullOrEmpty(x.ManpowerRequest.HiringManagerId))
                    .Select(x => x.ManpowerRequest!.HiringManagerId!)
                    .Distinct()
                    .ToList();

                // Get Employee Names using UserId
                var managerEmployees = await _context.Employees
                    .Where(e => managerUserIds.Contains(e.UserId))
                    .Select(e => new
                    {
                        e.UserId,
                        e.FirstName,
                        e.LastName
                    })
                    .ToListAsync();

                var managers = managerEmployees.ToDictionary(
                    e => e.UserId!,
                    e => (e.FirstName + " " + (e.LastName ?? "")).Trim());

                var data = rawList.Select(x => new HiringCandidateViewModel
                {
                    ApplicantId = x.ApplicantId,
                    ApplicantCode = x.ApplicantCode,
                    FullName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                    Email = x.Email,
                    MprCode = x.ManpowerRequest?.RequestCode ?? "",
                    MprTitle = x.ManpowerRequest?.JobTitle ?? "",
                    MatchPercentage = x.MatchPercentage,
                    TotalExperience = x.TotalExperience,
                    AppliedOn = x.AppliedOn,
                    CurrentStage = x.CurrentStage,
                    DaysInStage = (today - x.StageChangedOn.Date).Days,

                    HiringManagerName =
                        x.ManpowerRequest != null &&
                        !string.IsNullOrEmpty(x.ManpowerRequest.HiringManagerId) &&
                        managers.ContainsKey(x.ManpowerRequest.HiringManagerId)
                            ? managers[x.ManpowerRequest.HiringManagerId]
                            : "—"
                }).ToList();

                return Json(new
                {
                    success = true,
                    data
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
        public class UpdateApplicantStageDto
        {
            public List<int> ApplicantIds { get; set; } = new();
            public string NewStage { get; set; } = string.Empty;
            public string? RejectReason { get; set; }
            public string? RejectNotes { get; set; }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateApplicantStage([FromBody] UpdateApplicantStageDto dto)
        {
            try
            {
                if (dto.ApplicantIds == null || !dto.ApplicantIds.Any())
                    return Json(new { success = false, message = "No candidates selected." });

                var validStages = new[] { "New", "Screening", "Evaluating", "Offered", "Hired", "Rejected", "Dropout" };
                if (!validStages.Contains(dto.NewStage))
                    return Json(new { success = false, message = "Invalid stage." });

                var applicants = await _context.Applicants
                    .Where(x => dto.ApplicantIds.Contains(x.ApplicantId) && x.IsActive)
                    .ToListAsync();

                if (!applicants.Any())
                    return Json(new { success = false, message = "No matching applicants found." });

                var currentEmployeeId = GetCurrentEmployeeId();

                foreach (var applicant in applicants)
                {
                    applicant.CurrentStage = dto.NewStage;
                    applicant.StageChangedOn = DateTime.Now;
                    applicant.ModifiedOn = DateTime.Now;
                    applicant.ModifiedBy = currentEmployeeId;

                    if (dto.NewStage == "Rejected")
                    {
                        applicant.RejectReason = dto.RejectReason;
                        applicant.RejectNotes = dto.RejectNotes;
                    }
                }

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = $"{applicants.Count} candidate(s) moved to \"{dto.NewStage}\" successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}