using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToSportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Sport",
                table: "Sports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Sport",
                table: "Sports");
        }
    }
}
