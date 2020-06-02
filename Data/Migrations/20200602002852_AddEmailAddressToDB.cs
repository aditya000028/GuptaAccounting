using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class AddEmailAddressToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Client",
                maxLength: 320,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Client");
        }
    }
}
