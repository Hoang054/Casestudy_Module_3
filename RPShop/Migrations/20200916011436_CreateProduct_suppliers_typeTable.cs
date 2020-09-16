using Microsoft.EntityFrameworkCore.Migrations;

namespace RPShop.Migrations
{
    public partial class CreateProduct_suppliers_typeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Business_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typeProducts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeProducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    imagePath = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    idType = table.Column<int>(nullable: false),
                    idSupplier = table.Column<int>(nullable: false),
                    supplierid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_typeProducts_idType",
                        column: x => x.idType,
                        principalTable: "typeProducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_suppliers_supplierid",
                        column: x => x.supplierid,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_idType",
                table: "Products",
                column: "idType");

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierid",
                table: "Products",
                column: "supplierid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "typeProducts");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
