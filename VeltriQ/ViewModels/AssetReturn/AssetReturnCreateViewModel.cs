using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.AssetReturn
{
    public class AssetReturnCreateViewModel
    {
        public int EmployeeAssetId { get; set; }

        public int EmployeeId { get; set; }

        public int AssetInventoryId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string InventoryCode { get; set; } = string.Empty;

        public string AssetCode { get; set; } = string.Empty;

        public string AssetName { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public DateTime? IssueDate { get; set; }

        [Required(ErrorMessage = "Return Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please select the asset condition.")]
        [StringLength(100)]
        public string ConditionStatus { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Remarks { get; set; }
    }
}