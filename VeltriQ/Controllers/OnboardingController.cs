using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.Services.HR.Onboarding;
using VeltriQ.ViewModels.EmployeeOnboarding;
using VeltriQ.ViewModels.EmployeeOnboarding.Requests;


namespace VeltriQ.Controllers
{
    public class OnboardingController : BaseController
    {
        private readonly TenantDbContext _context;
        private readonly IOnboardingWorkspaceService _workspaceService;

        public OnboardingController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager,
            IOnboardingWorkspaceService workspaceService)
            : base(context, masterContext, userManager)
        {
            _context = context;
            _workspaceService = workspaceService;
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


        [HttpGet]
        public async Task<IActionResult> InitiateOnboarding()
        {
            var model = new InitiateOnboardingViewModel();

            await LoadDropdowns(model);

            await LoadCandidates(model);

            return View(model);
        }
        private async Task CopySections
(
    int employeeOnboardingId,
    int onboardingTemplateId
)
        {
            var templateSections = await _context.OnboardingTemplateSections

                .Where(x =>
                    x.OnboardingTemplateId == onboardingTemplateId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .ToListAsync();

            if (!templateSections.Any())
                return;

            var employeeSections = templateSections.Select(x =>
                new EmployeeOnboardingSection
                {
                    EmployeeOnboardingId = employeeOnboardingId,

                    OnboardingSectionMasterId = x.OnboardingSectionMasterId,

                    IsMandatory = x.IsMandatory,

                    DisplayOrder = x.DisplayOrder,

                    IsCompleted = false,

                    IsActive = true,

                    CreatedOn = DateTime.Now
                });

            await _context.EmployeeOnboardingSections.AddRangeAsync(employeeSections);
        }
        private async Task CopyDocuments
(
    int employeeOnboardingId,
    int onboardingTemplateId
)
        {
            var templateDocuments = await _context.OnboardingTemplateDocuments

                .Where(x =>
                    x.OnboardingTemplateId == onboardingTemplateId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .ToListAsync();

            if (!templateDocuments.Any())
                return;

            var employeeDocuments = templateDocuments.Select(x =>
                new EmployeeOnboardingDocument
                {
                    EmployeeOnboardingId = employeeOnboardingId,

                    OnboardingDocumentMasterId = x.OnboardingDocumentMasterId,

                    IsMandatory = x.IsMandatory,

                    DisplayOrder = x.DisplayOrder,

                    IsUploaded = false,

                    IsVerified = false,

                    IsActive = true,

                    CreatedOn = DateTime.Now
                });

            await _context.EmployeeOnboardingDocuments.AddRangeAsync(employeeDocuments);
        }
        private async Task CopyPolicies
(
    int employeeOnboardingId,
    int onboardingTemplateId
)
        {
            var templatePolicies = await _context.OnboardingTemplatePolicies

                .Where(x =>
                    x.OnboardingTemplateId == onboardingTemplateId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .ToListAsync();

            if (!templatePolicies.Any())
                return;

            var employeePolicies = templatePolicies.Select(x =>
                new EmployeeOnboardingPolicy
                {
                    EmployeeOnboardingId = employeeOnboardingId,

                    OnboardingPolicyMasterId = x.OnboardingPolicyMasterId,

                    IsMandatory = x.IsMandatory,

                    DisplayOrder = x.DisplayOrder,

                    IsAccepted = false,

                    IsActive = true,

                    CreatedOn = DateTime.Now
                });

            await _context.EmployeeOnboardingPolicies.AddRangeAsync(employeePolicies);
        }
        private async Task CopyActivities
            (
                int employeeOnboardingId,
                int onboardingTemplateId
            )
        {
            var templateActivities = await _context.OnboardingTemplateActivities

                .Where(x =>
                    x.OnboardingTemplateId == onboardingTemplateId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .ToListAsync();

            if (!templateActivities.Any())
                return;

            var employeeActivities = templateActivities.Select(x =>
                new EmployeeOnboardingActivity
                {
                    EmployeeOnboardingId = employeeOnboardingId,

                    OnboardingActivityMasterId = x.OnboardingActivityMasterId,

                    DisplayOrder = x.DisplayOrder,

                    IsCompleted = false,

                    IsActive = true,

                    CreatedOn = DateTime.Now
                });

            await _context.EmployeeOnboardingActivities.AddRangeAsync(employeeActivities);
        }
        private async Task GenerateOnboardingPipeline(EmployeeOnboarding onboarding)
        {
            await CopySections(
                onboarding.EmployeeOnboardingId,
                onboarding.OnboardingTemplateId);

            await CopyDocuments(
                onboarding.EmployeeOnboardingId,
                onboarding.OnboardingTemplateId);

            await CopyPolicies(
                onboarding.EmployeeOnboardingId,
                onboarding.OnboardingTemplateId);

            await CopyActivities(
                onboarding.EmployeeOnboardingId,
                onboarding.OnboardingTemplateId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateOnboarding(InitiateOnboardingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);
                await LoadCandidates(model);
                return View(model);
            }

            var selectedCandidates = model.Candidates
                .Where(x => x.IsSelected)
                .ToList();

            if (!selectedCandidates.Any())
            {
                ModelState.AddModelError("", "Please select at least one candidate.");

                await LoadDropdowns(model);
                await LoadCandidates(model);

                return View(model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var candidate in selectedCandidates)
                {
                    bool alreadyExists = await _context.EmployeeOnboardings
                        .AnyAsync(x =>
                            x.OnboardingCandidateId == candidate.OnboardingCandidateId &&
                            x.IsActive);

                    if (alreadyExists)
                        continue;

                    var onboarding = new EmployeeOnboarding
                    {
                        OnboardingCandidateId = candidate.OnboardingCandidateId,
                        OnboardingTemplateId = model.OnboardingTemplateId,
                        OnboardingStatusMasterId = 2, // INVITED
                        AssignedOn = DateTime.Now,
                        CompletionPercentage = 0,
                        IsActive = true,
                        CreatedOn = DateTime.Now
                    };

                    // Create parent record
                    _context.EmployeeOnboardings.Add(onboarding);

                    // Save immediately to generate EmployeeOnboardingId
                    await _context.SaveChangesAsync();

                    // Copy template sections
                    await GenerateOnboardingPipeline(onboarding);
                    //============================================================
                    // Create Candidate Portal Invitation
                    //============================================================

                    var invitation = new OnboardingCandidateInvitation
                    {
                        OnboardingCandidateId = onboarding.OnboardingCandidateId,

                        EmployeeOnboardingId = onboarding.EmployeeOnboardingId,

                        InvitationToken = Guid.NewGuid().ToString(),

                        InvitedOn = DateTime.Now,

                        ExpiryDate = DateTime.Now.AddDays(7),

                        InvitationCount = 1,

                        IsInvitationAccepted = false,

                        IsPortalAccessEnabled = true,

                        IsActive = true,

                        CreatedOn = DateTime.Now
                    };

                    _context.OnboardingCandidateInvitations.Add(invitation);

                    // Update candidate status
                    var onboardingCandidate = await _context.OnboardingCandidates
                        .FirstOrDefaultAsync(x =>
                            x.OnboardingCandidateId == candidate.OnboardingCandidateId);

                    if (onboardingCandidate != null)
                    {
                        onboardingCandidate.OnboardingStatusMasterId = 2; // INVITED
                    }
                }

                // Save copied sections and candidate status changes
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                TempData["Success"] = "Onboarding initiated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #endregion

        #region Private Methods

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
        public async Task<IActionResult> Details(int id)
        {
            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x => x.EmployeeOnboardingId == id);

            if (onboarding == null)
                return NotFound();

            var model = new EmployeeOnboardingDetailsViewModel();

            //====================================================
            // HEADER
            //====================================================

            await _workspaceService.LoadHeader(model, id);

            //====================================================
            // OVERVIEW
            //====================================================

            await _workspaceService.LoadOverview(model, id);

            //====================================================
            // INFORMATION
            //====================================================

            model.PersonalInformation =
                await _workspaceService.LoadPersonalInformation(id);

            model.Address =
                await _workspaceService.LoadAddress(id);

            model.EmergencyContact =
                await _workspaceService.LoadEmergencyContact(id);

            model.Dependents =
                await _workspaceService.LoadDependents(id);

            model.Qualifications =
                await _workspaceService.LoadQualifications(id);

            //====================================================
            // DOCUMENTS
            //====================================================

            await _workspaceService.LoadDocuments(model, id);

            //====================================================
            // POLICIES
            //====================================================

            //====================================================
            // POLICIES
            //====================================================

            await _workspaceService.LoadPolicies(model, id);

            return View(model);
        }

        #endregion
        [HttpPost]
        public async Task<IActionResult> ApproveDocument(
    [FromBody] ApproveDocumentRequest request)
        {

            var document = await _context.EmployeeOnboardingDocuments
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingDocumentId == request.Id);
            return Json(new
{
    success = true,
    message = "RejectDocument action reached."
});

            if (document == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Document not found."
                });
            }

            document.IsVerified = true;

            document.VerifiedOn = DateTime.Now;

            document.VerifiedBy = User.Identity?.Name;

            document.Remarks = null;

            document.ModifiedOn = DateTime.Now;

            document.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Document verified successfully."
            });
        }
        [HttpPost]
        public async Task<IActionResult> RejectDocument(
    [FromBody] RejectDocumentRequest request)
        {
            var document = await _context.EmployeeOnboardingDocuments
                .Include(x => x.EmployeeOnboarding)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingDocumentId == request.Id);

            if (document == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Document not found."
                });
            }

            //=========================================
            // DOCUMENT STATUS
            //=========================================

            document.IsVerified = false;
            document.VerifiedOn = null;
            document.VerifiedBy = null;
            document.Remarks = request.Remarks;

            document.ModifiedOn = DateTime.Now;
            document.ModifiedBy = User.Identity?.Name;

            //=========================================
            // UNLOCK CANDIDATE PORTAL
            //=========================================
            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == document.EmployeeOnboardingId);

            if (onboarding != null)
            {
                onboarding.IsPortalLocked = false;

                onboarding.OnboardingStatusMasterId = 6; // CORRECTION

                onboarding.ModifiedOn = DateTime.Now;
                onboarding.ModifiedBy = User.Identity?.Name;
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Document rejected successfully."
            });
        }
    }
}