using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.Training
{
    public class TrainingMaster
    {
        [Key]
        public int TrainingMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string TrainingCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string TrainingName { get; set; } = string.Empty;

        [Required]
        public int TrainingCategoryId { get; set; }

        [ForeignKey(nameof(TrainingCategoryId))]
        public virtual TrainingCategory? TrainingCategory { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero.")]
        public int Duration { get; set; }

        // 1 = Minutes, 2 = Hours, 3 = Days
        [Required]
        public byte DurationType { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsAssessmentRequired { get; set; }

        public bool IsCertificateRequired { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}