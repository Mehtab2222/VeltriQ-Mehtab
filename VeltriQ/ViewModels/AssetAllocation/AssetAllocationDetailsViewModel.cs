namespace VeltriQ.ViewModels.AssetAllocation
{
    public class AssetAllocationDetailsViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Designation { get; set; } = "";
        public string Branch { get; set; } = "";
        public DateTime? JoiningDate { get; set; }

        public List<AllocatedAssetItemViewModel> AllocatedAssets { get; set; } = new();
    }

    public class AllocatedAssetItemViewModel
    {
        public int EmployeeAssetId { get; set; }
        public string AssetCode { get; set; } = "";
        public string AssetName { get; set; } = "";
        public string AssetCategory { get; set; } = "";
        public string BrandName { get; set; } = "";
        public string ModelName { get; set; } = "";
        public string AllocatedBy { get; set; } = "";
        public DateTime? AllocatedOn { get; set; }
    }
}