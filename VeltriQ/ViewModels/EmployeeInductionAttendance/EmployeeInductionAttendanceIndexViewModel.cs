using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class EmployeeInductionAttendanceIndexViewModel
    {
        public int? InductionProgramMasterId { get; set; }

        public int? InductionSessionMasterId { get; set; }

        public List<SelectListItem> Programs { get; set; } = new();

        public List<SelectListItem> Sessions { get; set; } = new();
    }
}