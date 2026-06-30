namespace VeltriQ.ViewModels.Shared
{
    public interface IOnboardingWorkspaceHeader
    {
        int EmployeeOnboardingId { get; set; }

        int OnboardingCandidateId { get; set; }

        string CandidateName { get; set; }

        string CandidateCode { get; set; }

        string Email { get; set; }

        string MobileNumber { get; set; }

        string Department { get; set; }

        string Designation { get; set; }

        string EmploymentType { get; set; }

        string TemplateName { get; set; }

        string Status { get; set; }

        decimal CompletionPercentage { get; set; }

        DateTime? ExpectedJoiningDate { get; set; }
    }
}