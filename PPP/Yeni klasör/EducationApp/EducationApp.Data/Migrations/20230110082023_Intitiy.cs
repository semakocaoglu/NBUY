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
                    { "21be1879-fc27-41c1-83dd-d9491be7fab5", null, "Admin rolü", "Admin", "ADMIN" },
                    { "f9938a8a-a8d1-4d97-adce-d1f621c37389", null, "User rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "314d3a84-a42a-4019-89f9-c51d31c56733", 0, "6d3430f2-aa3d-4cd1-b434-8d5aa08444a2", "ahmetakyilmaz@gmail.com", true, false, null, "AHMETAKYILMAZ@GMAIL.COM", "AHMETAKYILMAZ", "AQAAAAIAAYagAAAAEK986Xtaq9iWlIRnLkpOtq4TBAv+i3b3lsxcKxSUSG+VEM40A5egOSHQG3Ntn5U9EQ==", "05368667989", false, "fd593fda-af54-4ef4-a472-f283b6055f02", false, "ahmetakyilmaz" },
                    { "34dd098b-0d6f-4038-aabc-825b78205b7a", 0, "2f00039a-5df3-4c23-a60e-c0658a33ea5f", "aysesaglam@gmail.com", true, false, null, "AYSESAGLAM@GMAIL.COM", "AYSESAGLAM", "AQAAAAIAAYagAAAAEK+ArI+6GHNXK9rzVi9MRNE0f8w7Pk5KjImElBch8GrJh+VhiT70tqgUnNW5mXIngA==", "05256558998", false, "38b75790-1723-4f87-8ae6-9b963661b064", false, "aysesaglam" },
                    { "4815a22c-87a1-416d-8438-2beb2bd1c7b7", 0, "4135f7e7-cffa-4bcb-a557-b58d974fcd10", "duygukara@gmail.com", true, false, null, "DUYGUKARA@GMAIL.COM", "DUYGUKARA", "AQAAAAIAAYagAAAAEDhmJ8auMXP4Yc44Pnu+O9mOBnd88/g8TteGldxZbEX2fVJVIpz61tycZqOkvrjrBw==", "05256554545", false, "dd261092-41c5-4bc2-9467-7a5db8a648bb", false, "duygukara" },
                    { "4c2aca21-ea4c-4931-b476-772f602a506d", 0, "b55be43d-0f84-4590-b13c-9583ba61c87e", "mehmetyildirim@gmail.com", true, false, null, "MEHMETYILDIRIM@GMAIL.COM", "MEHMETYILDIRIM", "AQAAAAIAAYagAAAAEKTV/2jhG0RwPTY/vp2Rosp8b44WQCNFwZJXmgtLKeUQTCKLG63BZ0bAxAgI33wtqw==", "05256554545", false, "438c432b-5604-49be-a1c8-ffe0c42608a2", false, "mehmetyildirim" },
                    { "51ae6500-2b14-4480-b3a9-e10509673156", 0, "d3314999-8ec7-43d5-be0b-606de4362055", "aysecandan@gmail.com", true, false, null, "AYSECANDAN@GMAIL.COM", "AYSECANDAN", "AQAAAAIAAYagAAAAEDFBQSPoClGQgs+7E/mmt3UFiefsV3XU3KHiCyAfCBOpd/VwllQHHzRcybtEiG6ExA==", "05256552535", false, "9fd3bf80-a26c-49e3-8f77-21d4955d2265", false, "aysecandan" },
                    { "87874beb-783e-47f5-bd52-b9cd48d8f723", 0, "20f403db-bddc-43e0-bba2-b19afccb5241", "ahmetak@gmail.com", true, false, null, "AHMETAK@GMAIL.COM", "AHMETAK", "AQAAAAIAAYagAAAAEGPtESqHcmCtSZzabPBVuiSu8acInYqbxt1g8rTCwlzZaZp3svm1weHxgDv0Z5TduQ==", "05359886547", false, "9033b299-5e23-4910-aacb-ac31e5c3b5bc", false, "ahmetak" },
                    { "8cc522a5-5c4b-4aa6-9c09-43d06f3c305a", 0, "cfbc22ed-879a-456c-ada5-482bd7d9e520", "mugesecer@gmail.com", true, false, null, "MUGESECER@GMAIL.COM", "MUGESECER", "AQAAAAIAAYagAAAAEKCbB8d90mAUYe8dCAb/zKu1IYJYfMtui055x2vEv3gFNC4lD7eOx4RmQbWzaPvpZw==", "05256554545", false, "849ea692-04e1-40e8-8bb6-ec8fa291c461", false, "mugesecer" },
                    { "9554c523-946b-4351-aae0-91c352e06766", 0, "a65886e5-95a0-4b63-a05f-43eb32a40e44", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENwPXuOCMxqNobSkMdkoaG39ILrUpthlxRWaZOVAwgwIybqUBFZYfHQXKYYf66dlmg==", "5555555555", false, "040b6213-e50b-408e-8036-0374ac768a13", false, "admin" },
                    { "b30b66c0-64b2-4f62-b838-e7446564b451", 0, "8b55b67f-706b-45e5-bbb4-676296261e14", "arzuozcan@gmail.com", true, false, null, "ARZUOZCAN@GMAIL.COM", "ARZUOZCAN", "AQAAAAIAAYagAAAAEBDEquLIsRdUPn353XSezHbf6Itp+OhDMS/+wuBHLdpOHBVa3IAuFAFIaHN7mUDbpw==", "05256554545", false, "b80478de-45d9-41bc-a5a8-fe76e5bef3da", false, "arzuozcan" },
                    { "b7a4aa4e-272e-4f89-b3eb-520f3f0fa6ff", 0, "36bfce34-9e55-408b-bc3c-417e9b542b7d", "aysegulguzel@gmail.com", true, false, null, "AYSEGULGUZEL@GMAIL.COM", "AYSEGULGUZEL", "AQAAAAIAAYagAAAAEJzRXc9OwGfP0np0CH8cHAud2gd6oyCoKLiHqrqn/Kej2QywQXDZuGI9xbJc0Y7tKw==", "05256554545", false, "c4d9dd73-4ad2-4788-b248-14c8c8516c36", false, "aysegulguzel" },
                    { "bd9226fd-d2cb-4e47-b80c-7fdd6443d7e1", 0, "b709afad-10f6-40e0-a5b6-f6d3ac003768", "efeyilmaz@gmail.com", true, false, null, "EFEYILMAZ@GMAIL.COM", "EFEYILMAZ", "AQAAAAIAAYagAAAAENrN6y25HJoDDnflrIpHi8pKJKxZcH/FY2Vnxy+4xim3H+TCu3GEfPsJAz3yHElD9w==", "05256554545", false, "f8246175-acb2-420e-ab8e-6b22d2c21226", false, "efeyilmaz" },
                    { "bf715b55-63ff-45b4-ae60-32d543a885df", 0, "e571fb3a-b69e-4ea1-a99f-5699a1b4b23e", "merveakman@gmail.com", true, false, null, "MERVEAKMAN@GMAIL.COM", "MERVEAKMAN", "AQAAAAIAAYagAAAAEFzdwixmzeFLVb+f0KPWpxwW+Eb8h3MHaQeIpPFrQCqxZkP8i0B+45bAVf239icIzg==", "05321498998", false, "2fb039ac-3a9e-4c89-9154-2ffa7d46761f", false, "merveakman" },
                    { "da22d9ba-2679-48e8-8e9c-06e2e7a9d3fa", 0, "bb8b26a0-4b61-4142-9c7f-077bd2cfa0d6", "gamzeyildiz@gmail.com", true, false, null, "GAMZEYLDIZ@GMAIL.COM", "GAMZEYILDIZ", "AQAAAAIAAYagAAAAENU/EKSnD+noQ8tFhHy96yiSlB51HGUwMQ7MbkES0b0b9pPQFhUA0pFOSNydiigymg==", "05256552535", false, "acc042e9-b2b1-4a4d-8d66-987d477464cd", false, "gamzeyildiz" },
                    { "dccb7448-197c-4cd9-96ca-ca4e7537c889", 0, "593d3cbd-cf73-4b7f-9dd1-7ebf3e9e64e7", "busragunduz@gmail.com", true, false, null, "BUSRAGUNDUZ@GMAIL.COM", "BUSRAGUNDUZ", "AQAAAAIAAYagAAAAEPdX1legbYyi/YbcMR/HyoL5rieUtQJjqF94I1GUhYz+lE+gJoZFAcL2xya5kIXsZg==", "05256554545", false, "a52a56cc-a997-4b82-abf7-57dd3e70a062", false, "busragunduz" },
                    { "e5477702-41d0-4b9a-89de-07e9c9dd260b", 0, "39f78bd2-a27d-42b7-8a43-0a6594f35904", "beyzaguven@gmail.com", true, false, null, "BEYZAGUVEN@GMAIL.COM", "BEYZAGUVEN", "AQAAAAIAAYagAAAAEG6jso3+M74pK+Hisl5IZpqrzUG5R/3Pb1zLE4jjGuxklOJv6qj4tisjbLzquNUNbQ==", "05359886547", false, "a8521219-0038-4f52-bcf2-f83965f0dc00", false, "beyzaguven" },
                    { "f6ab8d27-f6bf-4e39-b9c1-cdbe10d096df", 0, "1e922c9c-2e9a-467a-b6d4-5038c864f9ae", "alikara@gmail.com", true, false, null, "ALIKARA@GMAIL.COM", "ALIKARA", "AQAAAAIAAYagAAAAEK+TKay+ZWY7t+zLw3M6u7OPejg18y1uhI1/wr33kXcWc3sDapZDIpVkktn4rSzf3w==", "05359886547", false, "8e328342-82d5-448e-83df-c9a188a7690b", false, "alikara" }
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
                    { "21be1879-fc27-41c1-83dd-d9491be7fab5", "9554c523-946b-4351-aae0-91c352e06766" },
                    { "f9938a8a-a8d1-4d97-adce-d1f621c37389", "da22d9ba-2679-48e8-8e9c-06e2e7a9d3fa" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "gamze-yildiz", "da22d9ba-2679-48e8-8e9c-06e2e7a9d3fa" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "ahmet-akyilmaz", "314d3a84-a42a-4019-89f9-c51d31c56733" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "Ayşe", "Kadın", "3.png", "Candan", "Online", "ayse-candan", "51ae6500-2b14-4480-b3a9-e10509673156" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "Merve", "Kadın", "4.png", "Akman", "Online", "merve-akman", "bf715b55-63ff-45b4-ae60-32d543a885df" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "Ali", "Erkek", "5.png", "Kara", "Online", "ali-kara", "f6ab8d27-f6bf-4e39-b9c1-cdbe10d096df" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "Ayşe", "Kadın", "6.png", "Sağlam", "Yüz yüze", "ayse-saglam", "34dd098b-0d6f-4038-aabc-825b78205b7a" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "Ahmet", "Erkek", "7.png", "Ak", "Online", "ahmet-ak", "87874beb-783e-47f5-bd52-b9cd48d8f723" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "Beyza", "Kadın", "8.png", "Güven", "Online", "beyza-guven", "e5477702-41d0-4b9a-89de-07e9c9dd260b" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "4 yıl", "Büşra", "Kadın", "9.png", "Gündüz", "Online", 200m, "busra-gunduz", "dccb7448-197c-4cd9-96ca-ca4e7537c889" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "8 yıl", "Mehmet", "Erkek", "10.png", "Yıldırım", "Online", 250m, "mehmet-yildirim", "4c2aca21-ea4c-4931-b476-772f602a506d" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "4 yıl", "Ayşegül", "Kadın", "11.png", "Güzel", "Yüz yüze", 300m, "aysegul-guzel", "b7a4aa4e-272e-4f89-b3eb-520f3f0fa6ff" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "12 yıl", "Efe", "Erkek", "12.png", "Yılmaz", "Yüz yüze", 250m, "efe-yilmaz", "bd9226fd-d2cb-4e47-b80c-7fdd6443d7e1" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "10 yıl", "Arzu", "Kadın", "13.png", "Özcan", "Online", 300m, "arzu-ozcan", "b30b66c0-64b2-4f62-b838-e7446564b451" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "15 yıl", "Müge", "Kadın", "14.png", "Seçer", "Online", 300m, "muge-secer", "8cc522a5-5c4b-4aa6-9c09-43d06f3c305a" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "15 yıl", "Duygu", "Kadın", "15.png", "Kara", "Online", 300m, "duygu-kara", "4815a22c-87a1-416d-8438-2beb2bd1c7b7" }
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
