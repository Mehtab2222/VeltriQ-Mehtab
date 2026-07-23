using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.TransactionApproval
{
    public class TransactionApprovalViewModel
    {
        public int TransactionApprovalId { get; set; }

        public string ModuleName { get; set; } = string.Empty;

        public int TransactionId { get; set; }

        public int RequestedBy { get; set; }

        public string RequestedByName { get; set; } = string.Empty;

        public int? ApproverId { get; set; }

        public string? ApproverName { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Remarks { get; set; }

        public DateTime? ActionDate { get; set; }

        // Filters
        public int? EmployeeId { get; set; }

        public string? EmployeeNo { get; set; }

        public string? EmployeeName { get; set; }

        public string? SelectedModule { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Modules { get; set; } = new List<SelectListItem>();
    }
}