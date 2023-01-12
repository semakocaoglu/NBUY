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
                    { "4f7e3de1-ce8a-4cb5-a553-0f6830458659", null, "User rolü", "User", "USER" },
                    { "944a8655-f5ce-4812-a93f-36860d7a9fa5", null, "Admin rolü", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20678268-f7ba-4705-9bc9-36caa26efea5", 0, "87ceaa90-1765-4b1b-8846-a1ee9f579c7c", "arzuozcan@gmail.com", true, false, null, "ARZUOZCAN@GMAIL.COM", "ARZUOZCAN", "AQAAAAIAAYagAAAAEI0Z/jWDN3a8K6Vct7a8ku21UBBWt6IbsnVhJCJ3Pzz1eVVzPM+yaHyyWSeFmWDqxg==", "05256554545", false, "adf18a69-a848-4387-8589-2a42c9ed1d14", false, "arzuozcan" },
                    { "2c06cbac-e992-4c4d-85fa-443336e753ba", 0, "b05d9473-ba79-4e7b-aa0f-d21c9f01708c", "duygukara@gmail.com", true, false, null, "DUYGUKARA@GMAIL.COM", "DUYGUKARA", "AQAAAAIAAYagAAAAEMldPSAZLEa+CWRlP8D6HCc220DCqEZ5CVGSTjkDuSK7hkO8TePaT09z5vZwIiTrLQ==", "05256554545", false, "fd0f9025-49ab-4358-a15e-c860b28749b6", false, "duygukara" },
                    { "4cf9b33c-82b0-4fc9-9625-f24c761ae011", 0, "821381bd-24fd-47a6-837c-7ac69e40674a", "busragunduz@gmail.com", true, false, null, "BUSRAGUNDUZ@GMAIL.COM", "BUSRAGUNDUZ", "AQAAAAIAAYagAAAAECj7eQpD+K2j7C4c/GQzrMRifbUiQgK7C1xKBjFjqDWaZ8Jvp+5RahI9B8UuW0XgZQ==", "05256554545", false, "7cd9a06f-08d8-4949-b068-f456970b3caa", false, "busragunduz" },
                    { "4e39cab6-6aba-4dd5-9f2c-fdc57e688e87", 0, "08f14266-8fd8-4615-9feb-1e5292459e58", "aysecandan@gmail.com", true, false, null, "AYSECANDAN@GMAIL.COM", "AYSECANDAN", "AQAAAAIAAYagAAAAEKCnOVh2ylwJdBpJ/v6EabEZDrzE4htUr38C6uNkHXGiflSLC0975M+iZSUr9CjiIw==", "05256552535", false, "05466f7c-9fcf-40d8-ac1a-0479122d0e5a", false, "aysecandan" },
                    { "4f058378-0e31-4fca-a6cc-5bbb5e570de0", 0, "c7e402ff-16b3-4d27-b952-1b854427b5c6", "aysesaglam@gmail.com", true, false, null, "AYSESAGLAM@GMAIL.COM", "AYSESAGLAM", "AQAAAAIAAYagAAAAEIoO5Y8KvsCXyRomD0t3P2siN8BkBkmaoGVs2xM+3p/R4LX/UOJ5rIib9LVQR7LgBA==", "05256558998", false, "2c85d0f8-83d1-4ff9-ad98-553f832f832e", false, "aysesaglam" },
                    { "5f14d4e7-6919-453f-851b-354c79c5f885", 0, "04fb56a6-9493-4b5e-99cb-83eafa5e9eb8", "ahmetak@gmail.com", true, false, null, "AHMETAK@GMAIL.COM", "AHMETAK", "AQAAAAIAAYagAAAAELo2L1dX0FZ8DM6rmxr5Pka3Q0Z9RL0Ndb13RyleJuSwTi1N920cOAoblhmzC/DBTQ==", "05359886547", false, "d97825e8-8b93-4ee4-b9c1-6ebc6200523d", false, "ahmetak" },
                    { "60d89b6d-1230-451d-84bd-ee916fc05f91", 0, "e8ba6b26-1b76-4dd9-b151-e053db004909", "beyzaguven@gmail.com", true, false, null, "BEYZAGUVEN@GMAIL.COM", "BEYZAGUVEN", "AQAAAAIAAYagAAAAELR3iEraAmGXzAn1UaaoeCiDvGQYhLLBi14O6tr+fbnKWSvbyM7foXsULTPuZcsL1A==", "05359886547", false, "d1cee964-2719-44c9-acd6-d6532d45f1aa", false, "beyzaguven" },
                    { "763c10d1-b6fa-42c4-8f27-f61f3518d358", 0, "c341843b-9d73-44d6-93c4-bdf9692c3b54", "aysegulguzel@gmail.com", true, false, null, "AYSEGULGUZEL@GMAIL.COM", "AYSEGULGUZEL", "AQAAAAIAAYagAAAAEKSFtXXfDsPpRtKe5UGM28+qSvZmh4jN4h5iomHlp5kzAdcjftbLHjXPAPmdVOLxrA==", "05256554545", false, "4aa13001-0731-4682-8cc5-b76ed4a4248e", false, "aysegulguzel" },
                    { "8c7bb993-eba7-4005-8193-1713b1a6c449", 0, "d1e162b8-8a63-4921-b3c1-42777f7c7799", "merveakman@gmail.com", true, false, null, "MERVEAKMAN@GMAIL.COM", "MERVEAKMAN", "AQAAAAIAAYagAAAAEKT2hk+AheVEYZlkWo/4oF96/WUtnQk1e/4Vf2Wt70D/EKqtYHpXO5d+TL+3d8qDnA==", "05321498998", false, "083a7361-5f3f-477e-b013-f98f67fc4127", false, "merveakman" },
                    { "9e153d67-7338-46e9-b4a5-a713acdc3a87", 0, "f273fa29-2d49-4289-b7fe-e9e3d2cbb737", "mugesecer@gmail.com", true, false, null, "MUGESECER@GMAIL.COM", "MUGESECER", "AQAAAAIAAYagAAAAEIep+TJa7O3okjbJ4LGVaDiiNCqDXxnkKkaHGOhlhO38K+X+ERerTrZQkHXew5rLjg==", "05256554545", false, "93b5f698-63fd-46a3-9378-aa10ee0f6ec0", false, "mugesecer" },
                    { "aaac5fa6-40b7-4cd1-a9b0-679103326886", 0, "9d8a4d0e-7ccf-4d79-a39e-9b493beb3453", "efeyilmaz@gmail.com", true, false, null, "EFEYILMAZ@GMAIL.COM", "EFEYILMAZ", "AQAAAAIAAYagAAAAEOKnKjs6/TjG8cy2B8idwx4wFjxaKRKOiuGzMnGPwvecgz+pVlAkH9pcvP/sHFE5LA==", "05256554545", false, "5e9564a5-130b-4cf2-9b9c-5245528103ad", false, "efeyilmaz" },
                    { "ac880911-c9d7-4a48-a453-d6ec70b5acc1", 0, "fd6cc0f6-8ebb-4852-8ce2-95cc3f12907a", "ahmetakyilmaz@gmail.com", true, false, null, "AHMETAKYILMAZ@GMAIL.COM", "AHMETAKYILMAZ", "AQAAAAIAAYagAAAAEJkRcgoqlOYrHCIUtRLoPgDSVg0Oo2aFUgR6/FrCc/jNdznGhz0Nut8xH2939pSL2A==", "05368667989", false, "a82e4db7-7b8a-4be6-833c-d4530eeaa060", false, "ahmetakyilmaz" },
                    { "bcf93610-9017-43ed-9477-c46d713fd6a9", 0, "3f8baeab-64ef-4269-836a-4af3223a263b", "gamzeyildiz@gmail.com", true, false, null, "GAMZEYLDIZ@GMAIL.COM", "GAMZEYILDIZ", "AQAAAAIAAYagAAAAEPQkQsv6rfBPWcdTfhRHPV5L+cT8rVi0kj8HdhuHhMZNaBEkziauxfdjkDV2oa28fQ==", "05256552535", false, "1624d0ca-c9fb-4f28-9fdf-001723f4cda1", false, "gamzeyildiz" },
                    { "dd3e1b79-d964-4c3b-a152-7f8ff2f1efb4", 0, "bd5ff525-dbe4-4db7-85de-3b493532e3ff", "mehmetyildirim@gmail.com", true, false, null, "MEHMETYILDIRIM@GMAIL.COM", "MEHMETYILDIRIM", "AQAAAAIAAYagAAAAECdnxhK8jy7aXpgBIRdgFHEoBEQft4ESwYSnvLdprHegpcMjdnU7rTECfxLD2NwrGA==", "05256554545", false, "ee98ec4a-988d-4b8a-acc6-4ce5685da680", false, "mehmetyildirim" },
                    { "fa5f8e33-0d11-4f44-8ebb-ed85264fcb66", 0, "7882c3f4-2863-4ed5-9ab0-217d63d35aff", "alikara@gmail.com", true, false, null, "ALIKARA@GMAIL.COM", "ALIKARA", "AQAAAAIAAYagAAAAEDa5r006APnUbw6XcSFJEKv0LYhmqSM7EbuAP+dODe67fQLISQiU4yjCCRwCjpeq0w==", "05359886547", false, "0f6264ed-0244-4eee-ab99-10fe9ef0196d", false, "alikara" },
                    { "fe91c03a-f751-42d0-9698-d8b98f3efe79", 0, "cc59a7f4-6c4d-42ee-89ab-121813ec3311", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEA6ysPa9qeRWdkPvxwV1DvSzSeHVoc6FBw/BUUXIJINNUqvdV+PrLUGhkJW9sMBLZQ==", "5555555555", false, "d6e8850c-dc56-4f74-9842-158f69a0dcf2", false, "admin" }
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
                    { 18, "", "İnglizce", 15, "ingilizce" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4f7e3de1-ce8a-4cb5-a553-0f6830458659", "bcf93610-9017-43ed-9477-c46d713fd6a9" },
                    { "944a8655-f5ce-4812-a93f-36860d7a9fa5", "fe91c03a-f751-42d0-9698-d8b98f3efe79" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "City", "Description", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "İstanbul", "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", "Gamze", "Kadın", "1.png", "Yıldız", "Yüz Yüze", "gamze-yildiz", "bcf93610-9017-43ed-9477-c46d713fd6a9" },
                    { 2, 25, "İzmir", "Tenis öğrenmek istiyorum.", "Ahmet", "Erkek", "2.png", "Akyılmaz", "Yüz Yüze", "ahmet-akyilmaz", "ac880911-c9d7-4a48-a453-d6ec70b5acc1" },
                    { 3, 16, "Ankara", "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", "Ayşe", "Kadın", "1.png", "Candan", "Online", "ayse-candan", "4e39cab6-6aba-4dd5-9f2c-fdc57e688e87" },
                    { 4, 18, "Bursa", "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", "Merve", "Kadın", "1.png", "Akman", "Online", "merve-akman", "8c7bb993-eba7-4005-8193-1713b1a6c449" },
                    { 5, 22, "İstanbul", "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", "Ali", "Erkek", "2.png", "Kara", "Online", "ali-kara", "fa5f8e33-0d11-4f44-8ebb-ed85264fcb66" },
                    { 6, 35, "İzmir", "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", "Ayşe", "Kadın", "1.png", "Sağlam", "Yüz yüze", "ayse-saglam", "4f058378-0e31-4fca-a6cc-5bbb5e570de0" },
                    { 7, 17, "Adana", "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", "Ahmet", "Erkek", "2.png", "Ak", "Online", "ahmet-ak", "5f14d4e7-6919-453f-851b-354c79c5f885" },
                    { 8, 20, "İstanbul", "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", "Beyza", "Kadın", "1.png", "Güven", "Online", "beyza-guven", "60d89b6d-1230-451d-84bd-ee916fc05f91" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Age", "City", "Description", "EducationStatus", "Experience", "FirstName", "Gender", "ImageUrl", "LastName", "LessonPlace", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 35, "İstanbul", "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", "4 yıl", "Büşra", "Kadın", "1.png", "Gündüz", "Online", 200m, "busra-gunduz", "4cf9b33c-82b0-4fc9-9625-f24c761ae011" },
                    { 2, 42, "Ankara", "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", "Ankara Üniversitesi, Matematik", "8 yıl", "Mehmet", "Erkek", "2.png", "Yıldırım", "Online", 250m, "mehmet-yildirim", "dd3e1b79-d964-4c3b-a152-7f8ff2f1efb4" },
                    { 3, 27, "İzmir", "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", "4 yıl", "Ayşegül", "Kadın", "1.png", "Güzel", "Yüz yüze", 300m, "aysegul-guzel", "763c10d1-b6fa-42c4-8f27-f61f3518d358" },
                    { 4, 38, "İstanbul", "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", "Odtü", "12 yıl", "Efe", "Erkek", "2.png", "Yılmaz", "Yüz yüze", 250m, "efe-yilmaz", "aaac5fa6-40b7-4cd1-a9b0-679103326886" },
                    { 5, 30, "Adana", "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", "Sakarya Üniversitesi , Fizik", "10 yıl", "Arzu", "Kadın", "1.png", "Özcan", "Online", 300m, "arzu-ozcan", "20678268-f7ba-4705-9bc9-36caa26efea5" },
                    { 6, 36, "İzmir", "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", "İtü Devlet Konservatuar", "15 yıl", "Müge", "Kadın", "1.png", "Seçer", "Online", 300m, "muge-secer", "9e153d67-7338-46e9-b4a5-a713acdc3a87" },
                    { 7, 35, "İstanbul", "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", "İtü, Mimarlık", "15 yıl", "Duygu", "Kadın", "1.png", "Kara", "Online", 300m, "duygu-kara", "2c06cbac-e992-4c4d-85fa-443336e753ba" }
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
