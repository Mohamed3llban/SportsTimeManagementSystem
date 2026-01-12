using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTrainerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                schema: "Training",
                table: "Trainers",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CVPath",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVPath",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "Training",
                table: "Trainers",
                newName: "BirthDay");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CV",
                schema: "Training",
                table: "Trainers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Training",
                table: "Trainers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
