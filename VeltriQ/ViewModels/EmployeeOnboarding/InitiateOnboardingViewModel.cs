using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class InitiateOnboardingViewModel
    {
        public int OnboardingTemplateId { get; set; }

        public List<int> SelectedCandidateIds { get; set; } = new();

        public IEnumerable<SelectListItem> Templates { get; set; }
            = new List<SelectListItem>();

        public List<OnboardingCandidateItemViewModel> Candidates { get; set; }
            = new();
    }
}  