using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class durum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pasif",
                table: "lessons");

            migrationBuilder.AddColumn<bool>(
                name: "durum",
                table: "lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "durum",
                table: "lessons");

            migrationBuilder.AddColumn<string>(
                name: "pasif",
                table: "lessons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
