
using System.Collections.Generic;

namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateDocumentViewModel
    {
        public int OnboardingTemplateDocumentId { get; set; }

        public int OnboardingDocumentMasterId { get; set; }

        public string DocumentName { get; set; } = string.Empty;

        public bool IsSelected { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }
    }
}