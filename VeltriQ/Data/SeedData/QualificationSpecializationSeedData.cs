using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class QualificationSpecializationSeedData
    {
        public static IEnumerable<QualificationSpecializationMaster> GetData()
        {
            return new List<QualificationSpecializationMaster>
            {
                // ============================================
                // Bachelor's Degree
                // QualificationMasterId = 4
                // ============================================

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 1,
                    QualificationMasterId = 4,
                    SpecializationCode = "CS",
                    SpecializationName = "Computer Science",
                    DisplayOrder = 1,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 2,
                    QualificationMasterId = 4,
                    SpecializationCode = "IT",
                    SpecializationName = "Information Technology",
                    DisplayOrder = 2,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 3,
                    QualificationMasterId = 4,
                    SpecializationCode = "MECH",
                    SpecializationName = "Mechanical Engineering",
                    DisplayOrder = 3,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 4,
                    QualificationMasterId = 4,
                    SpecializationCode = "CIVIL",
                    SpecializationName = "Civil Engineering",
                    DisplayOrder = 4,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 5,
                    QualificationMasterId = 4,
                    SpecializationCode = "ECE",
                    SpecializationName = "Electronics & Communication",
                    DisplayOrder = 5,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 6,
                    QualificationMasterId = 4,
                    SpecializationCode = "COMMERCE",
                    SpecializationName = "Commerce",
                    DisplayOrder = 6,
                    IsDefault = true,
                    IsActive = true
                },

                // ============================================
                // Master's Degree
                // QualificationMasterId = 5
                // ============================================

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 7,
                    QualificationMasterId = 5,
                    SpecializationCode = "HR",
                    SpecializationName = "Human Resources",
                    DisplayOrder = 7,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 8,
                    QualificationMasterId = 5,
                    SpecializationCode = "FIN",
                    SpecializationName = "Finance",
                    DisplayOrder = 8,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 9,
                    QualificationMasterId = 5,
                    SpecializationCode = "MKT",
                    SpecializationName = "Marketing",
                    DisplayOrder = 9,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 10,
                    QualificationMasterId = 5,
                    SpecializationCode = "DS",
                    SpecializationName = "Data Science",
                    DisplayOrder = 10,
                    IsDefault = true,
                    IsActive = true
                },

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 11,
                    QualificationMasterId = 5,
                    SpecializationCode = "AI",
                    SpecializationName = "Artificial Intelligence",
                    DisplayOrder = 11,
                    IsDefault = true,
                    IsActive = true
                },

                // ============================================
                // Doctorate
                // QualificationMasterId = 6
                // ============================================

                new QualificationSpecializationMaster
                {
                    QualificationSpecializationMasterId = 12,
                    QualificationMasterId = 6,
                    SpecializationCode = "RESEARCH",
                    SpecializationName = "Research",
                    DisplayOrder = 12,
                    IsDefault = true,
                    IsActive = true
                }
            };
        }
    }
}