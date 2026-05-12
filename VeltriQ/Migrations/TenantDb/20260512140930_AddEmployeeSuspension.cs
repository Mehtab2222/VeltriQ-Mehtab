using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddEmployeeSuspension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                schema: "HR",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EmployeeSuspension",
                schema: "HR",
                columns: table => new
                {
                    EmployeeSuspensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SuspensionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SuspensionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReinstated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSuspension", x => x.EmployeeSuspensionId);
                    table.ForeignKey(
                        name: "FK_EmployeeSuspension_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSuspension_EmployeeId",
                schema: "HR",
                table: "EmployeeSuspension",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSuspension",
                schema: "HR");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                schema: "HR",
                table: "Employee");
        }
    }
}
