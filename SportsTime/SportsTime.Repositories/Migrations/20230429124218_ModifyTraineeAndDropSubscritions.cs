using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTraineeAndDropSubscritions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribtions",
                schema: "Sport");

            migrationBuilder.DropColumn(
                name: "FatherJob",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "IsMail",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "School",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                schema: "Training",
                table: "Trainees",
                newName: "SubPayingDate");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "Training",
                table: "Trainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubEndingDate",
                schema: "Training",
                table: "Trainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SubEndingDate",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.RenameColumn(
                name: "SubPayingDate",
                schema: "Training",
                table: "Trainees",
                newName: "BirthDay");

            migrationBuilder.AddColumn<string>(
                name: "FatherJob",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMail",
                schema: "Training",
                table: "Trainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "School",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subscribtions",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdultSubscribtion = table.Column<bool>(type: "bit", nullable: false),
                    IsCollected = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribtions", x => x.Id);
                });
        }
    }
}
