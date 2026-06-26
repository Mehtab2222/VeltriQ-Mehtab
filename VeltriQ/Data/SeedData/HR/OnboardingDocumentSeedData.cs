using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class OnboardingDocumentSeedData
    {
        public static IEnumerable<OnboardingDocumentMaster> GetData()
        {
            return new List<OnboardingDocumentMaster>
            {
                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 1,
                    OnboardingDocumentCategoryMasterId = 1,
                    DocumentCode = "PHOTO",
                    DocumentName = "Passport Size Photo",
                    Description = "Recent passport size photograph.",
                    IsMandatory = true,
                    AllowedFileTypes = "jpg,jpeg,png",
                    MaxFileSizeMB = 2,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 2,
                    OnboardingDocumentCategoryMasterId = 1,
                    DocumentCode = "AADHAAR",
                    DocumentName = "Aadhaar Card",
                    Description = "Government issued Aadhaar card.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 3,
                    OnboardingDocumentCategoryMasterId = 1,
                    DocumentCode = "PAN",
                    DocumentName = "PAN Card",
                    Description = "Permanent Account Number card.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 4,
                    OnboardingDocumentCategoryMasterId = 1,
                    DocumentCode = "PASSPORT",
                    DocumentName = "Passport",
                    Description = "Passport document.",
                    IsMandatory = false,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = true,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    ValidationRule = "InternationalEmployee",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 5,
                    OnboardingDocumentCategoryMasterId = 2,
                    DocumentCode = "ADDRESS",
                    DocumentName = "Address Proof",
                    Description = "Proof of current residential address.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 6,
                    OnboardingDocumentCategoryMasterId = 3,
                    DocumentCode = "EDUCATION",
                    DocumentName = "Educational Certificates",
                    Description = "Educational certificates and mark sheets.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 10,
                    AllowMultipleFiles = true,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 7,
                    OnboardingDocumentCategoryMasterId = 4,
                    DocumentCode = "RESUME",
                    DocumentName = "Resume / CV",
                    Description = "Latest resume or CV.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,doc,docx",
                    MaxFileSizeMB = 10,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 7,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 8,
                    OnboardingDocumentCategoryMasterId = 4,
                    DocumentCode = "EXPERIENCE",
                    DocumentName = "Experience Certificate",
                    Description = "Previous employment experience certificate.",
                    IsMandatory = false,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 10,
                    AllowMultipleFiles = true,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    ValidationRule = "ExperienceYears > 0",
                    DisplayOrder = 8,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 9,
                    OnboardingDocumentCategoryMasterId = 5,
                    DocumentCode = "BANK",
                    DocumentName = "Cancelled Cheque / Passbook",
                    Description = "Bank account verification document.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 9,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 10,
                    OnboardingDocumentCategoryMasterId = 6,
                    DocumentCode = "MEDICAL",
                    DocumentName = "Medical Fitness Certificate",
                    Description = "Medical fitness certificate.",
                    IsMandatory = false,
                    AllowedFileTypes = "pdf,jpg,jpeg,png",
                    MaxFileSizeMB = 5,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = false,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = false,
                    DisplayOrder = 10,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 11,
                    OnboardingDocumentCategoryMasterId = 4,
                    DocumentCode = "OFFER",
                    DocumentName = "Offer Letter",
                    Description = "Offer letter issued by HR.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf",
                    MaxFileSizeMB = 10,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = true,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = true,
                    DisplayOrder = 11,
                    IsActive = true
                },

                new OnboardingDocumentMaster
                {
                    OnboardingDocumentMasterId = 12,
                    OnboardingDocumentCategoryMasterId = 4,
                    DocumentCode = "APPOINTMENT",
                    DocumentName = "Appointment Letter",
                    Description = "Appointment letter generated after approval.",
                    IsMandatory = true,
                    AllowedFileTypes = "pdf",
                    MaxFileSizeMB = 10,
                    AllowMultipleFiles = false,
                    IsExpiryRequired = false,
                    IsSystemDocument = true,
                    IsVisibleToCandidate = true,
                    AllowDownloadByCandidate = true,
                    DisplayOrder = 12,
                    IsActive = true
                }
            };
        }
    }
}