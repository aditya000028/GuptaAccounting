using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class AddSMTPKeysToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMTP",
                columns: table => new
                {
                    ServerName = table.Column<string>(nullable: false),
                    EmailFromName = table.Column<string>(nullable: false),
                    EmailFrom = table.Column<string>(nullable: false),
                    EmailToName = table.Column<string>(nullable: false),
                    EmailTo = table.Column<string>(nullable: false),
                    ServerAddress = table.Column<string>(nullable: false),
                    AuthenticationEmail = table.Column<string>(nullable: false),
                    AuthenticationPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMTP", x => x.ServerName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMTP");
        }
    }
}
