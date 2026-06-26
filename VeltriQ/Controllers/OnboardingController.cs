using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Controllers
{
    public class OnboardingController : BaseController
    {
        private readonly TenantDbContext _context;

        public OnboardingController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new EmployeeOnboardingDashboardViewModel();

            // Dashboard Cards
            model.Total = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive);

            model.Invited = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive &&
                                 x.OnboardingStatus.StatusCode == "INVITED");

            model.InProgress = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive &&
                                 x.OnboardingStatus.StatusCode == "INPROGRESS");

            model.Submitted = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive &&
                                 x.OnboardingStatus.StatusCode == "SUBMITTED");

            model.Approved = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive &&
                                 x.OnboardingStatus.StatusCode == "APPROVED");

            model.Converted = await _context.EmployeeOnboardings
                .CountAsync(x => x.IsActive &&
                                 x.OnboardingStatus.StatusCode == "CONVERTED");

            // Dashboard Grid
            model.Items = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Department)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Designation)

                .Include(x => x.OnboardingTemplate)

                .Include(x => x.OnboardingStatus)

                .OrderByDescending(x => x.CreatedOn)

                .Select(x => new EmployeeOnboardingDashboardItemViewModel
                {
                    EmployeeOnboardingId = x.EmployeeOnboardingId,

                    CandidateName = x.OnboardingCandidate.FullName,

                    Email = x.OnboardingCandidate.Email,

                    Department = x.OnboardingCandidate.Department.DepartmentName,

                    Designation = x.OnboardingCandidate.Designation.DesignationName,

                    Template = x.OnboardingTemplate.TemplateName,

                    Status = x.OnboardingStatus.StatusName,

                    AssignedOn = x.AssignedOn,

                    Completion = x.CompletionPercentage
                })

                .ToListAsync();

            return View(model);
        }

        #region Initiate Onboarding

        //============================================================
        // INDEX
        //============================================================

        [HttpGet]
        public async Task<IActionResult> InitiateOnboarding()
        {
            var model = new InitiateOnboardingViewModel();

            await LoadDropdowns(model);

            await LoadCandidates(model);

            return View(model);
        }

        //============================================================
        // POST
        //============================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateOnboarding
        (
            InitiateOnboardingViewModel model
        )
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);

                await LoadCandidates(model);

                return View(model);
            }

            // We will implement the onboarding generation logic next.

            TempData["Success"] = "Selected candidates have been initiated successfully.";

            return RedirectToAction(nameof(InitiateOnboarding));
        }

        #endregion

        #region Private Methods

        //------------------------------------------------------------
        // Load Templates
        //------------------------------------------------------------

        private async Task LoadDropdowns
        (
            InitiateOnboardingViewModel model
        )
        {
            model.Templates = await _context
                .OnboardingTemplates
                .Where(x => x.IsActive && x.IsPublished)
                .OrderBy(x => x.TemplateName)
                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingTemplateId.ToString(),

                    Text = x.TemplateName
                })
                .ToListAsync();
        }

        //------------------------------------------------------------
        // Load Candidates
        //------------------------------------------------------------

        private async Task LoadCandidates
(
    InitiateOnboardingViewModel model
)
        {
            model.Candidates = await _context
                .OnboardingCandidates

                .Include(x => x.Department)

                .Include(x => x.Designation)

                .Include(x => x.EmploymentType)

                .Include(x => x.Status)

                .Where(x =>
                    x.IsActive &&
                    x.Status.StatusCode == "APPROVED")

                .OrderBy(x => x.FullName)

                .Select(x => new OnboardingCandidateItemViewModel
                {
                    OnboardingCandidateId = x.OnboardingCandidateId,

                    IsSelected = false,

                    CandidateCode = x.CandidateCode,

                    FullName = x.FullName,

                    Email = x.Email,

                    MobileNumber = x.MobileNumber ?? string.Empty,

                    Nationality = string.Empty,   // We'll populate this after adding Nationality to OnboardingCandidate

                    Department = x.Department.DepartmentName,

                    Designation = x.Designation.DesignationName,

                    EmploymentType = x.EmploymentType.EmploymentTypeName,

                    JobProfile = x.JobProfile,

                    ManpowerRequestCode = x.ManpowerRequestCode,

                    ExpectedJoiningDate = x.ExpectedJoiningDate
                })

                .ToListAsync();
        }

        #endregion
    }
}