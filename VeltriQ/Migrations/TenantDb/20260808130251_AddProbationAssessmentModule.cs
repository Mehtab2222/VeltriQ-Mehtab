using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddProbationAssessmentModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProbationAssessmentMaster",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppraiserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProbationStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OverallStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalDecision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalDecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationAssessmentMaster", x => x.AssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProbationCriteriaMaster",
                columns: table => new
                {
                    CriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriteriaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriteriaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationCriteriaMaster", x => x.CriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "ProbationAssessmentDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    CheckpointNo = table.Column<int>(type: "int", nullable: false),
                    CheckpointLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScorePersonal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ScoreOperational = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverallScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverallGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strengths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopmentAreas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SigManager = table.Column<bool>(type: "bit", nullable: false),
                    SigManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigEmployee = table.Column<bool>(type: "bit", nullable: false),
                    SigEmployeeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigHR = table.Column<bool>(type: "bit", nullable: false),
                    SigHRDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckpointDecision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckpointDecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationAssessmentDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ProbationAssessmentDetails_ProbationAssessmentMaster_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "ProbationAssessmentMaster",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProbationAssessmentRatings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    CriteriaId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingScore = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationAssessmentRatings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_ProbationAssessmentRatings_ProbationAssessmentDetails_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ProbationAssessmentDetails",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProbationAssessmentRatings_ProbationCriteriaMaster_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "ProbationCriteriaMaster",
                        principalColumn: "CriteriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProbationExtensionLog",
                columns: table => new
                {
                    ExtensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    OldProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewCheckpointNo = table.Column<int>(type: "int", nullable: true),
                    NewCheckpointDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtendedBy = table.Column<int>(type: "int", nullable: true),
                    ExtendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationExtensionLog", x => x.ExtensionId);
                    table.ForeignKey(
                        name: "FK_ProbationExtensionLog_ProbationAssessmentDetails_DetailId",
                        column: x => x.DetailId,
                        principalTable: "ProbationAssessmentDetails",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProbationExtensionLog_ProbationAssessmentMaster_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "ProbationAssessmentMaster",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                keyColumn: "IdentityDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7464));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentMaster",
                keyColumn: "OnboardingDocumentMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7645));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(384));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingSectionMaster",
                keyColumn: "OnboardingSectionMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 200, DateTimeKind.Local).AddTicks(386));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 217, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7041));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationMaster",
                keyColumn: "QualificationMasterId",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(7063));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6818));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                keyColumn: "QualificationSpecializationMasterId",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "QualificationTypeMaster",
                keyColumn: "QualificationTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 8, 8, 18, 32, 49, 216, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.CreateIndex(
                name: "IX_ProbationAssessmentDetails_AssessmentId_CheckpointNo",
                table: "ProbationAssessmentDetails",
                columns: new[] { "AssessmentId", "CheckpointNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProbationAssessmentMaster_EmployeeNo_CompanyId",
                table: "ProbationAssessmentMaster",
                columns: new[] { "EmployeeNo", "CompanyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProbationAssessmentRatings_CriteriaId",
                table: "ProbationAssessmentRatings",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProbationAssessmentRatings_DetailId_CriteriaId",
                table: "ProbationAssessmentRatings",
                columns: new[] { "DetailId", "CriteriaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProbationExtensionLog_AssessmentId",
                table: "ProbationExtensionLog",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProbationExtensionLog_DetailId",
                table: "ProbationExtensionLog",
                column: "DetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProbationAssessmentRatings");

            migrationBuilder.DropTable(
                name: "ProbationExtensionLog");

            migrationBuilder.DropTable(
                name: "ProbationCriteriaMaster");

            migrationBuilder.DropTable(
                name: "ProbationAssessmentDetails");

            migrationBuilder.DropTable(
                name: "ProbationAssessmentMaster");

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
        }
    }
}
