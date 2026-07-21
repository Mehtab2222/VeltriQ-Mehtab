using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingEnrollment
    {
        [Key]
        public int TrainingEnrollmentId { get; set; }

        [Required]
        public int TrainingScheduleId { get; set; }

        [ForeignKey(nameof(TrainingScheduleId))]
        public virtual TrainingSchedule? TrainingSchedule { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsCancelled { get; set; } = false;
        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}