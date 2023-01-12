using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    UpCatId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    LessonPlace = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    LessonPlace = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    EducationStatus = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Experience = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "StudentCategories",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCategories", x => new { x.StudentId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_StudentCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCategories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCategories",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCategories", x => new { x.TeacherId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TeacherCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCategories_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UpCatId", "Url" },
                values: new object[,]
                {
                    { 1, "", "Matematik", 0, "matematik" },
                    { 2, "", "Fizik", 0, "fizik" },
                    { 3, "", "Kimya", 0, "kimya" },
                    { 4, "", "İlkokul Dersleri", 0, "ilkokul-dersleri" },
                    { 5, "", "Yabancı Dil", 0, "yabanci-dil" },
                    { 6, "", "Almanca", 4, "almanca" },
                    { 7, "", "Sanat", 0, "sanat" },
                    { 8, "", "Dans", 7, "dans" },
                    { 9, "", "Piyano", 7, "ingilizce" },
                    { 10, "", "Bilgisayar", 0, "bilgisayar" },
                    { 11, "", "AutoCad", 10, "autocad" },
                    { 12, "", "JavaScript", 10, "javascript" },
                    { 13, "", "Spor", 0, "spor" },
                    { 14, "", "Yüzme", 13, "yüzme" },
                    { 15, "", "Tenis", 13, "tenis" },
                    { 16, "", "Gitar", 7, "gitar" },
                    { 17, "", "Photoshop", 10, "photoshop" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "Email", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Phone", "Url" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "gamzeyildiz@gmail.com", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "05256552535", "gamze-yildiz" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "ahmetakyilmaz@gmail.com", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "05368667989", "ahmet-akyilmaz" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "aysecandan@gmail.com", "Ayşe", "Kadın", "3.png", "Candan", "Online", "05256552535", "ayse-candan" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "merveakman@gmail.com", "Merve", "Kadın", "4.png", "Akman", "Online", "05321498998", "merve-akman" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "alikara@gmail.com", "Ali", "Erkek", "5.png", "Kara", "Online", "05359886547", "ali-kara" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "aysesaglam@gmail.com", "Ayşe", "Kadın", "6.png", "Sağlam", "Yüz yüze", "05256558998", "ayse-saglam" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "ahmetak@gmail.com", "Ahmet", "Erkek", "7.png", "Ak", "Online", "05359886547", "ahmet-ak" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "beyzaguven@gmail.com", "Beyza", "Kadın", "8.png", "Güven", "Online", "05359886547", "beyza-guven" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Email", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Phone", "Price", "Url" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "busragunduz@gmail.com", "4 yıl", "Büşra", "Kadın", "9.png", "Gündüz", "Online", "05256554545", 200m, "busra-gunduz" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "mehmetyildirim@gmail.com", "8 yıl", "Mehmet", "Erkek", "10.png", "Yıldırım", "Online", "05256554545", 250m, "mehmet-yildirim" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "aysegulguzel@gmail.com", "4 yıl", "Ayşegül", "Kadın", "11.png", "Güzel", "Yüz yüze", "05256554545", 300m, "aysegul-guzel" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "efeyilmaz@gmail.com", "12 yıl", "Efe", "Erkek", "12.png", "Yılmaz", "Yüz yüze", "05256554545", 250m, "efe-yilmaz" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "arzuozcan@gmail.com", "10 yıl", "Arzu", "Kadın", "13.png", "Özcan", "Online", "05256554545", 300m, "arzu-ozcan" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "mugesecer@gmail.com", "15 yıl", "Müge", "Kadın", "14.png", "Seçer", "Online", "05256554545", 300m, "muge-secer" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "duygukara@gmail.com", "15 yıl", "Duygu", "Kadın", "15.png", "Kara", "Online", "05256554545", 300m, "duygu-kara" }
                });

            migrationBuilder.InsertData(
                table: "StudentCategories",
                columns: new[] { "CategoryId", "StudentId" },
                values: new object[,]
                {
                    { 16, 1 },
                    { 15, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 5, 5 },
                    { 8, 6 },
                    { 9, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 11, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCategories",
                columns: new[] { "CategoryId", "TeacherId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 1, 2 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 4 },
                    { 2, 5 },
                    { 8, 6 },
                    { 11, 7 },
                    { 17, 7 }
                });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 3, 2 },
                    { 7, 2 },
                    { 2, 3 },
                    { 1, 4 },
                    { 4, 5 },
                    { 7, 5 },
                    { 6, 6 },
                    { 8, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCategories_CategoryId",
                table: "StudentCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCategories_CategoryId",
                table: "TeacherCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "StudentCategories");

            migrationBuilder.DropTable(
                name: "TeacherCategories");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
