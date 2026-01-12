using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultsSubscriptionId",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "KidsSubscriptionId",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.RenameColumn(
                name: "IsAdultSport",
                schema: "Sport",
                table: "Sports",
                newName: "IsIndividual");

            migrationBuilder.RenameColumn(
                name: "IsAdultChamp",
                schema: "Sport",
                table: "Championshipes",
                newName: "IsIndividual");

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                schema: "Sport",
                table: "Championshipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Championshipes_SportId",
                schema: "Sport",
                table: "Championshipes",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championshipes_Sports_SportId",
                schema: "Sport",
                table: "Championshipes",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championshipes_Sports_SportId",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.DropIndex(
                name: "IX_Championshipes_SportId",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.DropColumn(
                name: "SportId",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.RenameColumn(
                name: "IsIndividual",
                schema: "Sport",
                table: "Sports",
                newName: "IsAdultSport");

            migrationBuilder.RenameColumn(
                name: "IsIndividual",
                schema: "Sport",
                table: "Championshipes",
                newName: "IsAdultChamp");

            migrationBuilder.AddColumn<int>(
                name: "AdultsSubscriptionId",
                schema: "Sport",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KidsSubscriptionId",
                schema: "Sport",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
