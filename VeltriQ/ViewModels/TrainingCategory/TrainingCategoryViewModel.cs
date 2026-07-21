using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.TrainingCategory
{
    public class TrainingCategoryViewModel
    {
        public int TrainingCategoryId { get; set; }

        public string? CategoryCode { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;
    }
}