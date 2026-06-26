using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.Master;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingTemplate", Schema = "HR")]
    public class OnboardingTemplate
    {
        [Key]
        public int OnboardingTemplateId { get; set; }
        [StringLength(50)]
        public string TemplateVersion { get; set; } = "1.0";
        [Required]
        [StringLength(20)]
        public string TemplateCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string TemplateName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        // Employment Type
        public int EmploymentTypeMasterId { get; set; }

        [ForeignKey(nameof(EmploymentTypeMasterId))]
        public virtual EmploymentTypeMaster? EmploymentType { get; set; }
        public bool IsPublished { get; set; } = false;
        // Optional Department
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        // Optional Designation
        public int? DesignationId { get; set; }

        [ForeignKey(nameof(DesignationId))]
        public virtual Designation? Designation { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}