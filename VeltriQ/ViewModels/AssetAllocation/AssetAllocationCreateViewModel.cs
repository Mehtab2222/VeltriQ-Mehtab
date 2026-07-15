using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.AssetAllocation
{
    public class AssetAllocationCreateViewModel
    {
        //====================================================
        // DROPDOWNS
        //====================================================

        public int? EmployeeId { get; set; }

        public int? AssetMasterId { get; set; }

        public List<SelectListItem> Employees { get; set; } = new();

        public List<SelectListItem> Assets { get; set; } = new();

        //====================================================
        // GRID
        //====================================================

        public List<AssetAllocationGridItemViewModel> Items { get; set; } = new();
    }
}