namespace VeltriQ.ViewModels.OnboardingSection
{
    public class OnboardingSectionIndexViewModel
    {
        public string SearchText { get; set; } = "";

        public List<OnboardingSectionListItemViewModel> Sections { get; set; }
            = new();
    }
}