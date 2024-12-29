using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "QuizzGames");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Games",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "WiningScore",
                table: "QuizzGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-1232aa84fab3"),
                columns: new[] { "CanExchangeVoucherPieces", "GameplayInstruction", "ImageUrl", "Status" },
                values: new object[] { true, "Shake your phone to win a voucher piece, combine all difference pieces to get a voucher", "https://play-lh.googleusercontent.com/gtcbFGJIhU9Zfni1REuvrzlyQ0AnSV-9wUlL_hf32ACzwGAfeL1ttJJ09RSfvFoNA7nI=w240-h480-rw", "Active" });

            migrationBuilder.UpdateData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-53d2ed84fab3"),
                columns: new[] { "GameplayInstruction", "ImageUrl", "Name", "Status", "Type" },
                values: new object[] { "Answer the questions in livestream, choose right answers exceeding threshold to win a voucher", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCqwR5F3YJTWvePHVfsLoUgppmfPwEKJTV3A&s", "Quiz Game", "Active", "Quiz" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Hash", "ImageUrl", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab3"), "player@example.com", "Player 1", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", "", "0333444555", "player" },
                    { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab4"), "brand@example.com", "Brand 1", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", "", "0333444556", "brand" },
                    { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab5"), "admin@example.com", "Admin 1", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", "", "0333444557", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Email", "Field", "ImageUrl", "Latitude", "Longitude", "Name", "Phone", "UserId" },
                values: new object[] { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), null, null, null, null, null, "Brand 1", null, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab4") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "BrandId", "EndAt", "ImageUrl", "Name", "StartAt", "Status" },
                values: new object[] { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Event Example", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "QuestionSets",
                columns: new[] { "Id", "BrandId" },
                values: new object[] { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6") });

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "Id", "BrandId", "Code", "Description", "ExpiredAt", "ImageUrl", "PieceCount", "QrCodeUrl", "Quantity", "Value" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab7"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), "Voucher 1", "Đổi 1 tỉ tiền mặt", new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "", 10000000, 1000000 },
                    { new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab8"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), "Voucher 2", "Chúc bạn 1 ngày zui zẻ", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "", 10000000, 1000000 }
                });

            migrationBuilder.InsertData(
                table: "EventVouchers",
                columns: new[] { "Id", "EventId", "Quantity", "VoucherId" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab10"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), 100000000, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab7") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab11"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), 1, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab8") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "EndTime", "EventId", "GamePrototypeId", "StartTime", "Status" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab26"), new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), new Guid("9e4f49fe-0786-44c6-9061-53d2ed84fab3"), new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab27"), new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), new Guid("9e4f49fe-0786-44c6-9061-1232aa84fab3"), new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerList", "Content", "CorrectAnswer", "QuestionSetId" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab18"), "Hanoi;Ho Chi Minh;Da Nang;Hue", "What is the capital of Vietnam?", 1, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab19"), "Lyon;Paris;Marseille;Nice", "What is the capital of France?", 2, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab20"), "New York;Washington D.C;Los Angeles;Chicago", "What is the capital of USA?", 3, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab21"), "Tokyo;Osaka;Kyoto;Hokkaido", "What is the capital of Japan?", 4, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab22"), "Seoul;Busan;Incheon;Daegu", "What is the capital of South Korea?", 1, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab23"), "Beijing;Shanghai;Guangzhou;Shenzhen", "What is the capital of China?", 2, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab24"), "Bangkok;Chiang Mai;Phuket;Pattaya", "What is the capital of Thailand?", 3, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab25"), "Singapore;Sentosa;Jurong;Changi", "What is the capital of Singapore?", 4, new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17") }
                });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "Id", "EventId", "TurnsLeft", "UserId" },
                values: new object[] { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab16"), new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), 300, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab3") });

            migrationBuilder.InsertData(
                table: "VoucherPieces",
                columns: new[] { "Id", "ImageUrl", "PieceNumber", "VoucherId" },
                values: new object[,]
                {
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab12"), "https://roflmagnets.com/447-medium_default/number-1.jpg", 1, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab7") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab13"), "https://roflmagnets.com/304-large_default/number-2.jpg", 2, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab7") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab14"), "https://roflmagnets.com/447-medium_default/number-1.jpg", 1, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab8") },
                    { new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab15"), "https://roflmagnets.com/304-large_default/number-2.jpg", 2, new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventVouchers",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab10"));

            migrationBuilder.DeleteData(
                table: "EventVouchers",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab11"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab26"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab27"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab18"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab19"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab20"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab21"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab22"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab23"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab24"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab25"));

            migrationBuilder.DeleteData(
                table: "UserEvents",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab16"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab5"));

            migrationBuilder.DeleteData(
                table: "VoucherPieces",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab12"));

            migrationBuilder.DeleteData(
                table: "VoucherPieces",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab13"));

            migrationBuilder.DeleteData(
                table: "VoucherPieces",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab14"));

            migrationBuilder.DeleteData(
                table: "VoucherPieces",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab15"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab9"));

            migrationBuilder.DeleteData(
                table: "QuestionSets",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-3d2ed84fab17"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab3"));

            migrationBuilder.DeleteData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab7"));

            migrationBuilder.DeleteData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0783-44c6-9061-53d2ed84fab4"));

            migrationBuilder.DropColumn(
                name: "WiningScore",
                table: "QuizzGames");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Games",
                newName: "Type");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "QuizzGames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-1232aa84fab3"),
                columns: new[] { "CanExchangeVoucherPieces", "GameplayInstruction", "ImageUrl", "Status" },
                values: new object[] { false, "", "", "" });

            migrationBuilder.UpdateData(
                table: "GamePrototypes",
                keyColumn: "Id",
                keyValue: new Guid("9e4f49fe-0786-44c6-9061-53d2ed84fab3"),
                columns: new[] { "GameplayInstruction", "ImageUrl", "Name", "Status", "Type" },
                values: new object[] { "", "", "Quizz Game", "", "Quizz" });
        }
    }
}
