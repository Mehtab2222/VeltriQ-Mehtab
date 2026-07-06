using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR
{
    [Table("EmployeeEmergencyContact", Schema = "HR")]
    public class EmployeeEmergencyContact
    {
        [Key]
        public int EmployeeEmergencyContactId { get; set; }

        //====================================================
        // EMPLOYEE
        //====================================================

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        //====================================================
        // CONTACT DETAILS
        //====================================================

        [Required]
        [StringLength(100)]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string MobileNumber { get; set; } = string.Empty;

        [StringLength(20)]
        public string? AlternateMobileNumber { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        //====================================================
        // ADDRESS
        //====================================================

        [StringLength(250)]
        public string? AddressLine1 { get; set; }

        [StringLength(250)]
        public string? AddressLine2 { get; set; }

        [StringLength(150)]
        public string? Landmark { get; set; }

        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country? Country { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City? City { get; set; }

        [StringLength(20)]
        public string? PostalCode { get; set; }

        //====================================================
        // OTHER DETAILS
        //====================================================

        [StringLength(100)]
        public string? Occupation { get; set; }

        public bool LivesWithEmployee { get; set; }

        public bool IsPrimaryContact { get; set; }

        public int PriorityOrder { get; set; } = 1;

        public bool IsAuthorizedToReceiveInformation { get; set; } = true;

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