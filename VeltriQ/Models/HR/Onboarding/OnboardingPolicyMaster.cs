using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingPolicyMaster", Schema = "HR")]
    public class OnboardingPolicyMaster
    {
        [Key]
        public int OnboardingPolicyMasterId { get; set; }

        public int OnboardingPolicyCategoryMasterId { get; set; }

        [ForeignKey(nameof(OnboardingPolicyCategoryMasterId))]
        public virtual OnboardingPolicyCategoryMaster? PolicyCategory { get; set; }

        [Required]
        [StringLength(20)]
        public string PolicyCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string PolicyName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(20)]
        public string PolicyVersion { get; set; } = "1.0";

        public DateTime EffectiveDate { get; set; } = DateTime.Today;

        public bool IsMandatory { get; set; } = true;

        public bool RequiresAcceptance { get; set; } = true;

        public bool AllowDownload { get; set; } = true;
        [StringLength(255)]
        public string? FileName { get; set; }

        [StringLength(500)]
        public string? FilePath { get; set; }
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