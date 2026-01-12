using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPayrollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Trainers_TrainerId",
                schema: "Finance",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                schema: "Finance",
                table: "Payrolls",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Payrolls_TrainerId",
                schema: "Finance",
                table: "Payrolls",
                newName: "IX_Payrolls_EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainer",
                schema: "Finance",
                table: "Payrolls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Trainers_EmployeeId",
                schema: "Finance",
                table: "Payrolls",
                column: "EmployeeId",
                principalSchema: "Training",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Trainers_EmployeeId",
                schema: "Finance",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "IsTrainer",
                schema: "Finance",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                schema: "Finance",
                table: "Payrolls",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payrolls_EmployeeId",
                schema: "Finance",
                table: "Payrolls",
                newName: "IX_Payrolls_TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Trainers_TrainerId",
                schema: "Finance",
                table: "Payrolls",
                column: "TrainerId",
                principalSchema: "Training",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
