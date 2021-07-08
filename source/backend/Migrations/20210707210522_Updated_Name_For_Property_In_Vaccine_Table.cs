using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Updated_Name_For_Property_In_Vaccine_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableDoses",
                table: "AvailableDoses",
                newName: "Doses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Doses",
                table: "AvailableDoses",
                newName: "AvailableDoses");
        }
    }
}
