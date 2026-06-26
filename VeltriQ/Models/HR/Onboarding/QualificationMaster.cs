using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("QualificationMaster", Schema = "HR")]
    public class QualificationMaster
    {
        [Key]
        public int QualificationMasterId { get; set; }

        public int QualificationTypeMasterId { get; set; }

        [ForeignKey(nameof(QualificationTypeMasterId))]
        public virtual QualificationTypeMaster? QualificationType { get; set; }

        [Required]
        [StringLength(30)]
        public string QualificationCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string QualificationName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        public bool RequiresExpiryDate { get; set; }

        public bool IsProfessionalQualification { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        [StringLength(100)]
        public string? EducationLevel { get; set; }

        public bool RequiresRenewal { get; set; }

        public bool IsDefault { get; set; } = true;
    }
}