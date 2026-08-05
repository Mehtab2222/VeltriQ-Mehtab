using Microsoft.AspNetCore.Mvc.Rendering;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.ViewModels.Attendance
{
    public class EmployeeShiftViewModel
    {
        public EmployeeShift EmployeeShift { get; set; } = new();

        public IEnumerable<SelectListItem> Companies { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Employees { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Shifts { get; set; }
            = new List<SelectListItem>();
    }
}