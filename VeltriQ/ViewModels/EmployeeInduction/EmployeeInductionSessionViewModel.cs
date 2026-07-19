namespace VeltriQ.ViewModels.EmployeeInduction
{
    public class EmployeeInductionSessionViewModel
    {
        public int EmployeeInductionSessionId { get; set; }

        public string SessionTitle { get; set; } = string.Empty;

        public int SessionOrder { get; set; }

        public int DurationInMinutes { get; set; }

        public bool IsMandatory { get; set; }

        public string AttendanceStatus { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}