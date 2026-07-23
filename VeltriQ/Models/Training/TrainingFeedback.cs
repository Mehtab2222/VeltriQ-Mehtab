using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingFeedback
    {
        [Key]
        public int TrainingFeedbackId { get; set; }

        [Required]
        public int TrainingEnrollmentId { get; set; }
        [ForeignKey(nameof(TrainingEnrollmentId))]
        public virtual TrainingEnrollment? TrainingEnrollment { get; set; }

        [Required]
        public int TrainingScheduleId { get; set; }
        [ForeignKey(nameof(TrainingScheduleId))]
        public virtual TrainingSchedule? TrainingSchedule { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [Range(1, 5)]
        public int TrainerRating { get; set; }

        [Range(1, 5)]
        public int ContentRating { get; set; }

        [Range(1, 5)]
        public int VenueRating { get; set; }

        [Range(1, 5)]
        public int OverallRating { get; set; }

        public bool WouldRecommend { get; set; }

        [StringLength(1000)]
        public string? Comments { get; set; }
        public bool IsAnonymous { get; set; } = false;
        [Required]
        public DateTime SubmittedOn { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}