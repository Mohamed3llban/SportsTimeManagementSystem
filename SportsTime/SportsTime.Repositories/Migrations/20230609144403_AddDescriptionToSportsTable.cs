using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToSportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Sport",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Sport",
                table: "Sports",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
