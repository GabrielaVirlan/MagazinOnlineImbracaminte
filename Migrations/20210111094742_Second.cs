using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinOnlineImbracaminte.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCartID",
                table: "Products",
                newName: "ProductCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCartId",
                table: "Products",
                newName: "ProductCartID");
        }
    }
}
