using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class ApplicantController : BaseController
    {
        private readonly TenantDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ApplicantController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicants(int? manpowerRequestId, string? stage, string? search)
        {
            try
            {
                var query = _context.Applicants
                    .Include(x => x.ManpowerRequest)
                    .Where(x => x.IsActive)
                    .AsQueryable();

                if (manpowerRequestId.HasValue)
                    query = query.Where(x => x.ManpowerRequestId == manpowerRequestId.Value);

                if (!string.IsNullOrWhiteSpace(stage))
                    query = query.Where(x => x.CurrentStage == stage);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var s = search.ToLower();
                    query = query.Where(x =>
                        x.FirstName.ToLower().Contains(s) ||
                        (x.LastName != null && x.LastName.ToLower().Contains(s)) ||
                        x.Email.ToLower().Contains(s));
                }

                var data = await query
                    .OrderByDescending(x => x.AppliedOn)
                    .Select(x => new ApplicantListItemViewModel
                    {
                        ApplicantId = x.ApplicantId,
                        ApplicantCode = x.ApplicantCode,
                        FullName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                        Email = x.Email,
                        Phone = x.Phone,
                        MprCode = x.ManpowerRequest != null ? x.ManpowerRequest.RequestCode : "",
                        MprTitle = x.ManpowerRequest != null ? x.ManpowerRequest.JobTitle : "",
                        MatchPercentage = x.MatchPercentage,
                        TotalExperience = x.TotalExperience,
                        AppliedOn = x.AppliedOn,
                        CurrentStage = x.CurrentStage,
                        SourceType = x.SourceType
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
        public async Task<IActionResult> GetManpowerRequestsForApplicant()
        {
            try
            {
                // Adjust the Where(...) clause to your actual "open" status field on ManpowerRequest
                var list = await _context.ManpowerRequests
                    .Where(x => x.IsActive)
                    .OrderByDescending(x => x.ManpowerRequestId)
                    .Select(x => new
                    {
                        x.ManpowerRequestId,
                        x.RequestCode,
                        x.JobTitle
                    })
                    .ToListAsync();

                return Json(new { success = true, data = list });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveApplicant(ApplicantCreateViewModel model)
        {
            // NOTE: this is bound from multipart/form-data (because of ResumeFile),
            // NOT JSON — so no [FromBody] here. The JS below uses FormData, not JSON.stringify.
            try
            {
                if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.Email))
                    return Json(new { success = false, message = "Name and email are required." });

                var mpr = await _context.ManpowerRequests
                    .FirstOrDefaultAsync(x => x.ManpowerRequestId == model.ManpowerRequestId && x.IsActive);

                if (mpr == null)
                    return Json(new { success = false, message = "Manpower request not found." });

                var currentEmployeeId = GetCurrentEmployeeId();

                string applicantCode = "APP0001";
                var last = await _context.Applicants.OrderByDescending(x => x.ApplicantId).FirstOrDefaultAsync();
                if (last != null)
                {
                    var num = int.Parse(last.ApplicantCode.Substring(3));
                    applicantCode = "APP" + (num + 1).ToString("D4");
                }

                string? resumePath = null;
                if (model.ResumeFile != null && model.ResumeFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "resumes");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = $"{applicantCode}_{Path.GetFileName(model.ResumeFile.FileName)}";
                    var fullPath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.ResumeFile.CopyToAsync(stream);
                    }

                    resumePath = $"/uploads/resumes/{fileName}";
                }

                var applicant = new Applicant
                {
                    ApplicantCode = applicantCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    ManpowerRequestId = model.ManpowerRequestId,
                    SourceType = model.SourceType,
                    TotalExperience = model.TotalExperience,
                    RelevantExperience = model.RelevantExperience,
                    MatchPercentage = model.MatchPercentage,
                    ResumePath = resumePath,
                    CurrentStage = ApplicantStages.New,
                    StageChangedOn = DateTime.Now,
                    AppliedOn = DateTime.Now,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = currentEmployeeId
                };

                _context.Applicants.Add(applicant);
                await _context.SaveChangesAsync();
                // Auto-shortlist: below-threshold applicants simply stay at "New" on the Applicant page.
                if (applicant.MatchPercentage.HasValue && applicant.MatchPercentage.Value >= ApplicantStages.ShortlistThresholdPercent)
                {
                    applicant.CurrentStage = ApplicantStages.Shortlisted;
                    applicant.StageChangedOn = DateTime.Now;
                    await _context.SaveChangesAsync();
                }

                return Json(new { success = true, message = "Applicant added successfully.", applicantId = applicant.ApplicantId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}