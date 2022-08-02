using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class adding_relations_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "FileID",
                table: "FileOperations",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "FileID",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FileOperations_CategoryID",
                table: "FileOperations",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOperations_Categories_CategoryID",
                table: "FileOperations",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOperations_Categories_CategoryID",
                table: "FileOperations");

            migrationBuilder.DropIndex(
                name: "IX_FileOperations_CategoryID",
                table: "FileOperations");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "FileOperations",
                newName: "FileID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "FileID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryFileID",
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
    }
}
