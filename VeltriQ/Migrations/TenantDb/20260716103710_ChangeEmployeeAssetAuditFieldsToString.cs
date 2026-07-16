using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class ChangeEmployeeAssetAuditFieldsToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnboardingEmployeeActivity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeAddress",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeBank",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeDocument",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeEmergencyContact",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeIdentity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeePersonal",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeePolicyAcceptance",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeQualification",
                schema: "HR");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "HR",
                table: "EmployeeAsset",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "HR",
                table: "EmployeeAsset",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2924));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4325));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 26, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 48, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 16, 16, 7, 8, 47, DateTimeKind.Local).AddTicks(3441));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                schema: "HR",
                table: "EmployeeAsset",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                schema: "HR",
                table: "EmployeeAsset",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeActivity",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingActivityMasterId = table.Column<int>(type: "int", nullable: false),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ActivityStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CompletedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsOverdue = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeActivity", x => x.OnboardingEmployeeActivityId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeActivity_OnboardingActivityMaster_OnboardingActivityMasterId",
                        column: x => x.OnboardingActivityMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingActivityMaster",
                        principalColumn: "OnboardingActivityMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeActivity_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeAddress",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsSameAsPermanentAddress = table.Column<bool>(type: "bit", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ResidenceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    StayFrom = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeAddress", x => x.OnboardingEmployeeAddressId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "HR",
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeBank",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IFSCCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SWIFTCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeBank", x => x.OnboardingEmployeeBankId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeBank_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeDocument",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingDocumentMasterId = table.Column<int>(type: "int", nullable: false),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoredFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeDocument", x => x.OnboardingEmployeeDocumentId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeDocument_OnboardingDocumentMaster_OnboardingDocumentMasterId",
                        column: x => x.OnboardingDocumentMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingDocumentMaster",
                        principalColumn: "OnboardingDocumentMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeDocument_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeEmergencyContact",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeEmergencyContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AlternateMobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthorizedToReceiveInformation = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimaryContact = table.Column<bool>(type: "bit", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LivesWithEmployee = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PriorityOrder = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeEmergencyContact", x => x.OnboardingEmployeeEmergencyContactId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "HR",
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeIdentity",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeIdentityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityDocumentMasterId = table.Column<int>(type: "int", nullable: false),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeIdentity", x => x.OnboardingEmployeeIdentityId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeIdentity_IdentityDocumentMaster_IdentityDocumentMasterId",
                        column: x => x.IdentityDocumentMasterId,
                        principalSchema: "HR",
                        principalTable: "IdentityDocumentMaster",
                        principalColumn: "IdentityDocumentMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeIdentity_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeePersonal",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeePersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    BirthCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisabilityDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDifferentlyAbled = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotherTongue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeePersonal", x => x.OnboardingEmployeePersonalId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePersonal_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "HR",
                        principalTable: "Nationality",
                        principalColumn: "NationalityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePersonal_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeePolicyAcceptance",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeePolicyAcceptanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    OnboardingPolicyMasterId = table.Column<int>(type: "int", nullable: false),
                    AcceptanceMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AcceptanceRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AcceptanceStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcceptedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PolicyVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequiresReAcceptance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeePolicyAcceptance", x => x.OnboardingEmployeePolicyAcceptanceId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePolicyAcceptance_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePolicyAcceptance_OnboardingPolicyMaster_OnboardingPolicyMasterId",
                        column: x => x.OnboardingPolicyMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingPolicyMaster",
                        principalColumn: "OnboardingPolicyMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeQualification",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeQualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    QualificationMasterId = table.Column<int>(type: "int", nullable: false),
                    QualificationSpecializationMasterId = table.Column<int>(type: "int", nullable: true),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AttachmentFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BoardOrUniversity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CGPA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsHighestQualification = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassingYear = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SpecializationDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeQualification", x => x.OnboardingEmployeeQualificationId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_QualificationMaster_QualificationMasterId",
                        column: x => x.QualificationMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationMaster",
                        principalColumn: "QualificationMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_QualificationSpecializationMaster_QualificationSpecializationMasterId",
                        column: x => x.QualificationSpecializationMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationSpecializationMaster",
                        principalColumn: "QualificationSpecializationMasterId");
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1621));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1044));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5795));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 699, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1718));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 701, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5104));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(4999));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 15, 41, 44, 700, DateTimeKind.Local).AddTicks(5001));

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeActivity_OnboardingActivityMasterId",
                schema: "HR",
                table: "OnboardingEmployeeActivity",
                column: "OnboardingActivityMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeActivity_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeActivity",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_CityId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_CountryId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeBank_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeBank",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeDocument_OnboardingDocumentMasterId",
                schema: "HR",
                table: "OnboardingEmployeeDocument",
                column: "OnboardingDocumentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeDocument_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeDocument",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_CityId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_CountryId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeIdentity_IdentityDocumentMasterId",
                schema: "HR",
                table: "OnboardingEmployeeIdentity",
                column: "IdentityDocumentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeIdentity_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeIdentity",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePersonal_NationalityId",
                schema: "HR",
                table: "OnboardingEmployeePersonal",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePersonal_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeePersonal",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePolicyAcceptance_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeePolicyAcceptance",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePolicyAcceptance_OnboardingPolicyMasterId",
                schema: "HR",
                table: "OnboardingEmployeePolicyAcceptance",
                column: "OnboardingPolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_QualificationMasterId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "QualificationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_QualificationSpecializationMasterId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "QualificationSpecializationMasterId");
        }
    }
}
