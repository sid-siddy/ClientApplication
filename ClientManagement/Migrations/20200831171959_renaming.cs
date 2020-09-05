using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagement.Migrations
{
    public partial class renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientResp",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "ClientResponse",
                table: "Response",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientResponse",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "ClientResp",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
