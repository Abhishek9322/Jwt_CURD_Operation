using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jwt_CURD_Operation.Migrations
{
    /// <inheritdoc />
    public partial class jwtmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product1",
                table: "Product1",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product1",
                table: "Product1");

            migrationBuilder.RenameTable(
                name: "Product1",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
