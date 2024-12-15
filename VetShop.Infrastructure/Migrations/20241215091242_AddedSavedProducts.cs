using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSavedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 11, 12, 42, 150, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e3bcccf-4500-47b7-b59e-b279a495f1df", "AQAAAAIAAYagAAAAEA+YbnQzWeHS47XxK3B6wICGErkJ5vLyH9MI3QWcovBGIE3Cvwuuy3bHq5cSNP9fQQ==", "49b47901-7508-45ee-bc6c-69fc0589c633" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b70b6e1-7db5-464c-b6f7-715bab6d2093", "AQAAAAIAAYagAAAAEM82WPGcdLrQCUhMzbyRLBlE8JM1QRa7EWyCRu1EW8POGmLtnepmguxKwcqD7/rmow==", "2467224b-a20f-40da-a94c-de58d6862bd0" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 11, 12, 42, 150, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 11, 12, 42, 150, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 11, 12, 42, 150, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 17, 53, 40, 419, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9627163f-24e4-4d1d-8bf9-5511b795abc4", "AQAAAAIAAYagAAAAEG6yH19/ukrV1aObaNjch3CAFcLpYqqLk0O4c3DOW7Paft10ZTD/1XQWqnQ6XSMVPw==", "b488254f-db9f-4abb-8670-8314052353ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f9611d-3dcb-4401-b52f-145ba3af5e0a", "AQAAAAIAAYagAAAAEGvj5Ia16dNs9u2wzfe6Ybo8oygoWyp7rk3hJRsPCPZ9LUsl1yUdfENBcAa7Jh4TVw==", "3c7ef61f-878a-41b4-b0a7-20e10bcc27bb" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 17, 53, 40, 419, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 17, 53, 40, 419, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 17, 53, 40, 419, DateTimeKind.Local).AddTicks(98));
        }
    }
}
