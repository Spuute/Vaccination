using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Changed_One_To_Many_To_One_To_One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Vaccinations_VaccinationId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_VaccinationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PersonId",
                table: "Vaccinations",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Persons_PersonId",
                table: "Vaccinations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Persons_PersonId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_PersonId",
                table: "Vaccinations");

            migrationBuilder.AddColumn<int>(
                name: "VaccinationId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_VaccinationId",
                table: "Persons",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Vaccinations_VaccinationId",
                table: "Persons",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
