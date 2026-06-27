using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingCandidateInvitation", Schema = "HR")]
    public class OnboardingCandidateInvitation
    {
        [Key]
        public int OnboardingCandidateInvitationId { get; set; }

        //====================================================
        // RELATIONSHIPS
        //====================================================

        public int OnboardingCandidateId { get; set; }

        [ForeignKey(nameof(OnboardingCandidateId))]
        public virtual OnboardingCandidate? OnboardingCandidate { get; set; }

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // INVITATION
        //====================================================

        [Required]
        [StringLength(200)]
        public string InvitationToken { get; set; } = Guid.NewGuid().ToString();

        public DateTime InvitedOn { get; set; } = DateTime.Now;
        public int InvitationCount { get; set; } = 1;
        public DateTime ExpiryDate { get; set; }

        public DateTime? AcceptedOn { get; set; }

        //====================================================
        // PORTAL ACCESS
        //====================================================

        public bool IsInvitationAccepted { get; set; } = false;

        public bool IsPortalAccessEnabled { get; set; } = true;

        public DateTime? LastLoginOn { get; set; }

        //====================================================
        // STATUS
        //====================================================

        public bool IsActive { get; set; } = true;

        //====================================================
        // AUDIT
        //====================================================

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}