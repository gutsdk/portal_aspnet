using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProj.Migrations
{
    public partial class DeleteUselessExtraEducationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraEducationId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraEducationId",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
