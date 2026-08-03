using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Attendance
{
    public class AttendancePolicyViewModel
    {
        public int AttendancePolicyId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Policy Code")]
        public string PolicyCode { get; set; } = "";

        [Required]
        [Display(Name = "Policy Name")]
        public string PolicyName { get; set; } = "";

        [Display(Name = "Late Grace (Minutes)")]
        public int LateGraceMinutes { get; set; }

        [Display(Name = "Early Exit Grace (Minutes)")]
        public int EarlyExitGraceMinutes { get; set; }

        public decimal HalfDayHours { get; set; }

        public decimal FullDayHours { get; set; }

        public decimal MinimumWorkingHours { get; set; }

        public bool AllowMultiplePunch { get; set; }

        public bool AllowRegularization { get; set; }

        public bool AllowOvertime { get; set; }

        public decimal OvertimeAfterHours { get; set; }

        public bool AllowCompOff { get; set; }

        public bool AutoAbsent { get; set; }

        public bool IsDefaultPolicy { get; set; }

        public bool IsActive { get; set; }
    }
}