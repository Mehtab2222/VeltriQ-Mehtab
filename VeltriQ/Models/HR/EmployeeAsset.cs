using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class EmployeeAsset
    {
        public int EmployeeAssetId { get; set; }

        public int EmployeeId { get; set; }

        public int AssetInventoryId { get; set; }

        public string? AssetNumber { get; set; }

        public string? SerialNumber { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? AssetStatus { get; set; }

        public string? ConditionStatus { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual AssetInventory? AssetInventory { get; set; }
    }
}