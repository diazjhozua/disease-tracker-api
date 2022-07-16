using Microsoft.EntityFrameworkCore.Migrations;

namespace disease_tracker_api.Migrations
{
    public partial class UpdateColumnNameOfEmailFieldToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");
        }
    }
}
