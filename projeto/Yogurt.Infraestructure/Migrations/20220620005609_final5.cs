using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class final5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Publicacao_IdPublicacao",
                table: "Arquivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos");

            migrationBuilder.RenameTable(
                name: "Arquivos",
                newName: "Arquivo");

            migrationBuilder.RenameIndex(
                name: "IX_Arquivos_IdPublicacao",
                table: "Arquivo",
                newName: "IX_Arquivo_IdPublicacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivo_Publicacao_IdPublicacao",
                table: "Arquivo",
                column: "IdPublicacao",
                principalTable: "Publicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivo_Publicacao_IdPublicacao",
                table: "Arquivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo");

            migrationBuilder.RenameTable(
                name: "Arquivo",
                newName: "Arquivos");

            migrationBuilder.RenameIndex(
                name: "IX_Arquivo_IdPublicacao",
                table: "Arquivos",
                newName: "IX_Arquivos_IdPublicacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Publicacao_IdPublicacao",
                table: "Arquivos",
                column: "IdPublicacao",
                principalTable: "Publicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
