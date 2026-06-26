using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("QualificationSpecializationMaster", Schema = "HR")]
    public class QualificationSpecializationMaster
    {
        [Key]
        public int QualificationSpecializationMasterId { get; set; }

        public int QualificationMasterId { get; set; }

        [ForeignKey(nameof(QualificationMasterId))]
        public virtual QualificationMaster? Qualification { get; set; }

        [Required]
        [StringLength(30)]
        public string SpecializationCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string SpecializationName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsDefault { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}