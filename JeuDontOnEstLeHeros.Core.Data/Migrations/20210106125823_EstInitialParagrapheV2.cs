using Microsoft.EntityFrameworkCore.Migrations;

namespace JeuDontOnEstLeHeros.Core.Data.Migrations
{
    public partial class EstInitialParagrapheV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstInitial",
                table: "Paragraphe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstInitial",
                table: "Paragraphe");
        }
    }
}
