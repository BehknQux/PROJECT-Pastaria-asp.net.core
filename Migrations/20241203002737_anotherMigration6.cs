using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebAppProject.Migrations
{
    /// <inheritdoc />
    public partial class anotherMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cart_ItemId",
                table: "Cart",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_MenuItems_ItemId",
                table: "Cart",
                column: "ItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_MenuItems_ItemId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ItemId",
                table: "Cart");
        }
    }
}
