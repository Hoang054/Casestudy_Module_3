using Microsoft.EntityFrameworkCore.Migrations;

namespace RPShop.Migrations
{
    public partial class voteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "RoleId",
            //    table: "User",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "RoleName",
            //    table: "User",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Avatar",
            //    table: "Comments",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "Comments",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    vote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProductId",
                table: "Votes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            //migrationBuilder.DropColumn(
            //    name: "RoleId",
            //    table: "User");

            //migrationBuilder.DropColumn(
            //    name: "RoleName",
            //    table: "User");

            //migrationBuilder.DropColumn(
            //    name: "Avatar",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "Comments");
        }
    }
}
