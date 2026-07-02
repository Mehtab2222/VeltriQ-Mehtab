using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.OnboardingPolicy
{
    public class OnboardingPolicyCreateViewModel
    {
        [Required]
        [Display(Name = "Policy Name")]
        public string PolicyName { get; set; } = "";

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int OnboardingPolicyCategoryMasterId { get; set; }

        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Mandatory")]
        public bool IsMandatory { get; set; } = true;

        [Display(Name = "Allow Candidate Download")]
        public bool AllowDownload { get; set; }
        [Display(Name = "Version")]
        public string PolicyVersion { get; set; } = "1.0";

        [Display(Name = "Effective Date")]
        public DateTime EffectiveDate { get; set; } = DateTime.Today;

        [Display(Name = "Requires Acceptance")]
        public bool RequiresAcceptance { get; set; } = true;

        [Display(Name = "Policy Document")]
        public IFormFile? PolicyFile { get; set; }
        public List<SelectListItem> Categories { get; set; } = new();
    }
}