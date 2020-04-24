using Microsoft.EntityFrameworkCore.Migrations;

namespace GuptaAccounting.Data.Migrations
{
    public partial class AddMultipleWorkTypeFieldsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Client",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Bookkeeping",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GST_PST_WCB_Returns",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Government_Requisite_Form_Applications",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Payroll_Services",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Personal_Income_Taxation",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Previous_Year_Filings",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Self_Employed_Business_Taxes",
                table: "Client",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tax_Returns",
                table: "Client",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bookkeeping",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "GST_PST_WCB_Returns",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Government_Requisite_Form_Applications",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Payroll_Services",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Personal_Income_Taxation",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Previous_Year_Filings",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Self_Employed_Business_Taxes",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Tax_Returns",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Client",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
