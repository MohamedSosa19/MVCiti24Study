﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCiti24.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CrsResults_CrsResultsId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "CrsResultsId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CrsResults_CrsResultsId",
                table: "Courses",
                column: "CrsResultsId",
                principalTable: "CrsResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CrsResults_CrsResultsId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "CrsResultsId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CrsResults_CrsResultsId",
                table: "Courses",
                column: "CrsResultsId",
                principalTable: "CrsResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
