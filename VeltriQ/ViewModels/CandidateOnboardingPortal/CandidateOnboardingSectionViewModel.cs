namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingSectionViewModel
    {
        public int EmployeeOnboardingSectionId { get; set; }

        public int OnboardingSectionMasterId { get; set; }

        public string SectionName { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        public string Icon { get; set; } = string.Empty;
    }
}