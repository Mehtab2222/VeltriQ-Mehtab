using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboarding", Schema = "HR")]
    public class EmployeeOnboarding
    {
        [Key]
        public int EmployeeOnboardingId { get; set; }

        public int OnboardingCandidateId { get; set; }

        [ForeignKey(nameof(OnboardingCandidateId))]
        public virtual OnboardingCandidate? OnboardingCandidate { get; set; }

        public int OnboardingTemplateId { get; set; }

        [ForeignKey(nameof(OnboardingTemplateId))]
        public virtual OnboardingTemplate? OnboardingTemplate { get; set; }

        public int OnboardingStatusMasterId { get; set; }

        [ForeignKey(nameof(OnboardingStatusMasterId))]
        public virtual OnboardingStatusMaster? OnboardingStatus { get; set; }

        public DateTime AssignedOn { get; set; } = DateTime.Now;

        public DateTime? ExpectedCompletionDate { get; set; }

        public DateTime? CompletedOn { get; set; }
        public DateTime? SubmittedOn { get; set; }

        public DateTime? ReviewedOn { get; set; }

        public DateTime? ApprovedOn { get; set; }
        [StringLength(450)]
        public string? ApprovedBy { get; set; }
        public DateTime? ConvertedOn { get; set; }

        public bool IsPortalLocked { get; set; } = false;
        public decimal CompletionPercentage { get; set; } = 0;


        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsConverted { get; set; } = false;

        public int? EmployeeId { get; set; }

        [StringLength(450)]
        public string? ConvertedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}