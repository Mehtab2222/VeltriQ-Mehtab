using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddOnboardingTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnboardingTemplate",
                schema: "HR",
                columns: table => new
                {
                    OnboardingTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TemplateCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EmploymentTypeMasterId = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingTemplate", x => x.OnboardingTemplateId);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplate_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_OnboardingTemplate_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "HR",
                        principalTable: "Designation",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: "FK_OnboardingTemplate_EmploymentTypeMaster_EmploymentTypeMasterId",
                        column: x => x.EmploymentTypeMasterId,
                        principalSchema: "HR",
                        principalTable: "EmploymentTypeMaster",
                        principalColumn: "EmploymentTypeMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingTemplateActivity",
                schema: "HR",
                columns: table => new
                {
                    OnboardingTemplateActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingTemplateId = table.Column<int>(type: "int", nullable: false),
                    OnboardingActivityMasterId = table.Column<int>(type: "int", nullable: false),
                    ActivityDay = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingTemplateActivity", x => x.OnboardingTemplateActivityId);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplateActivity_OnboardingActivityMaster_OnboardingActivityMasterId",
                        column: x => x.OnboardingActivityMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingActivityMaster",
                        principalColumn: "OnboardingActivityMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplateActivity_OnboardingTemplate_OnboardingTemplateId",
                        column: x => x.OnboardingTemplateId,
                        principalSchema: "HR",
                        principalTable: "OnboardingTemplate",
                        principalColumn: "OnboardingTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingTemplateDocument",
                schema: "HR",
                columns: table => new
                {
                    OnboardingTemplateDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingTemplateId = table.Column<int>(type: "int", nullable: false),
                    OnboardingDocumentMasterId = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingTemplateDocument", x => x.OnboardingTemplateDocumentId);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplateDocument_OnboardingDocumentMaster_OnboardingDocumentMasterId",
                        column: x => x.OnboardingDocumentMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingDocumentMaster",
                        principalColumn: "OnboardingDocumentMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplateDocument_OnboardingTemplate_OnboardingTemplateId",
                        column: x => x.OnboardingTemplateId,
                        principalSchema: "HR",
                        principalTable: "OnboardingTemplate",
                        principalColumn: "OnboardingTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingTemplatePolicy",
                schema: "HR",
                columns: table => new
                {
                    OnboardingTemplatePolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingTemplateId = table.Column<int>(type: "int", nullable: false),
                    OnboardingPolicyMasterId = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingTemplatePolicy", x => x.OnboardingTemplatePolicyId);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplatePolicy_OnboardingPolicyMaster_OnboardingPolicyMasterId",
                        column: x => x.OnboardingPolicyMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingPolicyMaster",
                        principalColumn: "OnboardingPolicyMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingTemplatePolicy_OnboardingTemplate_OnboardingTemplateId",
                        column: x => x.OnboardingTemplateId,
                        principalSchema: "HR",
                        principalTable: "OnboardingTemplate",
                        principalColumn: "OnboardingTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplate_DepartmentId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplate_DesignationId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplate_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "EmploymentTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplateActivity_OnboardingActivityMasterId",
                schema: "HR",
                table: "OnboardingTemplateActivity",
                column: "OnboardingActivityMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplateActivity_OnboardingTemplateId",
                schema: "HR",
                table: "OnboardingTemplateActivity",
                column: "OnboardingTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplateDocument_OnboardingDocumentMasterId",
                schema: "HR",
                table: "OnboardingTemplateDocument",
                column: "OnboardingDocumentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplateDocument_OnboardingTemplateId",
                schema: "HR",
                table: "OnboardingTemplateDocument",
                column: "OnboardingTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplatePolicy_OnboardingPolicyMasterId",
                schema: "HR",
                table: "OnboardingTemplatePolicy",
                column: "OnboardingPolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingTemplatePolicy_OnboardingTemplateId",
                schema: "HR",
                table: "OnboardingTemplatePolicy",
                column: "OnboardingTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnboardingTemplateActivity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingTemplateDocument",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingTemplatePolicy",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingTemplate",
                schema: "HR");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1185));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5818));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 234, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 2, 49, 235, DateTimeKind.Local).AddTicks(1287));
        }
    }
}
