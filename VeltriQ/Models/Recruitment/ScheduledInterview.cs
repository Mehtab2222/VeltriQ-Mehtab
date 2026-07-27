using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Recruitment
{
    public static class ScheduledInterviewStatus
    {
        public const string Scheduled = "Scheduled";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
    }

    public class ScheduledInterview
    {
        [Key]
        public int ScheduledInterviewId { get; set; }

        [Required]
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public virtual Applicant? Applicant { get; set; }

        [Required]
        public int AvailabilityRequestId { get; set; }
        [ForeignKey(nameof(AvailabilityRequestId))]
        public virtual AvailabilityRequest? AvailabilityRequest { get; set; }

        [Required]
        public int AvailabilitySlotId { get; set; }
        [ForeignKey(nameof(AvailabilitySlotId))]
        public virtual AvailabilitySlot? AvailabilitySlot { get; set; }

        [Required]
        public int InterviewerEmployeeId { get; set; }
        [ForeignKey(nameof(InterviewerEmployeeId))]
        public virtual Employee? InterviewerEmployee { get; set; }

        [Required]
        public int RoundTypeId { get; set; }
        [ForeignKey(nameof(RoundTypeId))]
        public virtual RoundType? RoundType { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = ScheduledInterviewStatus.Scheduled;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}