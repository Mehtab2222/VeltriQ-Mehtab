using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingMasterViewModel
    {
        public int TrainingMasterId { get; set; }

        public string? TrainingCode { get; set; }

        [Required(ErrorMessage = "Training Name is required.")]
        [StringLength(200)]
        public string TrainingName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category.")]
        public int TrainingCategoryId { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please select duration type.")]
        public byte DurationType { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsAssessmentRequired { get; set; }

        public bool IsCertificateRequired { get; set; }

        public bool IsActive { get; set; } = true;

        public List<SelectListItem> TrainingCategories { get; set; } = new();

        public List<SelectListItem> DurationTypes { get; set; } = new()
        {
            new SelectListItem { Value = "1", Text = "Minutes" },
            new SelectListItem { Value = "2", Text = "Hours" },
            new SelectListItem { Value = "3", Text = "Days" }
        };
    }
}