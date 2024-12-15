using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedSomething : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 14, 54, 4, 470, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb62100-4696-453f-bf11-334e7a8a37ee", "AQAAAAIAAYagAAAAECkIT/4664Lt8iplM3oBnzKa9aKZ/rRRR7xclwm9zGVMCDx/9PmGW8w2Vk6B9KEx8w==", "a649985b-0970-415b-8fee-7d9a0500363b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a26bb3-5c29-4a68-9096-34a5b4c66966", "AQAAAAIAAYagAAAAEN2DWx/WO+Uy8YfvUBI/Kd+mWrcxUwSKeulieMHVG8SiYBK1kFT8Bsrqh797BxbwRQ==", "20835a3e-66e3-4fc2-bc4a-0cd56323271a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 14, 14, 54, 4, 470, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 14, 54, 4, 470, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 14, 14, 54, 4, 470, DateTimeKind.Local).AddTicks(4620));
        }
    }
}
