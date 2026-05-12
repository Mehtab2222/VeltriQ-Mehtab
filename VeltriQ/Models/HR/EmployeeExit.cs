namespace VeltriQ.Models.HR
{
    public class EmployeeExit
    {
        public int EmployeeExitId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ResignationDate { get; set; }

        public DateTime LastWorkingDate { get; set; }

        public string? ExitType { get; set; }

        public string? ExitReason { get; set; }

        public string? Status { get; set; }

        public bool AssetsReturned { get; set; }

        public bool FnFCompleted { get; set; }

        public string? HRRemarks { get; set; }

        public DateTime CreatedOn { get; set; }

        // NAVIGATION

        public Employee? Employee { get; set; }
    }
}