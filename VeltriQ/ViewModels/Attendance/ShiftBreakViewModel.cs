namespace VeltriQ.ViewModels.Attendance
{
    public class ShiftBreakViewModel
    {
        public int ShiftBreakId { get; set; }

        public string BreakName { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public bool IsPaidBreak { get; set; }
    }
}