using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.Recruitment
{
    public static class RecommendationOptions
    {
        public const string StrongYes = "StrongYes";
        public const string Yes = "Yes";
        public const string No = "No";
        public const string StrongNo = "StrongNo";
    }

    public class InterviewFeedback
    {
        [Key]
        public int InterviewFeedbackId { get; set; }

        [Required]
        public int ScheduledInterviewId { get; set; }
        [ForeignKey(nameof(ScheduledInterviewId))]
        public virtual ScheduledInterview? ScheduledInterview { get; set; }

        [Range(1, 5)]
        public int SkillRating { get; set; }

        [Range(1, 5)]
        public int CommunicationRating { get; set; }

        [Range(1, 5)]
        public int CultureFitRating { get; set; }

        [Required]
        [StringLength(20)]
        public string OverallRecommendation { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public DateTime SubmittedOn { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}