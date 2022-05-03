using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseStorage.Migrations
{
    public partial class ImplementNumberOfStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "Groups");
        }
    }
}
