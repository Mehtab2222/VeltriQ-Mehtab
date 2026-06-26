using System;

namespace VeltriQ.ViewModels.EmployeeOnboarding
{
    public class EmployeeOnboardingDashboardItemViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public string CandidateName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string Template { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime AssignedOn { get; set; }

        public decimal Completion { get; set; }
    }
}