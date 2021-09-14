using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class relationship5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstId",
                table: "Relationships");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Relationships",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_AspNetUsers_UserId",
                table: "Relationships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_AspNetUsers_UserId",
                table: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Relationships");

            migrationBuilder.AddColumn<string>(
                name: "UserFirstId",
                table: "Relationships",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
