using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseStorage.Migrations
{
    public partial class NormView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Disciplines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_DepartmentId",
                table: "Disciplines",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Departments_DepartmentId",
                table: "Disciplines",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialities_SpecialityId",
                table: "Groups",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Departments_DepartmentId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialities_SpecialityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_DepartmentId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Disciplines");
        }
    }
}
