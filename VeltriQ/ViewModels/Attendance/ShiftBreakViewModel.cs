using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Attendance
{
    public class ShiftBreakViewModel
    {
        public int ShiftBreakId { get; set; }

        [Required]
        [Display(Name = "Break Name")]
        public string BreakName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Paid Break")]
        public bool IsPaidBreak { get; set; }
    }
}