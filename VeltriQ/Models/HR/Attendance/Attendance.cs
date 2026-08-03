using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int CompanyId { get; set; }

        public int BranchId { get; set; }

        public int EmployeeId { get; set; }

        public int ShiftMasterId { get; set; }

        public int AttendancePolicyId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public DateTime? FirstPunchIn { get; set; }

        public DateTime? LastPunchOut { get; set; }

        public decimal WorkingHours { get; set; }

        public decimal BreakHours { get; set; }

        public decimal OvertimeHours { get; set; }

        public int LateMinutes { get; set; }

        public int EarlyExitMinutes { get; set; }

        public string AttendanceStatus { get; set; } = "Present";

        public string? Remarks { get; set; }

        public bool IsLocked { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Company? Company { get; set; }

        public virtual Branch? Branch { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual ShiftMaster? ShiftMaster { get; set; }

        public virtual AttendancePolicy? AttendancePolicy { get; set; }

        public virtual ICollection<AttendancePunch> AttendancePunches { get; set; }
            = new List<AttendancePunch>();
    }
}