using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingSchedule
    {
        [Key]
        public int TrainingScheduleId { get; set; }

        [Required]
        [StringLength(20)]
        public string ScheduleCode { get; set; } = string.Empty;

        // Training
        [Required]
        public int TrainingMasterId { get; set; }

        [ForeignKey(nameof(TrainingMasterId))]
        public virtual TrainingMaster? TrainingMaster { get; set; }

        // Trainer
        [Required]
        public int TrainingTrainerId { get; set; }

        [ForeignKey(nameof(TrainingTrainerId))]
        public virtual TrainingTrainer? TrainingTrainer { get; set; }

        // Venue
        [Required]
        public int TrainingVenueId { get; set; }

        [ForeignKey(nameof(TrainingVenueId))]
        public virtual TrainingVenue? TrainingVenue { get; set; }

        // Department (0 = All Departments)
        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        // Schedule
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        // Enrollment closes after this date
        public DateTime? EnrollmentLastDate { get; set; }

        // Maximum participants
        [Range(1, 10000)]
        public int Capacity { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        // Admin Controls
        public bool IsCancelled { get; set; } = false;

        public bool IsActive { get; set; } = true;

        // Audit
        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}