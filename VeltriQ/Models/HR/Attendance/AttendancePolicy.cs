using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendancePolicy
    {
        [Key]
        public int AttendancePolicyId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(20)]
        public string PolicyCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string PolicyName { get; set; } = string.Empty;

        public int LateGraceMinutes { get; set; }

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

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        public virtual ICollection<ShiftMaster> Shifts { get; set; }
            = new List<ShiftMaster>();
    }
}