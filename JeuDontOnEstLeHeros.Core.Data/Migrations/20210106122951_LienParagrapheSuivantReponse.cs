using Microsoft.EntityFrameworkCore.Migrations;

namespace JeuDontOnEstLeHeros.Core.Data.Migrations
{
    public partial class LienParagrapheSuivantReponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Proposition_ParagrapheId",
                table: "Proposition",
                column: "ParagrapheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposition_Paragraphe_ParagrapheId",
                table: "Proposition",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposition_Paragraphe_ParagrapheId",
                table: "Proposition");

            migrationBuilder.DropIndex(
                name: "IX_Proposition_ParagrapheId",
                table: "Proposition");
        }
    }
}
