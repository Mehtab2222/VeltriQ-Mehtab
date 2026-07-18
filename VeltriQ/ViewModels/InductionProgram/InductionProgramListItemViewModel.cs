namespace VeltriQ.ViewModels.InductionProgram
{
    public class InductionProgramListItemViewModel
    {
        public int InductionProgramMasterId { get; set; }

        public string ProgramCode { get; set; } = string.Empty;

        public string ProgramName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int DurationInDays { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}