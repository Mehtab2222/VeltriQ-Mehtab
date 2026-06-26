using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("OnboardingEmployeeBank", Schema = "HR")]
    public class OnboardingEmployeeBank
    {
        [Key]
        public int OnboardingEmployeeBankId { get; set; }

        // ==========================================
        // ONBOARDING EMPLOYEE
        // ==========================================

        public int OnboardingEmployeeId { get; set; }

        [ForeignKey(nameof(OnboardingEmployeeId))]
        public virtual OnboardingEmployee? OnboardingEmployee { get; set; }

        // ==========================================
        // BANK DETAILS
        // ==========================================

        [Required]
        [StringLength(150)]
        public string BankName { get; set; } = string.Empty;

        [StringLength(150)]
        public string? BranchName { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountHolderName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string AccountType { get; set; } = string.Empty;

        [StringLength(30)]
        public string? IFSCCode { get; set; }

        [StringLength(30)]
        public string? SWIFTCode { get; set; }

        [StringLength(50)]
        public string? IBAN { get; set; }

        [StringLength(10)]
        public string? CurrencyCode { get; set; }

        public bool IsPrimary { get; set; } = true;

        // ==========================================
        // VERIFICATION
        // ==========================================

        public bool IsVerified { get; set; }

        public DateTime? VerifiedOn { get; set; }

        [StringLength(450)]
        public string? VerifiedBy { get; set; }

        // ==========================================
        // REMARKS
        // ==========================================

        [StringLength(500)]
        public string? Remarks { get; set; }

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