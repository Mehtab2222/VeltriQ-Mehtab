using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddRecruitmentSkillTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                schema: "Recruitment",
                table: "JobProfile");

            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                schema: "Recruitment",
                table: "JobProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobCategory",
                schema: "Recruitment",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobProfileSkill",
                schema: "Recruitment",
                columns: table => new
                {
                    JobProfileSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobProfileId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobProfileSkill", x => x.JobProfileSkillId);
                });

            migrationBuilder.CreateTable(
                name: "SkillMaster",
                schema: "Recruitment",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMaster", x => x.SkillId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCategory",
                schema: "Recruitment");

            migrationBuilder.DropTable(
                name: "JobProfileSkill",
                schema: "Recruitment");

            migrationBuilder.DropTable(
                name: "SkillMaster",
                schema: "Recruitment");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                schema: "Recruitment",
                table: "JobProfile");

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                schema: "Recruitment",
                table: "JobProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
