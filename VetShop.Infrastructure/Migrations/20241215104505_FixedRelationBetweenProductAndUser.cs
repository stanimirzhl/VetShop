using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationBetweenProductAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "SavedProducts",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedProducts", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SavedProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SavedProducts_ProductId",
                table: "SavedProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedProducts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
