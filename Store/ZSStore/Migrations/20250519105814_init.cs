using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZSStore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
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
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    SentAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Line1 = table.Column<string>(type: "TEXT", nullable: false),
                    Line2 = table.Column<string>(type: "TEXT", nullable: true),
                    Line3 = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Shipped = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "SupportMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMessages", x => x.Id);
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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProductTechnicalSpecs = table.Column<string>(type: "TEXT", nullable: true),
                    ProductUsageAreas = table.Column<string>(type: "TEXT", nullable: true),
                    ProductDocumentsPath = table.Column<string>(type: "TEXT", nullable: true),
                    ProductWeight = table.Column<double>(type: "REAL", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShowCase = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_CartLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAnalyses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20e28613-d581-48a7-84c9-5c9cfbb572ae", null, "User", "USER" },
                    { "8095db8f-1ce7-42b8-8db3-f260891be148", null, "Technical", "TECHNICAL" },
                    { "a007bf31-08b6-47be-a9b7-88f1c1a551a3", null, "Editor", "EDITOR" },
                    { "fe52d7d2-1d7b-45a6-86e6-dc281c5b5ecd", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "", "Elektronik Dozimetre" },
                    { 2, "", "Pasif Dozimetre" },
                    { 3, "", "Survey Metre" },
                    { 4, "", "Yüzey Kontaminasyon Ölçer" },
                    { 5, "", "Alan Monitörü" },
                    { 6, "", "Baca Dedektör" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImageUrl", "ProductDescription", "ProductDocumentsPath", "ProductName", "ProductPrice", "ProductTechnicalSpecs", "ProductUsageAreas", "ProductWeight", "ShowCase" },
                values: new object[,]
                {
                    { 1, 1, "/images/1.jpg", "Kişisel radyasyon dozimetresi; Geiger-Müller tüpü ile gama ve X-ışını tespiti yapar.", "/documents/geiger-dokuman.pdf", "Geiger Müller Tabanlı Elektronik Dozimetre", 7500m, "Dedektör: Geiger-Müller tüpü, Enerji Aralığı: 50 keV – 3 MeV, Ekran: LCD, Alarm: Sesli ve titreşimli", "Nükleer tesisler, hastaneler, radyasyon güvenliği uygulamaları", 0.29999999999999999, false },
                    { 2, 1, "/images/2.jpg", "Yüksek hassasiyetli kişisel dozimetre; düşük doz tespiti yapar.", "/documents/katihal-dokuman.pdf", "Katı Hal Dedektörlü Elektronik Dozimetre", 8900m, "Dedektör: Katı hal dedektörü, Enerji Aralığı: 50 keV – 3 MeV, Ekran: LCD, Alarm: Sesli ve titreşimli", "Nükleer enerji santralleri, tıbbi görüntüleme merkezleri", 0.25, true },
                    { 3, 2, "/images/3.jpg", "Geniş bantlı OSL dozimetri sistemi; farklı radyasyon türlerine karşı hassasiyet sağlar.", "/documents/wbext-osl.pdf", "Wbext OSL Dozimetri", 2000m, "Dedektör: Geniş bant OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tesisler, araştırma laboratuvarları", null, false },
                    { 4, 2, "/images/4.jpg", "Hastaların maruz kaldığı radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/hasta-osl.pdf", "Hasta OSL Dozimetri-MOSFET", 1800m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Radyoterapi, nükleer tıp uygulamaları", null, true },
                    { 5, 2, "/images/5.jpg", "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/ekstremite-osl.pdf", "Bilek Dozimetre", 1600m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tıp, radyoloji bölümleri", null, false },
                    { 6, 2, "/images/6.jpg", "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/ekstremite-osl.pdf", "Tüm Vücut Dozimetre", 1600m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tıp, radyoloji bölümleri", null, true },
                    { 7, 2, "/images/7.jpg", "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/ekstremite-osl.pdf", "Yüzük Dozimetre", 1600m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tıp, radyoloji bölümleri", null, false },
                    { 8, 2, "/images/8.jpg", "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/ekstremite-osl.pdf", "Göz(Lens) Dozimetre", 1600m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tıp, radyoloji bölümleri", null, true },
                    { 9, 2, "/images/9.jpg", "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.", "/documents/ekstremite-osl.pdf", "Ortam Dozimetresi", 1600m, "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV", "Nükleer tıp, radyoloji bölümleri", null, false },
                    { 10, 2, "/images/10.jpg", "Nötron radyasyonuna maruz kalınan dozları ölçmek için kullanılan sistem.", "/documents/notron.pdf", "Nötron Dozimetre", 3500m, "Dedektör: Nötron hassas dedektör, Enerji Aralığı: Termal – 15 MeV", "Nükleer reaktörler, araştırma laboratuvarları", null, false },
                    { 11, 2, "/images/11.jpg", "Radon gazına maruz kalınan dozları ölçmek için kullanılan sistem.", "/documents/radon.pdf", "Radon Dozimetre", 2800m, "Dedektör: Radon hassas dedektör, Enerji Aralığı: 5 keV – 40 MeV", "Yer altı madenleri, evler, ofisler", null, true },
                    { 12, 3, "/images/12.jpg", "Çevresel radyasyon seviyelerini ölçmek için kullanılan taşınabilir cihaz.", "/documents/gm-survey.pdf", "Geiger Müller Tabanlı Survey Metre", 11000m, "Dedektör: Geiger-Müller tüp, Enerji Aralığı: 30 keV – 3 MeV", "Sanayi, çevre izleme, sağlık fizik laboratuvarları", 1.2, true },
                    { 13, 3, "/images/13.jpg", "Katı hal dedektörlü gelişmiş survey metre.", "/documents/katihal-survey.pdf", "Katı Hal Dedektörlü Survey Metre", 13500m, "Dedektör: Katı hal dedektör, Enerji Aralığı: 30 keV – 3 MeV", "Nükleer tesisler, laboratuvarlar", 1.1000000000000001, true },
                    { 14, 4, "/images/14.jpg", "Yüzeylerdeki alfa, beta kontaminasyonunu tespit eder.", "/documents/yuzey.pdf", "Yüzey Kontaminasyon Ölçer", 9900m, "Dedektör: Plastik scinitillation, Enerji Aralığı: 20 keV – 2 MeV", "Laboratuvarlar, hastaneler, sınır güvenliği", 0.90000000000000002, false },
                    { 15, 5, "/images/15.jpg", "Sabit olarak kurulan alan monitörü; gamma radyasyon takibi yapar.", "/documents/alan-monitor-gm.pdf", "Geiger Müller Tabanlı Radyasyon Alan Monitörü", 12500m, "Dedektör: GM tüp, Aralık: 50 keV – 3 MeV, Çıkış: Analog/dijital", "Nükleer reaktörler, sınır kapıları", 1.3999999999999999, true },
                    { 16, 5, "/images/16.jpg", "Yüksek hassasiyetli sabit radyasyon izleme cihazı.", "/documents/alan-monitor-katihal.pdf", "Katı Hal Dedektörlü Radyasyon Alan Monitörü", 13900m, "Dedektör: Katı hal dedektör, Aralık: 50 keV – 3 MeV", "Nükleer alanlar, tıbbi merkezler", 1.3, false },
                    { 17, 6, "/images/17.jpg", "Bacadan yayılan radyoaktif partikülleri tespit eden cihaz.", "/documents/baca.pdf", "Baca Dedektör", 17500m, "Dedektör: Partikül sayım dedektörü, Aralık: 0.1 µCi/m3 – 100 µCi/m3", "Nükleer santraller, filtre izleme sistemleri", 2.0, true }
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
                name: "IX_CartLine_OrderId",
                table: "CartLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnalyses_ProductId",
                table: "ProductAnalyses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
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
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "ProductAnalyses");

            migrationBuilder.DropTable(
                name: "SupportMessages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
