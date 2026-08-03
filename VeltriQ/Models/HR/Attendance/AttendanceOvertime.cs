using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendanceOvertime
    {
        public int AttendanceOvertimeId { get; set; }

        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }

        public decimal OvertimeHours { get; set; }

        public string Status { get; set; } = "Pending";

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string? Remarks { get; set; }

        public bool PayrollProcessed { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(AttendanceId))]
        public virtual Attendance? Attendance { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }
    }
}