using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateHolidayMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HolidayMaster_CompanyId_BranchId_HolidayDate",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayName",
                schema: "HR",
                table: "HolidayMaster",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR",
                table: "HolidayMaster",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HalfDaySession",
                schema: "HR",
                table: "HolidayMaster",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HolidayType",
                schema: "HR",
                table: "HolidayMaster",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsHalfDay",
                schema: "HR",
                table: "HolidayMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IX_HolidayMaster_CompanyId",
                schema: "HR",
                table: "HolidayMaster",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HolidayMaster_CompanyId",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.DropColumn(
                name: "HalfDaySession",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.DropColumn(
                name: "HolidayType",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.DropColumn(
                name: "IsHalfDay",
                schema: "HR",
                table: "HolidayMaster");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayName",
                schema: "HR",
                table: "HolidayMaster",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(693));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5678));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5684));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5496));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 399, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 419, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8082));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 46, 27, 417, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.CreateIndex(
                name: "IX_HolidayMaster_CompanyId_BranchId_HolidayDate",
                schema: "HR",
                table: "HolidayMaster",
                columns: new[] { "CompanyId", "BranchId", "HolidayDate" },
                unique: true,
                filter: "[BranchId] IS NOT NULL");
        }
    }
}
