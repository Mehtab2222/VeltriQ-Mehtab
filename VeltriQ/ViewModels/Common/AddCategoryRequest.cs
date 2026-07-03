using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Common
{
    public class AddCategoryRequest
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = "";

        [StringLength(500)]
        public string? Description { get; set; }
    }
}