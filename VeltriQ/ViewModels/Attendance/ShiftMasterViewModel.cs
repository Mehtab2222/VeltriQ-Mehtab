using Microsoft.AspNetCore.Mvc.Rendering;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.ViewModels.Attendance
{
    public class ShiftMasterViewModel
    {
        public ShiftMaster Shift { get; set; } = new();

        public List<ShiftBreakViewModel> ShiftBreaks { get; set; }
            = new List<ShiftBreakViewModel>();

        public IEnumerable<SelectListItem> Companies { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Branches { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> AttendancePolicies { get; set; }
            = new List<SelectListItem>();
    }
}