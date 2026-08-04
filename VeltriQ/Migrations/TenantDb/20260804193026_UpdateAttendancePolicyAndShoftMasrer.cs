using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class UpdateAttendancePolicyAndShoftMasrer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AttendancePolicies_AttendancePolicyId",
                schema: "HR",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendancePolicies_Company_CompanyId",
                table: "AttendancePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftMaster_AttendancePolicies_AttendancePolicyId",
                schema: "HR",
                table: "ShiftMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendancePolicies",
                table: "AttendancePolicies");

            migrationBuilder.DropIndex(
                name: "IX_AttendancePolicies_CompanyId",
                table: "AttendancePolicies");

            migrationBuilder.DropColumn(
                name: "OvertimeAfterHours",
                table: "AttendancePolicies");

            migrationBuilder.RenameTable(
                name: "AttendancePolicies",
                newName: "AttendancePolicy",
                newSchema: "HR");

            migrationBuilder.RenameColumn(
                name: "EarlyExitGraceMinutes",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "MinimumPunchesPerDay");

            migrationBuilder.RenameColumn(
                name: "AutoAbsent",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "RoundOvertime");

            migrationBuilder.RenameColumn(
                name: "AllowRegularization",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "IncludeWeeklyOffPrefixSuffix");

            migrationBuilder.RenameColumn(
                name: "AllowOvertime",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "IncludeHolidayPrefixSuffix");

            migrationBuilder.RenameColumn(
                name: "AllowMultiplePunch",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "IgnoreDuplicatePunch");

            migrationBuilder.RenameColumn(
                name: "AllowCompOff",
                schema: "HR",
                table: "AttendancePolicy",
                newName: "EnableSandwichRule");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyName",
                schema: "HR",
                table: "AttendancePolicy",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumWorkingHours",
                schema: "HR",
                table: "AttendancePolicy",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HalfDayHours",
                schema: "HR",
                table: "AttendancePolicy",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FullDayHours",
                schema: "HR",
                table: "AttendancePolicy",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "AllowSinglePunch",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AutoAbsentForMissingPunch",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AutoHalfDayForMissingPunch",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR",
                table: "AttendancePolicy",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuplicatePunchIntervalMinutes",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "EarlyOutDeductionDays",
                schema: "HR",
                table: "AttendancePolicy",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EarlyOutGraceMinutes",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EnableEarlyOut",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableLateMark",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableOvertime",
                schema: "HR",
                table: "AttendancePolicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LateMarkDeductionDays",
                schema: "HR",
                table: "AttendancePolicy",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaxEarlyOutPerMonth",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxLateMarksPerMonth",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumOvertimeHours",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumOvertimeMinutes",
                schema: "HR",
                table: "AttendancePolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendancePolicy",
                schema: "HR",
                table: "AttendancePolicy",
                column: "AttendancePolicyId");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5543));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 325, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 350, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6158));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 5, 1, 0, 24, 348, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePolicy_CompanyId_PolicyCode",
                schema: "HR",
                table: "AttendancePolicy",
                columns: new[] { "CompanyId", "PolicyCode" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AttendancePolicy_AttendancePolicyId",
                schema: "HR",
                table: "Attendance",
                column: "AttendancePolicyId",
                principalSchema: "HR",
                principalTable: "AttendancePolicy",
                principalColumn: "AttendancePolicyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendancePolicy_Company_CompanyId",
                schema: "HR",
                table: "AttendancePolicy",
                column: "CompanyId",
                principalSchema: "HR",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftMaster_AttendancePolicy_AttendancePolicyId",
                schema: "HR",
                table: "ShiftMaster",
                column: "AttendancePolicyId",
                principalSchema: "HR",
                principalTable: "AttendancePolicy",
                principalColumn: "AttendancePolicyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AttendancePolicy_AttendancePolicyId",
                schema: "HR",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendancePolicy_Company_CompanyId",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftMaster_AttendancePolicy_AttendancePolicyId",
                schema: "HR",
                table: "ShiftMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendancePolicy",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropIndex(
                name: "IX_AttendancePolicy_CompanyId_PolicyCode",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "AllowSinglePunch",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "AutoAbsentForMissingPunch",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "AutoHalfDayForMissingPunch",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "DuplicatePunchIntervalMinutes",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "EarlyOutDeductionDays",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "EarlyOutGraceMinutes",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "EnableEarlyOut",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "EnableLateMark",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "EnableOvertime",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "LateMarkDeductionDays",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "MaxEarlyOutPerMonth",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "MaxLateMarksPerMonth",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "MaximumOvertimeHours",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.DropColumn(
                name: "MinimumOvertimeMinutes",
                schema: "HR",
                table: "AttendancePolicy");

            migrationBuilder.RenameTable(
                name: "AttendancePolicy",
                schema: "HR",
                newName: "AttendancePolicies");

            migrationBuilder.RenameColumn(
                name: "RoundOvertime",
                table: "AttendancePolicies",
                newName: "AutoAbsent");

            migrationBuilder.RenameColumn(
                name: "MinimumPunchesPerDay",
                table: "AttendancePolicies",
                newName: "EarlyExitGraceMinutes");

            migrationBuilder.RenameColumn(
                name: "IncludeWeeklyOffPrefixSuffix",
                table: "AttendancePolicies",
                newName: "AllowRegularization");

            migrationBuilder.RenameColumn(
                name: "IncludeHolidayPrefixSuffix",
                table: "AttendancePolicies",
                newName: "AllowOvertime");

            migrationBuilder.RenameColumn(
                name: "IgnoreDuplicatePunch",
                table: "AttendancePolicies",
                newName: "AllowMultiplePunch");

            migrationBuilder.RenameColumn(
                name: "EnableSandwichRule",
                table: "AttendancePolicies",
                newName: "AllowCompOff");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyName",
                table: "AttendancePolicies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumWorkingHours",
                table: "AttendancePolicies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HalfDayHours",
                table: "AttendancePolicies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FullDayHours",
                table: "AttendancePolicies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "OvertimeAfterHours",
                table: "AttendancePolicies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendancePolicies",
                table: "AttendancePolicies",
                column: "AttendancePolicyId");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6152));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4593));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6391));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6511));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 230, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6884));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 252, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5743));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5403));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 4, 3, 3, 31, 251, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePolicies_CompanyId",
                table: "AttendancePolicies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AttendancePolicies_AttendancePolicyId",
                schema: "HR",
                table: "Attendance",
                column: "AttendancePolicyId",
                principalTable: "AttendancePolicies",
                principalColumn: "AttendancePolicyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendancePolicies_Company_CompanyId",
                table: "AttendancePolicies",
                column: "CompanyId",
                principalSchema: "HR",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftMaster_AttendancePolicies_AttendancePolicyId",
                schema: "HR",
                table: "ShiftMaster",
                column: "AttendancePolicyId",
                principalTable: "AttendancePolicies",
                principalColumn: "AttendancePolicyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
