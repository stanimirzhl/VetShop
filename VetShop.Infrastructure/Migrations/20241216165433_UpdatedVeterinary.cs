using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedVeterinary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Veterinaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 16, 18, 54, 33, 236, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a08f28-3434-45fe-b44c-90c7cae4916d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64e05ab2-c52e-4c40-bb20-0e8c712566dd", "AQAAAAIAAYagAAAAEOF17AxEotIb8cP83zx+NfCV+9UxUJmOB5Kdvv0L/ONG3R7lfDqkvPmruDCTfVTgZg==", "b1566d12-fe20-43c6-a83b-e5bc69fce8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83732e67-3ebd-4d20-83ce-1acbfb49aa78", "AQAAAAIAAYagAAAAEAOPjI5EtjF3Rc49X3BDBnP1TNtBKxjPZ9mf4fdANl83aQxvLlvYfesWoqLvi2/rAg==", "95832a0b-136e-4597-887b-8e85561bb905" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 16, 18, 54, 33, 236, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 16, 18, 54, 33, 235, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 16, 18, 54, 33, 235, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "Veterinaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "24 Kapitan Dimitar Spisarevski");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Veterinaries");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
