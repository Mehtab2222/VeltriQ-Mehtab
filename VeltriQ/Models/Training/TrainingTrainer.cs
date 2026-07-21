using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingTrainer
    {
        [Key]
        public int TrainingTrainerId { get; set; }

        [Required]
        [StringLength(20)]
        public string TrainerCode { get; set; } = string.Empty;

        // 1 = Internal, 2 = External
        [Required]
        public byte TrainerType { get; set; }

        // Required for Internal Trainer
        public int? EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        // Required for External Trainer
        [StringLength(200)]
        public string? TrainerName { get; set; }

        [StringLength(20)]
        public string? MobileNo { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}