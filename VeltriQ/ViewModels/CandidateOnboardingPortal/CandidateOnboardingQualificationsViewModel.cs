namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingQualificationsViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public List<QualificationViewModel> Qualifications { get; set; } = new();
    }

    public class QualificationViewModel
    {
        public int EmployeeOnboardingQualificationId { get; set; }

        public string? QualificationName { get; set; }

        public string? Institute { get; set; }

        public int? PassingYear { get; set; }

        public decimal? Percentage { get; set; }
    }
}