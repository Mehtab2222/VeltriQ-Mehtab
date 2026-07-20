namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class AttendanceSaveViewModel
    {
        public int? EmployeeInductionAttendanceId { get; set; }

        public int InductionProgramMasterId { get; set; }

        public int InductionSessionMasterId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public List<AttendanceEmployeeViewModel> Employees { get; set; } = new();
    }
}