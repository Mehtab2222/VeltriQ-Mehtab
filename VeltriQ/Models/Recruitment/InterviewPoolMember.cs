using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Recruitment
{
    public class InterviewPoolMember
    {
        [Key]
        public int InterviewPoolMemberId { get; set; }

        [Required]
        public int InterviewPoolId { get; set; }

        [ForeignKey(nameof(InterviewPoolId))]
        public virtual InterviewPool? InterviewPool { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        // Preferred interviewer order (1 = highest priority)
        public int Priority { get; set; } = 1;

        // Maximum interviews this interviewer should receive
        // in one scheduling batch/day.
        public int DailyCapacity { get; set; } = 8;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}