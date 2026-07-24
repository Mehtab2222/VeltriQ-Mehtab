using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;
using VeltriQ.Models.Recruitment;

namespace VeltriQ.Models.Recruitment
{
    public static class ApplicantStages
    {
        public const string New = "New";
        public const string Screening = "Screening";
        public const string Evaluating = "Evaluating";
        public const string Offered = "Offered";
        public const string Hired = "Hired";
        public const string Rejected = "Rejected";
        public const string Dropout = "Dropout";
    }

    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required]
        [StringLength(20)]
        public string ApplicantCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int ManpowerRequestId { get; set; }
        [ForeignKey(nameof(ManpowerRequestId))]
        public virtual ManpowerRequest? ManpowerRequest { get; set; }

        [StringLength(50)]
        public string? SourceType { get; set; } // Indeed, Portal, Referral, LinkedIn, Other

        public decimal TotalExperience { get; set; }
        public decimal? RelevantExperience { get; set; }

        [Range(0, 100)]
        public int? MatchPercentage { get; set; }

        [StringLength(300)]
        public string? ResumePath { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrentStage { get; set; } = ApplicantStages.New;

        [Required]
        public DateTime StageChangedOn { get; set; }

        [Required]
        public DateTime AppliedOn { get; set; }

        [StringLength(200)]
        public string? RejectReason { get; set; }

        [StringLength(1000)]
        public string? RejectNotes { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}