using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeeAddress", Schema = "HR")]
    public class OnboardingEmployeeAddress
    {
        [Key]
        public int OnboardingEmployeeAddressId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // ADDRESS INFORMATION
        // ==========================================

        [Required]
        [StringLength(30)]
        public string AddressType { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string AddressLine1 { get; set; } = string.Empty;

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

        [StringLength(20)]
        public string? ResidenceType { get; set; }
        public DateTime? StayFrom { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSameAsPermanentAddress { get; set; }
        // ==========================================
        // AUDIT
        // ==========================================

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}