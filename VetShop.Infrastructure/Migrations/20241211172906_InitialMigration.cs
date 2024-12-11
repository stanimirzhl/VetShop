using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veterinaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VeterinaryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusOfAppointment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Veterinaries_VeterinaryId",
                        column: x => x.VeterinaryId,
                        principalTable: "Veterinaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "73a08f28-3434-45fe-b44c-90c7cae4916d", 0, "87e644c9-6175-4a20-8d4f-85e38dbdd394", "guest@gmail.com", false, "Guest", "User", false, null, null, null, "AQAAAAIAAYagAAAAECKrSzsfTolshHP6NbFU0AALgyNKAqVY+zIusb+Qd7MzUUvFPalhprA/ajWoa/8Zsw==", null, false, "a92392a9-8af7-4461-a15e-93a50a08bea5", false, "Guest User" },
                    { "cb2e865b-c700-40b6-af4f-9ed7429ac4bc", 0, "eea998ef-c3b9-4386-b9b3-8f9d1daa2bc4", "veterinary@gmail.com", false, "Veterinary", "User", false, null, null, null, "AQAAAAIAAYagAAAAEJhmgkBPv3r1jaJhgeiuGHyk56xwxyMyP4uF/Ej0UaHa0OsWI5elxhHBtR9nnp4vXQ==", null, false, "0fe7839c-b59e-447f-8b41-83f64855df41", false, "Guest2 User" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Hill’s Science Diet", "https://upload.wikimedia.org/wikipedia/en/a/a7/Hill%27s_Science_Diet_logo.jpg" },
                    { 2, "Royal Canin", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Royal-Canin-Logo.svg/1920px-Royal-Canin-Logo.svg.png" },
                    { 3, "Pedigree", "https://imgs.search.brave.com/frtJBlHhDNgydF724H2Y2bn0iH7BpIdBOxD21embM1M/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pLnBp/bmltZy5jb20vb3Jp/Z2luYWxzLzlkLzQ5/L2Q2LzlkNDlkNjU4/YjFhZjYyOTMxYjJm/MTY4ZThjODFhNjM2/LmpwZw" },
                    { 4, "Purina", "https://imgs.search.brave.com/Z3GVpNkUeONQEF2lTMGvGLO_-XmWc4fFMMqD62jNdo4/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/bmVzdGxlLmNvbS9z/aXRlcy9kZWZhdWx0/L2ZpbGVzL3N0eWxl/cy93ZWJwX2ltYWdl/L3B1YmxpYy9wdXJp/bmEtbG9nby1zcXVh/cmUtMjAyMy5wbmcu/d2VicD9pdG9rPVgt/LWRaZXpo" },
                    { 5, "Blue Buffalo", "https://imgs.search.brave.com/FijpYqOLAnX9_i67vECFBphIJJEGGmKI7zTzxgBsxsE/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9hc3Nl/dHMuc3RpY2twbmcu/Y29tL2ltYWdlcy82/MDI5MGYwMDYyNTFl/NTAwMDRlNWYxZjku/cG5n" },
                    { 6, "Wellness", "https://www.wellnesspetfood.com/wp-content/uploads/2024/01/Wellness.png" },
                    { 7, "Iams", "https://imgs.search.brave.com/SQXbqX5SQX_PC0vrWgSARARuSIvCIbwzHMObBUXOex8/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy90/aHVtYi81LzUwL0lB/TVMtTG9nby5zdmcv/MjIwcHgtSUFNUy1M/b2dvLnN2Zy5wbmc" },
                    { 8, "Orijen", "https://imgs.search.brave.com/9Bc0WMTArndMR0Y5gQOm2ozjwqHS9-PuBpRmjhX4JzA/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4x/MS5iaWdjb21tZXJj/ZS5jb20vcy1pYWt3/enI3cnM3L2ltYWdl/cy9zdGVuY2lsL29y/aWdpbmFsL2ovb3Jp/amVuXzE1MzQ5NDk2/NjNfXzUwNjkyLm9y/aWdpbmFsLnBuZw" },
                    { 9, "Acana", "https://imgs.search.brave.com/yM_0sL0U1T9nlCzFr-MoeZ5vDo6WnGgxITk9W9LRc7I/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4x/MS5iaWdjb21tZXJj/ZS5jb20vcy1pYWt3/enI3cnM3L2ltYWdl/cy9zdGVuY2lsL29y/aWdpbmFsL28vMTky/OF9hY25fMTUzNDM3/MjI1Nl9fMjE0MjIu/b3JpZ2luYWwuanBn" },
                    { 10, "Merrick", "https://imgs.search.brave.com/zU4e80z1aJu6vqlaREbXCAhmLcgW0l79vubMy68CPNY/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/azljdWlzaW5lLmNv/bS9tZWRpYS9hbWFz/dHkvc2hvcGJ5L29w/dGlvbl9pbWFnZXMv/bWVycmljay1wZXQt/Zm9vZC5qcGc" },
                    { 11, "Canidae", "https://img.petfoodindustry.com/files/base/wattglobalmedia/all/image/2023/05/pfi.canidae-logo.png?auto=format%2Ccompress&fit=max&q=70&w=1200" },
                    { 12, "Natural Balance", "https://www.naturalbalanceinc.com/wp-content/themes/natural-balance/resources/images/natural-balance.png?" },
                    { 13, "Taste of the Wild", "https://www.tasteofthewildpetfood.com/wp-content/uploads/2019/08/totw-logo-stacked.png" },
                    { 14, "Solid Gold", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRYHq0CD0gmGzvwGseAsR9FR0tQayfvn2xmiw&s" },
                    { 15, "KONG", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbTowr_PTTt9MIl1HfFsKksT5QdJfHZBRwig&s" },
                    { 16, "Chuckit!", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8nnPZPSrDr_GI5GQwD3Zi8fBKvbEnMgDdwA&s" },
                    { 17, "Nerf Dog", "https://www.wnp.com.hk/cdn/shop/collections/Nerf_Dog.jpg?v=1556537026" },
                    { 18, "Outward Hound", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBpoUwlVPIGLyGt9S7U8qf2KmcE1E0Pt5Obg&s" },
                    { 19, "PetSafe", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHlfvZUmjZyjltXNW9nHZ51gsyWrp9ADjOzQ&s" },
                    { 20, "Gourmet", "https://static.wikia.nocookie.net/logopedia/images/a/a6/Gourmet_%28pet_food%29_2.png/revision/latest?cb=20210123122812" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cats" },
                    { 2, "Dogs" },
                    { 3, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 11, 19, 29, 6, 428, DateTimeKind.Local).AddTicks(1981), 0, "73a08f28-3434-45fe-b44c-90c7cae4916d" },
                    { 2, new DateTime(2024, 12, 11, 19, 29, 6, 428, DateTimeKind.Local).AddTicks(2033), 2, "cb2e865b-c700-40b6-af4f-9ed7429ac4bc" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 12, 1, "Complete and balanced food with minerals and vitamins, made with fresh ingredients for superior taste and natural nutrition. Grain-free.\r\n\r\nSpecial Cat GOLD Pâté for Kittens with Chicken: From weaning to around 12 months or until neutering. Suitable for pregnant and nursing mothers.\r\n\r\nIngredients: Fresh chicken meat and meat products (45%), plant-based products, minerals. Additives: Vitamins, provitamins, and similar substances: Vitamin A 2,000 i.u./kg, Vitamin D3 200 i.u./kg, Vitamin E 20 i.u./kg, Manganese (Manganese sulfate monohydrate) 5.0mg/kg, Selenium (Sodium selenite) 0.04mg/kg, Iodine (Calcium iodate) 0.50mg/kg, Taurine 500mg/kg. Trace elements: Zinc (Zinc sulfate monohydrate) 10.0mg/kg.\r\n\r\nFeeding Guide: Feed 1/4 of the can for every 3 months of kitten's age. Adjust the amount of food based on activity level and body condition. Serve at room temperature. Always provide fresh drinking water. Storage: Store unopened cans in a dry, cool place. After opening, store in an airtight container in the fridge and use within 72 hours.\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Turkey: Ingredients: Fresh meat and meat products (35%), fresh turkey (min. 4%), plant-based products, minerals.\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Beef: Ingredients: Fresh meat and meat products (35%), fresh beef (min. 4%), plant-based products, minerals.\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Lamb: Ingredients: Fresh meat and meat products (35%), fresh lamb (min. 4%), plant-based products, minerals.\r\n\r\nSpecial Cat GOLD Pâté for Neutered Cats (1+ years) with Salmon: Ingredients: Fresh meat and meat products (31%), fresh salmon (min. 8%), plant-based products, minerals.\r\n\r\nAdditives: Vitamins, provitamins, and similar substances: Vitamin A 1,000 i.u./kg, Vitamin D3 100 i.u./kg, Vitamin E 10 i.u./kg, Manganese (Manganese sulfate monohydrate) 2.5mg/kg, Selenium (Sodium selenite) 0.02mg/kg, Iodine (Calcium iodate) 0.25mg/kg, Taurine 250mg/kg. Trace elements: Zinc (Zinc sulfate monohydrate) 5.0mg/kg.\r\n\r\nAnalytical Composition: Crude protein 8.0%, Crude fat 5.0%, Crude fiber 0.2%, Crude ash 2.0%, Moisture 82%.\r\n\r\nFeeding Guide: Feed 1 can (400g) per 5kg cat per 24 hours. Adjust the amount of food based on activity level and body condition. Serve at room temperature. Always provide fresh drinking water. Storage: Store unopened cans in a dry, cool place. After opening, store in an airtight container in the fridge and use within 72 hours.\r\n\r\nMade in Turkey.", "https://m.media-amazon.com/images/I/61ccbUsZsdL._AC_SL1000_.jpg", false, 15.56m, 54, "Pate for Cats" },
                    { 2, 11, 1, "Cat Can Ocean Fish & Chicken - 3.74 kg (Transparent)\r\n\r\nTreat your cat to a nutritious and flavorful meal with Cat Can Ocean Fish & Chicken. This premium cat food combines the delicious taste of ocean fish and tender chicken to provide your feline friend with a balanced diet that supports overall health. With a generous 3.74 kg weight, this large pack is perfect for cat owners looking for a cost-effective and high-quality option to keep their pets satisfied.\r\n\r\nFormulated with high-quality proteins, this formula supports your cat's lean muscle development and energy levels, while promoting a shiny coat and healthy skin. The recipe is enriched with essential vitamins and minerals, ensuring your cat receives all the nutrients it needs for optimal well-being.\r\n\r\nPackaged in a transparent can, this product showcases the quality and freshness of the ingredients, giving you peace of mind that your cat is enjoying a wholesome meal. Perfect for cats of all ages, Cat Can Ocean Fish & Chicken is the ideal choice for a delicious, healthy, and satisfying meal.\r\n\r\nKey Features:\r\n\r\n    Flavorful Blend: Made with a combination of ocean fish and chicken for a taste cats love.\r\n    High-Quality Protein: Supports lean muscle development and provides essential energy.\r\n    Essential Nutrients: Packed with vitamins and minerals for a healthy, balanced diet.\r\n    Transparent Packaging: Clear can design ensures product quality and freshness.\r\n    Large Size: 3.74 kg pack, ideal for multi-cat households or long-term feeding.\r\n\r\nFeeding Guidelines: Adjust portion sizes based on your cat's weight and activity level. Always provide fresh water alongside meals.\r\n\r\nGive your cat the best with Cat Can Ocean Fish & Chicken—the perfect meal for a happy, healthy feline!", "https://m.media-amazon.com/images/I/71dsU3Y0hRL._AC_SL1500_.jpg", false, 5.99m, 100, "Cat Can Ocean Fish, Chicken" },
                    { 3, 3, 1, "Saves Time, More Moments Together: With the automatic cat feeder, my mom no longer has to open the cat food container every time to refill my bowl. She just watches me eat, and I love that it gives her more time to be with me. I get my meals on time, ensuring I’m never hungry, and my food stays fresh and crispy, unlike the old bowls where my food would sit too long. Before, when my mom came home late, I’d often go hungry. Now, I’m fed and happy!\r\n\r\nDouble Lock Design, No Spills: When mom’s out, I’m busy guarding the house. I run around excitedly, sometimes bumping into the feeder, but thanks to its double-lock design, the food stays in place. No more mess for mom to clean up, and I can stay focused on my duties without worrying about spilled food.\r\n\r\n10s Voice Message, Mom’s Call: One of my favorite features is the ability to hear my mom’s voice before I eat! The automatic feeder can record a 10-second personalized message, so when it’s time for me to eat, I hear her say, “Baby, come eat!” I always run over immediately because I love hearing her voice, and the feeder doesn’t scare me at all!\r\n\r\n3L Capacity, Worry-Free Travel: When mom goes on trips, she leaves me in the care of the cat feeder. It holds 3L of food, enough to last me for up to 15 days. Mom no longer worries that I’ll go hungry while she’s away, and I’m happy knowing she’s having a relaxing time. She even sets up a feeding schedule for me, with 1 to 6 meals a day, and each meal can consist of 1 to 9 servings (11g per serving). I’m now a punctual kitty, eating on time!\r\n\r\nDual Power Supply, Consistent Feeding: One day, there was a power outage, and mom explained that the lights went out. But the automatic feeder kept working, and I got my food on time. It turns out the feeder runs on both electricity and batteries, so even if the power goes out, I still get my meals. Now, mom doesn’t have to worry about me missing a meal.", "https://m.media-amazon.com/images/I/71823ihrMEL._AC_SL1500_.jpg", false, 35.99m, 23, "Automatic Cat Feeder - Cat Feeder with 1-6 Meals" },
                    { 4, 7, 2, "Complete Dry Dog Food for Adult Dogs - Rich in Lamb and Rice\r\n\r\nGive your adult dog the best with our Complete Dry Dog Food, formulated with a delicious blend of rich lamb and nutritious rice. This balanced, high-quality formula is designed to meet the specific dietary needs of adult dogs, providing everything they need to thrive.\r\n\r\nPacked with premium protein from lamb, it helps support lean muscle mass, while easily digestible rice promotes optimal digestion and gut health. Enhanced with essential vitamins, minerals, and omega fatty acids, this food helps maintain a shiny coat, healthy skin, and supports overall immune function.\r\n\r\nPerfect for active dogs, this complete meal delivers the energy and nutrients your pet needs to stay strong and active throughout the day. Free from artificial preservatives and fillers, it offers a wholesome, natural meal that your dog will love.", "https://m.media-amazon.com/images/I/61JUpVMSEkL._AC_SL1500_.jpg", false, 10.99m, 3000, "Complete Dry Dog Food for Adult Dogs, Rich in Lamb and Rice" },
                    { 5, 9, 2, "Dog Food Mixed in Gravy - Delicious and Nutritious\r\n\r\nTreat your dog to a meal they'll love with our Dog Food Mixed in Gravy. This savory recipe combines high-quality meat with a rich, flavorful gravy that enhances the taste and texture, making every bite irresistible. Packed with protein-rich meat and essential nutrients, it provides a complete and balanced diet to support your dog’s overall health and well-being.\r\n\r\nPerfect for picky eaters or dogs in need of extra hydration, this wet food ensures that every meal is both satisfying and nourishing. The gravy not only adds a burst of flavor but also promotes healthy digestion and helps keep your dog hydrated throughout the day.\r\n\r\nIdeal as a standalone meal or as a tasty topper to dry kibble, Dog Food Mixed in Gravy is suitable for dogs of all breeds and sizes, providing them with the nutrients they need to stay happy, active, and healthy.", "https://m.media-amazon.com/images/I/61bvaNMzZQL._AC_SL1024_.jpg", false, 15.89m, 5129, "Dog Food Mixed in Gravy" },
                    { 6, 10, 2, "Meaty Chunks Mixed in Jelly Wet Dog Food – A Savory Delight\r\n\r\nSatisfy your dog's cravings with our Meaty Chunks Mixed in Jelly Wet Dog Food. This delectable recipe features tender, meaty chunks combined with a flavorful jelly that enhances the texture and taste, making every meal an irresistible treat. Packed with high-quality protein and essential nutrients, it supports your dog's overall health, providing the energy and nourishment they need.\r\n\r\nThe soft, juicy chunks in savory jelly are perfect for picky eaters or dogs who enjoy a variety of textures in their meals. The added jelly not only boosts the flavor but also promotes healthy digestion and hydration.\r\n\r\nWhether served as a stand-alone meal or as a topping for dry kibble, Meaty Chunks Mixed in Jelly Wet Dog Food is ideal for dogs of all sizes and breeds. Your dog will love every bite, and you'll love knowing they’re getting a balanced, nutritious meal.", "https://m.media-amazon.com/images/I/71qVGX-Z22L._AC_SL1500_.jpg", false, 14.89m, 3450, "Meaty Chunks Mixed in Jelly Wet" },
                    { 7, 12, 2, "Here’s a product description for Complete Food for Adult Dogs, Meat Selection in Gravy:\r\n\r\nComplete Food for Adult Dogs - Meat Selection in Gravy\r\n\r\nGive your adult dog a meal they’ll love with our Complete Food for Adult Dogs, featuring a delicious Meat Selection in Gravy. This tasty formula combines a variety of high-quality meats, including beef, chicken, and lamb, all served in a rich, flavorful gravy that adds moisture and enhances the taste.\r\n\r\nDesigned to meet the nutritional needs of adult dogs, this complete and balanced meal is packed with protein to support strong muscles and energy, along with essential vitamins and minerals to promote overall health and well-being. The gravy not only boosts flavor but also helps with hydration and digestion, ensuring your dog stays satisfied and healthy.\r\n\r\nIdeal for dogs of all breeds and sizes, Complete Food for Adult Dogs, Meat Selection in Gravy can be served as a standalone meal or as a tasty topper to dry kibble. With its delicious taste and balanced nutrition, it's the perfect choice for keeping your dog happy and thriving.", "https://m.media-amazon.com/images/I/616nCQ1rIUL._AC_SL1500_.jpg", false, 19.99m, 1256, "Complete Food for Adult Dogs, Meat Selection in Gravy" },
                    { 8, 13, 2, "Adult Lamb & Rice 2 kg Bag - Hypoallergenic Dry Dog Food\r\n\r\nProvide your adult dog with a nutritious, easily digestible meal with our Adult Lamb & Rice Dry Dog Food. Specially formulated with high-quality lamb as the primary protein source and rice for easy digestion, this hypoallergenic recipe is ideal for dogs with food sensitivities or allergies.\r\n\r\nThis 2 kg bag contains a balanced mix of essential nutrients, including vitamins, minerals, and omega fatty acids, to support your dog’s overall health, strong muscles, shiny coat, and healthy skin. The lamb provides a high-quality, lean protein, while rice serves as a gentle carbohydrate that helps maintain digestive health.\r\n\r\nFree from common allergens like grains, gluten, and artificial additives, this dry dog food ensures that your dog gets a wholesome, satisfying meal without unnecessary fillers. It’s the perfect choice for adult dogs of all breeds, especially those with sensitive stomachs or allergies.\r\n\r\nGive your dog a delicious, healthy, and hypoallergenic diet with Adult Lamb & Rice 2 kg Bag, and support their well-being every day!", "https://m.media-amazon.com/images/I/81bM6ccyZ1L._AC_SL1500_.jpg", false, 12.99m, 567, "Adult Lamb & Rice 2 kg Bag, Hypoallergenic Dry Dog Food" },
                    { 9, 20, 3, "Country’s Best Gra Mix Chick & Quail\r\n\r\nProvide your pets with the finest, all-natural nutrition with Country’s Best Gra Mix Chick & Quail. This premium blend combines high-quality chicken and quail to create a delicious and nutritious diet that supports the health and vitality of your birds. Specially formulated for poultry, this feed ensures your animals receive essential proteins, vitamins, and minerals to thrive.\r\n\r\nWith carefully selected ingredients, the Gra Mix Chick & Quail is designed to support healthy growth, improved egg production, and a vibrant, active lifestyle. The mix is easily digestible, helping to maintain strong bones and a shiny plumage, while also encouraging healthy, consistent laying patterns.\r\n\r\nPerfect for both chicks and quail, this feed can be used as a standalone meal or alongside other supplements to provide a balanced diet. Country’s Best Gra Mix offers an ideal solution for anyone raising healthy, happy chickens or quail.", "https://www.foodforbirds.co.uk/wp-content/uploads/2024/02/Countrys-Best-Gra-Mix-Chick-Quail-20kg-scaled.jpg", false, 23.98m, 300, "Country’s Best Gra Mix Chick & Quail" },
                    { 10, 18, 3, "African Parrot Mix\r\n\r\nGive your African parrot a nutritious and flavorful diet with African Parrot Mix. This specially formulated blend combines a variety of seeds, grains, and dried fruits to provide a balanced, complete diet for your feathered friend. Rich in essential vitamins, minerals, and healthy fats, this mix is designed to support your parrot's overall health, vibrant plumage, and active lifestyle.\r\n\r\nWith carefully selected ingredients like sunflower seeds, millet, dried fruits, and nuts, this mix promotes healthy digestion, strong beaks, and bones while helping to maintain your parrot’s energy levels throughout the day. The variety of textures and flavors is sure to keep your African parrot engaged and excited during mealtime.\r\n\r\nAfrican Parrot Mix is perfect for parrots of all sizes, providing a rich, enjoyable diet that can be served as a standalone meal or as part of a balanced feeding routine. Keep your parrot healthy, happy, and full of energy with this premium mix tailored specifically for their needs.", "https://petmarket.bg/wp-content/uploads/2022/02/5410340222010pack.png", false, 6.99m, 123, "AFRICAN PARROT MIX" },
                    { 11, 2, 3, "Here’s a product description for Hamster Tasty Mix | Pack of 2 x 700g:\r\n\r\nHamster Tasty Mix | Pack of 2 x 700g\r\n\r\nTreat your hamster to a delicious and nutritious meal with Hamster Tasty Mix. This specially crafted blend offers a variety of high-quality ingredients, including seeds, grains, and dried fruits, ensuring a balanced diet that supports your hamster's health, energy, and well-being. Available in a convenient Pack of 2 x 700g, this mix provides a generous supply to keep your hamster satisfied and nourished.\r\n\r\nEach bite is packed with essential vitamins and minerals to promote healthy digestion, strong teeth, and a shiny coat. The mix’s variety of textures and flavors encourages natural foraging behavior, keeping your hamster active and engaged throughout the day.\r\n\r\nPerfect for all hamster breeds, Hamster Tasty Mix can be served as a standalone food or combined with fresh fruits and vegetables for an extra treat. With the 2 x 700g pack, you’ll have enough to feed your pet for weeks, ensuring they enjoy every meal!", "https://m.media-amazon.com/images/I/61is0DrvB4L._AC_SL1024_.jpg", false, 12.97m, 467, "Hamster Tasty Mix | Pack of 2 x 700g " },
                    { 12, 4, 3, "Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food\r\n\r\nGive your hamster or gerbil a healthy, delicious, and nutritionally balanced diet with Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food. This premium muesli blend combines a variety of wholesome ingredients such as seeds, grains, dried fruits, and mealworms, providing your small pet with the protein and energy they need to thrive.\r\n\r\nRich in fibre, this mix promotes healthy digestion and helps maintain strong teeth, while the mealworms provide essential protein, supporting your pet’s growth and overall health. With added vitamins and minerals, this food helps maintain a shiny coat, boosts immunity, and keeps your pet full of energy.\r\n\r\nIdeal for hamsters and gerbils, this blend encourages natural foraging behaviors and is perfect for pets of all life stages.Whether you serve it as a main meal or mix it with fresh fruits and vegetables, Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food ensures your pet enjoys a balanced, tasty diet every day.", "https://m.media-amazon.com/images/I/514qbqR-lUL._AC_.jpg", false, 7.89m, 890, "Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food" }
                });

            migrationBuilder.InsertData(
                table: "Veterinaries",
                columns: new[] { "Id", "PhoneNumber", "Specialty", "UserId" },
                values: new object[] { 1, "987-654-3210", "Dermatology", "cb2e865b-c700-40b6-af4f-9ed7429ac4bc" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedOn", "Reason", "StatusOfAppointment", "UserId", "VeterinaryId" },
                values: new object[] { 1, new DateTime(2024, 12, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 19, 29, 6, 429, DateTimeKind.Local).AddTicks(3614), "Routine checkup", 0, "73a08f28-3434-45fe-b44c-90c7cae4916d", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "DateTime", "Description", "ProductId", "Status", "Title" },
                values: new object[] { 1, "73a08f28-3434-45fe-b44c-90c7cae4916d", new DateTime(2024, 12, 11, 19, 29, 6, 429, DateTimeKind.Local).AddTicks(6291), "This product made wonders for my pet.", 1, 1, "Great product!" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 3, 3 },
                    { 4, 2, 6, 10 },
                    { 5, 2, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VeterinaryId",
                table: "Appointments",
                column: "VeterinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinaries_PhoneNumber",
                table: "Veterinaries",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinaries_UserId",
                table: "Veterinaries",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Veterinaries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
