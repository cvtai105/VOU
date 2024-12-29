using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makeNullableFieldGameBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames");

            migrationBuilder.AlterColumn<Guid>(
                name: "GamePrototypeId",
                table: "ShakeGames",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GamePrototypeId",
                table: "QuizzGames",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames");

            migrationBuilder.AlterColumn<Guid>(
                name: "GamePrototypeId",
                table: "ShakeGames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GamePrototypeId",
                table: "QuizzGames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
