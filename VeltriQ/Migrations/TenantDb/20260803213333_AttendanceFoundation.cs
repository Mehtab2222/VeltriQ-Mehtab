using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AttendanceFoundation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AttendancePolicies",
                columns: table => new
                {
                    AttendancePolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PolicyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LateGraceMinutes = table.Column<int>(type: "int", nullable: false),
                    EarlyExitGraceMinutes = table.Column<int>(type: "int", nullable: false),
                    HalfDayHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FullDayHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumWorkingHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllowMultiplePunch = table.Column<bool>(type: "bit", nullable: false),
                    AllowRegularization = table.Column<bool>(type: "bit", nullable: false),
                    AllowOvertime = table.Column<bool>(type: "bit", nullable: false),
                    OvertimeAfterHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllowCompOff = table.Column<bool>(type: "bit", nullable: false),
                    AutoAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsDefaultPolicy = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePolicies", x => x.AttendancePolicyId);
                    table.ForeignKey(
                        name: "FK_AttendancePolicies_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "HR",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayMaster",
                schema: "HR",
                columns: table => new
                {
                    HolidayMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    HolidayCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayMaster", x => x.HolidayMasterId);
                    table.ForeignKey(
                        name: "FK_HolidayMaster_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "HR",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HolidayMaster_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "HR",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyOffPolicy",
                schema: "HR",
                columns: table => new
                {
                    WeeklyOffPolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyOffPolicy", x => x.WeeklyOffPolicyId);
                    table.ForeignKey(
                        name: "FK_WeeklyOffPolicy_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "HR",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftMaster",
                schema: "HR",
                columns: table => new
                {
                    ShiftMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AttendancePolicyId = table.Column<int>(type: "int", nullable: false),
                    ShiftCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShiftName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    GraceInMinutes = table.Column<int>(type: "int", nullable: false),
                    GraceOutMinutes = table.Column<int>(type: "int", nullable: false),
                    FullDayHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    HalfDayHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinimumWorkingHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsNightShift = table.Column<bool>(type: "bit", nullable: false),
                    IsFlexibleShift = table.Column<bool>(type: "bit", nullable: false),
                    IsCrossDayShift = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftMaster", x => x.ShiftMasterId);
                    table.ForeignKey(
                        name: "FK_ShiftMaster_AttendancePolicies_AttendancePolicyId",
                        column: x => x.AttendancePolicyId,
                        principalTable: "AttendancePolicies",
                        principalColumn: "AttendancePolicyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftMaster_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "HR",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftMaster_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "HR",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "HR",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftMasterId = table.Column<int>(type: "int", nullable: false),
                    AttendancePolicyId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstPunchIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPunchOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BreakHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    LateMinutes = table.Column<int>(type: "int", nullable: false),
                    EarlyExitMinutes = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_AttendancePolicies_AttendancePolicyId",
                        column: x => x.AttendancePolicyId,
                        principalTable: "AttendancePolicies",
                        principalColumn: "AttendancePolicyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "HR",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "HR",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_ShiftMaster_ShiftMasterId",
                        column: x => x.ShiftMasterId,
                        principalSchema: "HR",
                        principalTable: "ShiftMaster",
                        principalColumn: "ShiftMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                schema: "HR",
                columns: table => new
                {
                    EmployeeShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftMasterId = table.Column<int>(type: "int", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => x.EmployeeShiftId);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_ShiftMaster_ShiftMasterId",
                        column: x => x.ShiftMasterId,
                        principalSchema: "HR",
                        principalTable: "ShiftMaster",
                        principalColumn: "ShiftMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftBreak",
                schema: "HR",
                columns: table => new
                {
                    ShiftBreakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftMasterId = table.Column<int>(type: "int", nullable: false),
                    BreakName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsPaidBreak = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftBreak", x => x.ShiftBreakId);
                    table.ForeignKey(
                        name: "FK_ShiftBreak_ShiftMaster_ShiftMasterId",
                        column: x => x.ShiftMasterId,
                        principalSchema: "HR",
                        principalTable: "ShiftMaster",
                        principalColumn: "ShiftMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceHistory",
                schema: "HR",
                columns: table => new
                {
                    AttendanceHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedBy = table.Column<int>(type: "int", nullable: false),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceHistory", x => x.AttendanceHistoryId);
                    table.ForeignKey(
                        name: "FK_AttendanceHistory_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "HR",
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceHistory_Employee_ChangedBy",
                        column: x => x.ChangedBy,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceOvertime",
                schema: "HR",
                columns: table => new
                {
                    AttendanceOvertimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollProcessed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceOvertime", x => x.AttendanceOvertimeId);
                    table.ForeignKey(
                        name: "FK_AttendanceOvertime_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "HR",
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceOvertime_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePunch",
                schema: "HR",
                columns: table => new
                {
                    AttendancePunchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PunchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AttendanceSource = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SelfiePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePunch", x => x.AttendancePunchId);
                    table.ForeignKey(
                        name: "FK_AttendancePunch_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "HR",
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendancePunch_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRegularization",
                schema: "HR",
                columns: table => new
                {
                    AttendanceRegularizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RequestedPunchIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedPunchOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRegularization", x => x.AttendanceRegularizationId);
                    table.ForeignKey(
                        name: "FK_AttendanceRegularization_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "HR",
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRegularization_Employee_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_AttendanceRegularization_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Attendance_AttendancePolicyId",
                schema: "HR",
                table: "Attendance",
                column: "AttendancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_BranchId",
                schema: "HR",
                table: "Attendance",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_CompanyId",
                schema: "HR",
                table: "Attendance",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmployeeId_AttendanceDate",
                schema: "HR",
                table: "Attendance",
                columns: new[] { "EmployeeId", "AttendanceDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ShiftMasterId",
                schema: "HR",
                table: "Attendance",
                column: "ShiftMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceHistory_AttendanceId",
                schema: "HR",
                table: "AttendanceHistory",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceHistory_ChangedBy",
                schema: "HR",
                table: "AttendanceHistory",
                column: "ChangedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceOvertime_AttendanceId",
                schema: "HR",
                table: "AttendanceOvertime",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceOvertime_EmployeeId",
                schema: "HR",
                table: "AttendanceOvertime",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePolicies_CompanyId",
                table: "AttendancePolicies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePunch_AttendanceId",
                schema: "HR",
                table: "AttendancePunch",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePunch_EmployeeId_PunchTime",
                schema: "HR",
                table: "AttendancePunch",
                columns: new[] { "EmployeeId", "PunchTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRegularization_ApprovedBy",
                schema: "HR",
                table: "AttendanceRegularization",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRegularization_AttendanceId",
                schema: "HR",
                table: "AttendanceRegularization",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRegularization_EmployeeId",
                schema: "HR",
                table: "AttendanceRegularization",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeId_EffectiveFrom",
                schema: "HR",
                table: "EmployeeShift",
                columns: new[] { "EmployeeId", "EffectiveFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftMasterId",
                schema: "HR",
                table: "EmployeeShift",
                column: "ShiftMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayMaster_BranchId",
                schema: "HR",
                table: "HolidayMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayMaster_CompanyId_BranchId_HolidayDate",
                schema: "HR",
                table: "HolidayMaster",
                columns: new[] { "CompanyId", "BranchId", "HolidayDate" },
                unique: true,
                filter: "[BranchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftBreak_ShiftMasterId",
                schema: "HR",
                table: "ShiftBreak",
                column: "ShiftMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftMaster_AttendancePolicyId",
                schema: "HR",
                table: "ShiftMaster",
                column: "AttendancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftMaster_BranchId",
                schema: "HR",
                table: "ShiftMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftMaster_CompanyId_BranchId_ShiftCode",
                schema: "HR",
                table: "ShiftMaster",
                columns: new[] { "CompanyId", "BranchId", "ShiftCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyOffPolicy_CompanyId",
                schema: "HR",
                table: "WeeklyOffPolicy",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceHistory",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AttendanceOvertime",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AttendancePunch",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AttendanceRegularization",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmployeeShift",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "HolidayMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ShiftBreak",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "WeeklyOffPolicy",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ShiftMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AttendancePolicies");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "HR",
                newName: "Company");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3188));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 215, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 238, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3676));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3752));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3377));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 28, 23, 54, 58, 237, DateTimeKind.Local).AddTicks(3540));
        }
    }
}
