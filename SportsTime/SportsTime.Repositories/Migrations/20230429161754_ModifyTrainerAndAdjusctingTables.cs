using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTrainerAndAdjusctingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMail",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "Training",
                table: "Trainers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Address",
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

            migrationBuilder.AddColumn<int>(
                name: "Code",
                schema: "Training",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Training",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "Training",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayingDate",
                schema: "Training",
                table: "Trainers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                schema: "Training",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Training",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                schema: "Training",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Training",
                table: "TraineeRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Sport",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Finance",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Finance",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Sport",
                table: "Championshipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationaId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Finance",
                table: "AmountTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Training",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SportId",
                schema: "Training",
                table: "Trainers",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_SportId",
                schema: "Training",
                table: "Trainees",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AmountTypeId",
                schema: "Finance",
                table: "Incomes",
                column: "AmountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AmountTypeId",
                schema: "Finance",
                table: "Expenses",
                column: "AmountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AmountTypes_AmountTypeId",
                schema: "Finance",
                table: "Expenses",
                column: "AmountTypeId",
                principalSchema: "Finance",
                principalTable: "AmountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AmountTypes_AmountTypeId",
                schema: "Finance",
                table: "Incomes",
                column: "AmountTypeId",
                principalSchema: "Finance",
                principalTable: "AmountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Sports_SportId",
                schema: "Training",
                table: "Trainees",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Sports_SportId",
                schema: "Training",
                table: "Trainers",
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
                name: "FK_Expenses_AmountTypes_AmountTypeId",
                schema: "Finance",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AmountTypes_AmountTypeId",
                schema: "Finance",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Sports_SportId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Sports_SportId",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_SportId",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_SportId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_AmountTypeId",
                schema: "Finance",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AmountTypeId",
                schema: "Finance",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CV",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Experience",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "PayingDate",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "SportId",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Training",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SportId",
                schema: "Training",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Training",
                table: "TraineeRates");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Sport",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Finance",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Finance",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Sport",
                table: "Championshipes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Finance",
                table: "AmountTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Training",
                table: "Achievements");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "Training",
                table: "Trainers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Training",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsMail",
                schema: "Training",
                table: "Trainers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Training",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NationaId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
