using VeltriQ.Models.HR;

namespace VeltriQ.Models
{
    public class AssetInventory
    {
        public int AssetInventoryId { get; set; }

        public string? InventoryCode { get; set; }

        public int AssetMasterId { get; set; }

        public virtual AssetMaster? AssetMaster { get; set; }

        public string? SerialNumber { get; set; }

        public string? AssetCondition { get; set; }

        public string? InventoryStatus { get; set; }
  
        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchaseCost { get; set; }

        public string? VendorName { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
