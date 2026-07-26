using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Recruitment
{
    public class RoundType
    {
        [Key]
        public int RoundTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoundTypeName { get; set; } = string.Empty;
        // Examples:
        // Screening Call
        // Technical Round 1
        // Technical Round 2
        // HR Discussion
        // Final Discussion

        [Required]
        [StringLength(20)]
        public string StageMapping { get; set; } = string.Empty;
        // Allowed values:
        // Screening
        // Evaluating

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}