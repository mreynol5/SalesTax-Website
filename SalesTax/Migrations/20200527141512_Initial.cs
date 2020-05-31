using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTax.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProductTaxCode = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "Name", "PhotoPath", "ProductTaxCode", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 900, "Toyota Tacoma battery", 10f, "Battery", "../wwwroot/images/battery.png", "0", 1, 125.78f },
                    { 910, "Goodyear X-300", 15f, "Tire", "../wwwroot/images/tire.png", "0", 4, 145.99f },
                    { 905, "Dodge Ram Heavy Duty Strut set", 5f, "Struts", "../wwwroot/images/struts.png", "0", 1, 98.99f },
                    { 934, "Silverado Air Filter", 10f, "Air Filter", "../wwwroot/images/airFilter.png", "0", 1, 38.55f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
