using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class IdentityDocumentSeedData
    {
        public static IEnumerable<IdentityDocumentMaster> GetData()
        {
            return new List<IdentityDocumentMaster>
            {
                // ===========================
                // INDIA
                // ===========================

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 1,
                    DocumentCode = "AADHAAR",
                    DocumentName = "Aadhaar Card",
                    CountryId = 1,
                    HasExpiry = false,
                    IsMandatory = false,
                    DisplayOrder = 1,
                    IsActive = true
                },

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 2,
                    DocumentCode = "PAN",
                    DocumentName = "PAN Card",
                    CountryId = 1,
                    HasExpiry = false,
                    IsMandatory = false,
                    DisplayOrder = 2,
                    IsActive = true
                },

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 3,
                    DocumentCode = "PASSPORT",
                    DocumentName = "Passport",
                    CountryId = 1,
                    HasExpiry = true,
                    IsMandatory = false,
                    DisplayOrder = 3,
                    IsActive = true
                },

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 4,
                    DocumentCode = "DL",
                    DocumentName = "Driving License",
                    CountryId = 1,
                    HasExpiry = true,
                    IsMandatory = false,
                    DisplayOrder = 4,
                    IsActive = true
                },

                // ===========================
                // GLOBAL
                // ===========================

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 5,
                    DocumentCode = "NATIONALID",
                    DocumentName = "National Identity Card",
                    CountryId = null,
                    HasExpiry = true,
                    IsMandatory = false,
                    DisplayOrder = 5,
                    IsActive = true
                },

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 6,
                    DocumentCode = "WORKPERMIT",
                    DocumentName = "Work Permit",
                    CountryId = null,
                    HasExpiry = true,
                    IsMandatory = false,
                    DisplayOrder = 6,
                    IsActive = true
                },

                new IdentityDocumentMaster
                {
                    IdentityDocumentMasterId = 7,
                    DocumentCode = "VISA",
                    DocumentName = "Visa",
                    CountryId = null,
                    HasExpiry = true,
                    IsMandatory = false,
                    DisplayOrder = 7,
                    IsActive = true
                }
            };
        }
    }
}