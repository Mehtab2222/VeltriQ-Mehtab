using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class QualificationTypeSeedData
    {
        public static IEnumerable<QualificationTypeMaster> GetData()
        {
            return new List<QualificationTypeMaster>
            {
                new QualificationTypeMaster
                {
                    QualificationTypeMasterId = 1,
                    QualificationTypeCode = "ACADEMIC",
                    QualificationTypeName = "Academic Qualification",
                    Description = "Formal educational qualifications.",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new QualificationTypeMaster
                {
                    QualificationTypeMasterId = 2,
                    QualificationTypeCode = "CERTIFICATION",
                    QualificationTypeName = "Professional Certification",
                    Description = "Professional certifications issued by recognized organizations.",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new QualificationTypeMaster
                {
                    QualificationTypeMasterId = 3,
                    QualificationTypeCode = "LICENSE",
                    QualificationTypeName = "License",
                    Description = "Government or industry issued licenses.",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new QualificationTypeMaster
                {
                    QualificationTypeMasterId = 4,
                    QualificationTypeCode = "TRAINING",
                    QualificationTypeName = "Training",
                    Description = "Professional or internal training programs.",
                    DisplayOrder = 4,
                    IsActive = true
                }
            };
        }
    }
}