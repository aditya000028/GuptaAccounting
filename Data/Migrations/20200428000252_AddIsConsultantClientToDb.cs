using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class AddIsConsultantClientToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConsultationClient",
                table: "Client",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConsultationClient",
                table: "Client");
        }
    }
}
