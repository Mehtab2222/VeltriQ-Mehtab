using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Services.HR.Onboarding
{
    public interface IOnboardingWorkspaceService
    {
        Task LoadHeader(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId);

        Task LoadOverview(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId);

        Task LoadInformationSidebar(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId);

        Task LoadDocuments(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId);

        Task<CandidateOnboardingPoliciesViewModel> LoadPolicies(
            int employeeOnboardingId);

        Task<decimal> CalculateCompletionPercentage(
            int employeeOnboardingId);
        Task<CandidateOnboardingPersonalInformationViewModel> LoadPersonalInformation(
    int employeeOnboardingId);

        Task<CandidateOnboardingAddressViewModel> LoadAddress(
            int employeeOnboardingId);

        Task<CandidateOnboardingEmergencyContactViewModel> LoadEmergencyContact(
            int employeeOnboardingId);

        Task<CandidateOnboardingDependentsViewModel> LoadDependents(
            int employeeOnboardingId);

        Task<CandidateOnboardingQualificationsViewModel> LoadQualifications(
            int employeeOnboardingId);
        Task<int> CalculateCompletedInformationSections(
    int employeeOnboardingId);
        Task LoadPolicies(
    EmployeeOnboardingDetailsViewModel model,
    int employeeOnboardingId);
        Task<(bool Success, string Message)> ApproveOnboarding(
    int employeeOnboardingId,
    string? approvedBy);
        Task LoadHeader(
    EmployeeOnboardingDetailsViewModel model,
    int employeeOnboardingId);

        Task LoadOverview(
            EmployeeOnboardingDetailsViewModel model,
            int employeeOnboardingId);

        Task LoadDocuments(
            EmployeeOnboardingDetailsViewModel model,
            int employeeOnboardingId);
        Task UpdateCompletionPercentage(int employeeOnboardingId);
        Task LoadCandidateHeaderState(CandidateOnboardingIndexViewModel model,int employeeOnboardingId);
    }
}