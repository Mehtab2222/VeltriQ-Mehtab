using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Attendance
{
    public class ShiftViewModel
    {
        public int ShiftMasterId { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [Required]
        [Display(Name = "Attendance Policy")]
        public int AttendancePolicyId { get; set; }

        [Required]
        [Display(Name = "Shift Code")]
        public string ShiftCode { get; set; } = "";

        [Required]
        [Display(Name = "Shift Name")]
        public string ShiftName { get; set; } = "";

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public int GraceInMinutes { get; set; }

        public int GraceOutMinutes { get; set; }

        public decimal FullDayHours { get; set; }

        public decimal HalfDayHours { get; set; }

        public decimal MinimumWorkingHours { get; set; }

        public bool IsNightShift { get; set; }

        public bool IsFlexibleShift { get; set; }

        public bool IsCrossDayShift { get; set; }

        public List<ShiftBreakViewModel> Breaks { get; set; }
            = new();

        public IEnumerable<SelectListItem> Companies { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Branches { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> AttendancePolicies { get; set; }
            = new List<SelectListItem>();
    }
}