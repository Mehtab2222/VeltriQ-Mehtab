using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingStatusSeedData
    {
        public static IEnumerable<OnboardingStatusMaster> GetData()
        {
            return new List<OnboardingStatusMaster>
            {
                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 1,
                    StatusCode = "DRAFT",
                    StatusName = "Draft",
                    Description = "Onboarding initiated but invitation not sent.",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 2,
                    StatusCode = "INVITED",
                    StatusName = "Invitation Sent",
                    Description = "Invitation has been sent to the candidate.",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 3,
                    StatusCode = "INPROGRESS",
                    StatusName = "In Progress",
                    Description = "Candidate is filling the onboarding information.",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 4,
                    StatusCode = "SUBMITTED",
                    StatusName = "Submitted",
                    Description = "Candidate has submitted the onboarding form.",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 5,
                    StatusCode = "REVIEW",
                    StatusName = "Under Review",
                    Description = "HR is reviewing the submitted onboarding details.",
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 6,
                    StatusCode = "CORRECTION",
                    StatusName = "Corrections Required",
                    Description = "Candidate needs to correct or update the submitted information.",
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 7,
                    StatusCode = "APPROVED",
                    StatusName = "Approved",
                    Description = "Onboarding has been approved by HR.",
                    DisplayOrder = 7,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 8,
                    StatusCode = "CONVERTED",
                    StatusName = "Converted to Employee",
                    Description = "Candidate has been converted into an employee.",
                    DisplayOrder = 8,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 9,
                    StatusCode = "CANCELLED",
                    StatusName = "Cancelled",
                    Description = "Onboarding process has been cancelled.",
                    DisplayOrder = 9,
                    IsActive = true
                },

                new OnboardingStatusMaster
                {
                    OnboardingStatusMasterId = 10,
                    StatusCode = "EXPIRED",
                    StatusName = "Expired",
                    Description = "Onboarding invitation has expired.",
                    DisplayOrder = 10,
                    IsActive = true
                }
            };
        }
    }
}