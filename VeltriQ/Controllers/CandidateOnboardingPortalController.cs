using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Controllers
{
    public class CandidateOnboardingPortalController
        : CandidateOnboardingBaseController
    {
        public CandidateOnboardingPortalController
        (
            TenantDbContext context
        )
            : base(context)
        {
        }
        private async Task<CandidateOnboardingPersonalInformationViewModel>
LoadPersonalInformation(int employeeOnboardingId)
        {
            var model =
                new CandidateOnboardingPersonalInformationViewModel();

            var entity =
                await _context.EmployeeOnboardingPersonalInformations
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeOnboardingId == employeeOnboardingId);

            if (entity == null)
            {
                model.EmployeeOnboardingId = employeeOnboardingId;

                return model;
            }

            model.EmployeeOnboardingPersonalInformationId =
                entity.EmployeeOnboardingPersonalInformationId;

            model.EmployeeOnboardingId =
                entity.EmployeeOnboardingId;

            model.FirstName =
                entity.FirstName;

            model.MiddleName =
                entity.MiddleName;

            model.LastName =
                entity.LastName;

            model.Gender = entity.Gender;

            model.MaritalStatus = entity.MaritalStatus;

            model.BloodGroup = entity.BloodGroup;

            model.Nationality = entity.Nationality;

            model.Religion = entity.Religion;

            model.FatherName = entity.FatherName;

            model.MotherName = entity.MotherName;

            model.Email = entity.Email;

            model.MobileNumber = entity.MobileNumber;

            model.AlternateMobileNumber = entity.AlternateMobileNumber;

            model.ProfilePhotoPath = entity.ProfilePhotoPath;
            return model;
        }
        //============================================================
        // LOGIN
        //============================================================

        [HttpGet]
        public async Task<IActionResult> Login(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return View("InvalidInvitation");
            }

            var invitation = await _context.OnboardingCandidateInvitations

                .Include(x => x.OnboardingCandidate)

                .Include(x => x.EmployeeOnboarding)

                .FirstOrDefaultAsync(x =>
                    x.InvitationToken == token);

            if (invitation == null)
            {
                return View("InvalidInvitation");
            }

            if (!invitation.IsActive)
            {
                return View("InvitationExpired");
            }

            if (!invitation.IsPortalAccessEnabled)
            {
                return View("InvitationExpired");
            }

            if (DateTime.Now > invitation.ExpiryDate)
            {
                return View("InvitationExpired");
            }

            //----------------------------------------------------
            // Create Candidate Session
            //----------------------------------------------------

            HttpContext.Session.SetInt32
            (
                "EmployeeOnboardingId",
                invitation.EmployeeOnboardingId
            );

            HttpContext.Session.SetInt32
            (
                "OnboardingCandidateId",
                invitation.OnboardingCandidateId
            );

            HttpContext.Session.SetInt32
            (
                "OnboardingCandidateInvitationId",
                invitation.OnboardingCandidateInvitationId
            );

            HttpContext.Session.SetString
            (
                "CandidateName",
                invitation.OnboardingCandidate?.FullName ?? ""
            );

            //----------------------------------------------------
            // First Login
            //----------------------------------------------------

            if (!invitation.IsInvitationAccepted)
            {
                invitation.IsInvitationAccepted = true;

                invitation.AcceptedOn = DateTime.Now;
            }

            invitation.LastLoginOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private async Task LoadInformationSidebar
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.Sections = await _context.EmployeeOnboardingSections

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new CandidateOnboardingSectionViewModel
                {
                    EmployeeOnboardingSectionId = x.EmployeeOnboardingSectionId,

                    OnboardingSectionMasterId = x.OnboardingSectionMasterId,

                    SectionName = x.Section.SectionName,

                    IsMandatory = x.IsMandatory,

                    IsCompleted = x.IsCompleted,

                    DisplayOrder = x.DisplayOrder,

                    Icon = ""
                })

                .ToListAsync();
        }
        private async Task LoadDocuments
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.DocumentsList = await _context.EmployeeOnboardingDocuments

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new EmployeeOnboardingDocumentViewModel
                {
                    EmployeeOnboardingDocumentId = x.EmployeeOnboardingDocumentId,

                    DocumentName = x.Document.DocumentName,

                    IsMandatory = x.IsMandatory,

                    IsUploaded = x.IsUploaded
                })

                .ToListAsync();
        }
        private async Task LoadPolicies
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.PoliciesList = await _context.EmployeeOnboardingPolicies

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new EmployeeOnboardingPolicyViewModel
                {
                    EmployeeOnboardingPolicyId = x.EmployeeOnboardingPolicyId,

                    PolicyName = x.Policy.PolicyName,

                    IsMandatory = x.IsMandatory,

                    IsAccepted = x.IsAccepted
                })

                .ToListAsync();
        }
        private async Task LoadOverview
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.TotalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);

            model.TotalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.UploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsUploaded);

            model.TotalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.AcceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsAccepted);

            model.TotalActivities = await _context.EmployeeOnboardingActivities
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedActivities = await _context.EmployeeOnboardingActivities
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);
        }
        private async Task LoadActivities
 (
     CandidateOnboardingIndexViewModel model,
     int employeeOnboardingId
 )
        {
            model.ActivitiesList = await _context.EmployeeOnboardingActivities

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new EmployeeOnboardingActivityViewModel
                {
                    EmployeeOnboardingActivityId = x.EmployeeOnboardingActivityId,

                    ActivityName = x.Activity.ActivityName,

                    IsCompleted = x.IsCompleted,

                    CompletedOn = x.CompletedOn
                })

                .ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeeOnboardingId =
                HttpContext.Session.GetInt32("EmployeeOnboardingId");

            if (employeeOnboardingId == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var model = new CandidateOnboardingIndexViewModel();

            await LoadHeader(model, employeeOnboardingId.Value);

            await LoadOverview(model, employeeOnboardingId.Value);

            await LoadInformationSidebar(model, employeeOnboardingId.Value);

            // We'll enable these later
            // await LoadDocuments(model, employeeOnboardingId.Value);
            // await LoadPolicies(model, employeeOnboardingId.Value);
            // await LoadActivities(model, employeeOnboardingId.Value);

            return View(model);
        }
        [HttpGet]
        public IActionResult LoadInformationSection(string section)
        {
            switch (section)
            {
                case "Personal Information":
                    return PartialView("Information/_PersonalInformation");

                case "Address":
                    return PartialView("Information/_Address");

                case "Education":
                    return PartialView("Information/_Education");

                case "Experience":
                    return PartialView("Information/_Experience");

                default:
                    return Content("Section not found.");
            }
        }
        private async Task LoadHeader
        (
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId
        )
        {
            var onboarding = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Department)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Designation)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.EmploymentType)

                .Include(x => x.OnboardingTemplate)

                .Include(x => x.OnboardingStatus)

                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding == null)
                return;

            var candidate = onboarding.OnboardingCandidate;

            model.EmployeeOnboardingId = onboarding.EmployeeOnboardingId;

            model.OnboardingCandidateId = onboarding.OnboardingCandidateId;

            model.CandidateName = candidate?.FullName ?? "";

            model.CandidateCode = candidate?.CandidateCode ?? "";

            model.Email = candidate?.Email ?? "";

            model.MobileNumber = candidate?.MobileNumber ?? "";

            model.Department = candidate?.Department?.DepartmentName ?? "";

            model.Designation = candidate?.Designation?.DesignationName ?? "";

            model.EmploymentType = candidate?.EmploymentType?.EmploymentTypeName ?? "";

            model.TemplateName = onboarding.OnboardingTemplate?.TemplateName ?? "";

            model.Status = onboarding.OnboardingStatus?.StatusName ?? "";

            model.ExpectedJoiningDate = candidate?.ExpectedJoiningDate;

            model.CompletionPercentage = onboarding.CompletionPercentage;
        }
        //============================================================
        // LOGOUT
        //============================================================

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("EmployeeOnboardingId");
            HttpContext.Session.Remove("OnboardingCandidateId");
            HttpContext.Session.Remove("OnboardingCandidateInvitationId");
            HttpContext.Session.Remove("CandidateName");

            return RedirectToAction(nameof(Login));
        }
    }
}