using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProj.Migrations
{
    public partial class AddedDescriptionForEE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExtraEducations",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExtraEducations");
        }
    }
}
