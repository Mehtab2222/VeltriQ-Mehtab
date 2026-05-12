namespace VeltriQ.Models.HR
{
    public class EmployeeSuspension
    {
        public int EmployeeSuspensionId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime SuspensionDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? SuspensionReason { get; set; }

        public string? SuspensionType { get; set; }

        public string? Status { get; set; }

        public bool IsReinstated { get; set; }

        public DateTime CreatedOn { get; set; }

        // NAVIGATION

        public Employee? Employee { get; set; }
    }
}