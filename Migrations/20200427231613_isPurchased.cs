using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreBackEnd.Migrations
{
    public partial class isPurchased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "AddToCart",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "AddToCart");
        }
    }
}
