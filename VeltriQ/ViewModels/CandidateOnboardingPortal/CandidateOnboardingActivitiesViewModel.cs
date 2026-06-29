namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingActivitiesViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public List<ActivityViewModel> Activities { get; set; } = new();
    }

    public class ActivityViewModel
    {
        public int EmployeeOnboardingActivityId { get; set; }

        public string ActivityName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedOn { get; set; }

        public string? ActivityOwner { get; set; }
    }
}