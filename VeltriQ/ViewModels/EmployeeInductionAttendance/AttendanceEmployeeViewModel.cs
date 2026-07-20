namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class AttendanceEmployeeViewModel
    {
        public int EmployeeInductionSessionId { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public int AttendanceStatus { get; set; }

        public string AttendanceStatusText { get; set; } = "Pending";

        public bool IsSelected { get; set; }

        public string? Remarks { get; set; }
    }
}