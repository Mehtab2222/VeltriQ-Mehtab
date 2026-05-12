using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddEmployeeExit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeExit",
                schema: "HR",
                columns: table => new
                {
                    EmployeeExitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ResignationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastWorkingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetsReturned = table.Column<bool>(type: "bit", nullable: false),
                    FnFCompleted = table.Column<bool>(type: "bit", nullable: false),
                    HRRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExit", x => x.EmployeeExitId);
                    table.ForeignKey(
                        name: "FK_EmployeeExit_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExit_EmployeeId",
                schema: "HR",
                table: "EmployeeExit",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeExit",
                schema: "HR");
        }
    }
}
