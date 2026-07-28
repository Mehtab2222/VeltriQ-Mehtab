namespace VeltriQ.ViewModels.Recruitment
{
    public class MyScheduledInterviewViewModel
    {
        public int ScheduledInterviewId { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public string MprTitle { get; set; } = string.Empty;
        public string RoundTypeName { get; set; } = string.Empty;
        public DateTime SlotDateTime { get; set; }
        public int? MatchPercentage { get; set; }
    }

    public class MyInterviewHistoryItemViewModel
    {
        public int ScheduledInterviewId { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public string MprTitle { get; set; } = string.Empty;
        public string RoundTypeName { get; set; } = string.Empty;
        public DateTime SlotDateTime { get; set; }
        public int SkillRating { get; set; }
        public int CommunicationRating { get; set; }
        public int CultureFitRating { get; set; }
        public string OverallRecommendation { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime SubmittedOn { get; set; }
    }

    public class SubmitInterviewFeedbackDto
    {
        public int ScheduledInterviewId { get; set; }
        public int SkillRating { get; set; }
        public int CommunicationRating { get; set; }
        public int CultureFitRating { get; set; }
        public string OverallRecommendation { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}