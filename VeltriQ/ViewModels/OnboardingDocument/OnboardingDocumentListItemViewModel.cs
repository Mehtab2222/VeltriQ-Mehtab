namespace VeltriQ.ViewModels.OnboardingDocument
{
    public class OnboardingDocumentListItemViewModel
    {
        public int OnboardingDocumentMasterId { get; set; }

        public string DocumentName { get; set; } = "";

        public string Description { get; set; } = "";

        public string CategoryName { get; set; } = "";

        public string AllowedFileTypes { get; set; } = "";

        public int MaxFileSizeMB { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsExpiryRequired { get; set; }

        public bool IsAllowMultipleFiles { get; set; }

        public bool IsVisibleToCandidate { get; set; }

        public bool AllowDownloadByCandidate { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}