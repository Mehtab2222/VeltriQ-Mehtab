using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.AssetInventory
{
    public class AssetInventoryEditViewModel
    {
        public int AssetInventoryId { get; set; }

        public string InventoryCode { get; set; } = string.Empty;

        public int AssetMasterId { get; set; }

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public string AssetCategory { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ModelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Serial Number is required.")]
        [StringLength(100)]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Asset Condition is required.")]
        public string AssetCondition { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inventory Status is required.")]
        public string InventoryStatus { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchaseCost { get; set; }

        [StringLength(200)]
        public string? VendorName { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsActive { get; set; }
    }
}