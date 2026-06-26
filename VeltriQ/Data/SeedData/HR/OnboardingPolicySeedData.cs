using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingPolicySeedData
    {
        public static IEnumerable<OnboardingPolicyMaster> GetData()
        {
            return new List<OnboardingPolicyMaster>
            {
                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 1,
                    OnboardingPolicyCategoryMasterId = 1,
                    PolicyCode = "HRPOLICY",
                    PolicyName = "HR Policy",
                    Description = "Company HR policy.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 2,
                    OnboardingPolicyCategoryMasterId = 1,
                    PolicyCode = "LEAVE",
                    PolicyName = "Leave Policy",
                    Description = "Employee leave policy.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 3,
                    OnboardingPolicyCategoryMasterId = 2,
                    PolicyCode = "IT",
                    PolicyName = "IT Acceptable Use Policy",
                    Description = "Acceptable use of company IT resources.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 4,
                    OnboardingPolicyCategoryMasterId = 2,
                    PolicyCode = "PASSWORD",
                    PolicyName = "Password Policy",
                    Description = "Password management policy.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 5,
                    OnboardingPolicyCategoryMasterId = 3,
                    PolicyCode = "COC",
                    PolicyName = "Code of Conduct",
                    Description = "Employee code of conduct.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 6,
                    OnboardingPolicyCategoryMasterId = 3,
                    PolicyCode = "NDA",
                    PolicyName = "Non-Disclosure Agreement",
                    Description = "Confidentiality agreement.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 7,
                    OnboardingPolicyCategoryMasterId = 4,
                    PolicyCode = "INFOSEC",
                    PolicyName = "Information Security Policy",
                    Description = "Information security guidelines.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = true,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 7,
                    IsActive = true
                },

                new OnboardingPolicyMaster
                {
                    OnboardingPolicyMasterId = 8,
                    OnboardingPolicyCategoryMasterId = 5,
                    PolicyCode = "EXPENSE",
                    PolicyName = "Expense Reimbursement Policy",
                    Description = "Expense reimbursement process.",
                    PolicyVersion = "1.0",
                    EffectiveDate = new DateTime(2026, 1, 1),
                    IsMandatory = false,
                    RequiresAcceptance = true,
                    AllowDownload = true,
                    DisplayOrder = 8,
                    IsActive = true
                }
            };
        }
    }
}