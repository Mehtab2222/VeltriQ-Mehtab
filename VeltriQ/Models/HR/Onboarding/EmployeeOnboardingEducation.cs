using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingEducation", Schema = "HR")]
    public class EmployeeOnboardingEducation
    {
        [Key]
        public int EmployeeOnboardingEducationId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // EDUCATION DETAILS
        //====================================================

        [Required]
        [StringLength(100)]
        public int QualificationTypeMasterId { get; set; }

        [ForeignKey(nameof(QualificationTypeMasterId))]
        public virtual QualificationTypeMaster? QualificationType { get; set; }

        [Required]
        [StringLength(200)]
        public string InstituteName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? BoardUniversity { get; set; }

        [StringLength(150)]
        public string? Specialization { get; set; }

        public int? PassingYear { get; set; }

        [StringLength(20)]
        public string? PercentageOrCGPA { get; set; }

        [StringLength(500)]
        public string? CertificatePath { get; set; }



        //====================================================
        // AUDIT
        //====================================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}