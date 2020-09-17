using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPShop.Migrations
{
    public partial class Create_Oder_OderDetail_Customer_EmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_typeProductid",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TypeProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_supplierid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_typeProductid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "supplierid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "typeProductid",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    totalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    AvatarPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Oders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCus = table.Column<int>(nullable: false),
                    idEmployee = table.Column<int>(nullable: false),
                    employeeid = table.Column<int>(nullable: true),
                    OderDay = table.Column<DateTime>(nullable: false),
                    customerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Oders_Customers_customerid",
                        column: x => x.customerid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oders_Employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OderDetails",
                columns: table => new
                {
                    idOder = table.Column<int>(nullable: false),
                    idProduct = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Surcharge = table.Column<double>(nullable: false),
                    oderid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OderDetails", x => new { x.idOder, x.idProduct });
                    table.ForeignKey(
                        name: "FK_OderDetails_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OderDetails_Oders_oderid",
                        column: x => x.oderid,
                        principalTable: "Oders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Customerid",
                table: "Products",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_OderDetails_idProduct",
                table: "OderDetails",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OderDetails_oderid",
                table: "OderDetails",
                column: "oderid");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_customerid",
                table: "Oders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_employeeid",
                table: "Oders",
                column: "employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_Customerid",
                table: "Products",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_Customerid",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OderDetails");

            migrationBuilder.DropTable(
                name: "Oders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Products_Customerid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "supplierid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "typeProductid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Business_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProducts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierid",
                table: "Products",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_typeProductid",
                table: "Products",
                column: "typeProductid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierid",
                table: "Products",
                column: "supplierid",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_typeProductid",
                table: "Products",
                column: "typeProductid",
                principalTable: "TypeProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
