using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.Recruitment
{
    public static class AvailabilityRequestStatus
    {
        public const string Open = "Open";
        public const string Closed = "Closed";
    }

    public class AvailabilityRequest
    {
        [Key]
        public int AvailabilityRequestId { get; set; }

        [Required]
        public int RoundTypeId { get; set; }
        [ForeignKey(nameof(RoundTypeId))]
        public virtual RoundType? RoundType { get; set; }

        [Required]
        public int InterviewPoolId { get; set; }
        [ForeignKey(nameof(InterviewPoolId))]
        public virtual InterviewPool? InterviewPool { get; set; }

        [Required]
        public DateTime TargetDate { get; set; } // the day interviews/calls will actually happen

        [Required]
        public DateTime ReplyDeadline { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = AvailabilityRequestStatus.Open;

        public DateTime? ClosedOn { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<AvailabilitySlot> Slots { get; set; } = new List<AvailabilitySlot>();
    }
}