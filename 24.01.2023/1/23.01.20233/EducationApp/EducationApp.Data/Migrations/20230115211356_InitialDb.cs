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
                    { "984a526b-025e-4b2b-889d-dcc9123567be", null, "Admin rolü", "Admin", "ADMIN" },
                    { "fdae6d48-5dc2-4816-b313-30183c6bca0e", null, "User rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07e4d4e0-8a32-44d9-88d4-781f17dbdfd8", 0, "cbecdde3-79f7-4314-ba8b-8b53b143facc", "busragunduz@gmail.com", true, false, null, "BUSRAGUNDUZ@GMAIL.COM", "BUSRAGUNDUZ", "AQAAAAIAAYagAAAAECstCpsEs2t7g90T0RDCSZIHRuV5pg9m1pZ8AsF2NdySbpshNro7TxHyE5Sti9a5Lg==", "05256554545", false, "1035b8c5-6965-4422-a653-289b9b82c43c", false, "busragunduz" },
                    { "182fa6cf-80c1-47d3-b92f-cee31a133d09", 0, "3e6293b5-033b-41c4-8bc5-e30cc47594cc", "mugesecer@gmail.com", true, false, null, "MUGESECER@GMAIL.COM", "MUGESECER", "AQAAAAIAAYagAAAAEJZRM/KjWvoumE3xyNZVNoYbaVEd6xj7Vx4/cfRriAqK7BVjUrw0eXMNqWIPJ1H4mQ==", "05256554545", false, "4f8c45d5-7fd4-4020-ae73-f27d1ef33eeb", false, "mugesecer" },
                    { "1f333965-6b38-4a7a-9164-f7b79abfbbfc", 0, "591419c6-b806-47a8-883e-296963c689d4", "alikara@gmail.com", true, false, null, "ALIKARA@GMAIL.COM", "ALIKARA", "AQAAAAIAAYagAAAAEKpjDRBA2U6LvxgOdH+fkQJQI2Y/xItEjRCgwQWE0SQMyG14Ht8LqjTF3HW8L2BeoA==", "05359886547", false, "a501ae5d-7e5f-4a1c-8761-a492f59ebb55", false, "alikara" },
                    { "53fe17cc-9d54-4377-8ce6-59ee87eea4e3", 0, "85f4ae2c-18a2-4dd3-8621-bcbbb3dd8ffa", "aysesaglam@gmail.com", true, false, null, "AYSESAGLAM@GMAIL.COM", "AYSESAGLAM", "AQAAAAIAAYagAAAAEP5N/xQKhTJqstBI08LrMVYgFn83TKT4tLzzkckNbOv0OZ0ncIDWOJ3c2cHkbGMqBA==", "05256558998", false, "bf582581-8764-4cf2-bc3e-65f469c7f40e", false, "aysesaglam" },
                    { "54ecad9d-383b-4629-81e3-f4489f884781", 0, "b3ff6c0f-0fbf-4517-b005-6bebb605f057", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEAMinSD0Bmr0HJbJa6Siwv3R8teht+sAyEnOA5lhxow4jMrILQCSZwk1TFZh84eVZQ==", "5555555555", false, "e7fe1982-ad30-4f98-88c4-5e463705440b", false, "admin" },
                    { "5795500a-7277-4f0d-855b-dcdc3667eede", 0, "962db0af-b11a-44d3-a9dc-7a89595aee06", "duygukara@gmail.com", true, false, null, "DUYGUKARA@GMAIL.COM", "DUYGUKARA", "AQAAAAIAAYagAAAAECF5gm2mF4/HG7rMnB1XR6P1vE/33UkB+dpvGaFzOjiCqH7viiEP8ZlebdQ7e7uuJw==", "05256554545", false, "0d6e1f5f-3081-4038-8d4d-6043bbd69bba", false, "duygukara" },
                    { "5847ddda-a49c-4a73-b8e4-6427b61d920a", 0, "3205b805-7278-4841-b8a2-067fb01074d6", "merveakman@gmail.com", true, false, null, "MERVEAKMAN@GMAIL.COM", "MERVEAKMAN", "AQAAAAIAAYagAAAAEB7Fdozx2Xuui0IFB0+esMSFKlqjWANUb6yhRUWqVoSWBUmA0KdODrAJuZVaH5OXLA==", "05321498998", false, "f5ae7214-875c-4ac4-8308-f1abf505d6ec", false, "merveakman" },
                    { "6e9bf44b-a546-47a3-9026-a2a9061a8e02", 0, "f7f8de72-9206-4dc2-bade-1d7f660a0e7d", "beyzaguven@gmail.com", true, false, null, "BEYZAGUVEN@GMAIL.COM", "BEYZAGUVEN", "AQAAAAIAAYagAAAAEK3p6KDv3p/RLnK1MVI1cKNSlRAahqnagaZapyD/9p6RDFoZr7yJUba5KcbtN8nETw==", "05359886547", false, "624ccc35-c270-45ae-b7eb-6e853acf99b6", false, "beyzaguven" },
                    { "7c5cdbd7-4438-42c1-812d-f126d7868128", 0, "bf5c9d7b-7f4c-4906-82e2-ffbcd786f80a", "gamzeyildiz@gmail.com", true, false, null, "GAMZEYLDIZ@GMAIL.COM", "GAMZEYILDIZ", "AQAAAAIAAYagAAAAEPrAHPb55PsCJ8JnXPTGb/J7P5sBaeAcBDtmTrzNnm1Zsr7VlPAIX60z0kQI/DpvZQ==", "05256552535", false, "455d68ec-368c-4372-af4c-25bd49aed751", false, "gamzeyildiz" },
                    { "80cb74e1-ad1d-46bd-a266-c3986475f9d7", 0, "f015e717-f53d-44a8-9265-7aa836f8f056", "mehmetyildirim@gmail.com", true, false, null, "MEHMETYILDIRIM@GMAIL.COM", "MEHMETYILDIRIM", "AQAAAAIAAYagAAAAELbz+DrxSswkMDNAB4eOYw2794hLhbUbbx4h6HUgxV1xeurjXvq2xqgvEG4QEeZ4iA==", "05256554545", false, "a1fd376b-0ac6-4021-9d67-70907ead0680", false, "mehmetyildirim" },
                    { "8587b3d6-b633-4c28-8703-dff42dc9dd43", 0, "cae5c971-ee71-49af-8714-933111fa604b", "aysecandan@gmail.com", true, false, null, "AYSECANDAN@GMAIL.COM", "AYSECANDAN", "AQAAAAIAAYagAAAAEA/CcOYFl6YpXswSczFS9p7fPEVVf33apGmPe+fSbSOwOyC4D0FPtbNJSCHJz5sWqw==", "05256552535", false, "d0b980c1-714a-4e06-90d4-d121188dd4c3", false, "aysecandan" },
                    { "860e1ec7-030f-4d82-801b-7326c068d896", 0, "487c1c24-a155-4cb0-85c4-38ed6cac7e8c", "arzuozcan@gmail.com", true, false, null, "ARZUOZCAN@GMAIL.COM", "ARZUOZCAN", "AQAAAAIAAYagAAAAEBZzEuColtcuOKw/C7GddzD6R6+lnSLTLK3Agoyhe6E5xpu37HDDXMnvIIdVo6S0/w==", "05256554545", false, "01d6547d-336a-4167-af66-763ff599229a", false, "arzuozcan" },
                    { "a24ab6e7-b4f1-4d57-b427-d710fd5908b1", 0, "2122784e-a061-44a9-a8d3-a345d3cdaddb", "aysegulguzel@gmail.com", true, false, null, "AYSEGULGUZEL@GMAIL.COM", "AYSEGULGUZEL", "AQAAAAIAAYagAAAAEClZsplTPjFiU3SIS2ZDoBBtsazVqWpDiASpzUlLErI6AZdlkK/FBqcb/2zIMZLMyw==", "05256554545", false, "37255c24-9b7e-4a92-ad93-cd0dd4fa6f0b", false, "aysegulguzel" },
                    { "a453d888-8e89-4276-90c8-118f230a1284", 0, "9a9ac41a-f016-48b1-a969-4eb279333275", "ahmetakyilmaz@gmail.com", true, false, null, "AHMETAKYILMAZ@GMAIL.COM", "AHMETAKYILMAZ", "AQAAAAIAAYagAAAAEIA3sTFrcl27zbJVN1MdO9+8jdQrorAPeZ73CFwi6bVDXdfGvg9WGPx3zTA4+7BcKQ==", "05368667989", false, "6495503b-3598-4779-8b7e-8e98267327fb", false, "ahmetakyilmaz" },
                    { "cc32d7dd-da6a-4351-aa4f-cae52789db80", 0, "e9d78a28-746b-4cbb-98d6-758768cecb8a", "efeyilmaz@gmail.com", true, false, null, "EFEYILMAZ@GMAIL.COM", "EFEYILMAZ", "AQAAAAIAAYagAAAAEEXXtBQcBFu4/yZklEHs9PG7nijJK7VvYW4HNK1eiaMFB1QRSB7ExgHKr0W/SBmy8g==", "05256554545", false, "55e00ec9-175a-4f09-b9f5-f432ac6049aa", false, "efeyilmaz" },
                    { "eb424a5a-5d63-428c-aafe-21ccaa8af073", 0, "006980f9-f77c-4a78-9d6f-1ec0c837d834", "ahmetak@gmail.com", true, false, null, "AHMETAK@GMAIL.COM", "AHMETAK", "AQAAAAIAAYagAAAAEIiQmSYY54c/0w2wtFpK1hBn3RfHAKMj3Jwglv68GUNeb/cWPt5YnwfYpoNfmhcZhw==", "05359886547", false, "733dd83a-d6e4-4acb-b254-e2bca8e774fc", false, "ahmetak" }
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
                    { 6, "", "Almanca", 5, "almanca" },
                    { 7, "", "Sanat", 0, "sanat" },
                    { 8, "", "Dans", 7, "dans" },
                    { 9, "", "Piyano", 7, "piyano" },
                    { 10, "", "Bilgisayar", 0, "bilgisayar" },
                    { 11, "", "AutoCad", 10, "autocad" },
                    { 12, "", "JavaScript", 10, "javascript" },
                    { 13, "", "Spor", 0, "spor" },
                    { 14, "", "Yüzme", 13, "yüzme" },
                    { 15, "", "Tenis", 13, "tenis" },
                    { 16, "", "Gitar", 7, "gitar" },
                    { 17, "", "Photoshop", 10, "photoshop" },
                    { 18, "", "İnglizce", 5, "ingilizce" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "984a526b-025e-4b2b-889d-dcc9123567be", "54ecad9d-383b-4629-81e3-f4489f884781" },
                    { "fdae6d48-5dc2-4816-b313-30183c6bca0e", "7c5cdbd7-4438-42c1-812d-f126d7868128" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "gamze-yildiz", "7c5cdbd7-4438-42c1-812d-f126d7868128" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "ahmet-akyilmaz", "a453d888-8e89-4276-90c8-118f230a1284" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "Ayşe", "Kadın", "1.png", "Candan", "Online", "ayse-candan", "8587b3d6-b633-4c28-8703-dff42dc9dd43" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "Merve", "Kadın", "1.png", "Akman", "Online", "merve-akman", "5847ddda-a49c-4a73-b8e4-6427b61d920a" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "Ali", "Erkek", "2.png", "Kara", "Online", "ali-kara", "1f333965-6b38-4a7a-9164-f7b79abfbbfc" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "Ayşe", "Kadın", "1.png", "Sağlam", "Yüz yüze", "ayse-saglam", "53fe17cc-9d54-4377-8ce6-59ee87eea4e3" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "Ahmet", "Erkek", "2.png", "Ak", "Online", "ahmet-ak", "eb424a5a-5d63-428c-aafe-21ccaa8af073" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "Beyza", "Kadın", "1.png", "Güven", "Online", "beyza-guven", "6e9bf44b-a546-47a3-9026-a2a9061a8e02" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "4 yıl", "Büşra", "Kadın", "1.png", "Gündüz", "Online", 200m, "busra-gunduz", "07e4d4e0-8a32-44d9-88d4-781f17dbdfd8" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "8 yıl", "Mehmet", "Erkek", "2.png", "Yıldırım", "Online", 250m, "mehmet-yildirim", "80cb74e1-ad1d-46bd-a266-c3986475f9d7" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "4 yıl", "Ayşegül", "Kadın", "1.png", "Güzel", "Yüz yüze", 300m, "aysegul-guzel", "a24ab6e7-b4f1-4d57-b427-d710fd5908b1" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "12 yıl", "Efe", "Erkek", "2.png", "Yılmaz", "Yüz yüze", 250m, "efe-yilmaz", "cc32d7dd-da6a-4351-aa4f-cae52789db80" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "10 yıl", "Arzu", "Kadın", "1.png", "Özcan", "Online", 300m, "arzu-ozcan", "860e1ec7-030f-4d82-801b-7326c068d896" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "15 yıl", "Müge", "Kadın", "1.png", "Seçer", "Online", 300m, "muge-secer", "182fa6cf-80c1-47d3-b92f-cee31a133d09" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "15 yıl", "Duygu", "Kadın", "1.png", "Kara", "Online", 300m, "duygu-kara", "5795500a-7277-4f0d-855b-dcdc3667eede" }
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
                    { 18, 5 },
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
                    { 18, 1 },
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
