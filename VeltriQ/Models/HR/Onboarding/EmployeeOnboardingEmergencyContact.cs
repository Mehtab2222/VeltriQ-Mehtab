using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingEmergencyContact", Schema = "HR")]
    public class EmployeeOnboardingEmergencyContact
    {
        [Key]
        public int EmployeeOnboardingEmergencyContactId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // CONTACT DETAILS
        //====================================================

        [StringLength(150)]
        public string? ContactPersonName { get; set; }

        [StringLength(100)]
        public string? Relationship { get; set; }

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [StringLength(20)]
        public string? AlternateMobileNumber { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

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