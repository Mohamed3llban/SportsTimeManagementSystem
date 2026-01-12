using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifySportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndividual",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.AddColumn<int>(
                name: "SportType",
                schema: "Sport",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SportType",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.AddColumn<bool>(
                name: "IsIndividual",
                schema: "Sport",
                table: "Sports",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
