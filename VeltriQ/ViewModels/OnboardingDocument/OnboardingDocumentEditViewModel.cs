using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.OnboardingDocument
{
    public class OnboardingDocumentEditViewModel
    {
        public int OnboardingDocumentMasterId { get; set; }

        [Required]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; } = "";

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int OnboardingDocumentCategoryMasterId { get; set; }

        [Required]
        [Display(Name = "Allowed File Types")]
        public string AllowedFileTypes { get; set; } = "";

        [Required]
        [Display(Name = "Maximum File Size (MB)")]
        public int MaxFileSizeMB { get; set; }

        [Display(Name = "Allow Multiple Files")]
        public bool AllowMultipleFiles { get; set; }

        [Display(Name = "Expiry Required")]
        public bool IsExpiryRequired { get; set; }

        [Display(Name = "Mandatory")]
        public bool IsMandatory { get; set; }

        [Display(Name = "Visible To Candidate")]
        public bool IsVisibleToCandidate { get; set; }

        [Display(Name = "Allow Candidate Download")]
        public bool AllowDownloadByCandidate { get; set; }

        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public List<SelectListItem> Categories { get; set; } = new();
    }
}