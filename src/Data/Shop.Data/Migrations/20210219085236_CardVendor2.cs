using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class CardVendor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardVendorId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardVendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardVendors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CardVendorId",
                table: "Products",
                column: "CardVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_CardVendors_IsDeleted",
                table: "CardVendors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CardVendors_UserId",
                table: "CardVendors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CardVendors_CardVendorId",
                table: "Products",
                column: "CardVendorId",
                principalTable: "CardVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CardVendors_CardVendorId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CardVendors");

            migrationBuilder.DropIndex(
                name: "IX_Products_CardVendorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CardVendorId",
                table: "Products");
        }
    }
}
