namespace VeltriQ.ViewModels.InductionSessions
{
    public class InductionSessionListItemViewModel
    {
        public int InductionSessionMasterId { get; set; }

        public int InductionProgramMasterId { get; set; }

        public string ProgramName { get; set; } = string.Empty;

        public string SessionCode { get; set; } = string.Empty;

        public string SessionTitle { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SessionOrder { get; set; }

        public int DurationInMinutes { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}