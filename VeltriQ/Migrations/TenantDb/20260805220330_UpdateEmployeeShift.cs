using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateEmployeeShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_EmployeeId_EffectiveFrom",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "HR",
                table: "EmployeeShift",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                schema: "HR",
                table: "EmployeeShift",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5680));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5683));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6855));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(96));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(103));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 818, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6884));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 843, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 33, 26, 842, DateTimeKind.Local).AddTicks(6124));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_CompanyId",
                schema: "HR",
                table: "EmployeeShift",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeId",
                schema: "HR",
                table: "EmployeeShift",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShift_Company_CompanyId",
                schema: "HR",
                table: "EmployeeShift",
                column: "CompanyId",
                principalSchema: "HR",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShift_Company_CompanyId",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_CompanyId",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_EmployeeId",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "Remarks",
                schema: "HR",
                table: "EmployeeShift");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 162, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(63));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 179, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 6, 3, 2, 28, 178, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeId_EffectiveFrom",
                schema: "HR",
                table: "EmployeeShift",
                columns: new[] { "EmployeeId", "EffectiveFrom" });
        }
    }
}
