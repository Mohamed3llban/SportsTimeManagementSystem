using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class FixNameSubscribtionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Sports_SportId",
                schema: "Subscribtion",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Trainees_TraineeId",
                schema: "Subscribtion",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Trainers_TrainerId",
                schema: "Subscribtion",
                table: "Sports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                schema: "Subscribtion",
                table: "Sports");

            migrationBuilder.EnsureSchema(
                name: "Sports");

            migrationBuilder.RenameTable(
                name: "Sports",
                schema: "Subscribtion",
                newName: "Subscribtions",
                newSchema: "Sports");

            migrationBuilder.RenameIndex(
                name: "IX_Sports_TrainerId",
                schema: "Sports",
                table: "Subscribtions",
                newName: "IX_Subscribtions_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sports_TraineeId",
                schema: "Sports",
                table: "Subscribtions",
                newName: "IX_Subscribtions_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions",
                newName: "IX_Subscribtions_SportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribtions",
                schema: "Sports",
                table: "Subscribtions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Trainees_TraineeId",
                schema: "Sports",
                table: "Subscribtions",
                column: "TraineeId",
                principalSchema: "Training",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Trainers_TrainerId",
                schema: "Sports",
                table: "Subscribtions",
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
                name: "FK_Subscribtions_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_Trainees_TraineeId",
                schema: "Sports",
                table: "Subscribtions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_Trainers_TrainerId",
                schema: "Sports",
                table: "Subscribtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribtions",
                schema: "Sports",
                table: "Subscribtions");

            migrationBuilder.EnsureSchema(
                name: "Subscribtion");

            migrationBuilder.RenameTable(
                name: "Subscribtions",
                schema: "Sports",
                newName: "Sports",
                newSchema: "Subscribtion");

            migrationBuilder.RenameIndex(
                name: "IX_Subscribtions_TrainerId",
                schema: "Subscribtion",
                table: "Sports",
                newName: "IX_Sports_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscribtions_TraineeId",
                schema: "Subscribtion",
                table: "Sports",
                newName: "IX_Sports_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscribtions_SportId",
                schema: "Subscribtion",
                table: "Sports",
                newName: "IX_Sports_SportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                schema: "Subscribtion",
                table: "Sports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Sports_SportId",
                schema: "Subscribtion",
                table: "Sports",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Trainees_TraineeId",
                schema: "Subscribtion",
                table: "Sports",
                column: "TraineeId",
                principalSchema: "Training",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Trainers_TrainerId",
                schema: "Subscribtion",
                table: "Sports",
                column: "TrainerId",
                principalSchema: "Training",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
