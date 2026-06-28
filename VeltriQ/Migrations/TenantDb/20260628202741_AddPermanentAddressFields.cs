using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddPermanentAddressFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentLandmark",
                schema: "HR",
                table: "EmployeeOnboardingAddress",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentLandmark",
                schema: "HR",
                table: "EmployeeOnboardingAddress",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeOnboardingDependent",
                schema: "HR",
                columns: table => new
                {
                    EmployeeOnboardingDependentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeOnboardingId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNominee = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOnboardingDependent", x => x.EmployeeOnboardingDependentId);
                    table.ForeignKey(
                        name: "FK_EmployeeOnboardingDependent_EmployeeOnboarding_EmployeeOnboardingId",
                        column: x => x.EmployeeOnboardingId,
                        principalSchema: "HR",
                        principalTable: "EmployeeOnboarding",
                        principalColumn: "EmployeeOnboardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOnboardingEmergencyContact",
                schema: "HR",
                columns: table => new
                {
                    EmployeeOnboardingEmergencyContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeOnboardingId = table.Column<int>(type: "int", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AlternateMobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOnboardingEmergencyContact", x => x.EmployeeOnboardingEmergencyContactId);
                    table.ForeignKey(
                        name: "FK_EmployeeOnboardingEmergencyContact_EmployeeOnboarding_EmployeeOnboardingId",
                        column: x => x.EmployeeOnboardingId,
                        principalSchema: "HR",
                        principalTable: "EmployeeOnboarding",
                        principalColumn: "EmployeeOnboardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOnboardingIdentity",
                schema: "HR",
                columns: table => new
                {
                    EmployeeOnboardingIdentityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeOnboardingId = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Uploaded = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOnboardingIdentity", x => x.EmployeeOnboardingIdentityId);
                    table.ForeignKey(
                        name: "FK_EmployeeOnboardingIdentity_EmployeeOnboarding_EmployeeOnboardingId",
                        column: x => x.EmployeeOnboardingId,
                        principalSchema: "HR",
                        principalTable: "EmployeeOnboarding",
                        principalColumn: "EmployeeOnboardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOnboardingQualification",
                schema: "HR",
                columns: table => new
                {
                    EmployeeOnboardingQualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeOnboardingId = table.Column<int>(type: "int", nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Institute = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PassingYear = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOnboardingQualification", x => x.EmployeeOnboardingQualificationId);
                    table.ForeignKey(
                        name: "FK_EmployeeOnboardingQualification_EmployeeOnboarding_EmployeeOnboardingId",
                        column: x => x.EmployeeOnboardingId,
                        principalSchema: "HR",
                        principalTable: "EmployeeOnboarding",
                        principalColumn: "EmployeeOnboardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2719));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3851));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3937));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2882));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 357, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 360, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3212));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3223));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3231));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2927));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2932));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2934));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 29, 1, 57, 38, 359, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnboardingDependent_EmployeeOnboardingId",
                schema: "HR",
                table: "EmployeeOnboardingDependent",
                column: "EmployeeOnboardingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnboardingEmergencyContact_EmployeeOnboardingId",
                schema: "HR",
                table: "EmployeeOnboardingEmergencyContact",
                column: "EmployeeOnboardingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnboardingIdentity_EmployeeOnboardingId",
                schema: "HR",
                table: "EmployeeOnboardingIdentity",
                column: "EmployeeOnboardingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnboardingQualification_EmployeeOnboardingId",
                schema: "HR",
                table: "EmployeeOnboardingQualification",
                column: "EmployeeOnboardingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOnboardingDependent",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmployeeOnboardingEmergencyContact",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmployeeOnboardingIdentity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmployeeOnboardingQualification",
                schema: "HR");

            migrationBuilder.DropColumn(
                name: "CurrentLandmark",
                schema: "HR",
                table: "EmployeeOnboardingAddress");

            migrationBuilder.DropColumn(
                name: "PermanentLandmark",
                schema: "HR",
                table: "EmployeeOnboardingAddress");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6945));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 878, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3081));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 880, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 28, 1, 52, 24, 879, DateTimeKind.Local).AddTicks(6343));
        }
    }
}
