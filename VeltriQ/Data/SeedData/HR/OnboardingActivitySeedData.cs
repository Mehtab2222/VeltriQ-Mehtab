using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingActivitySeedData
    {
        public static IEnumerable<OnboardingActivityMaster> GetData()
        {
            return new List<OnboardingActivityMaster>
            {
                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 1,
                    OnboardingActivityCategoryMasterId = 1,
                    ActivityCode = "DOCVERIFY",
                    ActivityName = "Document Verification",
                    Description = "Verify submitted onboarding documents.",
                    ActivityDay = 0,
                    ActivityOwner = "HR",
                    IsMandatory = true,
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 2,
                    OnboardingActivityCategoryMasterId = 2,
                    ActivityCode = "WELCOME",
                    ActivityName = "Welcome Session",
                    Description = "Welcome session conducted by HR.",
                    ActivityDay = 1,
                    ActivityOwner = "HR",
                    IsMandatory = true,
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 3,
                    OnboardingActivityCategoryMasterId = 2,
                    ActivityCode = "EMAIL",
                    ActivityName = "Official Email Creation",
                    Description = "Create official email account.",
                    ActivityDay = 1,
                    ActivityOwner = "IT",
                    IsMandatory = true,
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 4,
                    OnboardingActivityCategoryMasterId = 2,
                    ActivityCode = "IDCARD",
                    ActivityName = "ID Card Allocation",
                    Description = "Generate and issue employee ID card.",
                    ActivityDay = 1,
                    ActivityOwner = "Admin",
                    IsMandatory = true,
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 5,
                    OnboardingActivityCategoryMasterId = 2,
                    ActivityCode = "ASSET",
                    ActivityName = "Asset Allocation",
                    Description = "Allocate laptop and other assets.",
                    ActivityDay = 1,
                    ActivityOwner = "IT",
                    IsMandatory = true,
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 6,
                    OnboardingActivityCategoryMasterId = 2,
                    ActivityCode = "PAYROLL",
                    ActivityName = "Payroll Setup",
                    Description = "Create payroll profile.",
                    ActivityDay = 1,
                    ActivityOwner = "Finance",
                    IsMandatory = true,
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 7,
                    OnboardingActivityCategoryMasterId = 3,
                    ActivityCode = "MANAGERINTRO",
                    ActivityName = "Manager Introduction",
                    Description = "Introduction with reporting manager.",
                    ActivityDay = 2,
                    ActivityOwner = "Manager",
                    IsMandatory = true,
                    DisplayOrder = 7,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 8,
                    OnboardingActivityCategoryMasterId = 3,
                    ActivityCode = "TEAMINTRO",
                    ActivityName = "Team Introduction",
                    Description = "Meet team members.",
                    ActivityDay = 2,
                    ActivityOwner = "Manager",
                    IsMandatory = true,
                    DisplayOrder = 8,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 9,
                    OnboardingActivityCategoryMasterId = 3,
                    ActivityCode = "ORIENTATION",
                    ActivityName = "Department Orientation",
                    Description = "Department orientation session.",
                    ActivityDay = 3,
                    ActivityOwner = "Manager",
                    IsMandatory = true,
                    DisplayOrder = 9,
                    IsActive = true
                },

                new OnboardingActivityMaster
                {
                    OnboardingActivityMasterId = 10,
                    OnboardingActivityCategoryMasterId = 4,
                    ActivityCode = "REVIEW",
                    ActivityName = "First Month Review",
                    Description = "Review employee onboarding progress.",
                    ActivityDay = 30,
                    ActivityOwner = "HR",
                    IsMandatory = true,
                    DisplayOrder = 10,
                    IsActive = true
                }
            };
        }
    }
}