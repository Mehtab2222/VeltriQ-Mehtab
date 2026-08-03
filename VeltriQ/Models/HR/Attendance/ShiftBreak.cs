using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class ShiftBreak
    {
        public int ShiftBreakId { get; set; }

        public int ShiftMasterId { get; set; }

        public string BreakName { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public bool IsPaidBreak { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(ShiftMasterId))]
        public virtual ShiftMaster? ShiftMaster { get; set; }
    }
}