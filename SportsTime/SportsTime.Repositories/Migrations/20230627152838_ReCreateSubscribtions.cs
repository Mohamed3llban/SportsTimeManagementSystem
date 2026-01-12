using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Context.Migrations
{
    /// <inheritdoc />
    public partial class ReCreateSubscribtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribtions_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                schema: "Sports",
                table: "Subscribtions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
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

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                schema: "Sports",
                table: "Subscribtions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribtions_Sports_SportId",
                schema: "Sports",
                table: "Subscribtions",
                column: "SportId",
                principalSchema: "Sport",
                principalTable: "Sports",
                principalColumn: "Id");
        }
    }
}
