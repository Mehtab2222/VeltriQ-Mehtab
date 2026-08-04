using Microsoft.AspNetCore.Mvc.Rendering;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.ViewModels.Attendance
{
    public class WeeklyOffPolicyViewModel
    {
        public WeeklyOffPolicy WeeklyOffPolicy { get; set; }
            = new();

        public List<WeeklyOffPolicyDetailViewModel> WeeklyOffDetails { get; set; }
            = new();

        public IEnumerable<SelectListItem> Companies { get; set; }
            = new List<SelectListItem>();
    }
}