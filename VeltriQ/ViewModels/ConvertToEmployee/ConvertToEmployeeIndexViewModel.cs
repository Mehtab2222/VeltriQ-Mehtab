using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.ConvertToEmployee
{
    public class ConvertToEmployeeIndexViewModel
    {
        //====================================================
        // FILTERS
        //====================================================

        public string? SearchText { get; set; }

        public int? DepartmentId { get; set; }

        public string? ConversionStatus { get; set; }

        public int? ManpowerRequestId { get; set; }

        //====================================================
        // DROPDOWNS
        //====================================================

        public List<SelectListItem> Departments { get; set; } = new();

        public List<SelectListItem> ConversionStatuses { get; set; } = new();

        public List<SelectListItem> ManpowerRequests { get; set; } = new();

        //====================================================
        // DASHBOARD
        //====================================================

        public int TotalApproved { get; set; }

        public int PendingConversion { get; set; }

        public int Converted { get; set; }

        public int ApprovedToday { get; set; }

        //====================================================
        // GRID
        //====================================================

        public List<ConvertToEmployeeListItemViewModel> Items { get; set; }
            = new();
    }
}