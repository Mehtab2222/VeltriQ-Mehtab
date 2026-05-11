using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddEmployeeTransferProper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTransfer",
                schema: "HR",
                columns: table => new
                {
                    EmployeeTransferId =
                        table.Column<int>(nullable: false)
                            .Annotation
                            (
                                "SqlServer:Identity",
                                "1, 1"
                            ),

                    EmployeeId =
                        table.Column<int>(nullable: false),

                    CurrentBranchId =
                        table.Column<int>(nullable: false),

                    NewBranchId =
                        table.Column<int>(nullable: false),

                    CurrentDepartmentId =
                        table.Column<int>(nullable: false),

                    NewDepartmentId =
                        table.Column<int>(nullable: false),

                    CurrentDesignationId =
                        table.Column<int>(nullable: false),

                    NewDesignationId =
                        table.Column<int>(nullable: false),

                    EffectiveDate =
                        table.Column<DateTime>(nullable: false),

                    TransferReason =
                        table.Column<string>(nullable: true),

                    Status =
                        table.Column<string>(nullable: true),

                    CreatedOn =
                        table.Column<DateTime>(nullable: false)
                },

                constraints: table =>
                {
                    table.PrimaryKey
                    (
                        "PK_EmployeeTransfer",
                        x => x.EmployeeTransferId
                    );

                    table.ForeignKey(
                        name:
                            "FK_EmployeeTransfer_Employee_EmployeeId",

                        column:
                            x => x.EmployeeId,

                        principalSchema:
                            "HR",

                        principalTable:
                            "Employee",

                        principalColumn:
                            "EmployeeId",

                        onDelete:
                            ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        name:
                            "FK_EmployeeTransfer_Branch_CurrentBranchId",

                        column:
                            x => x.CurrentBranchId,

                        principalSchema:
                            "HR",

                        principalTable:
                            "Branch",

                        principalColumn:
                            "BranchId",

                        onDelete:
                            ReferentialAction.NoAction
                    );

                    table.ForeignKey(
                        name:
                            "FK_EmployeeTransfer_Branch_NewBranchId",

                        column:
                            x => x.NewBranchId,

                        principalSchema:
                            "HR",

                        principalTable:
                            "Branch",

                        principalColumn:
                            "BranchId",

                        onDelete:
                            ReferentialAction.NoAction
                    );
                });

            migrationBuilder.CreateIndex(
                name:
                    "IX_EmployeeTransfer_EmployeeId",

                schema:
                    "HR",

                table:
                    "EmployeeTransfer",

                column:
                    "EmployeeId"
            );

            migrationBuilder.CreateIndex(
                name:
                    "IX_EmployeeTransfer_CurrentBranchId",

                schema:
                    "HR",

                table:
                    "EmployeeTransfer",

                column:
                    "CurrentBranchId"
            );

            migrationBuilder.CreateIndex(
                name:
                    "IX_EmployeeTransfer_NewBranchId",

                schema:
                    "HR",

                table:
                    "EmployeeTransfer",

                column:
                    "NewBranchId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTransfer",
                schema: "HR");
        }
    }
}
