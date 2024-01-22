using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migthirdinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AboutSkills_SkillId",
                table: "AboutSkills");

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "AboutSkills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "idx_AboutSkill_SkillId_Deleted",
                table: "AboutSkills",
                columns: new[] { "SkillId", "Deleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_AboutSkill_SkillId_Deleted",
                table: "AboutSkills");

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "AboutSkills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AboutSkills_SkillId",
                table: "AboutSkills",
                column: "SkillId");
        }
    }
}
