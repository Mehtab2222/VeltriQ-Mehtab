using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Administration
{
    public class UserMasterEditViewModel
    {
        // =========================================================
        // USER
        // =========================================================

        public string UserId { get; set; } = string.Empty;


        // =========================================================
        // EMPLOYEE INFORMATION
        // Read-only on Edit page
        // =========================================================

        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeCode { get; set; }

        public string? OfficialEmail { get; set; }


        // =========================================================
        // USERNAME
        // =========================================================

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;


        // =========================================================
        // ROLE
        // =========================================================

        [Required(ErrorMessage = "Please select a role.")]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;


        // =========================================================
        // COMPANY ACCESS
        // =========================================================

        [Required(ErrorMessage = "Please select a company.")]
        [Display(Name = "Company Access")]
        public int CompanyId { get; set; }


        // =========================================================
        // BRANCH
        // =========================================================

        [Display(Name = "Branch")]
        public int? BranchId { get; set; }


        // =========================================================
        // PASSWORD
        // Optional during Edit
        // Leave blank = keep existing password
        // =========================================================

        [DataType(DataType.Password)]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 characters."
        )]
        [Display(Name = "New Password")]
        public string? Password { get; set; }


        // =========================================================
        // CONFIRM PASSWORD
        // =========================================================

        [DataType(DataType.Password)]
        [Compare(
            "Password",
            ErrorMessage = "Password and confirm password do not match."
        )]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }


        // =========================================================
        // STATUS
        // =========================================================

        [Display(Name = "Active")]
        public bool IsActive { get; set; }


        // =========================================================
        // DROPDOWNS
        // =========================================================

        public List<SelectListItem> Roles { get; set; }
            = new();

        public List<SelectListItem> Companies { get; set; }
            = new();

        public List<SelectListItem> Branches { get; set; }
            = new();
    }
}