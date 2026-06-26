using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeeDocument", Schema = "HR")]
    public class OnboardingEmployeeDocument
    {
        [Key]
        public int OnboardingEmployeeDocumentId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // DOCUMENT
        // ==========================================

        public int OnboardingDocumentMasterId { get; set; }

        [ForeignKey(nameof(OnboardingDocumentMasterId))]
        public virtual OnboardingDocumentMaster? Document { get; set; }

        // ==========================================
        // FILE INFORMATION
        // ==========================================

        [Required]
        [StringLength(255)]
        public string OriginalFileName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string StoredFileName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ContentType { get; set; }

        public long FileSize { get; set; }

        // ==========================================
        // DOCUMENT STATUS
        // ==========================================

        [StringLength(30)]
        public string DocumentStatus { get; set; } = "Pending";

        public int VersionNo { get; set; } = 1;

        // ==========================================
        // DATES
        // ==========================================
        public bool IsMandatory { get; set; }
        public DateTime? UploadedOn { get; set; }

        public DateTime? ReviewedOn { get; set; }

        // ==========================================
        // VERIFIED BY
        // ==========================================

        [StringLength(450)]
        public string? ReviewedBy { get; set; }

        // ==========================================
        // REMARKS
        // ==========================================

        [StringLength(1000)]
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