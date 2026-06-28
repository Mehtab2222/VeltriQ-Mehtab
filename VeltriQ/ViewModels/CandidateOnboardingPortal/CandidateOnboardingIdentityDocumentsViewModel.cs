namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingIdentityDocumentsViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public List<IdentityDocumentViewModel> Documents { get; set; } = new();
    }

    public class IdentityDocumentViewModel
    {
        public int EmployeeOnboardingIdentityDocumentId { get; set; }

        public string? DocumentName { get; set; }

        public string? DocumentNumber { get; set; }

        public bool Uploaded { get; set; }
    }
}