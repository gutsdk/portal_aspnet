using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProj.Migrations
{
    public partial class UserChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraEducationId",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "ExtraEducationsList",
                table: "Users",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraEducationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraEducationsList",
                table: "Users");
        }
    }
}
