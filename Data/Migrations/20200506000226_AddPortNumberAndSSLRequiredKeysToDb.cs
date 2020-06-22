using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class AddPortNumberAndSSLRequiredKeysToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortNumber",
                table: "SMTP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SSLRequired",
                table: "SMTP",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortNumber",
                table: "SMTP");

            migrationBuilder.DropColumn(
                name: "SSLRequired",
                table: "SMTP");
        }
    }
}
