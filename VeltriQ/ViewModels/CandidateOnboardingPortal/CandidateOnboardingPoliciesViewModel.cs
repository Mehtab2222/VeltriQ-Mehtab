namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingPoliciesViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public List<PolicyViewModel> Policies { get; set; } = new();
    }

    public class PolicyViewModel
    {
        public int EmployeeOnboardingPolicyId { get; set; }

        public string PolicyName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime? AcceptedOn { get; set; }

        public bool AllowDownload { get; set; }
    }
}