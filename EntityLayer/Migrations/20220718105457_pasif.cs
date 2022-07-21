using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class pasif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check_box",
                table: "siniflars");

            migrationBuilder.AddColumn<string>(
                name: "pasif",
                table: "lesson_İceriks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pasif",
                table: "lesson_İceriks");

            migrationBuilder.AddColumn<bool>(
                name: "check_box",
                table: "siniflars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
