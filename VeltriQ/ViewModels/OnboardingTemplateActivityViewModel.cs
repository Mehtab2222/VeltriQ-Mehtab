namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateActivityViewModel
    {
        public int OnboardingTemplateActivityId { get; set; }

        public int OnboardingActivityMasterId { get; set; }

        public string ActivityName { get; set; } = string.Empty;

        public bool IsSelected { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }
    }
}