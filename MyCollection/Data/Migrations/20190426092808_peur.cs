using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCollection.Data.Migrations
{
    public partial class peur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName_TXT",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName_TXT",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName_TXT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName_TXT",
                table: "AspNetUsers");
        }
    }
}
