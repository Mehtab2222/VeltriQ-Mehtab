using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingAddress", Schema = "HR")]
    public class EmployeeOnboardingAddress
    {
        [Key]
        public int EmployeeOnboardingAddressId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // CURRENT ADDRESS
        //====================================================

        [StringLength(250)]
        public string? CurrentAddressLine1 { get; set; }

        [StringLength(250)]
        public string? CurrentAddressLine2 { get; set; }

        [StringLength(100)]
        public string? CurrentCity { get; set; }

        [StringLength(100)]
        public string? CurrentState { get; set; }

        [StringLength(100)]
        public string? CurrentCountry { get; set; }

        [StringLength(20)]
        public string? CurrentPincode { get; set; }

        //====================================================
        // PERMANENT ADDRESS
        //====================================================

        public bool IsPermanentAddressSame { get; set; }

        [StringLength(250)]
        public string? PermanentAddressLine1 { get; set; }

        [StringLength(250)]
        public string? PermanentAddressLine2 { get; set; }

        [StringLength(100)]
        public string? PermanentCity { get; set; }

        [StringLength(100)]
        public string? PermanentState { get; set; }

        [StringLength(100)]
        public string? PermanentCountry { get; set; }

        [StringLength(20)]
        public string? PermanentPincode { get; set; }

        //====================================================
        // WORKFLOW
        //====================================================



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