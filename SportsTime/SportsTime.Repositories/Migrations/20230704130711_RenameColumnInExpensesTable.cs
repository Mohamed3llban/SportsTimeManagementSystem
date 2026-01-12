using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInExpensesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecordTypeId",
                schema: "Finance",
                table: "Expenses",
                newName: "RecordScreenCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecordScreenCode",
                schema: "Finance",
                table: "Expenses",
                newName: "RecordTypeId");
        }
    }
}
