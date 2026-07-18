namespace VeltriQ.ViewModels.EmployeeAssets
{
    public class EmployeeAssetsDetailsViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int ActiveAssets { get; set; }

        public int ReturnedAssets { get; set; }

        public int TotalAssetsIssued { get; set; }

        public List<EmployeeAssetHistoryItemViewModel> Assets { get; set; } = new();
    }
}