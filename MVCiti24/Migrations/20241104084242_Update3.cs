using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCiti24.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_CrsResults_CrsResultsId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "CrsResultsId",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_CrsResults_CrsResultsId",
                table: "Trainees",
                column: "CrsResultsId",
                principalTable: "CrsResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_CrsResults_CrsResultsId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "CrsResultsId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_CrsResults_CrsResultsId",
                table: "Trainees",
                column: "CrsResultsId",
                principalTable: "CrsResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
