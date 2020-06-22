using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class ChangeNextStepToNotesInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextStep",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Client",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "NextStep",
                table: "Client",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
