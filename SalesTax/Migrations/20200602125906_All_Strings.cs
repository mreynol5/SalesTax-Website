using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTax.Migrations
{
    public partial class All_Strings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnitPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Discount",
                table: "Products",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 900,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { "10", "125.78" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 905,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { "5", "98.99" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 910,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { "15", "145.99" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 934,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { "10", "38.55" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "UnitPrice",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "Discount",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 900,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { 10f, 125.78f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 905,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { 5f, 98.99f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 910,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { 15f, 145.99f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 934,
                columns: new[] { "Discount", "UnitPrice" },
                values: new object[] { 10f, 38.55f });
        }
    }
}
