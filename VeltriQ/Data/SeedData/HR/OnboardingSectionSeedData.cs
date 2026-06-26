using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeltriQ.Models.HR.Onboarding;

namespace VeltriQ.SeedData
{
    public class OnboardingSectionSeedData : IEntityTypeConfiguration<OnboardingSectionMaster>
    {
        public void Configure(EntityTypeBuilder<OnboardingSectionMaster> builder)
        {
            builder.HasData(

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 1,
                    SectionCode = "PERSONAL",
                    SectionName = "Personal Information",
                    DisplayOrder = 1,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 2,
                    SectionCode = "ADDRESS",
                    SectionName = "Address",
                    DisplayOrder = 2,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 3,
                    SectionCode = "EMERGENCY",
                    SectionName = "Emergency Contact",
                    DisplayOrder = 3,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 4,
                    SectionCode = "DEPENDENT",
                    SectionName = "Dependents",
                    DisplayOrder = 4,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 5,
                    SectionCode = "QUALIFICATION",
                    SectionName = "Qualifications",
                    DisplayOrder = 5,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 6,
                    SectionCode = "IDENTITY",
                    SectionName = "Identity Documents",
                    DisplayOrder = 6,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 7,
                    SectionCode = "BANK",
                    SectionName = "Bank Details",
                    DisplayOrder = 7,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 8,
                    SectionCode = "DOCUMENT",
                    SectionName = "Company Documents",
                    DisplayOrder = 8,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 9,
                    SectionCode = "POLICY",
                    SectionName = "Policy Acceptance",
                    DisplayOrder = 9,
                    IsActive = true
                },

                new OnboardingSectionMaster
                {
                    OnboardingSectionMasterId = 10,
                    SectionCode = "ACTIVITY",
                    SectionName = "Joining Activities",
                    DisplayOrder = 10,
                    IsActive = true
                }

            );
        }
    }
}