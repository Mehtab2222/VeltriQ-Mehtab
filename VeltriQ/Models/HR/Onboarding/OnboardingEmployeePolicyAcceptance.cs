using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeePolicyAcceptance", Schema = "HR")]
    public class OnboardingEmployeePolicyAcceptance
    {
        [Key]
        public int OnboardingEmployeePolicyAcceptanceId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // POLICY
        // ==========================================

        public int OnboardingPolicyMasterId { get; set; }

        [ForeignKey(nameof(OnboardingPolicyMasterId))]
        public virtual OnboardingPolicyMaster? Policy { get; set; }

        // ==========================================
        // ACCEPTANCE DETAILS
        // ==========================================

        [Required]
        [StringLength(20)]
        public string PolicyVersion { get; set; } = "1.0";

        public bool IsMandatory { get; set; }

        [StringLength(20)]
        public string AcceptanceStatus { get; set; } = "Pending";

        public DateTime? AcceptedOn { get; set; }

        // ==========================================
        // CONSENT
        // ==========================================
        [StringLength(30)]
        public string? AcceptanceMethod { get; set; }

        public bool RequiresReAcceptance { get; set; }
        [StringLength(500)]
        public string? AcceptanceRemarks { get; set; }

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
    }
}