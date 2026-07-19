using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class EmployeeInductionSession
    {
        public int EmployeeInductionSessionId { get; set; }

        [Required]
        public int EmployeeInductionId { get; set; }

        [Required]
        public int InductionSessionMasterId { get; set; }

        [Required]
        [StringLength(150)]
        public string SessionTitle { get; set; } = string.Empty;

        public int SessionOrder { get; set; }

        public int DurationInMinutes { get; set; }

        public bool IsMandatory { get; set; }

        /// <summary>
        /// 1 = Pending
        /// 2 = Present
        /// 3 = Absent
        /// 4 = Rescheduled
        /// </summary>
        public int AttendanceStatus { get; set; } = 1;

        public DateTime? LatestAttendanceDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        public DateTime? CompletedOn { get; set; }

        [StringLength(500)]
        public string? TrainerRemarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        public virtual EmployeeInduction? EmployeeInduction { get; set; }

        public virtual InductionSessionMaster? InductionSessionMaster { get; set; }

        #endregion
    }
}