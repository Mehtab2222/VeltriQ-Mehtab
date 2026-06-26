using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Onboarding Template")]
        public int OnboardingTemplateId { get; set; }

        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Templates { get; set; } = new List<SelectListItem>();
    }
}