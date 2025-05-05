using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jwt_CURD_Operation.Migrations
{
    /// <inheritdoc />
    public partial class imgmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "Name");
        }
    }
}
