using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationBetweenProductAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 12, 13, 23, 730, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72781064-9033-4889-b5be-bb60309eb91a", "AQAAAAIAAYagAAAAEGSSaBi9m9mV4/DPSMSyZ6XS9+YgtSoQ0vcYU5Ls6yD8evDRryh3lMQwKXulkWpccQ==", "1d7e2add-751e-4c17-837c-9ccbd83176c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b12ba631-fbf1-49c5-9d44-a38b16f9a905", "AQAAAAIAAYagAAAAECDAtZmUV1GvEPfA1rul6GxkjExoRLfYUABc1d7S9OD2ADw8q/hAmvqelNflv8vwqg==", "74a20cc9-59a3-482d-8132-cad684f51ef2" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 12, 13, 23, 731, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 12, 13, 23, 730, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 12, 13, 23, 730, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
