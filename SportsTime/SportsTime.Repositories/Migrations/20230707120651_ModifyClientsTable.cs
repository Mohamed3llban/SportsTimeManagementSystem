using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "User",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentClient",
                schema: "User",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                schema: "User",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrentClient",
                schema: "User",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                schema: "User",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "User",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
