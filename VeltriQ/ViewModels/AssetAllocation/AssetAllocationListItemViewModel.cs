namespace VeltriQ.ViewModels.AssetAllocation
{
    public class AssetAllocationListItemViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = "";

        public string EmployeeName { get; set; } = "";

        public string Department { get; set; } = "";

        public DateTime? JoiningDate { get; set; }

        public int TotalAssets { get; set; }

        public string AllocationStatus { get; set; } = "";
    }
}