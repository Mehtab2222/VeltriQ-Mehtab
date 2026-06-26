using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingTemplatePolicy", Schema = "HR")]
    public class OnboardingTemplatePolicy
    {
        [Key]
        public int OnboardingTemplatePolicyId { get; set; }

        public int OnboardingTemplateId { get; set; }

        [ForeignKey(nameof(OnboardingTemplateId))]
        public virtual OnboardingTemplate? OnboardingTemplate { get; set; }

        public int OnboardingPolicyMasterId { get; set; }

        [ForeignKey(nameof(OnboardingPolicyMasterId))]
        public virtual OnboardingPolicyMaster? Policy { get; set; }

        public bool IsMandatory { get; set; } = true;

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}