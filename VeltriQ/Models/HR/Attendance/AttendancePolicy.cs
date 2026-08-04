using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendancePolicy
    {
        public int AttendancePolicyId { get; set; }

        //==========================================
        // BASIC INFORMATION
        //==========================================

        public int CompanyId { get; set; }

        public string PolicyCode { get; set; } = string.Empty;

        public string PolicyName { get; set; } = string.Empty;

        public string? Description { get; set; }

        //==========================================
        // WORKING HOURS
        //==========================================

        public decimal FullDayHours { get; set; }

        public decimal HalfDayHours { get; set; }

        public decimal MinimumWorkingHours { get; set; }

        //==========================================
        // LATE ARRIVAL
        //==========================================

        public int LateGraceMinutes { get; set; }

        public bool EnableLateMark { get; set; }

        public int MaxLateMarksPerMonth { get; set; }

        public decimal LateMarkDeductionDays { get; set; }

        //==========================================
        // EARLY LEAVING
        //==========================================

        public int EarlyOutGraceMinutes { get; set; }

        public bool EnableEarlyOut { get; set; }

        public int MaxEarlyOutPerMonth { get; set; }

        public decimal EarlyOutDeductionDays { get; set; }

        //==========================================
        // OVERTIME
        //==========================================

        public bool EnableOvertime { get; set; }

        public int MinimumOvertimeMinutes { get; set; }

        public bool RoundOvertime { get; set; }

        public int MaximumOvertimeHours { get; set; }

        //==========================================
        // PUNCH SETTINGS
        //==========================================

        public int MinimumPunchesPerDay { get; set; }

        public bool AllowSinglePunch { get; set; }

        public bool IgnoreDuplicatePunch { get; set; }

        public int DuplicatePunchIntervalMinutes { get; set; }

        //==========================================
        // MISSING PUNCH RULES
        //==========================================

        public bool AutoAbsentForMissingPunch { get; set; }

        public bool AutoHalfDayForMissingPunch { get; set; }

        //==========================================
        // HOLIDAY & WEEKLY OFF RULES
        //==========================================

        public bool EnableSandwichRule { get; set; }

        public bool IncludeHolidayPrefixSuffix { get; set; }

        public bool IncludeWeeklyOffPrefixSuffix { get; set; }

        //==========================================
        // GENERAL SETTINGS
        //==========================================

        public bool IsDefaultPolicy { get; set; }

        public bool IsActive { get; set; }

        //==========================================
        // AUDIT
        //==========================================

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        //==========================================
        // NAVIGATION
        //==========================================

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        public virtual ICollection<ShiftMaster> ShiftMasters { get; set; }
            = new List<ShiftMaster>();

    }
}