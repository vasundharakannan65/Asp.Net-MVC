using Microsoft.EntityFrameworkCore.Migrations;

namespace BankProject.Migrations
{
    public partial class UpdatedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustGender",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustGender",
                table: "Customers",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
