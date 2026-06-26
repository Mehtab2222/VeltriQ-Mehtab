using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingTemplateSection", Schema = "HR")]
    public class OnboardingTemplateSection
    {
        [Key]
        public int OnboardingTemplateSectionId { get; set; }

        [Required]
        public int OnboardingTemplateId { get; set; }

        [ForeignKey(nameof(OnboardingTemplateId))]
        public virtual OnboardingTemplate? OnboardingTemplate { get; set; }

        [Required]
        public int OnboardingSectionMasterId { get; set; }

        [ForeignKey(nameof(OnboardingSectionMasterId))]
        public virtual OnboardingSectionMaster? OnboardingSectionMaster { get; set; }

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