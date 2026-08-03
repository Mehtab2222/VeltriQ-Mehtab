using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendanceHistory
    {
        public int AttendanceHistoryId { get; set; }

        public int AttendanceId { get; set; }

        public string FieldName { get; set; } = string.Empty;

        public string? OldValue { get; set; }

        public string? NewValue { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public string? Remarks { get; set; }

        [ForeignKey(nameof(AttendanceId))]
        public virtual Attendance? Attendance { get; set; }

        [ForeignKey(nameof(ChangedBy))]
        public virtual Employee? Employee { get; set; }
    }
}