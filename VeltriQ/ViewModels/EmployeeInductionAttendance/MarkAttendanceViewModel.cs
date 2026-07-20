namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class MarkAttendanceViewModel
    {
        public int EmployeeInductionAttendanceId { get; set; }
        public int ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public int SessionId { get; set; }
        public string? SessionName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsViewMode { get; set; }
        public bool IsLocked { get; set; }
        public List<MarkAttendanceEmployeeViewModel> Employees { get; set; } = new();
    }
}