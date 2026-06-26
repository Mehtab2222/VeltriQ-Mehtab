namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class OnboardingCandidateItemViewModel
    {
        public int OnboardingCandidateId { get; set; }

        public bool IsSelected { get; set; }

        public string CandidateCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string EmploymentType { get; set; } = string.Empty;

        public string? JobProfile { get; set; }

        public string? ManpowerRequestCode { get; set; }

        public DateTime? ExpectedJoiningDate { get; set; }
    }
}