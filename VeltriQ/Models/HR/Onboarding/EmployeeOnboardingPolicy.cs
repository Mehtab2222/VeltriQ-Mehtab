using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingPolicy", Schema = "HR")]
    public class EmployeeOnboardingPolicy
    {
        [Key]
        public int EmployeeOnboardingPolicyId { get; set; }

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        public int OnboardingPolicyMasterId { get; set; }

        [ForeignKey(nameof(OnboardingPolicyMasterId))]
        public virtual OnboardingPolicyMaster? Policy { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsAccepted { get; set; } = false;

        public DateTime? AcceptedOn { get; set; }

        [StringLength(450)]
        public string? AcceptedBy { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}