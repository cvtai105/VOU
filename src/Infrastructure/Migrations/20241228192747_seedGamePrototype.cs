using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedGamePrototype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GamePrototypes",
                columns: new[] { "Id", "CanExchangeVoucherPieces", "GameplayInstruction", "ImageUrl", "Name", "Status", "Type" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0786-44c6-9061-1232aa84fab3"), false, "", "", "Shake Game", "", "Shake" },
                    { new Guid("9e4f49fe-0786-44c6-9061-53d2ed84fab3"), false, "", "", "Quizz Game", "", "Quizz" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-1232aa84fab3"));

            migrationBuilder.DeleteData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-53d2ed84fab3"));
        }
    }
}
