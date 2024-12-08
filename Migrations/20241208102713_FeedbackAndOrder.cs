using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebAppProject.Migrations
{
    /// <inheritdoc />
    public partial class FeedbackAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cart",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");
        }
    }
}
