using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAngularWebApi.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageThemeId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageThemeId",
                table: "Messages",
                column: "MessageThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageThemes_MessageThemeId",
                table: "Messages",
                column: "MessageThemeId",
                principalTable: "MessageThemes",
                principalColumn: "ThemeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageThemes_MessageThemeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageThemeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageThemeId",
                table: "Messages");
        }
    }
}
