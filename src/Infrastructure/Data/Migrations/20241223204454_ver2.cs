using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Games_GameId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_QuestionSets_QuestionSetId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Events_GameId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "QuestionSetId",
                table: "Games",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Games",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_Games_QuestionSetId",
                table: "Games",
                newName: "IX_Games_EventId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Events",
                newName: "EventGameId");

            migrationBuilder.AddColumn<int>(
                name: "PieceCount",
                table: "Vouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "Status",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "QuizzGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizzGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizzGames_QuestionSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShakeGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherPieceCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShakeGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShakeGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherPieces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PieceNumber = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherPieces_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangePieces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherPieceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangePieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangePieces_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExchangePieces_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExchangePieces_VoucherPieces_VoucherPieceId",
                        column: x => x.VoucherPieceId,
                        principalTable: "VoucherPieces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPieces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherPieceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPieces_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPieces_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPieces_VoucherPieces_VoucherPieceId",
                        column: x => x.VoucherPieceId,
                        principalTable: "VoucherPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePieces_FromUserId",
                table: "ExchangePieces",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePieces_ToUserId",
                table: "ExchangePieces",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangePieces_VoucherPieceId",
                table: "ExchangePieces",
                column: "VoucherPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzGames_GameId",
                table: "QuizzGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzGames_QuestionSetId",
                table: "QuizzGames",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ShakeGames_GameId",
                table: "ShakeGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPieces_GameId",
                table: "UserPieces",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPieces_UserId",
                table: "UserPieces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPieces_VoucherPieceId",
                table: "UserPieces",
                column: "VoucherPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherPieces_VoucherId",
                table: "VoucherPieces",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Events_EventId",
                table: "Games",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Events_EventId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "ExchangePieces");

            migrationBuilder.DropTable(
                name: "QuizzGames");

            migrationBuilder.DropTable(
                name: "ShakeGames");

            migrationBuilder.DropTable(
                name: "UserPieces");

            migrationBuilder.DropTable(
                name: "VoucherPieces");

            migrationBuilder.DropColumn(
                name: "PieceCount",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "CanExchangeVoucherPieces",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameplayInstruction",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Games",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Games",
                newName: "QuestionSetId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_EventId",
                table: "Games",
                newName: "IX_Games_QuestionSetId");

            migrationBuilder.RenameColumn(
                name: "EventGameId",
                table: "Events",
                newName: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_GameId",
                table: "Events",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Games_GameId",
                table: "Events",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_QuestionSets_QuestionSetId",
                table: "Games",
                column: "QuestionSetId",
                principalTable: "QuestionSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
