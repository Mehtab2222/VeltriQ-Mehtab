namespace VeltriQ.ViewModels.OnboardingSection
{
    public class OnboardingSectionListItemViewModel
    {
        public int OnboardingSectionMasterId { get; set; }

        public string SectionName { get; set; } = "";

        public string Description { get; set; } = "";

        public int DisplayOrder { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsVisible { get; set; }

        public bool IsActive { get; set; }

        public string IconCss { get; set; } = "";
    }
}