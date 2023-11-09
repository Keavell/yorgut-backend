using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Cidade_IdCidade",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "IdCompartilhamento",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "IdCidade",
                table: "Perfil",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPublicacao",
                table: "Comentarios",
                column: "IdPublicacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacao_IdPublicacao",
                table: "Comentarios",
                column: "IdPublicacao",
                principalTable: "Publicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Cidade_IdCidade",
                table: "Perfil",
                column: "IdCidade",
                principalTable: "Cidade",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacao_IdPublicacao",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Cidade_IdCidade",
                table: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdPublicacao",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "IdCidade",
                table: "Perfil",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCompartilhamento",
                table: "Comentarios",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Cidade_IdCidade",
                table: "Perfil",
                column: "IdCidade",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
