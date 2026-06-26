using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class QualificationSeedData
    {
        public static IEnumerable<QualificationMaster> GetData()
        {
            return new List<QualificationMaster>
            {
                // ===========================
                // Academic Qualifications
                // ===========================

                new QualificationMaster
                {
                    QualificationMasterId = 1,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "SSC",
                    QualificationName = "Secondary School Certificate (SSC)",
                    EducationLevel = "Secondary",
                    DisplayOrder = 1,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 2,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "HSC",
                    QualificationName = "Higher Secondary Certificate (HSC)",
                    EducationLevel = "Higher Secondary",
                    DisplayOrder = 2,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 3,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "DIPLOMA",
                    QualificationName = "Diploma",
                    EducationLevel = "Diploma",
                    DisplayOrder = 3,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 4,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "BACHELOR",
                    QualificationName = "Bachelor's Degree",
                    EducationLevel = "Graduation",
                    DisplayOrder = 4,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 5,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "MASTER",
                    QualificationName = "Master's Degree",
                    EducationLevel = "Post Graduation",
                    DisplayOrder = 5,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 6,
                    QualificationTypeMasterId = 1,
                    QualificationCode = "PHD",
                    QualificationName = "Doctor of Philosophy (PhD)",
                    EducationLevel = "Doctorate",
                    DisplayOrder = 6,
                    IsDefault = true,
                    IsActive = true
                },

                // ===========================
                // Professional Certifications
                // ===========================

                new QualificationMaster
                {
                    QualificationMasterId = 7,
                    QualificationTypeMasterId = 2,
                    QualificationCode = "AWS",
                    QualificationName = "AWS Certification",
                    EducationLevel = "Certification",
                    RequiresRenewal = true,
                    IsProfessionalQualification = true,
                    DisplayOrder = 7,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 8,
                    QualificationTypeMasterId = 2,
                    QualificationCode = "AZURE",
                    QualificationName = "Microsoft Azure Certification",
                    EducationLevel = "Certification",
                    RequiresRenewal = true,
                    IsProfessionalQualification = true,
                    DisplayOrder = 8,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 9,
                    QualificationTypeMasterId = 2,
                    QualificationCode = "PMP",
                    QualificationName = "Project Management Professional (PMP)",
                    EducationLevel = "Certification",
                    RequiresRenewal = true,
                    IsProfessionalQualification = true,
                    DisplayOrder = 9,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 10,
                    QualificationTypeMasterId = 2,
                    QualificationCode = "SCRUM",
                    QualificationName = "Scrum Master Certification",
                    EducationLevel = "Certification",
                    RequiresRenewal = true,
                    IsProfessionalQualification = true,
                    DisplayOrder = 10,
                    IsDefault = true,
                    IsActive = true
                },

                // ===========================
                // Licenses
                // ===========================

                new QualificationMaster
                {
                    QualificationMasterId = 11,
                    QualificationTypeMasterId = 3,
                    QualificationCode = "DL",
                    QualificationName = "Driving License",
                    EducationLevel = "License",
                    RequiresRenewal = true,
                    DisplayOrder = 11,
                    IsDefault = true,
                    IsActive = true
                },

                // ===========================
                // Training
                // ===========================

                new QualificationMaster
                {
                    QualificationMasterId = 12,
                    QualificationTypeMasterId = 4,
                    QualificationCode = "SAFETY",
                    QualificationName = "Safety Training",
                    EducationLevel = "Training",
                    DisplayOrder = 12,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationMaster
                {
                    QualificationMasterId = 13,
                    QualificationTypeMasterId = 4,
                    QualificationCode = "FIRSTAID",
                    QualificationName = "First Aid Training",
                    EducationLevel = "Training",
                    RequiresRenewal = true,
                    DisplayOrder = 13,
                    IsDefault = true,
                    IsActive = true
                }
            };
        }
    }
}