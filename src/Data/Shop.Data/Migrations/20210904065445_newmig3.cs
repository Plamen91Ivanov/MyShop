using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class newmig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Tests_TestId",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Tests_TestId",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_TestId",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ImageProduct_TestId",
                table: "ImageProduct");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "ProductCarts");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "ImageProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "ProductCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "ImageProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_TestId",
                table: "ProductCarts",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProduct_TestId",
                table: "ImageProduct",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Tests_TestId",
                table: "ImageProduct",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Tests_TestId",
                table: "ProductCarts",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
