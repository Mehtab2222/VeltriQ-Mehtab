using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingIdentity", Schema = "HR")]
    public class EmployeeOnboardingIdentity
    {
        [Key]
        public int EmployeeOnboardingIdentityId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // DOCUMENT DETAILS
        //====================================================

        [StringLength(150)]
        public string? DocumentName { get; set; }

        [StringLength(100)]
        public string? DocumentNumber { get; set; }

        public bool Uploaded { get; set; }

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