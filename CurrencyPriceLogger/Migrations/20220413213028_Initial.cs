using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyPriceLogger.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderBookUpdateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestBidPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestBidQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestAskPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestAskQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
