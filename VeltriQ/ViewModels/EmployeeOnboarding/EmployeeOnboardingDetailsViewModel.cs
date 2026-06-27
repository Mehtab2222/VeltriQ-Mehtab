namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingDetailsViewModel
    {
        //====================================================
        // HEADER
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        public int OnboardingCandidateId { get; set; }

        public string CandidateCode { get; set; } = "";

        public string CandidateName { get; set; } = "";

        public string Email { get; set; } = "";

        public string MobileNumber { get; set; } = "";

        public string Department { get; set; } = "";

        public string Designation { get; set; } = "";

        public string EmploymentType { get; set; } = "";

        public string TemplateName { get; set; } = "";

        public string Status { get; set; } = "";

        public decimal CompletionPercentage { get; set; }

        public DateTime AssignedOn { get; set; }

        public DateTime? ExpectedJoiningDate { get; set; }

        //====================================================
        // OVERVIEW
        //====================================================

        public int TotalSections { get; set; }

        public int CompletedSections { get; set; }

        public int TotalDocuments { get; set; }

        public int UploadedDocuments { get; set; }

        public int TotalPolicies { get; set; }

        public int AcceptedPolicies { get; set; }

        public int TotalActivities { get; set; }

        public int CompletedActivities { get; set; }

        //====================================================
        // TAB COLLECTIONS
        //====================================================

        public List<EmployeeOnboardingSectionViewModel> Sections { get; set; }
            = new();

        public List<EmployeeOnboardingDocumentViewModel> DocumentsList { get; set; }
            = new();

        public List<EmployeeOnboardingPolicyViewModel> PoliciesList { get; set; }
            = new();

        public List<EmployeeOnboardingActivityViewModel> ActivitiesList { get; set; }
            = new();

        public List<EmployeeOnboardingTimelineViewModel> TimelineList { get; set; }
            = new();
    }
}