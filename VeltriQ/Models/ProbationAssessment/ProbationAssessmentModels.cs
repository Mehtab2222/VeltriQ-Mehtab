using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.ProbationAssessment
{
    [Table("ProbationCriteriaMaster")]
    public class ProbationCriteriaMaster
    {
        [Key]
        public int CriteriaId { get; set; }
        public string CriteriaCode { get; set; } = string.Empty;
        public string CriteriaName { get; set; } = string.Empty;
        public string? CriteriaDescription { get; set; }
        public string Category { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string CompanyId { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
    }

    [Table("ProbationAssessmentMaster")]
    public class ProbationAssessmentMasterModel
    {
        [Key]
        public int AssessmentId { get; set; }
        public string EmployeeNo { get; set; } = string.Empty;
        public string AppraiserId { get; set; } = string.Empty;
        public DateTime? ProbationStartDate { get; set; }
        public DateTime? ProbationEndDate { get; set; }
        public string OverallStatus { get; set; } = "Pending";
        public string? FinalDecision { get; set; }
        public DateTime? FinalDecisionDate { get; set; }
        public string? HRRemarks { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [NotMapped] public string EmployeeName { get; set; } = string.Empty;
        [NotMapped] public string Designation { get; set; } = string.Empty;
        [NotMapped] public string Department { get; set; } = string.Empty;
        [NotMapped] public string AppraiserName { get; set; } = string.Empty;
    }

    [Table("ProbationAssessmentDetails")]
    public class ProbationAssessmentDetailsModel
    {
        [Key]
        public int DetailId { get; set; }
        public int AssessmentId { get; set; }
        public int CheckpointNo { get; set; }
        public string CheckpointLabel { get; set; } = string.Empty;
        public DateTime? ScheduledDate { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal? ScorePersonal { get; set; }
        public decimal? ScoreOperational { get; set; }
        public decimal? OverallScore { get; set; }
        public string? OverallGrade { get; set; }
        public string? Strengths { get; set; }
        public string? DevelopmentAreas { get; set; }
        public string? Progress { get; set; }
        public string? EmployeeComments { get; set; }
        public bool SigManager { get; set; }
        public DateTime? SigManagerDate { get; set; }
        public bool SigEmployee { get; set; }
        public DateTime? SigEmployeeDate { get; set; }
        public bool SigHR { get; set; }
        public DateTime? SigHRDate { get; set; }
        public string? CheckpointDecision { get; set; }
        public DateTime? CheckpointDecisionDate { get; set; }
        public string? HRComments { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [NotMapped] public bool IsLocked { get; set; }
        [NotMapped] public bool IsCurrent { get; set; }
    }

    [Table("ProbationAssessmentRatings")]
    public class ProbationAssessmentRatingsModel
    {
        [Key]
        public int RatingId { get; set; }
        public int DetailId { get; set; }
        public int CriteriaId { get; set; }
        public string? Rating { get; set; }
        public int? RatingScore { get; set; }
        public string CompanyId { get; set; } = string.Empty;

        [NotMapped] public string CriteriaCode { get; set; } = string.Empty;
        [NotMapped] public string CriteriaName { get; set; } = string.Empty;
        [NotMapped] public string? CriteriaDescription { get; set; }
        [NotMapped] public string Category { get; set; } = string.Empty;
        [NotMapped] public int DisplayOrder { get; set; }
    }

    [Table("ProbationExtensionLog")]
    public class ProbationExtensionLogModel
    {
        [Key]
        public int ExtensionId { get; set; }
        public int AssessmentId { get; set; }
        public string EmployeeNo { get; set; } = string.Empty;
        public int DetailId { get; set; }
        public DateTime? OldProbationEndDate { get; set; }
        public DateTime? NewProbationEndDate { get; set; }
        public int? NewCheckpointNo { get; set; }
        public DateTime? NewCheckpointDate { get; set; }
        public int? ExtendedBy { get; set; }
        public DateTime? ExtendedOn { get; set; } = DateTime.Now;
        public string? Reason { get; set; }
        public string CompanyId { get; set; } = string.Empty;
    }
}