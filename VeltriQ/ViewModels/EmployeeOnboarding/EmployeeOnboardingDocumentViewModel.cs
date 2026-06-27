namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingDocumentViewModel
    {
        public int EmployeeOnboardingDocumentId { get; set; }

        public string DocumentName { get; set; } = "";

        public bool IsMandatory { get; set; }

        public bool IsUploaded { get; set; }

        public bool IsVerified { get; set; }

        public DateTime? UploadedOn { get; set; }
    }
}