using Microsoft.EntityFrameworkCore.Migrations;

namespace RPShop.Migrations
{
    public partial class crateLinventory_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linventorys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProduct = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    importPrice = table.Column<double>(nullable: false),
                    idsupplier = table.Column<int>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    productid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linventorys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Linventorys_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linventorys_productid",
                table: "Linventorys",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linventorys");
        }
    }
}
