using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingDocument", Schema = "HR")]
    public class EmployeeOnboardingDocument
    {
        [Key]
        public int EmployeeOnboardingDocumentId { get; set; }

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        public int OnboardingDocumentMasterId { get; set; }

        [ForeignKey(nameof(OnboardingDocumentMasterId))]
        public virtual OnboardingDocumentMaster? Document { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsUploaded { get; set; } = false;

        [StringLength(500)]
        public string? FileName { get; set; }

        [StringLength(1000)]
        public string? FilePath { get; set; }

        public DateTime? UploadedOn { get; set; }

        [StringLength(450)]
        public string? UploadedBy { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsVerified { get; set; } = false;

        public DateTime? VerifiedOn { get; set; }

        [StringLength(450)]
        public string? VerifiedBy { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}