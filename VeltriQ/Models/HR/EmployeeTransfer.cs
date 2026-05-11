namespace VeltriQ.Models.HR
{
    public class EmployeeTransfer
    {
        public int EmployeeTransferId { get; set; }

        public int EmployeeId { get; set; }

        public int CurrentBranchId { get; set; }

        public int NewBranchId { get; set; }

        public int? CurrentDepartmentId { get; set; }

        public int? NewDepartmentId { get; set; }

        public int? CurrentDesignationId { get; set; }

        public int? NewDesignationId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string TransferReason { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        // NAVIGATION

        public Employee Employee { get; set; }

        public Branch CurrentBranch { get; set; }

        public Branch NewBranch { get; set; }
    }
}