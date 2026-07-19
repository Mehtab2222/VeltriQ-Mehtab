using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.EmployeeInduction
{
    public class EmployeeInductionCreateViewModel
    {
        [Required(ErrorMessage = "Please select an induction program.")]
        public int InductionProgramMasterId { get; set; }

        [Required(ErrorMessage = "Please select at least one employee.")]
        public List<int> EmployeeIds { get; set; } = new();

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime? ExpectedCompletionDate { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public List<SelectListItem> Programs { get; set; } = new();
    }
}