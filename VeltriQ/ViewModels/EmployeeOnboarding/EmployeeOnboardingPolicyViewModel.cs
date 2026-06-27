namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingPolicyViewModel
    {
        public int EmployeeOnboardingPolicyId { get; set; }

        public string PolicyName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime? AcceptedOn { get; set; }
    }
}