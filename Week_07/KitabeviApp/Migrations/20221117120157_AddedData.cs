using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabeviApp.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    DogumYili = table.Column<int>(type: "INTEGER", nullable: false),
                    Cinsiyet = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    BasimYili = table.Column<int>(type: "INTEGER", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false),
                    YazarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 1, "Çocuk Kitapları", "Çocuk" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 2, "Roman, Hikaye, Şiir Kitapları", "Edebiyat" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 3, "Bilgisayar Kitapları", "Bilgisayar" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[] { 4, "Akademik Kitaplar", "Akademik" });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 1, "Matt Heig", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 2, "Feyyaz Yiğit", 'E', 1990 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 3, "Gizem Doğan", 'K', 1960 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 4, "Jack London", 'E', 1930 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 5, "Margaret Atwood", 'K', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 6, "Cem Akaş", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 7, "Zafer Demirkol", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 8, "İlber Ortaylı", 'E', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 9, "Seda Yiğit", 'K', 1980 });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumYili" },
                values: new object[] { 10, "George Orwell", 'E', 1980 });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KategoriId",
                table: "Kitaplar",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarId",
                table: "Kitaplar",
                column: "YazarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
