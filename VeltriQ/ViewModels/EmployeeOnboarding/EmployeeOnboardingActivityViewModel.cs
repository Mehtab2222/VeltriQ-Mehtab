namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingActivityViewModel
    {
        public int EmployeeOnboardingActivityId { get; set; }

        public string ActivityName { get; set; } = "";

        public bool IsCompleted { get; set; }

        public DateTime? CompletedOn { get; set; }
    }
}