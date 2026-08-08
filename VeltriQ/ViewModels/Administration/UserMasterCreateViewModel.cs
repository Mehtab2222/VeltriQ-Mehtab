using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Administration
{
    public class UserMasterCreateViewModel
    {
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Please select an employee.")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeCode { get; set; }

        public string? OfficialEmail { get; set; }


        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please select a role.")]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please select a company.")]
        [Display(Name = "Company Access")]
        public int CompanyId { get; set; }


        [Display(Name = "Branch")]
        public int? BranchId { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 characters."
        )]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please confirm the password.")]
        [DataType(DataType.Password)]
        [Compare(
            "Password",
            ErrorMessage = "Password and confirm password do not match."
        )]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;


        public bool IsActive { get; set; } = true;


        // Dropdowns

        public List<SelectListItem> Employees { get; set; }
            = new();

        public List<SelectListItem> Roles { get; set; }
            = new();

        public List<SelectListItem> Companies { get; set; }
            = new();

        public List<SelectListItem> Branches { get; set; }
            = new();
    }
}