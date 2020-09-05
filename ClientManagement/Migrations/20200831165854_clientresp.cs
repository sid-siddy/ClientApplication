using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientManagement.Migrations
{
    public partial class clientresp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Clients_ClientFK",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_ClientFK",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "ClientComments",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "ClientFK",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "AuditorComments",
                table: "Response",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditorId",
                table: "Response",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Response",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientResp",
                table: "Response",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorComments",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "AuditorId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "ClientResp",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "ClientComments",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientFK",
                table: "Response",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_ClientFK",
                table: "Response",
                column: "ClientFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Clients_ClientFK",
                table: "Response",
                column: "ClientFK",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
