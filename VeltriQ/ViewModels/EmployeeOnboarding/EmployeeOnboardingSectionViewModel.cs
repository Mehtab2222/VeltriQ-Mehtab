namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingSectionViewModel
    {
        public int EmployeeOnboardingSectionId { get; set; }

        public string SectionName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool IsCompleted { get; set; }

        public int DisplayOrder { get; set; }

        public string ReviewStatus { get; set; } = "Pending";

        public string? Remarks { get; set; }
    }
}