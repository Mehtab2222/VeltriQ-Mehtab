using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class SeedOnboardingSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconCss",
                schema: "HR",
                table: "OnboardingSectionMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2637));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.InsertData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                columns: new[] { "OnboardingSectionMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IconCss", "IsActive", "IsMandatory", "IsVisible", "ModifiedBy", "ModifiedOn", "SectionCode", "SectionName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2360), null, 1, "", true, true, true, null, null, "PERSONAL", "Personal Information" },
                    { 2, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2400), null, 2, "", true, true, true, null, null, "ADDRESS", "Address" },
                    { 3, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2403), null, 3, "", true, true, true, null, null, "EMERGENCY", "Emergency Contact" },
                    { 4, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2406), null, 4, "", true, true, true, null, null, "DEPENDENT", "Dependents" },
                    { 5, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2408), null, 5, "", true, true, true, null, null, "QUALIFICATION", "Qualifications" },
                    { 6, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2410), null, 6, "", true, true, true, null, null, "IDENTITY", "Identity Documents" },
                    { 7, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2412), null, 7, "", true, true, true, null, null, "BANK", "Bank Details" },
                    { 8, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2414), null, 8, "", true, true, true, null, null, "DOCUMENT", "Company Documents" },
                    { 9, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2417), null, 9, "", true, true, true, null, null, "POLICY", "Policy Acceptance" },
                    { 10, null, new DateTime(2026, 6, 26, 21, 47, 0, 176, DateTimeKind.Local).AddTicks(2419), null, 10, "", true, true, true, null, null, "ACTIVITY", "Joining Activities" }
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 180, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1594));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1613));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(968));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 47, 0, 179, DateTimeKind.Local).AddTicks(1443));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IconCss",
                schema: "HR",
                table: "OnboardingSectionMaster");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4718));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 858, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3775));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 21, 11, 40, 857, DateTimeKind.Local).AddTicks(3889));
        }
    }
}
