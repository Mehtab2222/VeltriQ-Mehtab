using System;

namespace VeltriQ.ViewModels.CandidateOnboardingPortal
{
    public class CandidateOnboardingAddressViewModel
    {
        public int EmployeeOnboardingAddressId { get; set; }

        public int EmployeeOnboardingId { get; set; }

        //=========================
        // CURRENT ADDRESS
        //=========================

        public string? CurrentAddressLine1 { get; set; }

        public string? CurrentAddressLine2 { get; set; }

        public string? CurrentLandmark { get; set; }

        public string? CurrentCity { get; set; }

        public string? CurrentState { get; set; }

        public string? CurrentCountry { get; set; }

        public string? CurrentPostalCode { get; set; }

        //=========================
        // PERMANENT ADDRESS
        //=========================

        public bool IsPermanentAddressSame { get; set; }

        public string? PermanentAddressLine1 { get; set; }

        public string? PermanentAddressLine2 { get; set; }

        public string? PermanentLandmark { get; set; }

        public string? PermanentCity { get; set; }

        public string? PermanentState { get; set; }

        public string? PermanentCountry { get; set; }

        public string? PermanentPostalCode { get; set; }
    }
}