using System;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Training
{
    public class TrainingCategory
    {
        [Key]
        public int TrainingCategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}