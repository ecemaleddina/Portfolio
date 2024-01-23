using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migeleventhinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_WorkCategories_WorkCategoryID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "idx_Portfolio_CategoryId_Deleted",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "WorkCategoryID",
                table: "Portfolios",
                newName: "WorkCategoryId");

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_CategoryId_Deleted",
                table: "Portfolios",
                columns: new[] { "WorkCategoryId", "Deleted" });

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_WorkCategories_WorkCategoryId",
                table: "Portfolios",
                column: "WorkCategoryId",
                principalTable: "WorkCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_WorkCategories_WorkCategoryId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "idx_Portfolio_CategoryId_Deleted",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "WorkCategoryId",
                table: "Portfolios",
                newName: "WorkCategoryID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_CategoryId_Deleted",
                table: "Portfolios",
                columns: new[] { "CategoryId", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios",
                column: "WorkCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_WorkCategories_WorkCategoryID",
                table: "Portfolios",
                column: "WorkCategoryID",
                principalTable: "WorkCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
