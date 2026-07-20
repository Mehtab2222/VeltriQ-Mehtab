namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class MarkAttendanceEmployeeViewModel
    {
        public int EmployeeInductionId { get; set; }

        public int EmployeeInductionSessionId { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public string DepartmentName { get; set; }
        public string Designation { get; set; } = string.Empty;
        public int AttendanceStatus { get; set; }

        public string? Remarks { get; set; }
    }
}
