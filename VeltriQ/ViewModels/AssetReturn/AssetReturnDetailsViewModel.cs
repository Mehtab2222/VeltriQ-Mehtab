namespace VeltriQ.ViewModels.AssetReturn
{
    public class AssetReturnDetailsViewModel
    {
        public int EmployeeAssetId { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public int AssetInventoryId { get; set; }

        public string InventoryCode { get; set; } = string.Empty;

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public string AssetCategory { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ModelName { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public string AssetCondition { get; set; } = string.Empty;

        public DateTime? IssueDate { get; set; }

        public string InventoryStatus { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}