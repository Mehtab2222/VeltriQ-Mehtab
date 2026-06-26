using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingActivityCategorySeedData
    {
        public static IEnumerable<OnboardingActivityCategoryMaster> GetData()
        {
            return new List<OnboardingActivityCategoryMaster>
            {
                new OnboardingActivityCategoryMaster
                {
                    OnboardingActivityCategoryMasterId = 1,
                    CategoryCode = "PREJOIN",
                    CategoryName = "Pre Joining",
                    Description = "Activities before the joining date.",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingActivityCategoryMaster
                {
                    OnboardingActivityCategoryMasterId = 2,
                    CategoryCode = "DAYONE",
                    CategoryName = "Day One",
                    Description = "Activities to be completed on the first day.",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingActivityCategoryMaster
                {
                    OnboardingActivityCategoryMasterId = 3,
                    CategoryCode = "FIRSTWEEK",
                    CategoryName = "First Week",
                    Description = "Activities planned during the first week.",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingActivityCategoryMaster
                {
                    OnboardingActivityCategoryMasterId = 4,
                    CategoryCode = "FIRSTMONTH",
                    CategoryName = "First Month",
                    Description = "Activities planned during the first month.",
                    DisplayOrder = 4,
                    IsActive = true
                }
            };
        }
    }
}