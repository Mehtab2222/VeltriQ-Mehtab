using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployee", Schema = "HR")]
    public class OnboardingEmployee
    {
        [Key]
        public int OnboardingEmployeeId { get; set; }

        // ==========================
        // ONBOARDING INFORMATION
        // ==========================

        [Required]
        [StringLength(20)]
        public string OnboardingNumber { get; set; } = string.Empty;

        public int OnboardingTemplateId { get; set; }

        [ForeignKey(nameof(OnboardingTemplateId))]
        public virtual OnboardingTemplate? OnboardingTemplate { get; set; }

        public int EmploymentTypeMasterId { get; set; }

        [ForeignKey(nameof(EmploymentTypeMasterId))]
        public virtual EmploymentTypeMaster? EmploymentType { get; set; }

        public int OnboardingStatusMasterId { get; set; }

        [ForeignKey(nameof(OnboardingStatusMasterId))]
        public virtual OnboardingStatusMaster? OnboardingStatus { get; set; }

        // ==========================
        // BASIC INFORMATION
        // ==========================

        [StringLength(20)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string PersonalEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        public DateTime JoiningDate { get; set; }

        // ==========================
        // WORKFLOW
        // ==========================

        public DateTime? SubmittedOn { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public DateTime? ConvertedOn { get; set; }

        public bool IsPortalLocked { get; set; } = false;

        public bool IsConvertedToEmployee { get; set; } = false;

        public int? EmployeeId { get; set; }
        [StringLength(50)]
        public string? Source { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [StringLength(1000)]
        public string? Remarks { get; set; }
        public int? RecruitmentCandidateId { get; set; }
        // ==========================
        // AUDIT
        // ==========================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}