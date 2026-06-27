using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingSection", Schema = "HR")]
    public class EmployeeOnboardingSection
    {
        [Key]
        public int EmployeeOnboardingSectionId { get; set; }

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        public int OnboardingSectionMasterId { get; set; }

        [ForeignKey(nameof(OnboardingSectionMasterId))]
        public virtual OnboardingSectionMaster? Section { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        //====================================================
        // WORKFLOW
        //====================================================

        public bool IsCompleted { get; set; } = false;

        public DateTime? CompletedOn { get; set; }

        //====================================================
        // HR REVIEW
        //====================================================

        [StringLength(50)]
        public string ReviewStatus { get; set; } = "Pending";

        [StringLength(450)]
        public string? ReviewedBy { get; set; }

        public DateTime? ReviewedOn { get; set; }

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