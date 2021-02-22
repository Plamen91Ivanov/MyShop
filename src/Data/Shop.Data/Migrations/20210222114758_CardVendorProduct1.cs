using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class CardVendorProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProductCarts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_UserId",
                table: "ProductCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_AspNetUsers_UserId",
                table: "ProductCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_AspNetUsers_UserId",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_UserId",
                table: "ProductCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductCarts");
        }
    }
}
