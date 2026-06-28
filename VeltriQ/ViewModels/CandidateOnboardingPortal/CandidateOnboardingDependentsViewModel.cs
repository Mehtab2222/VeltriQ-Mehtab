namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingDependentsViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public List<DependentViewModel> Dependents { get; set; } = new();
    }

    public class DependentViewModel
    {
        public int EmployeeOnboardingDependentId { get; set; }

        public string? FullName { get; set; }

        public string? Relationship { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsNominee { get; set; }
    }
}