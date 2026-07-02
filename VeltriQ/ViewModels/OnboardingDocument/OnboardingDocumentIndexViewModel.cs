namespace VeltriQ.ViewModels.OnboardingDocument
{
    public class OnboardingDocumentIndexViewModel
    {
        public string SearchText { get; set; } = "";

        public List<OnboardingDocumentListItemViewModel> Documents { get; set; }
            = new();
    }
}