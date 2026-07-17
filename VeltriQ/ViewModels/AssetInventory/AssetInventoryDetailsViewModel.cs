namespace VeltriQ.ViewModels.AssetInventory
{
    public class AssetInventoryDetailsViewModel
    {
        public int AssetInventoryId { get; set; }

        public string InventoryCode { get; set; } = string.Empty;

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public string AssetCategory { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ModelName { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public string? AssetCondition { get; set; }

        public string InventoryStatus { get; set; } = string.Empty;

        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchaseCost { get; set; }

        public string? VendorName { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Allocation Information

        public bool IsAllocated { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime? IssueDate { get; set; }
    }
}