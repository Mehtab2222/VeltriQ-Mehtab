using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.AssetInventory
{
    public class AssetInventoryCreateViewModel
    {
        //====================================================
        // ASSET
        //====================================================

        [Required]
        public int AssetMasterId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; } = 1;

        //====================================================
        // PURCHASE
        //====================================================

        public DateTime? PurchaseDate { get; set; }

        public decimal? PurchaseCost { get; set; }

        public string? VendorName { get; set; }

        //====================================================
        // INVENTORY
        //====================================================

        public string? AssetCondition { get; set; }

        public string? Remarks { get; set; }

        //====================================================
        // SERIAL NUMBERS
        //====================================================

        public List<string> SerialNumbers { get; set; } = new();

        //====================================================
        // DROPDOWN
        //====================================================

        public List<SelectListItem> Assets { get; set; } = new();
    }
}