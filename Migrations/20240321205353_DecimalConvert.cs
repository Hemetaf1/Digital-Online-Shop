using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPhone.Migrations
{
    /// <inheritdoc />
    public partial class DecimalConvert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                }); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropTable(
                name: "Phone"); */
        }
    }
}
