namespace VeltriQ.ViewModels.EmployeeAssets
{
    public class EmployeeAssetHistoryItemViewModel
    {
        public int EmployeeAssetId { get; set; }

        public int AssetInventoryId { get; set; }

        public string InventoryCode { get; set; } = string.Empty;

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public string AssetCategory { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ModelName { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public DateTime? IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string AssetStatus { get; set; } = string.Empty;

        public string ConditionStatus { get; set; } = string.Empty;

        public string InventoryStatus { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}