using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinOnlineImbracaminte.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCartId",
                table: "Carts");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_CartId",
                table: "ProductCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_ProductId",
                table: "ProductCarts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Carts_CartId",
                table: "ProductCarts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Products_ProductId",
                table: "ProductCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Carts_CartId",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Products_ProductId",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_CartId",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_ProductId",
                table: "ProductCarts");

            migrationBuilder.AddColumn<int>(
                name: "ProductCartId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCartId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
