namespace VeltriQ.ViewModels.OnboardingPolicy
{
    public class OnboardingPolicyListItemViewModel
    {
        public int OnboardingPolicyMasterId { get; set; }

        public string PolicyName { get; set; } = "";

        public string Description { get; set; } = "";

        public string CategoryName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool AllowDownload { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
        public string PolicyVersion { get; set; } = "";

        public DateTime? EffectiveDate { get; set; }

        public bool RequiresAcceptance { get; set; }

        public string? FileName { get; set; }
    }
}