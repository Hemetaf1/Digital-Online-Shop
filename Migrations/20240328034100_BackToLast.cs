using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPhone.Migrations
{
    /// <inheritdoc />
    public partial class BackToLast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Phone",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
