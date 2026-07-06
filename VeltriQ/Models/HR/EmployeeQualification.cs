using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Models.HR
{
    [Table("EmployeeQualification", Schema = "HR")]
    public class EmployeeQualification
    {
        [Key]
        public int EmployeeQualificationId { get; set; }

        //====================================================
        // EMPLOYEE
        //====================================================

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        //====================================================
        // QUALIFICATION
        //====================================================

        public int QualificationMasterId { get; set; }

        [ForeignKey(nameof(QualificationMasterId))]
        public virtual QualificationMaster? Qualification { get; set; }

        public int? QualificationSpecializationMasterId { get; set; }

        [ForeignKey(nameof(QualificationSpecializationMasterId))]
        public virtual QualificationSpecializationMaster? QualificationSpecialization { get; set; }

        //====================================================
        // EDUCATION DETAILS
        //====================================================

        [Required]
        [StringLength(200)]
        public string InstituteName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? BoardOrUniversity { get; set; }

        [StringLength(200)]
        public string? SpecializationDescription { get; set; }

        public int? PassingYear { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? CGPA { get; set; }

        [StringLength(20)]
        public string? Grade { get; set; }

        //====================================================
        // CERTIFICATION / LICENSE
        //====================================================

        [StringLength(100)]
        public string? RegistrationNumber { get; set; }

        [StringLength(100)]
        public string? CertificateNumber { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        //====================================================
        // DOCUMENT INFORMATION
        //====================================================

        [StringLength(255)]
        public string? AttachmentFileName { get; set; }

        [StringLength(500)]
        public string? AttachmentFilePath { get; set; }

        //====================================================
        // FLAGS
        //====================================================

        public bool IsHighestQualification { get; set; }

        public bool IsVerified { get; set; }

        public DateTime? VerifiedOn { get; set; }

        [StringLength(450)]
        public string? VerifiedBy { get; set; }

        //====================================================
        // REMARKS
        //====================================================

        [StringLength(1000)]
        public string? Remarks { get; set; }

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