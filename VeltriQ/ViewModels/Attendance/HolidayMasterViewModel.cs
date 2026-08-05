using Microsoft.AspNetCore.Mvc.Rendering;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.ViewModels.Attendance
{
    public class HolidayMasterViewModel
    {
        public HolidayMaster HolidayMaster { get; set; } = new();

        public IEnumerable<SelectListItem> Companies { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Branches { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> HolidayTypes { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> HalfDaySessions { get; set; }
            = new List<SelectListItem>();
    }
}