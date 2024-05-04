using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPhone.Migrations
{
    /// <inheritdoc />
    public partial class sth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Categories_CategoryId",
                table: "Field");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Field_FieldId",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Field",
                table: "Field");

            migrationBuilder.RenameTable(
                name: "Field",
                newName: "Fields");

            migrationBuilder.RenameIndex(
                name: "IX_Field_CategoryId",
                table: "Fields",
                newName: "IX_Fields_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Categories_CategoryId",
                table: "Fields",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Categories_CategoryId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Fields_FieldId",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "Field");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_CategoryId",
                table: "Field",
                newName: "IX_Field_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Field",
                table: "Field",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Categories_CategoryId",
                table: "Field",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Field_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
