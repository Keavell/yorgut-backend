using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class Rename_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicacaoEntity");

            migrationBuilder.DropColumn(
                name: "Nome_Arquivo",
                table: "Arquivos");

            migrationBuilder.RenameColumn(
                name: "Id_Comentarios",
                table: "Resposta",
                newName: "IdComentarios");

            migrationBuilder.RenameColumn(
                name: "Data_Criacao",
                table: "Resposta",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id_Perfil",
                table: "Publicacao",
                newName: "IdPerfil");

            migrationBuilder.RenameColumn(
                name: "Id_Comunidade",
                table: "Publicacao",
                newName: "IdComunidade");

            migrationBuilder.RenameColumn(
                name: "Data_Criacao",
                table: "Publicacao",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id_Publicacao",
                table: "Comentarios",
                newName: "IdPublicacao");

            migrationBuilder.RenameColumn(
                name: "Id_Compartilhamento",
                table: "Comentarios",
                newName: "IdCompartilhamento");

            migrationBuilder.RenameColumn(
                name: "Data_Criacao",
                table: "Comentarios",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id_Publicacao",
                table: "Arquivos",
                newName: "IdPublicacao");

            migrationBuilder.RenameColumn(
                name: "Data_Criacao",
                table: "Arquivos",
                newName: "DataCriacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdComentarios",
                table: "Resposta",
                newName: "Id_Comentarios");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Resposta",
                newName: "Data_Criacao");

            migrationBuilder.RenameColumn(
                name: "IdPerfil",
                table: "Publicacao",
                newName: "Id_Perfil");

            migrationBuilder.RenameColumn(
                name: "IdComunidade",
                table: "Publicacao",
                newName: "Id_Comunidade");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Publicacao",
                newName: "Data_Criacao");

            migrationBuilder.RenameColumn(
                name: "IdPublicacao",
                table: "Comentarios",
                newName: "Id_Publicacao");

            migrationBuilder.RenameColumn(
                name: "IdCompartilhamento",
                table: "Comentarios",
                newName: "Id_Compartilhamento");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Comentarios",
                newName: "Data_Criacao");

            migrationBuilder.RenameColumn(
                name: "IdPublicacao",
                table: "Arquivos",
                newName: "Id_Publicacao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Arquivos",
                newName: "Data_Criacao");

            migrationBuilder.AddColumn<string>(
                name: "Nome_Arquivo",
                table: "Arquivos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicacaoEntity",
                columns: table => new
                {
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
