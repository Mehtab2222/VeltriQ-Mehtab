using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.InductionProgram
{
    public class InductionProgramEditViewModel
    {
        public int InductionProgramMasterId { get; set; }

        [Required(ErrorMessage = "Program Name is required.")]
        [StringLength(150)]
        public string ProgramName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, 365)]
        public int DurationInDays { get; set; }

        public bool IsActive { get; set; }
    }
}