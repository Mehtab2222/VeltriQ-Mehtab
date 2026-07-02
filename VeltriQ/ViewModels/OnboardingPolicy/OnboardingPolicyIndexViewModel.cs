namespace VeltriQ.ViewModels.OnboardingPolicy
{
    public class OnboardingPolicyIndexViewModel
    {
        public string SearchText { get; set; } = "";

        public List<OnboardingPolicyListItemViewModel> Policies { get; set; }
            = new();
    }
}