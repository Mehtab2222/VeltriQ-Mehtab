using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingSectionMaster", Schema = "HR")]
    public class OnboardingSectionMaster
    {
        [Key]
        public int OnboardingSectionMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string SectionCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string SectionName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }
        public string IconCss { get; set; } = string.Empty;
        public bool IsMandatory { get; set; } = true;

        public bool IsVisible { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}