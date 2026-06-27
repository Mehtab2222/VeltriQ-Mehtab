using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingActivity", Schema = "HR")]
    public class EmployeeOnboardingActivity
    {
        [Key]
        public int EmployeeOnboardingActivityId { get; set; }

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        public int OnboardingActivityMasterId { get; set; }

        [ForeignKey(nameof(OnboardingActivityMasterId))]
        public virtual OnboardingActivityMaster? Activity { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? CompletedOn { get; set; }

        [StringLength(450)]
        public string? CompletedBy { get; set; }

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