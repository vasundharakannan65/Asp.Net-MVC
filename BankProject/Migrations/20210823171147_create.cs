using Microsoft.EntityFrameworkCore.Migrations;

namespace BankProject.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAge = table.Column<int>(type: "int", nullable: false),
                    CustGender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CustBlnc = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
