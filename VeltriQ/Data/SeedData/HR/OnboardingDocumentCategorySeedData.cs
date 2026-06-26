using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingDocumentCategorySeedData
    {
        public static IEnumerable<OnboardingDocumentCategoryMaster> GetData()
        {
            return new List<OnboardingDocumentCategoryMaster>
            {
                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 1,
                    CategoryCode = "IDENTITY",
                    CategoryName = "Identity Documents",
                    Description = "Government issued identity documents.",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 2,
                    CategoryCode = "ADDRESS",
                    CategoryName = "Address Proof",
                    Description = "Documents used as address proof.",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 3,
                    CategoryCode = "EDUCATION",
                    CategoryName = "Educational Documents",
                    Description = "Academic certificates and mark sheets.",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 4,
                    CategoryCode = "EMPLOYMENT",
                    CategoryName = "Employment Documents",
                    Description = "Previous employment related documents.",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 5,
                    CategoryCode = "FINANCIAL",
                    CategoryName = "Financial Documents",
                    Description = "Bank and financial related documents.",
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 6,
                    CategoryCode = "MEDICAL",
                    CategoryName = "Medical Documents",
                    Description = "Medical certificates and health records.",
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingDocumentCategoryMaster
                {
                    OnboardingDocumentCategoryMasterId = 7,
                    CategoryCode = "OTHER",
                    CategoryName = "Other Documents",
                    Description = "Miscellaneous documents.",
                    DisplayOrder = 7,
                    IsActive = true
                }
            };
        }
    }
}