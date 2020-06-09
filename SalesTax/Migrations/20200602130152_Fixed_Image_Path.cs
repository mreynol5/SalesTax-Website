using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTax.Migrations
{
    public partial class Fixed_Image_Path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 900,
                column: "PhotoPath",
                value: "/images/battery.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 905,
                column: "PhotoPath",
                value: "/images/struts.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 910,
                column: "PhotoPath",
                value: "/images/tire.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 934,
                column: "PhotoPath",
                value: "/images/airFilter.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 900,
                column: "PhotoPath",
                value: "../wwwroot/images/battery.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 905,
                column: "PhotoPath",
                value: "../wwwroot/images/struts.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 910,
                column: "PhotoPath",
                value: "../wwwroot/images/tire.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 934,
                column: "PhotoPath",
                value: "../wwwroot/images/airFilter.png");
        }
    }
}
