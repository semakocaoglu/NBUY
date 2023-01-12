using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intitiy : Migration
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
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    LessonPlace = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    EducationStatus = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Experience = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    LessonPlace = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_AspNetUsers_UserId",
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96e02713-90c5-4b01-bbf1-f000086bc2c3", null, "User rolü", "User", "USER" },
                    { "d42a4d0b-4247-42c4-a4c0-dc21754fd946", null, "Admin rolü", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fa21988-7c7c-44b0-a34f-e447fc1ec33e", 0, "10dcf627-6a40-438f-b0e1-6809462bfd82", "busragunduz@gmail.com", true, false, null, "BUSRAGUNDUZ@GMAIL.COM", "BUSRAGUNDUZ", null, "05256554545", false, "98ecd546-8f2f-4161-99b7-4f5a318ad0b5", false, "busragunduz" },
                    { "3d00b943-a6f6-48d0-880a-5196b6bd0ccd", 0, "37f8166d-bfea-4997-b6fd-5b990dc936f9", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEAu7Y+p7iAgJGRQ01ksx/Qe99PcyS2sDh0ypsla0x957SQdNOvhrTif+4Wa90m3VPA==", "5555555555", false, "cb1f06a8-b4da-46cf-8bd0-1b93aeb2d0c6", false, "admin" },
                    { "40f9cac7-9bac-4a92-bd06-218480166039", 0, "5d935db0-6935-4de1-94dd-261b6d8108cf", "mugesecer@gmail.com", true, false, null, "MUGESECER@GMAIL.COM", "MUGESECER", null, "05256554545", false, "b8075a0d-f435-477a-aea4-1d933517a22f", false, "mugesecer" },
                    { "5c7acb40-ea2e-47fb-bb42-03eda425bbfa", 0, "f93d6e74-3e61-45d8-aaf9-2d0b05620669", "merveakman@gmail.com", true, false, null, "MERVEAKMAN@GMAIL.COM", "MERVEAKMAN", null, "05321498998", false, "dd9f8849-21a8-4575-b80a-8b839f4fa782", false, "merveakman" },
                    { "60273b9a-212a-4dc8-b2f7-c457dec77011", 0, "5efcebb7-354f-4c99-8b4d-22fb5d983dfc", "efeyilmaz@gmail.com", true, false, null, "EFEYILMAZ@GMAIL.COM", "EFEYILMAZ", null, "05256554545", false, "954c409e-04f2-4b20-a115-f8db0544bb67", false, "efeyilmaz" },
                    { "663c9f31-0d58-45f5-bd2f-ed4713ed8668", 0, "7006266d-7abc-4832-8f40-408f2d14e2ec", "duygukara@gmail.com", true, false, null, "DUYGUKARA@GMAIL.COM", "DUYGUKARA", null, "05256554545", false, "cf4ab2ba-57e7-44b0-a068-1315003f2125", false, "duygukara" },
                    { "8566fa5b-7379-42e1-8997-29c9ae1f5d2c", 0, "ce96a6d9-2557-4e30-811e-c88d8bb74cce", "beyzaguven@gmail.com", true, false, null, "BEYZAGUVEN@GMAIL.COM", "BEYZAGUVEN", null, "05359886547", false, "5d7e894e-e6a8-4395-87ea-9700c7b24621", false, "beyzaguven" },
                    { "8ff2e2ac-3883-483e-8aca-498f8ef5a39c", 0, "53586169-2a23-438d-b0f2-a8a30aafba96", "arzuozcan@gmail.com", true, false, null, "ARZUOZCAN@GMAIL.COM", "ARZUOZCAN", null, "05256554545", false, "0b0e502f-3fe7-4345-957a-489f74fbc787", false, "arzuozcan" },
                    { "af233ec6-fdef-47ef-9732-c6d4462b3ed7", 0, "1c812937-6fe0-433a-990c-bb075f56174a", "aysesaglam@gmail.com", true, false, null, "AYSESAGLAM@GMAIL.COM", "AYSESAGLAM", null, "05256558998", false, "36b024d2-0673-4f03-936a-27d90d1047e4", false, "aysesaglam" },
                    { "bb195c46-27d2-425d-95fa-bcf8efccbb7a", 0, "6f3aec0f-9e3d-4499-95a8-5709f5e994ae", "ahmetak@gmail.com", true, false, null, "AHMETAK@GMAIL.COM", "AHMETAK", null, "05359886547", false, "80887e17-5c38-4960-80ab-7e2f5f785773", false, "ahmetak" },
                    { "c3276a4b-fab0-4fdd-a5bb-b217def1a689", 0, "bcc13416-6735-44d1-8daa-2e6867ad260d", "alikara@gmail.com", true, false, null, "ALIKARA@GMAIL.COM", "ALIKARA", null, "05359886547", false, "3f77d8a4-d412-47d3-941a-b7cede5d35a2", false, "alikara" },
                    { "cc7790b7-8fdb-4d8d-88ae-72df5fc02c38", 0, "f8230a11-490a-4864-b105-3258d8d1da43", "gamzeyildiz@gmail.com", true, false, null, "GAMZEYLDIZ@GMAIL.COM", "GAMZEYILDIZ", "AQAAAAIAAYagAAAAEOjAjoUzQJb83llsxVvDT9r3dbre49SoI6UAehC5UeamnupJvivipyubWdYLButb8Q==", "05256552535", false, "667393c4-8252-4951-aaf5-3b0a3f6a2669", false, "gamzeyildiz" },
                    { "dfc377ab-a260-46fc-b22d-c0c464caad68", 0, "50a155c7-fb06-41b2-9ab0-aec13125c7e8", "aysecandan@gmail.com", true, false, null, "AYSECANDAN@GMAIL.COM", "AYSECANDAN", null, "05256552535", false, "17e7afac-b8f6-4d26-9229-dde62a70c6a6", false, "aysecandan" },
                    { "ebe10aca-2c6f-416d-ba8f-fe019ff2b512", 0, "9e961ed7-2bb6-40c3-b712-67bbd6780bf5", "mehmetyildirim@gmail.com", true, false, null, "MEHMETYILDIRIM@GMAIL.COM", "MEHMETYILDIRIM", null, "05256554545", false, "f125766f-a574-4b21-a845-237e6de44bd9", false, "mehmetyildirim" },
                    { "eede42d3-fba6-45e2-8e4f-3dffbc56100c", 0, "cb2258fb-ab00-41b3-99ae-7eda46eef100", "aysegulguzel@gmail.com", true, false, null, "AYSEGULGUZEL@GMAIL.COM", "AYSEGULGUZEL", null, "05256554545", false, "8da216ca-119c-424b-9e8b-98a878cd3291", false, "aysegulguzel" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d42a4d0b-4247-42c4-a4c0-dc21754fd946", "3d00b943-a6f6-48d0-880a-5196b6bd0ccd" },
                    { "96e02713-90c5-4b01-bbf1-f000086bc2c3", "cc7790b7-8fdb-4d8d-88ae-72df5fc02c38" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "gamze-yildiz", "cc7790b7-8fdb-4d8d-88ae-72df5fc02c38" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "ahmet-akyilmaz", "dfc377ab-a260-46fc-b22d-c0c464caad68" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "Ayşe", "Kadın", "3.png", "Candan", "Online", "ayse-candan", "5c7acb40-ea2e-47fb-bb42-03eda425bbfa" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "Merve", "Kadın", "4.png", "Akman", "Online", "merve-akman", "c3276a4b-fab0-4fdd-a5bb-b217def1a689" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "Ali", "Erkek", "5.png", "Kara", "Online", "ali-kara", "af233ec6-fdef-47ef-9732-c6d4462b3ed7" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "Ayşe", "Kadın", "6.png", "Sağlam", "Yüz yüze", "ayse-saglam", "bb195c46-27d2-425d-95fa-bcf8efccbb7a" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "Ahmet", "Erkek", "7.png", "Ak", "Online", "ahmet-ak", "8566fa5b-7379-42e1-8997-29c9ae1f5d2c" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "Beyza", "Kadın", "8.png", "Güven", "Online", "beyza-guven", "1fa21988-7c7c-44b0-a34f-e447fc1ec33e" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "4 yıl", "Büşra", "Kadın", "9.png", "Gündüz", "Online", 200m, "busra-gunduz", "ebe10aca-2c6f-416d-ba8f-fe019ff2b512" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "8 yıl", "Mehmet", "Erkek", "10.png", "Yıldırım", "Online", 250m, "mehmet-yildirim", "eede42d3-fba6-45e2-8e4f-3dffbc56100c" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "4 yıl", "Ayşegül", "Kadın", "11.png", "Güzel", "Yüz yüze", 300m, "aysegul-guzel", "60273b9a-212a-4dc8-b2f7-c457dec77011" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "12 yıl", "Efe", "Erkek", "12.png", "Yılmaz", "Yüz yüze", 250m, "efe-yilmaz", "8ff2e2ac-3883-483e-8aca-498f8ef5a39c" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "10 yıl", "Arzu", "Kadın", "13.png", "Özcan", "Online", 300m, "arzu-ozcan", "40f9cac7-9bac-4a92-bd06-218480166039" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "15 yıl", "Müge", "Kadın", "14.png", "Seçer", "Online", 300m, "muge-secer", "663c9f31-0d58-45f5-bd2f-ed4713ed8668" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "15 yıl", "Duygu", "Kadın", "15.png", "Kara", "Online", 300m, "duygu-kara", "663c9f31-0d58-45f5-bd2f-ed4713ed8668" }
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
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserId",
                table: "Teacher",
                column: "UserId");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
