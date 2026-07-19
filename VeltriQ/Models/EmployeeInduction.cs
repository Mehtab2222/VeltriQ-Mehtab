using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class EmployeeInduction
    {
        public int EmployeeInductionId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int InductionProgramMasterId { get; set; }

        public DateTime AssignedOn { get; set; } = DateTime.Now;

        public int? AssignedBy { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? ExpectedCompletionDate { get; set; }

        public DateTime? ActualCompletionDate { get; set; }

        /// <summary>
        /// 1 = Assigned
        /// 2 = In Progress
        /// 3 = Completed
        /// 4 = Cancelled
        /// </summary>
        public int InductionStatus { get; set; } = 1;

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        public virtual Employee? Employee { get; set; }

        public virtual InductionProgramMaster? InductionProgramMaster { get; set; }

        #endregion
    }
}