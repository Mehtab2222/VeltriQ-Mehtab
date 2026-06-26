using System.Collections.Generic;

namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateSectionDesignerViewModel
    {
        public int OnboardingTemplateId { get; set; }

        public string TemplateCode { get; set; } = string.Empty;

        public string TemplateName { get; set; } = string.Empty;

        public List<OnboardingTemplateSectionViewModel> Sections { get; set; } = new();
        public List<OnboardingTemplateDocumentViewModel> Documents { get; set; } = new();
        public List<OnboardingTemplatePolicyViewModel> Policies { get; set; } = new();
        public List<OnboardingTemplateActivityViewModel> Activities { get; set; } = new();
        public bool IsPublished { get; set; }
    }
}