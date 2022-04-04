using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Catalog.Persistence.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 420m },
                    { 2, "Description for product 2", "Product 2", 272m },
                    { 3, "Description for product 3", "Product 3", 583m },
                    { 4, "Description for product 4", "Product 4", 423m },
                    { 5, "Description for product 5", "Product 5", 109m },
                    { 6, "Description for product 6", "Product 6", 753m },
                    { 7, "Description for product 7", "Product 7", 566m },
                    { 8, "Description for product 8", "Product 8", 424m },
                    { 9, "Description for product 9", "Product 9", 140m },
                    { 10, "Description for product 10", "Product 10", 188m },
                    { 11, "Description for product 11", "Product 11", 933m },
                    { 12, "Description for product 12", "Product 12", 263m },
                    { 13, "Description for product 13", "Product 13", 431m },
                    { 14, "Description for product 14", "Product 14", 154m },
                    { 15, "Description for product 15", "Product 15", 424m },
                    { 16, "Description for product 16", "Product 16", 589m },
                    { 17, "Description for product 17", "Product 17", 808m },
                    { 18, "Description for product 18", "Product 18", 562m },
                    { 19, "Description for product 19", "Product 19", 777m },
                    { 20, "Description for product 20", "Product 20", 574m },
                    { 21, "Description for product 21", "Product 21", 651m },
                    { 22, "Description for product 22", "Product 22", 394m },
                    { 23, "Description for product 23", "Product 23", 251m },
                    { 24, "Description for product 24", "Product 24", 915m },
                    { 25, "Description for product 25", "Product 25", 499m },
                    { 26, "Description for product 26", "Product 26", 929m },
                    { 27, "Description for product 27", "Product 27", 545m },
                    { 28, "Description for product 28", "Product 28", 504m },
                    { 29, "Description for product 29", "Product 29", 309m },
                    { 30, "Description for product 30", "Product 30", 808m },
                    { 31, "Description for product 31", "Product 31", 903m },
                    { 32, "Description for product 32", "Product 32", 889m },
                    { 33, "Description for product 33", "Product 33", 948m },
                    { 34, "Description for product 34", "Product 34", 939m },
                    { 35, "Description for product 35", "Product 35", 828m },
                    { 36, "Description for product 36", "Product 36", 703m },
                    { 37, "Description for product 37", "Product 37", 863m },
                    { 38, "Description for product 38", "Product 38", 840m },
                    { 39, "Description for product 39", "Product 39", 103m },
                    { 40, "Description for product 40", "Product 40", 690m },
                    { 41, "Description for product 41", "Product 41", 343m },
                    { 42, "Description for product 42", "Product 42", 189m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 43, "Description for product 43", "Product 43", 970m },
                    { 44, "Description for product 44", "Product 44", 931m },
                    { 45, "Description for product 45", "Product 45", 777m },
                    { 46, "Description for product 46", "Product 46", 801m },
                    { 47, "Description for product 47", "Product 47", 737m },
                    { 48, "Description for product 48", "Product 48", 906m },
                    { 49, "Description for product 49", "Product 49", 960m },
                    { 50, "Description for product 50", "Product 50", 585m },
                    { 51, "Description for product 51", "Product 51", 617m },
                    { 52, "Description for product 52", "Product 52", 271m },
                    { 53, "Description for product 53", "Product 53", 638m },
                    { 54, "Description for product 54", "Product 54", 749m },
                    { 55, "Description for product 55", "Product 55", 596m },
                    { 56, "Description for product 56", "Product 56", 774m },
                    { 57, "Description for product 57", "Product 57", 392m },
                    { 58, "Description for product 58", "Product 58", 148m },
                    { 59, "Description for product 59", "Product 59", 571m },
                    { 60, "Description for product 60", "Product 60", 212m },
                    { 61, "Description for product 61", "Product 61", 665m },
                    { 62, "Description for product 62", "Product 62", 256m },
                    { 63, "Description for product 63", "Product 63", 816m },
                    { 64, "Description for product 64", "Product 64", 607m },
                    { 65, "Description for product 65", "Product 65", 954m },
                    { 66, "Description for product 66", "Product 66", 351m },
                    { 67, "Description for product 67", "Product 67", 171m },
                    { 68, "Description for product 68", "Product 68", 510m },
                    { 69, "Description for product 69", "Product 69", 425m },
                    { 70, "Description for product 70", "Product 70", 663m },
                    { 71, "Description for product 71", "Product 71", 788m },
                    { 72, "Description for product 72", "Product 72", 686m },
                    { 73, "Description for product 73", "Product 73", 456m },
                    { 74, "Description for product 74", "Product 74", 596m },
                    { 75, "Description for product 75", "Product 75", 386m },
                    { 76, "Description for product 76", "Product 76", 880m },
                    { 77, "Description for product 77", "Product 77", 693m },
                    { 78, "Description for product 78", "Product 78", 196m },
                    { 79, "Description for product 79", "Product 79", 192m },
                    { 80, "Description for product 80", "Product 80", 810m },
                    { 81, "Description for product 81", "Product 81", 789m },
                    { 82, "Description for product 82", "Product 82", 277m },
                    { 83, "Description for product 83", "Product 83", 388m },
                    { 84, "Description for product 84", "Product 84", 341m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 85, "Description for product 85", "Product 85", 271m },
                    { 86, "Description for product 86", "Product 86", 427m },
                    { 87, "Description for product 87", "Product 87", 736m },
                    { 88, "Description for product 88", "Product 88", 139m },
                    { 89, "Description for product 89", "Product 89", 790m },
                    { 90, "Description for product 90", "Product 90", 512m },
                    { 91, "Description for product 91", "Product 91", 884m },
                    { 92, "Description for product 92", "Product 92", 567m },
                    { 93, "Description for product 93", "Product 93", 872m },
                    { 94, "Description for product 94", "Product 94", 361m },
                    { 95, "Description for product 95", "Product 95", 647m },
                    { 96, "Description for product 96", "Product 96", 400m },
                    { 97, "Description for product 97", "Product 97", 180m },
                    { 98, "Description for product 98", "Product 98", 158m },
                    { 99, "Description for product 99", "Product 99", 826m },
                    { 100, "Description for product 100", "Product 100", 248m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 19 },
                    { 2, 2, 15 },
                    { 3, 3, 2 },
                    { 4, 4, 7 },
                    { 5, 5, 13 },
                    { 6, 6, 1 },
                    { 7, 7, 8 },
                    { 8, 8, 3 },
                    { 9, 9, 18 },
                    { 10, 10, 2 },
                    { 11, 11, 17 },
                    { 12, 12, 3 },
                    { 13, 13, 1 },
                    { 14, 14, 3 },
                    { 15, 15, 13 },
                    { 16, 16, 14 },
                    { 17, 17, 4 },
                    { 18, 18, 3 },
                    { 19, 19, 5 },
                    { 20, 20, 12 },
                    { 21, 21, 9 },
                    { 22, 22, 12 },
                    { 23, 23, 10 },
                    { 24, 24, 9 },
                    { 25, 25, 14 },
                    { 26, 26, 12 },
                    { 27, 27, 8 },
                    { 28, 28, 11 },
                    { 29, 29, 3 },
                    { 30, 30, 8 },
                    { 31, 31, 13 },
                    { 32, 32, 9 },
                    { 33, 33, 7 },
                    { 34, 34, 5 },
                    { 35, 35, 12 },
                    { 36, 36, 16 },
                    { 37, 37, 16 },
                    { 38, 38, 6 },
                    { 39, 39, 18 },
                    { 40, 40, 2 },
                    { 41, 41, 16 },
                    { 42, 42, 7 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 43, 43, 13 },
                    { 44, 44, 5 },
                    { 45, 45, 11 },
                    { 46, 46, 10 },
                    { 47, 47, 1 },
                    { 48, 48, 19 },
                    { 49, 49, 15 },
                    { 50, 50, 7 },
                    { 51, 51, 18 },
                    { 52, 52, 6 },
                    { 53, 53, 19 },
                    { 54, 54, 10 },
                    { 55, 55, 12 },
                    { 56, 56, 3 },
                    { 57, 57, 16 },
                    { 58, 58, 12 },
                    { 59, 59, 6 },
                    { 60, 60, 2 },
                    { 61, 61, 3 },
                    { 62, 62, 16 },
                    { 63, 63, 11 },
                    { 64, 64, 10 },
                    { 65, 65, 0 },
                    { 66, 66, 0 },
                    { 67, 67, 7 },
                    { 68, 68, 15 },
                    { 69, 69, 17 },
                    { 70, 70, 5 },
                    { 71, 71, 7 },
                    { 72, 72, 10 },
                    { 73, 73, 9 },
                    { 74, 74, 4 },
                    { 75, 75, 4 },
                    { 76, 76, 0 },
                    { 77, 77, 17 },
                    { 78, 78, 17 },
                    { 79, 79, 1 },
                    { 80, 80, 16 },
                    { 81, 81, 0 },
                    { 82, 82, 8 },
                    { 83, 83, 2 },
                    { 84, 84, 10 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 85, 85, 17 },
                    { 86, 86, 13 },
                    { 87, 87, 9 },
                    { 88, 88, 2 },
                    { 89, 89, 15 },
                    { 90, 90, 1 },
                    { 91, 91, 13 },
                    { 92, 92, 2 },
                    { 93, 93, 9 },
                    { 94, 94, 7 },
                    { 95, 95, 1 },
                    { 96, 96, 7 },
                    { 97, 97, 9 },
                    { 98, 98, 0 },
                    { 99, 99, 8 },
                    { 100, 100, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
