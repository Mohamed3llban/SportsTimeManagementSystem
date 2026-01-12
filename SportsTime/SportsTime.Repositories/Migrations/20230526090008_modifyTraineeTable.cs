using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class modifyTraineeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubEndingDate",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SubPayingDate",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrainerId",
                schema: "Training",
                table: "Trainees",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Trainers_TrainerId",
                schema: "Training",
                table: "Trainees",
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
                name: "FK_Trainees_Trainers_TrainerId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_TrainerId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "Training",
                table: "Trainees",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubEndingDate",
                schema: "Training",
                table: "Trainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubPayingDate",
                schema: "Training",
                table: "Trainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
