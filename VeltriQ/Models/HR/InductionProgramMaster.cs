using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class InductionProgramMaster
    {
        public int InductionProgramMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string ProgramCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string ProgramName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }
    }
}