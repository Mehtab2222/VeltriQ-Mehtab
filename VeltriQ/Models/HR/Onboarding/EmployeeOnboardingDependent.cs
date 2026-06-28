using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingDependent", Schema = "HR")]
    public class EmployeeOnboardingDependent
    {
        [Key]
        public int EmployeeOnboardingDependentId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // DEPENDENT DETAILS
        //====================================================

        [StringLength(150)]
        public string? FullName { get; set; }

        [StringLength(100)]
        public string? Relationship { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsNominee { get; set; }

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