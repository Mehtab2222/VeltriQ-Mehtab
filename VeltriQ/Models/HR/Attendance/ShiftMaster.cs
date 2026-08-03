using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class ShiftMaster
    {
        public int ShiftMasterId { get; set; }

        public int CompanyId { get; set; }

        public int BranchId { get; set; }

        public int AttendancePolicyId { get; set; }

        public string ShiftCode { get; set; } = string.Empty;

        public string ShiftName { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int GraceInMinutes { get; set; }

        public int GraceOutMinutes { get; set; }

        public decimal FullDayHours { get; set; }

        public decimal HalfDayHours { get; set; }

        public decimal MinimumWorkingHours { get; set; }

        public bool IsNightShift { get; set; }

        public bool IsFlexibleShift { get; set; }

        public bool IsCrossDayShift { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }

        [ForeignKey(nameof(AttendancePolicyId))]
        public virtual AttendancePolicy? AttendancePolicy { get; set; }

        public virtual ICollection<ShiftBreak> ShiftBreaks { get; set; }
            = new List<ShiftBreak>();

        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
            = new List<EmployeeShift>();
    }
}