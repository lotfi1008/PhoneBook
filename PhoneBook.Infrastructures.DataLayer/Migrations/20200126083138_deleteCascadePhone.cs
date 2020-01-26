using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Infrastructures.DataLayer.Migrations
{
    public partial class deleteCascadePhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
