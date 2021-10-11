using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingShop.Server.Migrations
{
    public partial class Variants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditionProduct");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "productVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariants", x => new { x.ProductId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_productVariants_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "EditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 1,
                column: "Name",
                value: "Default");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 2,
                column: "Name",
                value: "Paperback");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 3,
                column: "Name",
                value: "E-Book");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 4,
                column: "Name",
                value: "Audiobook");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 5,
                column: "Name",
                value: "PC");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 6,
                column: "Name",
                value: "Playstation");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "EditionId", "Name" },
                values: new object[] { 7, "Xbox" });

            migrationBuilder.InsertData(
                table: "productVariants",
                columns: new[] { "EditionId", "ProductId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 5, 299m, 159.99m },
                    { 1, 6, 400m, 73.74m },
                    { 2, 3, 0m, 6.99m },
                    { 6, 7, 0m, 69.99m },
                    { 5, 8, 24.99m, 9.99m },
                    { 5, 9, 0m, 14.99m },
                    { 2, 2, 14.99m, 7.99m },
                    { 4, 1, 29.99m, 19.99m },
                    { 3, 1, 0m, 7.99m },
                    { 2, 1, 19.99m, 9.99m },
                    { 1, 4, 249.00m, 166.66m },
                    { 5, 7, 29.99m, 19.99m }
                });

            migrationBuilder.InsertData(
                table: "productVariants",
                columns: new[] { "EditionId", "ProductId", "OriginalPrice", "Price" },
                values: new object[] { 7, 7, 59.99m, 49.99m });

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_EditionId",
                table: "productVariants",
                column: "EditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productVariants");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 7);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Products",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "EditionProduct",
                columns: table => new
                {
                    EditionsEditionId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionProduct", x => new { x.EditionsEditionId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_EditionProduct_Editions_EditionsEditionId",
                        column: x => x.EditionsEditionId,
                        principalTable: "Editions",
                        principalColumn: "EditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EditionProduct",
                columns: new[] { "EditionsEditionId", "ProductsProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 7 },
                    { 5, 7 },
                    { 6, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 1,
                column: "Name",
                value: "Paperback");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 2,
                column: "Name",
                value: "E-Book");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 3,
                column: "Name",
                value: "Audiobook");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 4,
                column: "Name",
                value: "PC");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 5,
                column: "Name",
                value: "Playstation");

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "EditionId",
                keyValue: 6,
                column: "Name",
                value: "Xbox");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 19.99m, 9.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 14.99m, 7.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 6.99m, 6.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 240.00m, 166.66m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 299.99m, 159.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 400.00m, 73.74m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 20.99m, 8.19m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 14.99m, 14.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 14.99m, 8.99m });

            migrationBuilder.CreateIndex(
                name: "IX_EditionProduct_ProductsProductId",
                table: "EditionProduct",
                column: "ProductsProductId");
        }
    }
}
