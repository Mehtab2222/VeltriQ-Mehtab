using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.EmployeeAssets
{
    public class EmployeeAssetAllocateViewModel
    {
        [Required(ErrorMessage = "Please select an employee.")]
        public int? EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select an asset.")]
        public int? AssetInventoryId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = DateTime.Today;

        [StringLength(500)]
        public string? Remarks { get; set; }

        public List<SelectListItem> AvailableAssets { get; set; } = new();

        // Added for global index allocation lookup
        public List<SelectListItem> Employees { get; set; } = new();
    }
}