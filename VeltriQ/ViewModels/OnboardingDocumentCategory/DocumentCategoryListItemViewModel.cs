namespace VeltriQ.ViewModels.OnboardingDocumentCategory
{
    public class DocumentCategoryListItemViewModel
    {
        public int OnboardingDocumentCategoryMasterId { get; set; }

        public string CategoryName { get; set; } = "";

        public string Description { get; set; } = "";

        public int DisplayOrder { get; set; }

        public int DocumentCount { get; set; }

        public bool IsActive { get; set; }
    }
}