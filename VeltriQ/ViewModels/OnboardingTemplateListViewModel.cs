namespace VeltriQ.ViewModels
{
    public class OnboardingTemplateListViewModel
    {
        public int OnboardingTemplateId { get; set; }

        public string TemplateCode { get; set; } = string.Empty;

        public string TemplateName { get; set; } = string.Empty;

        public string EmploymentType { get; set; } = string.Empty;

        public string? Department { get; set; }

        public string? Designation { get; set; }

        public string Version { get; set; } = string.Empty;

        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }

        public int TotalSections { get; set; }

        public int TotalDocuments { get; set; }

        public int TotalPolicies { get; set; }

        public int TotalActivities { get; set; }
    }
}