namespace VeltriQ.Models.HR
{
    public class AssetMaster
    {
        public int AssetMasterId { get; set; }

        public string? AssetCode { get; set; }

        public string? AssetName { get; set; }

        public string? AssetCategory { get; set; }

        public string? BrandName { get; set; }

        public string? ModelName { get; set; }

        public bool SerialNumberRequired { get; set; }

        public bool IsReturnable { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}