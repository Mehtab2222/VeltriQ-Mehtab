namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class AttendanceRegisterItemViewModel
    {
        public int EmployeeInductionAttendanceId { get; set; }

        public int InductionProgramMasterId { get; set; }

        public string ProgramName { get; set; } = string.Empty;

        public int InductionSessionMasterId { get; set; }

        public string SessionName { get; set; } = string.Empty;

        public DateTime? AttendanceDate { get; set; }

        public int TotalEmployees { get; set; }

        public int PresentCount { get; set; }

        public int AbsentCount { get; set; }

        public int LateCount { get; set; }

        public int PendingCount { get; set; }

        public string Status { get; set; } = string.Empty;

        public bool IsLocked { get; set; }
        public string Action { get; set; } = string.Empty;
    }
}