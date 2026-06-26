using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels
{
    public class OnboardingTemplatePolicyViewModel
    {
        public int OnboardingTemplatePolicyId { get; set; }

        public int OnboardingPolicyMasterId { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public bool IsSelected { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }
    }
}