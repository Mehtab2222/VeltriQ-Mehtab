using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeeActivity", Schema = "HR")]
    public class OnboardingEmployeeActivity
    {
        [Key]
        public int OnboardingEmployeeActivityId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // ACTIVITY
        // ==========================================

        public int OnboardingActivityMasterId { get; set; }

        [ForeignKey(nameof(OnboardingActivityMasterId))]
        public virtual OnboardingActivityMaster? Activity { get; set; }

        // ==========================================
        // ACTIVITY STATUS
        // ==========================================

        [Required]
        [StringLength(20)]
        public string ActivityStatus { get; set; } = "Pending";

        public DateTime? AssignedOn { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? StartedOn { get; set; }

        public DateTime? CompletedOn { get; set; }

        // ==========================================
        // RESPONSIBILITY
        // ==========================================

        [StringLength(450)]
        public string? AssignedTo { get; set; }

        [StringLength(450)]
        public string? CompletedBy { get; set; }

        // ==========================================
        // REMARKS
        // ==========================================

        [StringLength(1000)]
        public string? Remarks { get; set; }

        // ==========================================
        // AUDIT
        // ==========================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        public bool IsMandatory { get; set; }

        public bool IsOverdue { get; set; }
    }
}