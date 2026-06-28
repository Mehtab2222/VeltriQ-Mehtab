using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingQualification", Schema = "HR")]
    public class EmployeeOnboardingQualification
    {
        [Key]
        public int EmployeeOnboardingQualificationId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // QUALIFICATION
        //====================================================

        [StringLength(200)]
        public string? QualificationName { get; set; }

        [StringLength(250)]
        public string? Institute { get; set; }

        public int? PassingYear { get; set; }

        public decimal? Percentage { get; set; }

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