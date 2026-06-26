using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingPolicyCategorySeedData
    {
        public static IEnumerable<OnboardingPolicyCategoryMaster> GetData()
        {
            return new List<OnboardingPolicyCategoryMaster>
            {
                new OnboardingPolicyCategoryMaster
                {
                    OnboardingPolicyCategoryMasterId = 1,
                    CategoryCode = "HR",
                    CategoryName = "HR Policies",
                    Description = "Human Resource related policies.",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingPolicyCategoryMaster
                {
                    OnboardingPolicyCategoryMasterId = 2,
                    CategoryCode = "IT",
                    CategoryName = "IT Policies",
                    Description = "Information Technology policies.",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingPolicyCategoryMaster
                {
                    OnboardingPolicyCategoryMasterId = 3,
                    CategoryCode = "LEGAL",
                    CategoryName = "Legal Policies",
                    Description = "Legal agreements and compliance.",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingPolicyCategoryMaster
                {
                    OnboardingPolicyCategoryMasterId = 4,
                    CategoryCode = "SECURITY",
                    CategoryName = "Security Policies",
                    Description = "Information security policies.",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingPolicyCategoryMaster
                {
                    OnboardingPolicyCategoryMasterId = 5,
                    CategoryCode = "FINANCE",
                    CategoryName = "Finance Policies",
                    Description = "Finance and reimbursement policies.",
                    DisplayOrder = 5,
                    IsActive = true
                }
            };
        }
    }
}