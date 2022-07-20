using Microsoft.EntityFrameworkCore.Migrations;

namespace disease_tracker_api.Migrations
{
    public partial class OrgranizationDiseaseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Diseases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_OrganizationId",
                table: "Diseases",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Organizations_OrganizationId",
                table: "Diseases",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Organizations_OrganizationId",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_OrganizationId",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Diseases");
        }
    }
}
