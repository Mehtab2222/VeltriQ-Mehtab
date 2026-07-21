using Microsoft.EntityFrameworkCore;
using VeltriQ.Data.SeedData.HR;
using VeltriQ.Models;
using VeltriQ.Models.EmployeeInductionAttendance;
using VeltriQ.Models.HR;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.Models.Recruitment;
using VeltriQ.Models.Training;
using VeltriQ.SeedData;
namespace VeltriQ.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext
        (
            DbContextOptions<TenantDbContext> options
        )
            : base(options)
        {
        }

        // =========================
        // HR MODULE TABLES
        // =========================
        public DbSet<OnboardingTemplate> OnboardingTemplates { get; set; }

        public DbSet<OnboardingTemplateDocument> OnboardingTemplateDocuments { get; set; }

        public DbSet<OnboardingTemplatePolicy> OnboardingTemplatePolicies { get; set; }

        public DbSet<OnboardingTemplateActivity> OnboardingTemplateActivities { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<HRContact> HRContacts { get; set; }

        public DbSet<DocumentMaster> DocumentMasters { get; set; }

        public DbSet<AssetMaster> AssetMasters { get; set; }
        public DbSet<AssetInventory> AssetInventories { get; set; }
        public DbSet<EmployeeAsset> EmployeeAssets { get; set; }

        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public DbSet<EmployeeTransfer> EmployeeTransfers{ get; set; }
        public DbSet<EmployeeExit> EmployeeExits { get; set; }
        public DbSet<EmployeeSuspension> EmployeeSuspensions{ get; set; }
        public DbSet<ManpowerRequest> ManpowerRequests { get; set; }
        public DbSet<JobProfile> JobProfiles { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        public DbSet<SkillMaster> SkillMasters { get; set; }

        public DbSet<JobProfileSkill> JobProfileSkills { get; set; }
        //onboarding tables
        public DbSet<EmploymentTypeMaster> EmploymentTypeMasters { get; set; }

        public DbSet<OnboardingStatusMaster> OnboardingStatusMasters { get; set; }

        public DbSet<OnboardingSectionMaster> OnboardingSectionMasters { get; set; }

        public DbSet<OnboardingDocumentMaster> OnboardingDocumentMasters { get; set; }

        public DbSet<OnboardingPolicyMaster> OnboardingPolicyMasters { get; set; }
        public DbSet<OnboardingDocumentCategoryMaster> OnboardingDocumentCategoryMasters { get; set; }
        public DbSet<OnboardingActivityMaster> OnboardingActivityMasters { get; set; }
        public DbSet<OnboardingPolicyCategoryMaster> OnboardingPolicyCategoryMasters { get; set; }
        public DbSet<OnboardingActivityCategoryMaster> OnboardingActivityCategoryMasters { get; set; }

        public DbSet<QualificationTypeMaster> QualificationTypeMasters { get; set; }

        public DbSet<QualificationMaster> QualificationMasters { get; set; }
        public DbSet<QualificationSpecializationMaster> QualificationSpecializationMasters { get; set; }
        public DbSet<IdentityDocumentMaster> IdentityDocumentMasters { get; set; }

        public DbSet<OnboardingTemplateSection> OnboardingTemplateSections { get; set; }
        public DbSet<EmployeeOnboarding> EmployeeOnboardings { get; set; }
        public DbSet<OnboardingCandidate> OnboardingCandidates { get; set; }
        public DbSet<EmployeeOnboardingSection> EmployeeOnboardingSections { get; set; }
        public DbSet<EmployeeOnboardingDocument> EmployeeOnboardingDocuments { get; set; }
        public DbSet<EmployeeOnboardingPolicy> EmployeeOnboardingPolicies { get; set; }
        public DbSet<EmployeeOnboardingActivity> EmployeeOnboardingActivities { get; set; }
        public DbSet<EmployeeOnboardingPersonalInformation> EmployeeOnboardingPersonalInformations { get; set; }
        public DbSet<EmployeeOnboardingAddress> EmployeeOnboardingAddresses { get; set; }
        public DbSet<EmployeeOnboardingEducation> EmployeeOnboardingEducations { get; set; }
        public DbSet<EmployeeOnboardingExperience> EmployeeOnboardingExperiences { get; set; }
        public DbSet<OnboardingCandidateInvitation> OnboardingCandidateInvitations { get; set; }
        public DbSet<EmployeeOnboardingEmergencyContact> EmployeeOnboardingEmergencyContacts { get; set; }

        public DbSet<EmployeeOnboardingDependent> EmployeeOnboardingDependents { get; set; }

        public DbSet<EmployeeOnboardingQualification> EmployeeOnboardingQualifications { get; set; }

        public DbSet<EmployeeOnboardingIdentity> EmployeeOnboardingIdentities { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

        public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }

        public DbSet<EmployeeDependent> EmployeeDependents { get; set; }

        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public DbSet<InductionProgramMaster> InductionProgramMasters { get; set; }
        public DbSet<InductionSessionMaster> InductionSessionMasters { get; set; }
        public DbSet<InductionSessionTopicMaster> InductionSessionTopicMasters { get; set; }
        public DbSet<EmployeeInduction> EmployeeInductions { get; set; }
        public DbSet<EmployeeInductionSession> EmployeeInductionSessions { get; set; }
        public DbSet<EmployeeInductionAttendance> EmployeeInductionAttendances { get; set; }

        public DbSet<EmployeeInductionAttendanceDetail> EmployeeInductionAttendanceDetails { get; set; }
        public DbSet<TrainingCategory> TrainingCategories { get; set; }
        public DbSet<TrainingMaster> TrainingMasters { get; set; }
        public DbSet<TrainingTrainer> TrainingTrainers { get; set; }
        public DbSet<TrainingVenue> TrainingVenues { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        public DbSet<TrainingEnrollment> TrainingEnrollments { get; set; }
        // =========================
        // MAP SCHEMAS
        // =========================

        protected override void OnModelCreating
        (
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);
            //============================================================
            // Candidate Invitation
            //============================================================

            modelBuilder.Entity<TrainingSchedule>(entity =>
            {
                entity.HasKey(e => e.TrainingScheduleId);

                entity.Property(e => e.ScheduleCode)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.Remarks)
                      .HasMaxLength(500);

                entity.HasIndex(e => e.ScheduleCode)
                      .IsUnique();

                // Training Master
                entity.HasOne(e => e.TrainingMaster)
                      .WithMany()
                      .HasForeignKey(e => e.TrainingMasterId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Trainer
                entity.HasOne(e => e.TrainingTrainer)
                      .WithMany()
                      .HasForeignKey(e => e.TrainingTrainerId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Venue
                entity.HasOne(e => e.TrainingVenue)
                      .WithMany()
                      .HasForeignKey(e => e.TrainingVenueId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Department
                entity.HasOne(e => e.Department)
                      .WithMany()
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<TrainingVenue>(entity =>
            {
                entity.HasKey(e => e.TrainingVenueId);

                entity.Property(e => e.VenueCode)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.VenueName)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Address)
                      .HasMaxLength(500);

                entity.HasIndex(e => e.VenueCode)
                      .IsUnique();

                entity.HasIndex(e => e.VenueName)
                      .IsUnique();
            });
            modelBuilder.Entity<TrainingTrainer>(entity =>
            {
                entity.HasKey(e => e.TrainingTrainerId);

                entity.Property(e => e.TrainerCode)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.TrainerName)
                      .HasMaxLength(200);

                entity.Property(e => e.MobileNo)
                      .HasMaxLength(20);

                entity.Property(e => e.Email)
                      .HasMaxLength(150);

                entity.HasOne(e => e.Employee)
                      .WithMany()
                      .HasForeignKey(e => e.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.TrainerCode)
                      .IsUnique();
            });
            modelBuilder.Entity<TrainingMaster>()
    .HasIndex(x => new { x.TrainingCategoryId, x.TrainingName })
    .IsUnique();
            modelBuilder.Entity<TrainingCategory>(entity =>
            {
                entity.HasKey(e => e.TrainingCategoryId);

                entity.Property(e => e.CategoryCode)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.CategoryName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasIndex(e => e.CategoryName)
                      .IsUnique();
            });
            modelBuilder.Entity<EmployeeInductionAttendance>(entity =>
            {
                entity.HasKey(e => e.EmployeeInductionAttendanceId);

                entity.HasOne(e => e.InductionProgramMaster)
                    .WithMany()
                    .HasForeignKey(e => e.InductionProgramMasterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.InductionSessionMaster)
                    .WithMany()
                    .HasForeignKey(e => e.InductionSessionMasterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new
                {
                    e.InductionProgramMasterId,
                    e.InductionSessionMasterId,
                    e.AttendanceDate
                }).IsUnique();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.IsLocked)
                    .HasDefaultValue(false);
            });
            modelBuilder.Entity<EmployeeInductionAttendanceDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeInductionAttendanceDetailId);

                entity.HasOne(e => e.EmployeeInductionAttendance)
                    .WithMany(a => a.AttendanceDetails)
                    .HasForeignKey(e => e.EmployeeInductionAttendanceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.EmployeeInduction)
                    .WithMany()
                    .HasForeignKey(e => e.EmployeeInductionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.EmployeeInductionSession)
                    .WithMany()
                    .HasForeignKey(e => e.EmployeeInductionSessionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new
                {
                    e.EmployeeInductionAttendanceId,
                    e.EmployeeInductionId
                }).IsUnique();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<EmployeeInductionSession>()
                .ToTable("EmployeeInductionSession", "HR");

            modelBuilder.Entity<EmployeeInductionSession>()
                .HasOne(x => x.EmployeeInduction)
                .WithMany()
                .HasForeignKey(x => x.EmployeeInductionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeInductionSession>()
                .HasOne(x => x.InductionSessionMaster)
                .WithMany()
                .HasForeignKey(x => x.InductionSessionMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeInductionSession>()
                .HasIndex(x => new
                {
                    x.EmployeeInductionId,
                    x.SessionOrder
                });

            modelBuilder.Entity<EmployeeInduction>()
                .ToTable("EmployeeInduction", "HR");

            modelBuilder.Entity<EmployeeInduction>()
                .HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeInduction>()
                .HasOne(x => x.InductionProgramMaster)
                .WithMany()
                .HasForeignKey(x => x.InductionProgramMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeInduction>()
                .HasIndex(x => new
                {
                    x.EmployeeId,
                    x.InductionProgramMasterId,
                    x.IsActive
                });

            modelBuilder.Entity<InductionSessionTopicMaster>()
                .ToTable("InductionSessionTopicMaster", "HR");

            modelBuilder.Entity<InductionSessionTopicMaster>()
                .HasOne(x => x.InductionSessionMaster)
                .WithMany()
                .HasForeignKey(x => x.InductionSessionMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InductionSessionMaster>()
                .ToTable("InductionSessionMaster", "HR");

            modelBuilder.Entity<InductionSessionMaster>()
                .HasOne(x => x.InductionProgramMaster)
                .WithMany()
                .HasForeignKey(x => x.InductionProgramMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InductionSessionMaster>()
                .HasIndex(x => x.SessionCode)
                .IsUnique();

            modelBuilder.Entity<InductionProgramMaster>()
                .ToTable("InductionProgramMaster", "HR");

            modelBuilder.Entity<InductionProgramMaster>()
                .HasIndex(x => x.ProgramCode)
                .IsUnique();

            modelBuilder.Entity<InductionProgramMaster>()
                .HasIndex(x => x.ProgramName)
                .IsUnique();
            modelBuilder.Entity<OnboardingCandidateInvitation>()
                .HasOne(x => x.OnboardingCandidate)
                .WithMany()
                .HasForeignKey(x => x.OnboardingCandidateId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OnboardingCandidateInvitation>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OnboardingCandidateInvitation>()
                .HasIndex(x => x.InvitationToken)
                .IsUnique();
            //============================================================
            // Employee Onboarding Runtime
            //============================================================

            modelBuilder.Entity<EmployeeOnboardingPersonalInformation>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingPersonalInformation>()
                .HasIndex(x => x.EmployeeOnboardingId)
                .IsUnique();

            modelBuilder.Entity<EmployeeOnboardingAddress>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingAddress>()
                .HasIndex(x => x.EmployeeOnboardingId)
                .IsUnique();

            modelBuilder.Entity<EmployeeOnboardingEducation>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingExperience>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            //============================================================
            // Seed Data
            //============================================================

            modelBuilder.ApplyConfiguration(new OnboardingSectionSeedData());

            modelBuilder.Entity<OnboardingDocumentMaster>()
                .HasData(OnboardingDocumentSeedData.GetData());
            modelBuilder.Entity<OnboardingTemplateSection>()
    .ToTable("OnboardingTemplateSection", "HR");
            modelBuilder.Entity<OnboardingTemplate>()
    .HasOne(x => x.EmploymentType)
    .WithMany()
    .HasForeignKey(x => x.EmploymentTypeMasterId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingTemplate>()
                .HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingTemplate>()
                .HasOne(x => x.Designation)
                .WithMany()
                .HasForeignKey(x => x.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingEmployee>()
                .HasOne(x => x.OnboardingTemplate)
                .WithMany()
                .HasForeignKey(x => x.OnboardingTemplateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingEmployee>()
                .HasOne(x => x.EmploymentType)
                .WithMany()
                .HasForeignKey(x => x.EmploymentTypeMasterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingEmployee>()
                .HasOne(x => x.OnboardingStatus)
                .WithMany()
                .HasForeignKey(x => x.OnboardingStatusMasterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnboardingEmployee>()
                .HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeOnboarding>()
    .HasOne(x => x.OnboardingCandidate)
    .WithMany()
    .HasForeignKey(x => x.OnboardingCandidateId)
    .OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<QualificationTypeMaster>()
    .ToTable("QualificationTypeMaster", "HR");

            modelBuilder.Entity<IdentityDocumentMaster>()
    .ToTable("IdentityDocumentMaster", "HR");

            modelBuilder.Entity<IdentityDocumentMaster>()
    .HasData(IdentityDocumentSeedData.GetData());

            modelBuilder.Entity<QualificationSpecializationMaster>()
                .HasData(QualificationSpecializationSeedData.GetData());
            modelBuilder.Entity<QualificationMaster>()
                .ToTable("QualificationMaster", "HR");
            modelBuilder.Entity<QualificationTypeMaster>()
    .HasData(QualificationTypeSeedData.GetData());
            modelBuilder.Entity<QualificationSpecializationMaster>()
    .ToTable("QualificationSpecializationMaster", "HR");
            modelBuilder.Entity<QualificationMaster>()
                .HasData(QualificationSeedData.GetData());

            modelBuilder.Entity<OnboardingTemplate>()
    .ToTable("OnboardingTemplate", "HR");

            modelBuilder.Entity<OnboardingTemplateDocument>()
                .ToTable("OnboardingTemplateDocument", "HR");

            modelBuilder.Entity<OnboardingTemplatePolicy>()
                .ToTable("OnboardingTemplatePolicy", "HR");

            modelBuilder.Entity<OnboardingTemplateActivity>()
                .ToTable("OnboardingTemplateActivity", "HR");
            modelBuilder.Entity<OnboardingActivityCategoryMaster>()
    .ToTable("OnboardingActivityCategoryMaster", "HR");


            modelBuilder.Entity<OnboardingPolicyCategoryMaster>()
           .ToTable("OnboardingPolicyCategoryMaster", "HR");
            modelBuilder.Entity<OnboardingActivityCategoryMaster>()
    .HasData(OnboardingActivityCategorySeedData.GetData());

            modelBuilder.Entity<OnboardingActivityMaster>()
                .HasData(OnboardingActivitySeedData.GetData());
            modelBuilder.Entity<OnboardingPolicyMaster>()
                .ToTable("OnboardingPolicyMaster", "HR");
            modelBuilder.Entity<OnboardingPolicyCategoryMaster>()
    .HasData(OnboardingPolicyCategorySeedData.GetData());

            modelBuilder.Entity<OnboardingPolicyMaster>()
                .HasData(OnboardingPolicySeedData.GetData());
            modelBuilder.Entity<Employee>()
                .ToTable("Employee", "HR");

            modelBuilder.Entity<Department>()
                .ToTable("Department", "HR");

            modelBuilder.Entity<Designation>()
                .ToTable("Designation", "HR");

            modelBuilder.Entity<Branch>()
                .ToTable("Branch", "HR");

            modelBuilder.Entity<Division>()
                .ToTable("Division", "HR");

            modelBuilder.Entity<Country>()
                .ToTable("Country", "HR");

            modelBuilder.Entity<City>()
                .ToTable("City", "HR");

            modelBuilder.Entity<Nationality>()
                .ToTable("Nationality", "HR");

            modelBuilder.Entity<HRContact>()
                .ToTable("HRContact", "HR");

            modelBuilder.Entity<DocumentMaster>()
                .ToTable("DocumentMaster", "HR");

            modelBuilder.Entity<AssetMaster>()
     .ToTable("AssetMaster", "HR");

            modelBuilder.Entity<AssetInventory>()
                .ToTable("AssetInventory", "HR");

            modelBuilder.Entity<EmployeeAsset>()
                .ToTable("EmployeeAsset", "HR");

            modelBuilder.Entity<EmployeeDocument>()
                .ToTable("EmployeeDocument", "HR");

            modelBuilder.Entity<EmployeeActivity>()
                .ToTable("EmployeeActivity", "HR");
            modelBuilder.Entity<EmployeeTransfer>()
             .ToTable("EmployeeTransfer", "HR");
            modelBuilder.Entity<EmployeeExit>()
              .ToTable("EmployeeExit", "HR");
            modelBuilder.Entity<EmployeeSuspension>()
             .ToTable("EmployeeSuspension", "HR");
            modelBuilder.Entity<ManpowerRequest>()
           .ToTable("ManpowerRequest", "Recruitment");
            modelBuilder.Entity<JobProfile>()
             .ToTable("JobProfile", "Recruitment");
            modelBuilder.Entity<JobCategory>()
             .ToTable("JobCategory", "Recruitment");

            modelBuilder.Entity<SkillMaster>()
                .ToTable("SkillMaster", "Recruitment");

            modelBuilder.Entity<JobProfileSkill>()
                .ToTable("JobProfileSkill", "Recruitment");

            //onboarding
            modelBuilder.Entity<EmploymentTypeMaster>()
            .ToTable("EmploymentTypeMaster", "HR");
            //seeding the employemnttype data 
            modelBuilder.Entity<EmploymentTypeMaster>()
    .HasData(EmploymentTypeSeedData.GetData());

            modelBuilder.Entity<OnboardingStatusMaster>()
                .ToTable("OnboardingStatusMaster", "HR");
            modelBuilder.Entity<OnboardingStatusMaster>()
    .HasData(OnboardingStatusSeedData.GetData());

            modelBuilder.Entity<OnboardingSectionMaster>()
                .ToTable("OnboardingSectionMaster", "HR");

            modelBuilder.Entity<OnboardingDocumentMaster>()
                .ToTable("OnboardingDocumentMaster", "HR");

            modelBuilder.Entity<OnboardingPolicyMaster>()
                .ToTable("OnboardingPolicyMaster", "HR");

            modelBuilder.Entity<OnboardingActivityMaster>()
                .ToTable("OnboardingActivityMaster", "HR");
            modelBuilder.Entity<OnboardingDocumentCategoryMaster>()
    .ToTable("OnboardingDocumentCategoryMaster", "HR");

            modelBuilder.Entity<OnboardingDocumentCategoryMaster>()
    .HasData(OnboardingDocumentCategorySeedData.GetData());

            modelBuilder.Entity<EmployeeOnboardingSection>()
    .ToTable("EmployeeOnboardingSection", "HR");

            modelBuilder.Entity<EmployeeOnboardingSection>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingSection>()
                .HasOne(x => x.Section)
                .WithMany()
                .HasForeignKey(x => x.OnboardingSectionMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingDocument>()
    .ToTable("EmployeeOnboardingDocument", "HR");

            modelBuilder.Entity<EmployeeOnboardingDocument>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingDocument>()
                .HasOne(x => x.Document)
                .WithMany()
                .HasForeignKey(x => x.OnboardingDocumentMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingPolicy>()
    .ToTable("EmployeeOnboardingPolicy", "HR");

            modelBuilder.Entity<EmployeeOnboardingPolicy>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingPolicy>()
                .HasOne(x => x.Policy)
                .WithMany()
                .HasForeignKey(x => x.OnboardingPolicyMasterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingActivity>()
    .ToTable("EmployeeOnboardingActivity", "HR");

            modelBuilder.Entity<EmployeeOnboardingActivity>()
                .HasOne(x => x.EmployeeOnboarding)
                .WithMany()
                .HasForeignKey(x => x.EmployeeOnboardingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeOnboardingActivity>()
                .HasOne(x => x.Activity)
                .WithMany()
                .HasForeignKey(x => x.OnboardingActivityMasterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}