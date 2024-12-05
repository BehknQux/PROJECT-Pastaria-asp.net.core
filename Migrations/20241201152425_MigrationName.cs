using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebAppProject.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemModel",
                table: "MenuItemModel");

            migrationBuilder.RenameTable(
                name: "MenuItemModel",
                newName: "MenuItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItemModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemModel",
                table: "MenuItemModel",
                column: "Id");
        }
    }
}
