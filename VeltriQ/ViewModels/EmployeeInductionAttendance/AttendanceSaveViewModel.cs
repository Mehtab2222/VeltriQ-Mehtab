namespace VeltriQ.ViewModels.EmployeeInductionAttendance
{
    public class AttendanceSaveViewModel
    {
        public int InductionProgramMasterId { get; set; }

        public int InductionSessionMasterId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public List<AttendanceSaveItemViewModel> Employees { get; set; } = new();
    }
}