using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingAttendance
    {
        public int TrainingAttendanceId { get; set; }

        public int TrainingScheduleId { get; set; }
        public virtual TrainingSchedule? TrainingSchedule { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        // ✅ NEW: Tracks which specific calendar day this attendance record belongs to
        public DateTime AttendanceDate { get; set; }

        // Present | Absent | Late
        public string? AttendanceStatus { get; set; }

        public DateTime? AttendanceTime { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}