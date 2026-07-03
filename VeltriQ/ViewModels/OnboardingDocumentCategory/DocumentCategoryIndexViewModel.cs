namespace VeltriQ.ViewModels.OnboardingDocumentCategory
{
    public class DocumentCategoryIndexViewModel
    {
        public string SearchText { get; set; } = "";

        public DocumentCategoryCreateViewModel CreateCategory { get; set; }
            = new();

        public List<DocumentCategoryListItemViewModel> Categories { get; set; }
            = new();
    }
}