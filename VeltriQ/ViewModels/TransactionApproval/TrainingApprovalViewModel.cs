using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.TransactionApproval
{
    public class TrainingApprovalViewModel
    {
        public int TransactionApprovalId { get; set; }

        public int TrainingRequestId { get; set; }

        public string RequestNo { get; set; } = string.Empty;

        public int TrainingScheduleId { get; set; }

        public string TrainingName { get; set; } = string.Empty;

        public string TrainingCode { get; set; } = string.Empty;

        public DateTime TrainingDate { get; set; }

        public string TrainerName { get; set; } = string.Empty;

        public string VenueName { get; set; } = string.Empty;

        public string RequestedByName { get; set; } = string.Empty;

        public DateTime RequestDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? ApprovalRemarks { get; set; }

        // Employees included in the request
        public List<TrainingApprovalEmployeeViewModel> Employees { get; set; } = new();

        // Used when approving
        public int? ApproverId { get; set; }

        public IEnumerable<SelectListItem> Approvers { get; set; } = new List<SelectListItem>();
    }

    public class TrainingApprovalEmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public string DesignationName { get; set; } = string.Empty;
    }
}