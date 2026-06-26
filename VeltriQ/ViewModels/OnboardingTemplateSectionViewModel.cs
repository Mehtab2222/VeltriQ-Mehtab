using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateSectionViewModel
    {
        public int OnboardingTemplateSectionId { get; set; }

        public int OnboardingTemplateId { get; set; }

        public int OnboardingSectionMasterId { get; set; }

        public string SectionName { get; set; } = string.Empty;

        public bool IsSelected { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;
    }
}