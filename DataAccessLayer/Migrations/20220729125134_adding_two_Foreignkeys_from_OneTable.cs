using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class adding_two_Foreignkeys_from_OneTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "FileOperations");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "FileOperations");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "FileOperations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "FileOperations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileOperations_ReceiverID",
                table: "FileOperations",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_FileOperations_SenderID",
                table: "FileOperations",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOperations_Admins_ReceiverID",
                table: "FileOperations",
                column: "ReceiverID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileOperations_Admins_SenderID",
                table: "FileOperations",
                column: "SenderID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOperations_Admins_ReceiverID",
                table: "FileOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_FileOperations_Admins_SenderID",
                table: "FileOperations");

            migrationBuilder.DropIndex(
                name: "IX_FileOperations_ReceiverID",
                table: "FileOperations");

            migrationBuilder.DropIndex(
                name: "IX_FileOperations_SenderID",
                table: "FileOperations");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "FileOperations");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "FileOperations");

            migrationBuilder.AddColumn<int>(
                name: "Receiver",
                table: "FileOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sender",
                table: "FileOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
