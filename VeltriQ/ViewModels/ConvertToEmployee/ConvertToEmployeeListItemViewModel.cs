namespace VeltriQ.ViewModels.ConvertToEmployee
{
    public class ConvertToEmployeeListItemViewModel
    {
        public int EmployeeOnboardingId { get; set; }

        public int OnboardingCandidateId { get; set; }

        public string CandidateCode { get; set; } = "";

        public string CandidateName { get; set; } = "";

        public string Department { get; set; } = "";

        public string Designation { get; set; } = "";

        public string TemplateName { get; set; } = "";

        public DateTime? ApprovedOn { get; set; }

        public string ConversionStatus { get; set; } = "";

        public bool IsConverted { get; set; }
    }
}