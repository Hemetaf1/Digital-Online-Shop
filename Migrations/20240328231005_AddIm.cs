using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPhone.Migrations
{
    /// <inheritdoc />
    public partial class AddIm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Phone",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Phone",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Phone",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Phone");
        }
    }
}
