using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingDocumentMaster", Schema = "HR")]
    public class OnboardingDocumentMaster
    {
        [Key]
        public int OnboardingDocumentMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string DocumentCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }
        // NEW
        [StringLength(100)]
        public string AllowedFileTypes { get; set; } = "pdf,jpg,jpeg,png";

        // NEW (In MB)
        public int MaxFileSizeMB { get; set; } = 5;

        // NEW
        public bool AllowMultipleFiles { get; set; } = false;

        // NEW
        public bool IsExpiryRequired { get; set; } = false;
        public bool IsMandatory { get; set; } = true;

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ValidationRule { get; set; }
        public bool AllowDownloadByCandidate { get; set; } = false;
        public bool IsVisibleToCandidate { get; set; } = true;
        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public bool IsSystemDocument { get; set; } = false;
        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        public int OnboardingDocumentCategoryMasterId { get; set; }

        [ForeignKey(nameof(OnboardingDocumentCategoryMasterId))]
        public virtual OnboardingDocumentCategoryMaster? DocumentCategory { get; set; }
    }
}