using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreBackEnd.Migrations
{
    public partial class updatecart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToCart_UserDefn_UserDefnId",
                table: "AddToCart");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_UserDefnId",
                table: "AddToCart");

            migrationBuilder.DropColumn(
                name: "UserDefnId",
                table: "AddToCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDefnId",
                table: "AddToCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_UserDefnId",
                table: "AddToCart",
                column: "UserDefnId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToCart_UserDefn_UserDefnId",
                table: "AddToCart",
                column: "UserDefnId",
                principalTable: "UserDefn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
