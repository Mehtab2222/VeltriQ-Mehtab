using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingSectionProgress", Schema = "HR")]
    public class OnboardingSectionProgress
    {
        [Key]
        public int OnboardingSectionProgressId { get; set; }

        // ===================================
        // ONBOARDING EMPLOYEE
        // ===================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ===================================
        // SECTION
        // ===================================

        public int OnboardingSectionMasterId { get; set; }

        [ForeignKey(nameof(OnboardingSectionMasterId))]
        public virtual OnboardingSectionMaster? Section { get; set; }

        // ===================================
        // STATUS
        // ===================================

        public bool IsStarted { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? StartedOn { get; set; }

        public DateTime? CompletedOn { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = "Pending";
        // ===================================
        // AUDIT
        // ===================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsLocked { get; set; }
    }
}