using System.Collections.Generic;

namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingDashboardViewModel
    {
        public int Total { get; set; }

        public int Invited { get; set; }

        public int InProgress { get; set; }

        public int Submitted { get; set; }

        public int Approved { get; set; }

        public int Converted { get; set; }

        public List<EmployeeOnboardingDashboardItemViewModel> Items { get; set; } = new();
    }
}