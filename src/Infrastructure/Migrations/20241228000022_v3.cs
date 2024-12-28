using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzGames_Games_GameId",
                table: "QuizzGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShakeGames_Games_GameId",
                table: "ShakeGames");

            migrationBuilder.DropColumn(
                name: "CanExchangeVoucherPieces",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameplayInstruction",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "ShakeGames",
                newName: "GamePrototypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShakeGames_GameId",
                table: "ShakeGames",
                newName: "IX_ShakeGames_GamePrototypeId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "QuizzGames",
                newName: "GamePrototypeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizzGames_GameId",
                table: "QuizzGames",
                newName: "IX_QuizzGames_GamePrototypeId");

            migrationBuilder.AddColumn<Guid>(
                name: "EventGameId",
                table: "ShakeGames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventGameId",
                table: "QuizzGames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GamePrototypeId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GamePrototypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameplayInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanExchangeVoucherPieces = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePrototypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShakeGames_EventGameId",
                table: "ShakeGames",
                column: "EventGameId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzGames_EventGameId",
                table: "QuizzGames",
                column: "EventGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GamePrototypeId",
                table: "Games",
                column: "GamePrototypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GamePrototypes_GamePrototypeId",
                table: "Games",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzGames_Games_EventGameId",
                table: "QuizzGames",
                column: "EventGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames",
                column: "GamePrototypeId",
                principalTable: "GamePrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShakeGames_Games_EventGameId",
                table: "ShakeGames",
                column: "EventGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GamePrototypes_GamePrototypeId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzGames_GamePrototypes_GamePrototypeId",
                table: "QuizzGames");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzGames_Games_EventGameId",
                table: "QuizzGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShakeGames_GamePrototypes_GamePrototypeId",
                table: "ShakeGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShakeGames_Games_EventGameId",
                table: "ShakeGames");

            migrationBuilder.DropTable(
                name: "GamePrototypes");

            migrationBuilder.DropIndex(
                name: "IX_ShakeGames_EventGameId",
                table: "ShakeGames");

            migrationBuilder.DropIndex(
                name: "IX_QuizzGames_EventGameId",
                table: "QuizzGames");

            migrationBuilder.DropIndex(
                name: "IX_Games_GamePrototypeId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EventGameId",
                table: "ShakeGames");

            migrationBuilder.DropColumn(
                name: "EventGameId",
                table: "QuizzGames");

            migrationBuilder.DropColumn(
                name: "GamePrototypeId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GamePrototypeId",
                table: "ShakeGames",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_ShakeGames_GamePrototypeId",
                table: "ShakeGames",
                newName: "IX_ShakeGames_GameId");

            migrationBuilder.RenameColumn(
                name: "GamePrototypeId",
                table: "QuizzGames",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizzGames_GamePrototypeId",
                table: "QuizzGames",
                newName: "IX_QuizzGames_GameId");

            migrationBuilder.AddColumn<bool>(
                name: "CanExchangeVoucherPieces",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GameplayInstruction",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzGames_Games_GameId",
                table: "QuizzGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShakeGames_Games_GameId",
                table: "ShakeGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
