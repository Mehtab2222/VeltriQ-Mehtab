using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Administration
{
    public class UserMasterIndexViewModel
    {
        public List<UserMasterRowViewModel> Users { get; set; } = new();
        public List<EmployeeWithoutUserViewModel> EmployeesWithoutUsers { get; set; } = new();
    }

    public class UserMasterRowViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; } = "-";
        public string CompanyName { get; set; } = "-";
        public string BranchName { get; set; } = "-";
        public bool IsActive { get; set; }
    }

    public class EmployeeWithoutUserViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string? OfficialEmail { get; set; }
        public string BranchName { get; set; } = "-";
    }

 

    
}
