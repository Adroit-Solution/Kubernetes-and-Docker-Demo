using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DockerDemo.Migrations
{
    /// <inheritdoc />
    public partial class Init_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Slug = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    SKU = table.Column<string>(type: "longtext", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "longtext", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Devices, gadgets and accessories", true, "Electronics", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Printed and digital books across genres", true, "Books", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Men's and women's apparel", true, "Clothing", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home goods, decor and kitchenware", true, "Home", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toys, games and children's products", true, "Toys", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Currency", "Description", "ImageUrl", "IsActive", "Name", "Price", "SKU", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Battery-powered RC car with rechargeable battery.", null, true, "Remote Control Car", 44.50m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 0, 0, 0, 0)), "USD", "200-piece construction set for ages 6+.", null, true, "Building Blocks Set", 34.99m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(799), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 0, 0, 0, 0)), "USD", "1.7L stainless steel kettle with auto shut-off.", null, true, "Electric Kettle", 29.95m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(792), new TimeSpan(0, 0, 0, 0, 0)), "USD", "16-piece porcelain dinnerware set.", null, true, "Ceramic Dinner Set", 79.99m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 75, DateTimeKind.Unspecified).AddTicks(9043), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Over-ear, noise-cancelling headphones with long battery life.", null, true, "Wireless Headphones", 129.99m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 75, DateTimeKind.Unspecified).AddTicks(9047), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Fast-charge USB-C wall adapter, 30W.", null, true, "Smartphone Charger", 19.99m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Comprehensive guide to modern C# and .NET development.", null, true, "Modern C# Programming", 39.95m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(773), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Illustrated storybook for ages 3-7.", null, true, "Children's Picture Book", 12.50m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 0, 0, 0, 0)), "USD", "100% cotton, regular fit.", null, true, "Men's Casual T-Shirt", 24.00m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 0, 0, 0, 0)), "USD", "Stretch denim, slim fit.", null, true, "Women's Jeans", 49.99m, null, 0, new DateTimeOffset(new DateTime(2026, 4, 4, 11, 17, 26, 76, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
