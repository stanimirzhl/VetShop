using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedAnotherThing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 17, 52, 30, 287, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272a4378-a999-45e5-a41b-17d2fabe20e8", "AQAAAAIAAYagAAAAEGzxN1uJ3Dln5OZus/ApjX4sCTIyKbCVbYr4Jp6LOBWIKUuP8FqXj7nQCB4uZjCMVQ==", "22e4c6ad-8c4c-43d4-9263-f614bf9afceb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44b5f6e-421b-47df-8938-96cad1aa9dd9", "AQAAAAIAAYagAAAAEDRSkW6duxHK8D8azeI+u6GQzgP6KsPh9VMR8SNuhlv7uwFqO0pOndDkiGmQ2rA1Zg==", "4b75feff-d700-4d56-aa3a-753f810588ec" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 17, 52, 30, 287, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 17, 52, 30, 286, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 17, 52, 30, 286, DateTimeKind.Local).AddTicks(8261));
        }
    }
}
