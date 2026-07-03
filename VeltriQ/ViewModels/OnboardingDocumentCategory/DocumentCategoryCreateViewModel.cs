using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.OnboardingDocumentCategory
{
    public class DocumentCategoryCreateViewModel
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string CategoryName { get; set; } = "";

        [Display(Name = "Description")]
        [StringLength(250)]
        public string? Description { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order must be greater than 0.")]
        public int DisplayOrder { get; set; }
    }
}