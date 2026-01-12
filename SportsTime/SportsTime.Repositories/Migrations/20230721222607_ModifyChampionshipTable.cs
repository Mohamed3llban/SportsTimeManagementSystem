using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChampionshipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championshipes_Sports_SportId",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Championshipes",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.RenameTable(
                name: "Championshipes",
                schema: "Sport",
                newName: "Championships",
                newSchema: "Sport");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "Sport",
                table: "Championships",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Championshipes_SportId",
                schema: "Sport",
                table: "Championships",
                newName: "IX_Championships_SportId");

            migrationBuilder.AddColumn<bool>(
                name: "IsTest",
                schema: "Sport",
                table: "Championships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                schema: "Sport",
                table: "Championships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Championships",
                schema: "Sport",
                table: "Championships",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_TrainerId",
                schema: "Sport",
                table: "Championships",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_Sports_SportId",
                schema: "Sport",
                table: "Championships",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_Trainers_TrainerId",
                schema: "Sport",
                table: "Championships",
                column: "TrainerId",
                principalSchema: "Training",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_Sports_SportId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropForeignKey(
                name: "FK_Championships_Trainers_TrainerId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Championships",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropIndex(
                name: "IX_Championships_TrainerId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "IsTest",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.RenameTable(
                name: "Championships",
                schema: "Sport",
                newName: "Championshipes",
                newSchema: "Sport");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "Sport",
                table: "Championshipes",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Championships_SportId",
                schema: "Sport",
                table: "Championshipes",
                newName: "IX_Championshipes_SportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Championshipes",
                schema: "Sport",
                table: "Championshipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Championshipes_Sports_SportId",
                schema: "Sport",
                table: "Championshipes",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
