using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Resposta_IdComentario",
                table: "Resposta",
                column: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Comentarios_IdComentario",
                table: "Resposta",
                column: "IdComentario",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Comentarios_IdComentario",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_IdComentario",
                table: "Resposta");
        }
    }
}
