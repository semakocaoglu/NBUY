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
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PopularCategory = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    { "12c17632-dcee-4c30-a5d4-0e8c58e25552", null, "Admin rolü", "Admin", "ADMIN" },
                    { "ea49c988-55fd-4b35-a8b5-ec706e8c0f4b", null, "User rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "023dd29e-87aa-422e-bd6e-c9e3b95ed144", 0, "1392ade4-d701-47e7-a553-294330bb3f39", "mehmetyildirim@gmail.com", true, false, null, "MEHMETYILDIRIM@GMAIL.COM", "MEHMETYILDIRIM", "AQAAAAIAAYagAAAAENMs9XX6mdI15Hj5PKPpm6eMpt49ZfF9EsSx00YYc9XZFhgp1V/Or3aYwz2fJp/OIQ==", "05256554545", false, "ad75e88a-7c80-4c30-89db-d70010337956", false, "mehmetyildirim" },
                    { "0df62a18-3a43-4e76-8d1b-027c70812987", 0, "77814c47-41b6-4069-9e75-a37859fca6ea", "aysegulguzel@gmail.com", true, false, null, "AYSEGULGUZEL@GMAIL.COM", "AYSEGULGUZEL", "AQAAAAIAAYagAAAAENUamAaxtxUVhjgY+9lBqLaxPDiJ341sb79xOWWbXKn/siMjrYHFBUdW0QZylssZNA==", "05256554545", false, "683cff8c-a2d1-4d26-8600-9251b3dd78ac", false, "aysegulguzel" },
                    { "1a92938a-5039-496b-aaff-b76ae73ea5c6", 0, "f0074bbd-0755-4f14-af62-80a0d44fd2cc", "alikara@gmail.com", true, false, null, "ALIKARA@GMAIL.COM", "ALIKARA", "AQAAAAIAAYagAAAAECkYb8hS+iAXn3Abz+9FpfNgCr16ou4lRQyZ6iX/2WOByxOljUtdP284OCE+fVFMLQ==", "05359886547", false, "0c44ab5e-bcaa-4bd9-974e-e82118846995", false, "alikara" },
                    { "4a62b611-8a71-4373-9a4e-56f1f51d9a6a", 0, "61c99a8f-20c4-44f8-926f-3ea6f55fe0da", "busragunduz@gmail.com", true, false, null, "BUSRAGUNDUZ@GMAIL.COM", "BUSRAGUNDUZ", "AQAAAAIAAYagAAAAEFAmxAFBNxSrl2vf7Ac9HkDR9IrC/pXSLadPW+USYI0gx/lLDQ6mTPy7xj3aoTcBkQ==", "05256554545", false, "0ef0713a-9f64-447b-a66c-f05eb1731a25", false, "busragunduz" },
                    { "59ec29f5-16c3-460a-9eea-ce9817acd365", 0, "6d677cf3-3f73-4d03-a094-601321dff845", "gamzeyildiz@gmail.com", true, false, null, "GAMZEYLDIZ@GMAIL.COM", "GAMZEYILDIZ", "AQAAAAIAAYagAAAAEP74vMxUI1MqWpT3G2j1GvQH6U9qjHwQ1yUVMRiua7A6fzZk+bVbyGRxk6SODwswsg==", "05256552535", false, "52240310-6cc7-42d2-bdbb-609fedbb8003", false, "gamzeyildiz" },
                    { "66489368-2fa5-4bfc-aaa4-ed3ecf526aa2", 0, "878d1f98-2b81-4801-b899-ee90356a9767", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFAuYMifmwHxm3mu7ZCe5F+f2REjcp/gYj0TJTHUzCBhokO56VSZxcU6p5WSykr4Cw==", "5555555555", false, "3d4a27c7-84f6-4e38-98ca-fe3849265dfd", false, "admin" },
                    { "6e22c75f-6b7c-4fbf-999b-fa2fc80ad400", 0, "abbb0550-928d-46d6-bb0c-156f444a1dbe", "aysesaglam@gmail.com", true, false, null, "AYSESAGLAM@GMAIL.COM", "AYSESAGLAM", "AQAAAAIAAYagAAAAEBR8FU4vQirxekOQMfYUKGHSo0s/vNZ3+oUQH7I5lYoe1AIJCShXwVlJooj7P7y5xg==", "05256558998", false, "d5c84b2d-5e5a-4ba7-a8f8-24b9946c8d21", false, "aysesaglam" },
                    { "80df8e26-a335-447d-b25c-673c6fd96de7", 0, "19bdcba0-1c36-47b7-8874-00f4dda55381", "arzuozcan@gmail.com", true, false, null, "ARZUOZCAN@GMAIL.COM", "ARZUOZCAN", "AQAAAAIAAYagAAAAEHnJpdnAZpqzfDCsii4Z6z4tY0qcOs15pu78e7N7RQV2EZbnBtHlag7w260tFy8IQA==", "05256554545", false, "1a6eff48-41ed-485d-836a-d792f952587f", false, "arzuozcan" },
                    { "a5b31434-ceaf-4c05-b736-ba0537b0addf", 0, "b0490b00-d48e-471f-8afa-0d504b7fd265", "mugesecer@gmail.com", true, false, null, "MUGESECER@GMAIL.COM", "MUGESECER", "AQAAAAIAAYagAAAAEPo4rafUkhd4i3YTuZiFQtyj6J2eEInGm7SmYXlMVKUiGo96QLXRvGUqcFE6J1cbIw==", "05256554545", false, "837f931f-25f6-4d6e-8c8f-8c0758401185", false, "mugesecer" },
                    { "abfe089f-640e-40e5-9716-78469357f2d6", 0, "e38e28ad-e382-45b0-835a-55dc605e2efc", "duygukara@gmail.com", true, false, null, "DUYGUKARA@GMAIL.COM", "DUYGUKARA", "AQAAAAIAAYagAAAAEJamG2qHvguU7Lj1LLOatcgMKKwqbEdKU3QhlWIzua/TRT1Ip6+fUHUWQL6CZ0o7mQ==", "05256554545", false, "fc0e374a-5b88-475c-aebd-ad2f1f575bab", false, "duygukara" },
                    { "b2d02d00-2588-4407-b8d2-8cf9295269de", 0, "d29cf29a-a2fe-43a3-8a7f-ae5aa8b7f8f7", "beyzaguven@gmail.com", true, false, null, "BEYZAGUVEN@GMAIL.COM", "BEYZAGUVEN", "AQAAAAIAAYagAAAAEBbaTza9OZLDXNCBlBcp2dRQUGi4qeWJKsietRaVNopImgwMbOJCoiGFF+ht+0hMEw==", "05359886547", false, "6b08e438-5c7a-4c2a-9158-b5e984cc74d9", false, "beyzaguven" },
                    { "b4f20ec2-77ed-4c97-8cf3-3d65ee6c8071", 0, "ebb56271-8c6c-4f69-bded-f72c21ed1b0c", "ahmetak@gmail.com", true, false, null, "AHMETAK@GMAIL.COM", "AHMETAK", "AQAAAAIAAYagAAAAEMJlSy05RxZADULTPdJZ6eMmpJpQ7vkdvavSMoAr53vDLJvvuYTE7GHm6Gvi9oaRLQ==", "05359886547", false, "c9a287ad-a374-4630-8e69-c64cdde22eb2", false, "ahmetak" },
                    { "c14d4755-ef86-43fb-93c0-9d338694c945", 0, "9799b813-1520-4529-b931-605e8a3ebd6f", "ahmetakyilmaz@gmail.com", true, false, null, "AHMETAKYILMAZ@GMAIL.COM", "AHMETAKYILMAZ", "AQAAAAIAAYagAAAAEMJsC2tIRPNC7GHeAQvt9k9IVSOOaHmQmIxwSDrpDPUvM2FesOagQMhH2D0lBIfSfg==", "05368667989", false, "bd6cfdd4-ca67-40ed-932d-bdd0838d040a", false, "ahmetakyilmaz" },
                    { "d866f366-1251-499a-aedb-5116ecb4447e", 0, "40cfad8f-3299-4ca2-9d60-e879d39817c7", "aysecandan@gmail.com", true, false, null, "AYSECANDAN@GMAIL.COM", "AYSECANDAN", "AQAAAAIAAYagAAAAEErdLH7SdoaI8bMOmaOS48xENVkSpXjd0mg39u7VFfgnnRxrMfF2IebMByqLXvspqA==", "05256552535", false, "1dc9efe8-3b44-46af-8ddd-42daeb77ea45", false, "aysecandan" },
                    { "d87d415b-c586-4d0b-8b29-5aad0cb7dbb4", 0, "d8f55eb2-c6c4-423d-b81b-0e002f8721cf", "efeyilmaz@gmail.com", true, false, null, "EFEYILMAZ@GMAIL.COM", "EFEYILMAZ", "AQAAAAIAAYagAAAAEDCUEH0SoLbVyFVdZTGHtTouY2U4NkMSfy0M0CW2a/7c21xL9eMLFHn2Zd1NSeZmTQ==", "05256554545", false, "c0c0a6dd-1a7b-45b7-b216-f6bfb86cd9af", false, "efeyilmaz" },
                    { "fb051eec-1b69-4d9a-ae97-57863cf83321", 0, "a1071297-3817-47f7-97a5-c2021bf9cb83", "merveakman@gmail.com", true, false, null, "MERVEAKMAN@GMAIL.COM", "MERVEAKMAN", "AQAAAAIAAYagAAAAEMTFGq99gtO1l/kn95dm7M0JIlKmnKkQft2sJUND0sLk/O+ku4ZDRtnR6i7st7N6CA==", "05321498998", false, "bedf5b7d-844d-48ae-bb32-815c89694510", false, "merveakman" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PopularCategory", "UpCatId", "Url" },
                values: new object[,]
                {
                    { 1, "", "3.png", "Sınava Hazırlık", false, 0, "sinava-hazirlik" },
                    { 2, "", "3.png", "Fizik", false, 1, "fizik" },
                    { 3, "", "3.png", "Kimya", false, 1, "kimya" },
                    { 4, "", "3.png", "İlkokul Dersleri", false, 0, "ilkokul-dersleri" },
                    { 5, "", "3.png", "Yabancı Dil", false, 0, "yabanci-dil" },
                    { 6, "", "3.png", "Almanca", false, 5, "almanca" },
                    { 7, "", "3.png", "Sanat", false, 0, "sanat" },
                    { 8, "", "3.png", "Dans", false, 7, "dans" },
                    { 9, "", "3.png", "Piyano", true, 7, "piyano" },
                    { 10, "", "3.png", "Bilgisayar", false, 0, "bilgisayar" },
                    { 11, "", "3.png", "AutoCad", false, 10, "autocad" },
                    { 12, "", "3.png", "JavaScript", true, 10, "javascript" },
                    { 13, "", "3.png", "Spor", false, 0, "spor" },
                    { 14, "", "3.png", "Yüzme", true, 13, "yüzme" },
                    { 15, "", "3.png", "Tenis", true, 13, "tenis" },
                    { 16, "", "3.png", "Gitar", false, 7, "gitar" },
                    { 17, "", "3.png", "Photoshop", false, 10, "photoshop" },
                    { 18, "", "3.png", "İnglizce", true, 5, "ingilizce" },
                    { 19, "", "3.png", "Matematik", true, 1, "matematik" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ea49c988-55fd-4b35-a8b5-ec706e8c0f4b", "59ec29f5-16c3-460a-9eea-ce9817acd365" },
                    { "12c17632-dcee-4c30-a5d4-0e8c58e25552", "66489368-2fa5-4bfc-aaa4-ed3ecf526aa2" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "gamze-yildiz", "59ec29f5-16c3-460a-9eea-ce9817acd365" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "ahmet-akyilmaz", "c14d4755-ef86-43fb-93c0-9d338694c945" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "Ayşe", "Kadın", "1.png", "Candan", "Online", "ayse-candan", "d866f366-1251-499a-aedb-5116ecb4447e" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "Merve", "Kadın", "1.png", "Akman", "Online", "merve-akman", "fb051eec-1b69-4d9a-ae97-57863cf83321" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "Ali", "Erkek", "2.png", "Kara", "Online", "ali-kara", "1a92938a-5039-496b-aaff-b76ae73ea5c6" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "Ayşe", "Kadın", "1.png", "Sağlam", "Yüz yüze", "ayse-saglam", "6e22c75f-6b7c-4fbf-999b-fa2fc80ad400" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "Ahmet", "Erkek", "2.png", "Ak", "Online", "ahmet-ak", "b4f20ec2-77ed-4c97-8cf3-3d65ee6c8071" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "Beyza", "Kadın", "1.png", "Güven", "Online", "beyza-guven", "b2d02d00-2588-4407-b8d2-8cf9295269de" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "4 yıl", "Büşra", "Kadın", "1.png", "Gündüz", "Online", 200m, "busra-gunduz", "4a62b611-8a71-4373-9a4e-56f1f51d9a6a" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "8 yıl", "Mehmet", "Erkek", "2.png", "Yıldırım", "Online", 250m, "mehmet-yildirim", "023dd29e-87aa-422e-bd6e-c9e3b95ed144" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "4 yıl", "Ayşegül", "Kadın", "1.png", "Güzel", "Yüz yüze", 300m, "aysegul-guzel", "0df62a18-3a43-4e76-8d1b-027c70812987" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "12 yıl", "Efe", "Erkek", "2.png", "Yılmaz", "Yüz yüze", 250m, "efe-yilmaz", "d87d415b-c586-4d0b-8b29-5aad0cb7dbb4" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "10 yıl", "Arzu", "Kadın", "1.png", "Özcan", "Online", 300m, "arzu-ozcan", "80df8e26-a335-447d-b25c-673c6fd96de7" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "15 yıl", "Müge", "Kadın", "1.png", "Seçer", "Online", 300m, "muge-secer", "a5b31434-ceaf-4c05-b736-ba0537b0addf" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "15 yıl", "Duygu", "Kadın", "1.png", "Kara", "Online", 300m, "duygu-kara", "abfe089f-640e-40e5-9716-78469357f2d6" }
                });

            migrationBuilder.InsertData(
                table: "StudentCategories",
                columns: new[] { "CategoryId", "StudentId" },
                values: new object[,]
                {
                    { 16, 1 },
                    { 15, 2 },
                    { 19, 3 },
                    { 2, 4 },
                    { 18, 5 },
                    { 8, 6 },
                    { 9, 6 },
                    { 2, 7 },
                    { 19, 7 },
                    { 11, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCategories",
                columns: new[] { "CategoryId", "TeacherId" },
                values: new object[,]
                {
                    { 18, 1 },
                    { 19, 2 },
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
