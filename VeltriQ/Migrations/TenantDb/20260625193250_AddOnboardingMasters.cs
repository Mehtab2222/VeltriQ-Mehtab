using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddOnboardingMasters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentTypeMaster",
                schema: "HR",
                columns: table => new
                {
                    EmploymentTypeMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentTypeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmploymentTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypeMaster", x => x.EmploymentTypeMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingActivityCategoryMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingActivityCategoryMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingActivityCategoryMaster", x => x.OnboardingActivityCategoryMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingDocumentCategoryMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingDocumentCategoryMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingDocumentCategoryMaster", x => x.OnboardingDocumentCategoryMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingPolicyCategoryMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingPolicyCategoryMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingPolicyCategoryMaster", x => x.OnboardingPolicyCategoryMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingSectionMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingSectionMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingSectionMaster", x => x.OnboardingSectionMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingStatusMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingStatusMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingStatusMaster", x => x.OnboardingStatusMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingActivityMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingActivityMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ActivityDay = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ActivityOwner = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    OnboardingActivityCategoryMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingActivityMaster", x => x.OnboardingActivityMasterId);
                    table.ForeignKey(
                        name: "FK_OnboardingActivityMaster_OnboardingActivityCategoryMaster_OnboardingActivityCategoryMasterId",
                        column: x => x.OnboardingActivityCategoryMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingActivityCategoryMaster",
                        principalColumn: "OnboardingActivityCategoryMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingDocumentMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingDocumentMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AllowedFileTypes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxFileSizeMB = table.Column<int>(type: "int", nullable: false),
                    AllowMultipleFiles = table.Column<bool>(type: "bit", nullable: false),
                    IsExpiryRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidationRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowDownloadByCandidate = table.Column<bool>(type: "bit", nullable: false),
                    IsVisibleToCandidate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSystemDocument = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    OnboardingDocumentCategoryMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingDocumentMaster", x => x.OnboardingDocumentMasterId);
                    table.ForeignKey(
                        name: "FK_OnboardingDocumentMaster_OnboardingDocumentCategoryMaster_OnboardingDocumentCategoryMasterId",
                        column: x => x.OnboardingDocumentCategoryMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingDocumentCategoryMaster",
                        principalColumn: "OnboardingDocumentCategoryMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingPolicyMaster",
                schema: "HR",
                columns: table => new
                {
                    OnboardingPolicyMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingPolicyCategoryMasterId = table.Column<int>(type: "int", nullable: false),
                    PolicyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PolicyVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    RequiresAcceptance = table.Column<bool>(type: "bit", nullable: false),
                    AllowDownload = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingPolicyMaster", x => x.OnboardingPolicyMasterId);
                    table.ForeignKey(
                        name: "FK_OnboardingPolicyMaster_OnboardingPolicyCategoryMaster_OnboardingPolicyCategoryMasterId",
                        column: x => x.OnboardingPolicyCategoryMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingPolicyCategoryMaster",
                        principalColumn: "OnboardingPolicyCategoryMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                columns: new[] { "EmploymentTypeMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "EmploymentTypeCode", "EmploymentTypeName", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1169), "Permanent Employee", 1, "PERM", "Permanent", true, null, null },
                    { 2, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1182), "Employee on Probation", 2, "PROB", "Probation", true, null, null },
                    { 3, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1184), "Contract Employee", 3, "CONT", "Contract", true, null, null },
                    { 4, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1185), "Internship", 4, "INTERN", "Intern", true, null, null },
                    { 5, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1186), "Consultant", 5, "CONSULT", "Consultant", true, null, null },
                    { 6, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1190), "Trainee", 6, "TRAINEE", "Trainee", true, null, null },
                    { 7, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1191), "Apprenticeship", 7, "APPRENTICE", "Apprentice", true, null, null },
                    { 8, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1193), "Part Time Employee", 8, "PARTTIME", "Part Time", true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                columns: new[] { "OnboardingActivityCategoryMasterId", "CategoryCode", "CategoryName", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "PREJOIN", "Pre Joining", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5818), "Activities before the joining date.", 1, true, null, null },
                    { 2, "DAYONE", "Day One", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5840), "Activities to be completed on the first day.", 2, true, null, null },
                    { 3, "FIRSTWEEK", "First Week", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5841), "Activities planned during the first week.", 3, true, null, null },
                    { 4, "FIRSTMONTH", "First Month", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5843), "Activities planned during the first month.", 4, true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                columns: new[] { "OnboardingDocumentCategoryMasterId", "CategoryCode", "CategoryName", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "IDENTITY", "Identity Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1468), "Government issued identity documents.", 1, true, null, null },
                    { 2, "ADDRESS", "Address Proof", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1475), "Documents used as address proof.", 2, true, null, null },
                    { 3, "EDUCATION", "Educational Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1476), "Academic certificates and mark sheets.", 3, true, null, null },
                    { 4, "EMPLOYMENT", "Employment Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1478), "Previous employment related documents.", 4, true, null, null },
                    { 5, "FINANCIAL", "Financial Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1479), "Bank and financial related documents.", 5, true, null, null },
                    { 6, "MEDICAL", "Medical Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1481), "Medical certificates and health records.", 6, true, null, null },
                    { 7, "OTHER", "Other Documents", null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1482), "Miscellaneous documents.", 7, true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                columns: new[] { "OnboardingPolicyCategoryMasterId", "CategoryCode", "CategoryName", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "HR", "HR Policies", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6122), "Human Resource related policies.", 1, true, null, null },
                    { 2, "IT", "IT Policies", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6130), "Information Technology policies.", 2, true, null, null },
                    { 3, "LEGAL", "Legal Policies", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6131), "Legal agreements and compliance.", 3, true, null, null },
                    { 4, "SECURITY", "Security Policies", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6133), "Information security policies.", 4, true, null, null },
                    { 5, "FINANCE", "Finance Policies", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6134), "Finance and reimbursement policies.", 5, true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                columns: new[] { "OnboardingStatusMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedOn", "StatusCode", "StatusName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1270), "Onboarding initiated but invitation not sent.", 1, true, null, null, "DRAFT", "Draft" },
                    { 2, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1275), "Invitation has been sent to the candidate.", 2, true, null, null, "INVITED", "Invitation Sent" },
                    { 3, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1276), "Candidate is filling the onboarding information.", 3, true, null, null, "INPROGRESS", "In Progress" },
                    { 4, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1277), "Candidate has submitted the onboarding form.", 4, true, null, null, "SUBMITTED", "Submitted" },
                    { 5, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1279), "HR is reviewing the submitted onboarding details.", 5, true, null, null, "REVIEW", "Under Review" },
                    { 6, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1282), "Candidate needs to correct or update the submitted information.", 6, true, null, null, "CORRECTION", "Corrections Required" },
                    { 7, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1283), "Onboarding has been approved by HR.", 7, true, null, null, "APPROVED", "Approved" },
                    { 8, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1284), "Candidate has been converted into an employee.", 8, true, null, null, "CONVERTED", "Converted to Employee" },
                    { 9, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1285), "Onboarding process has been cancelled.", 9, true, null, null, "CANCELLED", "Cancelled" },
                    { 10, null, new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1287), "Onboarding invitation has expired.", 10, true, null, null, "EXPIRED", "Expired" }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                columns: new[] { "OnboardingActivityMasterId", "ActivityCode", "ActivityDay", "ActivityName", "ActivityOwner", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "IsMandatory", "ModifiedBy", "ModifiedOn", "OnboardingActivityCategoryMasterId" },
                values: new object[,]
                {
                    { 1, "DOCVERIFY", 0, "Document Verification", "HR", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5950), "Verify submitted onboarding documents.", 1, true, true, null, null, 1 },
                    { 2, "WELCOME", 1, "Welcome Session", "HR", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5958), "Welcome session conducted by HR.", 2, true, true, null, null, 2 },
                    { 3, "EMAIL", 1, "Official Email Creation", "IT", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5960), "Create official email account.", 3, true, true, null, null, 2 },
                    { 4, "IDCARD", 1, "ID Card Allocation", "Admin", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6027), "Generate and issue employee ID card.", 4, true, true, null, null, 2 },
                    { 5, "ASSET", 1, "Asset Allocation", "IT", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6029), "Allocate laptop and other assets.", 5, true, true, null, null, 2 },
                    { 6, "PAYROLL", 1, "Payroll Setup", "Finance", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6034), "Create payroll profile.", 6, true, true, null, null, 2 },
                    { 7, "MANAGERINTRO", 2, "Manager Introduction", "Manager", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6036), "Introduction with reporting manager.", 7, true, true, null, null, 3 },
                    { 8, "TEAMINTRO", 2, "Team Introduction", "Manager", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6038), "Meet team members.", 8, true, true, null, null, 3 },
                    { 9, "ORIENTATION", 3, "Department Orientation", "Manager", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6039), "Department orientation session.", 9, true, true, null, null, 3 },
                    { 10, "REVIEW", 30, "First Month Review", "HR", null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6042), "Review employee onboarding progress.", 10, true, true, null, null, 4 }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                columns: new[] { "OnboardingPolicyMasterId", "AllowDownload", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "EffectiveDate", "IsActive", "IsMandatory", "ModifiedBy", "ModifiedOn", "OnboardingPolicyCategoryMasterId", "PolicyCode", "PolicyName", "PolicyVersion", "RequiresAcceptance" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6178), "Company HR policy.", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 1, "HRPOLICY", "HR Policy", "1.0", true },
                    { 2, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6190), "Employee leave policy.", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 1, "LEAVE", "Leave Policy", "1.0", true },
                    { 3, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6193), "Acceptable use of company IT resources.", 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 2, "IT", "IT Acceptable Use Policy", "1.0", true },
                    { 4, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6196), "Password management policy.", 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 2, "PASSWORD", "Password Policy", "1.0", true },
                    { 5, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6198), "Employee code of conduct.", 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 3, "COC", "Code of Conduct", "1.0", true },
                    { 6, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6202), "Confidentiality agreement.", 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 3, "NDA", "Non-Disclosure Agreement", "1.0", true },
                    { 7, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6204), "Information security guidelines.", 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, 4, "INFOSEC", "Information Security Policy", "1.0", true },
                    { 8, true, null, new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6207), "Expense reimbursement process.", 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, 5, "EXPENSE", "Expense Reimbursement Policy", "1.0", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingActivityMaster_OnboardingActivityCategoryMasterId",
                schema: "HR",
                table: "OnboardingActivityMaster",
                column: "OnboardingActivityCategoryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingDocumentMaster_OnboardingDocumentCategoryMasterId",
                schema: "HR",
                table: "OnboardingDocumentMaster",
                column: "OnboardingDocumentCategoryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingPolicyMaster_OnboardingPolicyCategoryMasterId",
                schema: "HR",
                table: "OnboardingPolicyMaster",
                column: "OnboardingPolicyCategoryMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentTypeMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingActivityMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingDocumentMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingPolicyMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingSectionMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingStatusMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingActivityCategoryMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingDocumentCategoryMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingPolicyCategoryMaster",
                schema: "HR");
        }
    }
}
