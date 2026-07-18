namespace VeltriQ.ViewModels.EmployeeAssets
{
    public class EmployeeAssetsIndexViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int ActiveAssets { get; set; }

        public int TotalAssetsIssued { get; set; }

        public DateTime? LastAllocationDate { get; set; }

        public bool HasActiveAssets { get; set; }
    }
}