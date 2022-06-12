using Microsoft.EntityFrameworkCore.Migrations;

namespace disease_tracker_api.Migrations
{
    public partial class AddArchiveColumnToDiseaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArchiveReason",
                table: "Diseases",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Diseases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchiveReason",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Diseases");
        }
    }
}
