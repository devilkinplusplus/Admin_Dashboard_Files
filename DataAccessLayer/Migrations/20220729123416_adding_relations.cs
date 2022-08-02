using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class adding_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryFileID",
                table: "FileOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileID",
                table: "FileOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FileOperations_CategoryFileID",
                table: "FileOperations",
                column: "CategoryFileID");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOperations_Categories_CategoryFileID",
                table: "FileOperations",
                column: "CategoryFileID",
                principalTable: "Categories",
                principalColumn: "FileID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOperations_Categories_CategoryFileID",
                table: "FileOperations");

            migrationBuilder.DropIndex(
                name: "IX_FileOperations_CategoryFileID",
                table: "FileOperations");

            migrationBuilder.DropColumn(
                name: "CategoryFileID",
                table: "FileOperations");

            migrationBuilder.DropColumn(
                name: "FileID",
                table: "FileOperations");
        }
    }
}
