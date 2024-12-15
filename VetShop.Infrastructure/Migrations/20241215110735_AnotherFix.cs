using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnotherFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 13, 7, 35, 57, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2bd96e-91bb-408e-859e-2de6404d2ed9", "AQAAAAIAAYagAAAAEIh4Xn2wtXv5pp/xKOcvQVNG0Xg4hy9EKlqk7wjZfliAxGWPr467WoqcsJ9Gk+bx3A==", "689af8fb-7487-47c7-9a02-1906eb0b3465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2b55213-e482-4855-aef0-ea2f7f3fe295", "AQAAAAIAAYagAAAAEOYaaXQ00F3IZOOZcBYq3ACfptbWW8WONWRPCddvsUfoJ0q3tvsfU4JH3Z5xjb3GNQ==", "cf8883c0-e8b5-4bda-be2d-bc310e607e8c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 13, 7, 35, 57, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 13, 7, 35, 57, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 13, 7, 35, 57, DateTimeKind.Local).AddTicks(5811));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 12, 45, 4, 681, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8bf2436-9905-49a7-b066-694d751b950d", "AQAAAAIAAYagAAAAENDZ/hz3y0iNA7wovI23kFZF/umB8FYO+pke2qIOJcDYPStXalLhbINbg9uQNHjGvA==", "d0cd1aec-6ba5-4570-926c-122fed0ece9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1101e6a4-e2e8-477a-9144-6a5dee06ecf8", "AQAAAAIAAYagAAAAEHqh/IOQRq4AvBvx5HSgsahhMIEAGEv0gbqPPAEW+DmG0rL1urFlWXkyxoxOV0vdmg==", "4f67006e-dfe8-4f59-a3f0-898452fd052e" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 15, 12, 45, 4, 681, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 12, 45, 4, 680, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 15, 12, 45, 4, 680, DateTimeKind.Local).AddTicks(8275));
        }
    }
}
