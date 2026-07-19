namespace VeltriQ.ViewModels.EmployeeInduction
{
    public class EmployeeInductionListItemViewModel
    {
        public int EmployeeInductionId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string ProgramName { get; set; } = string.Empty;

        public DateTime AssignedOn { get; set; }

        public DateTime StartDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}