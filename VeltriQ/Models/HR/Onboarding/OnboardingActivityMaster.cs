using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingActivityMaster", Schema = "HR")]
    public class OnboardingActivityMaster
    {
        [Key]
        public int OnboardingActivityMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string ActivityCode { get; set; } = string.Empty;
        public int ActivityDay { get; set; }
        [Required]
        [StringLength(150)]
        public string ActivityName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsMandatory { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }
        [StringLength(20)]
        public string ActivityOwner { get; set; } = "HR";
        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        public int OnboardingActivityCategoryMasterId { get; set; }

        [ForeignKey(nameof(OnboardingActivityCategoryMasterId))]
        public virtual OnboardingActivityCategoryMaster? ActivityCategory { get; set; }
    }
}