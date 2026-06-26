using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeePersonal", Schema = "HR")]
    public class OnboardingEmployeePersonal
    {
        [Key]
        public int OnboardingEmployeePersonalId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // PERSONAL INFORMATION
        // ==========================================

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string? Gender { get; set; }

        [StringLength(20)]
        public string? MaritalStatus { get; set; }

        [StringLength(20)]
        public string? BloodGroup { get; set; }

        public int? NationalityId { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public virtual Nationality? Nationality { get; set; }

        [StringLength(100)]
        public string? PlaceOfBirth { get; set; }

        [StringLength(100)]
        public string? BirthCountry { get; set; }

        [StringLength(100)]
        public string? MotherTongue { get; set; }

        [StringLength(100)]
        public string? Religion { get; set; }

        public bool IsDifferentlyAbled { get; set; }

        [StringLength(250)]
        public string? DisabilityDetails { get; set; }

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