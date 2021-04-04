using Microsoft.EntityFrameworkCore.Migrations;

namespace PaperTradeAPI.Migrations
{
    public partial class currencyvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyValue",
                table: "Wallet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyValue",
                table: "Wallet");
        }
    }
}
