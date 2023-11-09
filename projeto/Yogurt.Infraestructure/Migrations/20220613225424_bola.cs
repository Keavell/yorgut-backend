using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class bola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amizade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPerfil = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amizade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amizade_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conectar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPerfil = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdAmizade = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conectar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conectar_Amizade_IdAmizade",
                        column: x => x.IdAmizade,
                        principalTable: "Amizade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conectar_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_IdComunidade",
                table: "Publicacao",
                column: "IdComunidade");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_IdPerfil",
                table: "Publicacao",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_IdPublicacao",
                table: "Arquivos",
                column: "IdPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Amizade_IdPerfil",
                table: "Amizade",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Conectar_IdAmizade",
                table: "Conectar",
                column: "IdAmizade");

            migrationBuilder.CreateIndex(
                name: "IX_Conectar_IdPerfil",
                table: "Conectar",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Publicacao_IdPublicacao",
                table: "Arquivos",
                column: "IdPublicacao",
                principalTable: "Publicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Comunidade_IdComunidade",
                table: "Publicacao",
                column: "IdComunidade",
                principalTable: "Comunidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Perfil_IdPerfil",
                table: "Publicacao",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Publicacao_IdPublicacao",
                table: "Arquivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Comunidade_IdComunidade",
                table: "Publicacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Perfil_IdPerfil",
                table: "Publicacao");

            migrationBuilder.DropTable(
                name: "Conectar");

            migrationBuilder.DropTable(
                name: "Amizade");

            migrationBuilder.DropIndex(
                name: "IX_Publicacao_IdComunidade",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Publicacao_IdPerfil",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_IdPublicacao",
                table: "Arquivos");
        }
    }
}
