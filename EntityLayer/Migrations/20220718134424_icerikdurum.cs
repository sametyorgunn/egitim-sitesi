using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class icerikdurum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pasif",
                table: "lesson_İceriks");

            migrationBuilder.AddColumn<bool>(
                name: "durum",
                table: "lesson_İceriks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "durum",
                table: "lesson_İceriks");

            migrationBuilder.AddColumn<string>(
                name: "pasif",
                table: "lesson_İceriks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
