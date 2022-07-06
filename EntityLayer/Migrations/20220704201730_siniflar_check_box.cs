using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class siniflar_check_box : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "check_box",
                table: "siniflars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check_box",
                table: "siniflars");
        }
    }
}
