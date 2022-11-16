using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje05_MVC_EfCore.CodeFirst.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[] { 1, "Phones", "Phone" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[] { 2, "Computers", "Computer" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[] { 3, "Electronics", "Electronic" });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "id", "Name" },
                values: new object[] { 18, "Çanakkale" });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "id", "Name" },
                values: new object[] { 34, "İstanbul" });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "id", "Name" },
                values: new object[] { 35, "İzmir" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "Name", "Price" },
                values: new object[] { 1, 1, "Güzel bir telefon", "Iphone 13", 19000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "Name", "Price" },
                values: new object[] { 2, 2, "Güzel bir bilgisayar", "Dell Xside", 15000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "Name", "Price" },
                values: new object[] { 3, 1, "KAmerası çok güzel", "Samsung A71", 17000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "Name", "Price" },
                values: new object[] { 4, 3, "Her yerde ses", "Piranha X13", 17000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }
    }
}
