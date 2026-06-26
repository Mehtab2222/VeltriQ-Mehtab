using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingInvitation", Schema = "HR")]
    public class OnboardingInvitation
    {
        [Key]
        public int OnboardingInvitationId { get; set; }

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        [Required]
        [StringLength(500)]
        public string InvitationToken { get; set; } = string.Empty;
        public Guid InvitationGuid { get; set; }
        public DateTime InvitationSentOn { get; set; }
        public bool IsEmailDelivered { get; set; }
        public int InvitationVersion { get; set; } = 1;
        public DateTime? EmailDeliveredOn { get; set; }
        public DateTime ExpiryDate { get; set; }

        public DateTime? FirstOpenedOn { get; set; }

        public DateTime? LastOpenedOn { get; set; }

        public DateTime? AcceptedOn { get; set; }

        public int ReminderCount { get; set; }

        public DateTime? LastReminderOn { get; set; }

        public bool IsExpired { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsCancelled { get; set; }

        [StringLength(1000)]
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