using System.Collections.Generic;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingIndexViewModel
    {
        //====================================================
        // HEADER
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        public int OnboardingCandidateId { get; set; }

        public string CandidateName { get; set; } = string.Empty;

        public string CandidateCode { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string EmploymentType { get; set; } = string.Empty;
        public CandidateOnboardingPoliciesViewModel Policies { get; set; }
        public DateTime? ExpectedJoiningDate { get; set; }
        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string TemplateName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int CompletedSections { get; set; }

        public int TotalSections { get; set; }

        public int UploadedDocuments { get; set; }

        public int TotalDocuments { get; set; }

        public int AcceptedPolicies { get; set; }

        public int TotalPolicies { get; set; }

        public decimal CompletionPercentage { get; set; }
        public List<EmployeeOnboardingDocumentViewModel> DocumentsList { get; set; }
    = new();

        public List<EmployeeOnboardingPolicyViewModel> PoliciesList { get; set; }
            = new();

        public bool CanSubmit { get; set; }

        public bool IsPortalLocked { get; set; }

        public string StatusCode { get; set; } = "";

        public string StatusName { get; set; } = "";

        //====================================================
        // LEFT SIDEBAR
        //====================================================

        public List<CandidateOnboardingSectionViewModel> Sections { get; set; }
            = new();

        //====================================================
        // DEFAULT SECTION
        //====================================================

        public string SelectedSection { get; set; } = "Personal Information";
        public List<ActivityViewModel> ActivitiesList { get; set; } = new();
    }
}