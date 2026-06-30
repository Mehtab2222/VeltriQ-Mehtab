using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Services.HR.Onboarding
{
    public class OnboardingWorkspaceService
        : IOnboardingWorkspaceService
    {
        private readonly TenantDbContext _context;

        public OnboardingWorkspaceService(
            TenantDbContext context)
        {
            _context = context;
        }

        public async Task LoadHeader
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
        public async Task LoadCandidateHeaderState(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId)
        {
            var onboarding = await _context.EmployeeOnboardings
                .Include(x => x.OnboardingStatus)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding == null)
                return;

            model.StatusName = onboarding.OnboardingStatus?.StatusName ?? "";

            model.StatusCode = onboarding.OnboardingStatus?.StatusCode ?? "";

            model.IsPortalLocked = onboarding.IsPortalLocked;

            model.CanSubmit =
                onboarding.CompletionPercentage == 100 &&
                !onboarding.IsPortalLocked &&
                (
                    onboarding.OnboardingStatus?.StatusCode == "INPROGRESS" ||
                    onboarding.OnboardingStatus?.StatusCode == "CORRECTION"
                );
        }
        public async Task LoadOverview(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId)
        {
            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(employeeOnboardingId);

            //====================================================
            // LOAD COMPLETION PERCENTAGE
            //====================================================

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding != null)
            {
                model.CompletionPercentage = onboarding.CompletionPercentage;
            }

            //====================================================
            // INFORMATION SECTIONS
            //====================================================

            model.TotalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);

            //====================================================
            // DOCUMENTS
            //====================================================

            model.TotalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.UploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsUploaded);

            //====================================================
            // POLICIES
            //====================================================

            model.TotalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.AcceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsAccepted);
        }
        public async Task<decimal> CalculateCompletionPercentage(int employeeOnboardingId)
        {
            decimal completed = 0;

            //====================================================
            // PERSONAL INFORMATION (30%)
            //====================================================

            var personal = await _context.EmployeeOnboardingPersonalInformations
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (personal != null &&
                !string.IsNullOrWhiteSpace(personal.FirstName) &&
                !string.IsNullOrWhiteSpace(personal.LastName) &&
                personal.DateOfBirth != null &&
                !string.IsNullOrWhiteSpace(personal.Email) &&
                !string.IsNullOrWhiteSpace(personal.MobileNumber))
            {
                completed += 30;
            }

            //====================================================
            // ADDRESS (20%)
            //====================================================

            var address = await _context.EmployeeOnboardingAddresses
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (address != null &&
                !string.IsNullOrWhiteSpace(address.CurrentAddressLine1) &&
                !string.IsNullOrWhiteSpace(address.CurrentCity) &&
                !string.IsNullOrWhiteSpace(address.CurrentState) &&
                !string.IsNullOrWhiteSpace(address.CurrentCountry) &&
                !string.IsNullOrWhiteSpace(address.CurrentPincode))
            {
                completed += 20;
            }

            //====================================================
            // EMERGENCY CONTACT (10%)
            //====================================================

            var emergency = await _context.EmployeeOnboardingEmergencyContacts
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (emergency != null &&
                !string.IsNullOrWhiteSpace(emergency.ContactPersonName) &&
                !string.IsNullOrWhiteSpace(emergency.Relationship) &&
                !string.IsNullOrWhiteSpace(emergency.MobileNumber))
            {
                completed += 10;
            }

            //====================================================
            // MANDATORY DOCUMENTS (30%)
            //====================================================

            var totalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory);

            var uploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory &&
                    x.IsUploaded);

            if (totalDocuments > 0 &&
                totalDocuments == uploadedDocuments)
            {
                completed += 30;
            }

            //====================================================
            // MANDATORY POLICIES (10%)
            //====================================================

            var totalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory);

            var acceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory &&
                    x.IsAccepted);

            if (totalPolicies > 0 &&
                totalPolicies == acceptedPolicies)
            {
                completed += 10;
            }

            return completed;
        }
        public async Task UpdateCompletionPercentage(int employeeOnboardingId)
        {
            var percentage = await CalculateCompletionPercentage(employeeOnboardingId);

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding != null)
            {
                onboarding.CompletionPercentage = percentage;
                onboarding.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }

        public async Task LoadInformationSidebar
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

        public async Task LoadDocuments(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId)
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

                    IsUploaded = x.IsUploaded,

                    IsVerified = x.IsVerified,

                    UploadedOn = x.UploadedOn
                })
                .ToListAsync();
        }
        public async Task<CandidateOnboardingPoliciesViewModel> LoadPolicies(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingPoliciesViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Policies = await _context.EmployeeOnboardingPolicies
                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new PolicyViewModel
                {
                    EmployeeOnboardingPolicyId = x.EmployeeOnboardingPolicyId,

                    PolicyName = x.Policy.PolicyName,

                    IsMandatory = x.IsMandatory,

                    IsAccepted = x.IsAccepted,

                    AcceptedOn = x.AcceptedOn,

                    AllowDownload = x.Policy.AllowDownload
                })
                .ToListAsync();

            return model;
        }
        public async Task<CandidateOnboardingQualificationsViewModel> LoadQualifications(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingQualificationsViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Qualifications = await _context.EmployeeOnboardingQualifications
                .Where(x => x.EmployeeOnboardingId == employeeOnboardingId && x.IsActive)
                .OrderBy(x => x.EmployeeOnboardingQualificationId)
                .Select(x => new QualificationViewModel
                {
                    EmployeeOnboardingQualificationId = x.EmployeeOnboardingQualificationId,
                    QualificationName = x.QualificationName,
                    Institute = x.Institute,
                    PassingYear = x.PassingYear,
                    Percentage = x.Percentage
                })
                .ToListAsync();

            return model;
        }
        public async Task<CandidateOnboardingDependentsViewModel> LoadDependents(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingDependentsViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Dependents = await _context.EmployeeOnboardingDependents
                .Where(x => x.EmployeeOnboardingId == employeeOnboardingId && x.IsActive)
                .OrderBy(x => x.EmployeeOnboardingDependentId)
                .Select(x => new DependentViewModel
                {
                    EmployeeOnboardingDependentId = x.EmployeeOnboardingDependentId,
                    FullName = x.FullName,
                    Relationship = x.Relationship,
                    DateOfBirth = x.DateOfBirth,
                    IsNominee = x.IsNominee
                })
                .ToListAsync();

            return model;
        }
        public async Task<CandidateOnboardingEmergencyContactViewModel> LoadEmergencyContact(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingEmergencyContactViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            var entity = await _context.EmployeeOnboardingEmergencyContacts
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
                return model;

            model.EmployeeOnboardingEmergencyContactId = entity.EmployeeOnboardingEmergencyContactId;
            model.ContactPersonName = entity.ContactPersonName;
            model.Relationship = entity.Relationship;
            model.MobileNumber = entity.MobileNumber;
            model.AlternateMobileNumber = entity.AlternateMobileNumber;
            model.Address = entity.Address;

            return model;
        }
        public async Task<CandidateOnboardingAddressViewModel> LoadAddress(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingAddressViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            var entity = await _context.EmployeeOnboardingAddresses
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
                return model;

            model.EmployeeOnboardingAddressId = entity.EmployeeOnboardingAddressId;

            //====================================================
            // CURRENT ADDRESS
            //====================================================

            model.CurrentAddressLine1 = entity.CurrentAddressLine1;
            model.CurrentAddressLine2 = entity.CurrentAddressLine2;
            model.CurrentLandmark = entity.CurrentLandmark;
            model.CurrentCity = entity.CurrentCity;
            model.CurrentState = entity.CurrentState;
            model.CurrentCountry = entity.CurrentCountry;
            model.CurrentPostalCode = entity.CurrentPincode;

            //====================================================
            // PERMANENT ADDRESS
            //====================================================

            model.IsPermanentAddressSame = entity.IsPermanentAddressSame;

            model.PermanentAddressLine1 = entity.PermanentAddressLine1;
            model.PermanentAddressLine2 = entity.PermanentAddressLine2;
            model.PermanentLandmark = entity.PermanentLandmark;
            model.PermanentCity = entity.PermanentCity;
            model.PermanentState = entity.PermanentState;
            model.PermanentCountry = entity.PermanentCountry;
            model.PermanentPostalCode = entity.PermanentPincode;

            return model;
        }
        public async Task<CandidateOnboardingPersonalInformationViewModel> LoadPersonalInformation(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingPersonalInformationViewModel();

            var entity = await _context.EmployeeOnboardingPersonalInformations
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
            {
                model.EmployeeOnboardingId = employeeOnboardingId;
                return model;
            }

            model.EmployeeOnboardingPersonalInformationId = entity.EmployeeOnboardingPersonalInformationId;
            model.EmployeeOnboardingId = entity.EmployeeOnboardingId;

            model.FirstName = entity.FirstName;
            model.MiddleName = entity.MiddleName;
            model.LastName = entity.LastName;

            model.DateOfBirth = entity.DateOfBirth;

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
        public async Task LoadHeader(
    EmployeeOnboardingDetailsViewModel model,
    int employeeOnboardingId)
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

            model.AssignedOn = onboarding.AssignedOn;
        }
        public async Task LoadOverview(
    EmployeeOnboardingDetailsViewModel model,
    int employeeOnboardingId)
        {
            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(employeeOnboardingId);

            //====================================================
            // LOAD COMPLETION PERCENTAGE
            //====================================================

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding != null)
            {
                model.CompletionPercentage = onboarding.CompletionPercentage;
            }

            //====================================================
            // INFORMATION SECTIONS
            //====================================================

            model.TotalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);

            //====================================================
            // DOCUMENTS
            //====================================================

            model.TotalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.UploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsUploaded);

            //====================================================
            // POLICIES
            //====================================================

            model.TotalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.AcceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsAccepted);
        }
        public async Task LoadDocuments(
    EmployeeOnboardingDetailsViewModel model,
    int employeeOnboardingId)
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

                    IsUploaded = x.IsUploaded,

                    IsVerified = x.IsVerified,

                    UploadedOn = x.UploadedOn
                })
                .ToListAsync();
        }

    }
}