using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingExperience", Schema = "HR")]
    public class EmployeeOnboardingExperience
    {
        [Key]
        public int EmployeeOnboardingExperienceId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // EXPERIENCE DETAILS
        //====================================================

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Designation { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Department { get; set; }

        public DateTime? JoiningDate { get; set; }

        public DateTime? RelievingDate { get; set; }

        public int? EmploymentTypeMasterId { get; set; }

        [ForeignKey(nameof(EmploymentTypeMasterId))]
        public virtual EmploymentTypeMaster? EmploymentType { get; set; }

        [StringLength(500)]
        public string? Responsibilities { get; set; }

        [StringLength(500)]
        public string? ReasonForLeaving { get; set; }

        [StringLength(500)]
        public string? ExperienceCertificatePath { get; set; }



        //====================================================
        // AUDIT
        //====================================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}