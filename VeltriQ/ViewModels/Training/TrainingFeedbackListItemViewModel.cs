namespace VeltriQ.ViewModels.Training
{
    public class TrainingFeedbackListItemViewModel
    {
        public int TrainingEnrollmentId { get; set; }
        public int TrainingScheduleId { get; set; }
        public string ScheduleCode { get; set; } = string.Empty;
        public string TrainingName { get; set; } = string.Empty;
        public string TrainerName { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsSubmitted { get; set; }
        public int? TrainingFeedbackId { get; set; }
        public int? TrainerRating { get; set; }
        public int? ContentRating { get; set; }
        public int? VenueRating { get; set; }
        public int? OverallRating { get; set; }
        public bool? WouldRecommend { get; set; }
        public string? Comments { get; set; }
        public DateTime? SubmittedOn { get; set; }
    }

    public class SaveFeedbackDto
    {
        public int TrainingEnrollmentId { get; set; }
        public int TrainerRating { get; set; }
        public int ContentRating { get; set; }
        public int VenueRating { get; set; }
        public int OverallRating { get; set; }
        public bool WouldRecommend { get; set; }
        public string? Comments { get; set; }
    }
}