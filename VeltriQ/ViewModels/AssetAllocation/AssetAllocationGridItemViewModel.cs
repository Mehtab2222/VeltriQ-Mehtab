namespace VeltriQ.ViewModels.AssetAllocation
{
    public class AssetAllocationGridItemViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = "";

        public string EmployeeName { get; set; } = "";

        public string Department { get; set; } = "";

        public int AssetInventoryId { get; set; }

        public string? InventoryCode { get; set; }

        public string? AssetName { get; set; }

        public string? AssetCode { get; set; }

        public string? SerialNumber { get; set; }

        public string AssetCategory { get; set; } = "";
    }
}