namespace VeltriQ.ViewModels.AssetAllocation
{
    public class AssetAllocationGridItemViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = "";

        public string EmployeeName { get; set; } = "";

        public string Department { get; set; } = "";

        public int AssetMasterId { get; set; }

        public string AssetCode { get; set; } = "";

        public string AssetName { get; set; } = "";

        public string AssetCategory { get; set; } = "";
    }
}