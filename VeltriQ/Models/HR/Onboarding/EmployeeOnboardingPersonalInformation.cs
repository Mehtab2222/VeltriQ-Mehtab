using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmployeeOnboardingPersonalInformation", Schema = "HR")]
    public class EmployeeOnboardingPersonalInformation
    {
        [Key]
        public int EmployeeOnboardingPersonalInformationId { get; set; }

        //====================================================
        // RELATIONSHIP
        //====================================================

        public int EmployeeOnboardingId { get; set; }

        [ForeignKey(nameof(EmployeeOnboardingId))]
        public virtual EmployeeOnboarding? EmployeeOnboarding { get; set; }

        //====================================================
        // BASIC INFORMATION
        //====================================================

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        //====================================================
        // PERSONAL DETAILS
        //====================================================

        [StringLength(20)]
        public string? Gender { get; set; }

        [StringLength(30)]
        public string? MaritalStatus { get; set; }

        [StringLength(10)]
        public string? BloodGroup { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }

        [StringLength(100)]
        public string? Religion { get; set; }

        //====================================================
        // FAMILY INFORMATION
        //====================================================

        [StringLength(150)]
        public string? FatherName { get; set; }

        [StringLength(150)]
        public string? MotherName { get; set; }

        //====================================================
        // CONTACT
        //====================================================
        public string? Email { get; set; }

        public string? MobileNumber { get; set; }

        public string? AlternateMobileNumber { get; set; }

        //====================================================
        // PROFILE
        //====================================================

        [StringLength(500)]
        public string? ProfilePhotoPath { get; set; }

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