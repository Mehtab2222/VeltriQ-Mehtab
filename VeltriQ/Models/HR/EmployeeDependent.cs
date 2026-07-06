using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR
{
    [Table("EmployeeDependent", Schema = "HR")]
    public class EmployeeDependent
    {
        [Key]
        public int EmployeeDependentId { get; set; }

        //====================================================
        // EMPLOYEE
        //====================================================

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        //====================================================
        // DEPENDENT INFORMATION
        //====================================================

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string? Gender { get; set; }

        [StringLength(100)]
        public string? Occupation { get; set; }

        //====================================================
        // BENEFITS
        //====================================================

        public bool IsDependent { get; set; } = true;

        public bool IsNominee { get; set; }

        public decimal? NomineePercentage { get; set; }

        public bool IsCoveredByInsurance { get; set; }

        //====================================================
        // CONTACT
        //====================================================

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

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