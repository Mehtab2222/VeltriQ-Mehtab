using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateViewModel
    {
        public int OnboardingTemplateId { get; set; }

        [Display(Name = "Template Code")]
        public string TemplateCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Template Name")]
        [StringLength(150)]
        public string TemplateName { get; set; } = string.Empty;

        [Display(Name = "Description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Employment Type")]
        public int EmploymentTypeMasterId { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Designation")]
        public int? DesignationId { get; set; }

        [Display(Name = "Version")]
        public string TemplateVersion { get; set; } = "1.0";

        [Display(Name = "Default Template")]
        public bool IsDefault { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        // ==========================
        // DROPDOWNS
        // ==========================

        public IEnumerable<SelectListItem>? EmploymentTypes { get; set; }

        public IEnumerable<SelectListItem>? Departments { get; set; }

        public IEnumerable<SelectListItem>? Designations { get; set; }
        public List<string> TemplateSuggestions { get; set; } = new();
    }
}