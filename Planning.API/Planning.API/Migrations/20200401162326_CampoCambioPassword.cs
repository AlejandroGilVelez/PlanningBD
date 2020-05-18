using Microsoft.EntityFrameworkCore.Migrations;

namespace Planning.API.Migrations
{
    public partial class CampoCambioPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CambioPassword",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CambioPassword",
                table: "Users");
        }
    }
}
