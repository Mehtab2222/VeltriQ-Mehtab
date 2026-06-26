using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeeIdentity", Schema = "HR")]
    public class OnboardingEmployeeIdentity
    {
        [Key]
        public int OnboardingEmployeeIdentityId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // IDENTITY DOCUMENT
        // ==========================================

        public int IdentityDocumentMasterId { get; set; }

        [ForeignKey(nameof(IdentityDocumentMasterId))]
        public virtual IdentityDocumentMaster? IdentityDocument { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentNumber { get; set; } = string.Empty;

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(100)]
        public string? PlaceOfIssue { get; set; }

        public bool IsPrimary { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        // ==========================================
        // AUDIT
        // ==========================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}