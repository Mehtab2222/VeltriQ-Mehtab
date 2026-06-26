using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingCandidate", Schema = "HR")]
    public class OnboardingCandidate
    {
        [Key]
        public int OnboardingCandidateId { get; set; }

        [StringLength(20)]
        public string CandidateCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [StringLength(15)]
        public string? MobileNumber { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        public int DesignationId { get; set; }

        [ForeignKey(nameof(DesignationId))]
        public virtual Designation? Designation { get; set; }

        public int EmploymentTypeMasterId { get; set; }

        [ForeignKey(nameof(EmploymentTypeMasterId))]
        public virtual EmploymentTypeMaster? EmploymentType { get; set; }

        [StringLength(200)]
        public string? JobProfile { get; set; }

        [StringLength(50)]
        public string? ManpowerRequestCode { get; set; }

        public DateTime? ExpectedJoiningDate { get; set; }

        public int OnboardingStatusMasterId { get; set; }

        [ForeignKey(nameof(OnboardingStatusMasterId))]
        public virtual OnboardingStatusMaster? Status { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}