using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChampTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipTrainee");

            migrationBuilder.DropColumn(
                name: "IsTest",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                schema: "Sport",
                table: "Championships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TraineesIds",
                schema: "Sport",
                table: "Championships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Sport",
                table: "Championships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Championships_TraineeId",
                schema: "Sport",
                table: "Championships",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_Trainees_TraineeId",
                schema: "Sport",
                table: "Championships",
                column: "TraineeId",
                principalSchema: "Training",
                principalTable: "Trainees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_Trainees_TraineeId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropIndex(
                name: "IX_Championships_TraineeId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "TraineesIds",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Sport",
                table: "Championships");

            migrationBuilder.AddColumn<bool>(
                name: "IsTest",
                schema: "Sport",
                table: "Championships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChampionshipTrainee",
                columns: table => new
                {
                    ChampionshipsId = table.Column<int>(type: "int", nullable: false),
                    TraineesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipTrainee", x => new { x.ChampionshipsId, x.TraineesId });
                    table.ForeignKey(
                        name: "FK_ChampionshipTrainee_Championships_ChampionshipsId",
                        column: x => x.ChampionshipsId,
                        principalSchema: "Sport",
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionshipTrainee_Trainees_TraineesId",
                        column: x => x.TraineesId,
                        principalSchema: "Training",
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTrainee_TraineesId",
                table: "ChampionshipTrainee",
                column: "TraineesId");
        }
    }
}
