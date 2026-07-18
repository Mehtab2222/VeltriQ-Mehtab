using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.InductionSessions
{
    public class InductionSessionCreateViewModel
    {
        public int InductionProgramMasterId { get; set; }

        public string ProgramName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Session title is required.")]
        [StringLength(150)]
        public string SessionTitle { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, 100)]
        public int SessionOrder { get; set; }

        [Range(1, 1440)]
        public int DurationInMinutes { get; set; }

        public bool IsMandatory { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}