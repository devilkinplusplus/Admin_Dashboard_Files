using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class tableForDownloads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "DownloadOperations",
                columns: table => new
                {
                    DownloadOperationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    DownloadFileStatus = table.Column<bool>(type: "bit", nullable: false),
                    DownloadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadOperations", x => x.DownloadOperationID);
                    table.ForeignKey(
                        name: "FK_DownloadOperations_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadOperations_CategoryID",
                table: "DownloadOperations",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "FileDownloads",
                columns: table => new
                {
                    DownloadOperationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    DownloadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DownloadFileStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDownloads", x => x.DownloadOperationID);
                    table.ForeignKey(
                        name: "FK_FileDownloads_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDownloads_CategoryID",
                table: "FileDownloads",
                column: "CategoryID");
        }
    }
}
