using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEvents.Migrations
{
    public partial class RelateCategorytoEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "EventCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventCategory_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "EventCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventCategory_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "EventCategory",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }
    }
}
