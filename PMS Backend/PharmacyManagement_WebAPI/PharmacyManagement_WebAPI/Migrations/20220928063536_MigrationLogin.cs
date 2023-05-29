using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyManagement_WebAPI.Migrations
{
    public partial class MigrationLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "LoginDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginDetails",
                newName: "EmailId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "LoginDetails",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
