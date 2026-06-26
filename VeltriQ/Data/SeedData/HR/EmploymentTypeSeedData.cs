using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.Data.SeedData.HR
{
    public static class EmploymentTypeSeedData
    {
        public static IEnumerable<EmploymentTypeMaster> GetData()
        {
            return new List<EmploymentTypeMaster>
            {
                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 1,
                    EmploymentTypeCode = "PERM",
                    EmploymentTypeName = "Permanent",
                    Description = "Permanent Employee",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 2,
                    EmploymentTypeCode = "PROB",
                    EmploymentTypeName = "Probation",
                    Description = "Employee on Probation",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 3,
                    EmploymentTypeCode = "CONT",
                    EmploymentTypeName = "Contract",
                    Description = "Contract Employee",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 4,
                    EmploymentTypeCode = "INTERN",
                    EmploymentTypeName = "Intern",
                    Description = "Internship",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 5,
                    EmploymentTypeCode = "CONSULT",
                    EmploymentTypeName = "Consultant",
                    Description = "Consultant",
                    DisplayOrder = 5,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 6,
                    EmploymentTypeCode = "TRAINEE",
                    EmploymentTypeName = "Trainee",
                    Description = "Trainee",
                    DisplayOrder = 6,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 7,
                    EmploymentTypeCode = "APPRENTICE",
                    EmploymentTypeName = "Apprentice",
                    Description = "Apprenticeship",
                    DisplayOrder = 7,
                    IsActive = true
                },

                new EmploymentTypeMaster
                {
                    EmploymentTypeMasterId = 8,
                    EmploymentTypeCode = "PARTTIME",
                    EmploymentTypeName = "Part Time",
                    Description = "Part Time Employee",
                    DisplayOrder = 8,
                    IsActive = true
                }
            };
        }
    }
}