using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChampionshipTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipTrainee");
        }
    }
}
