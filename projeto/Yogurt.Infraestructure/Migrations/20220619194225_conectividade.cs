using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yogurt.Infraestructure.Migrations
{
    public partial class conectividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Perfil",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conectividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPerfil = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdComunidade = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conectividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conectividade_Comunidade_IdComunidade",
                        column: x => x.IdComunidade,
                        principalTable: "Comunidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conectividade_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conectividade_IdComunidade",
                table: "Conectividade",
                column: "IdComunidade");

            migrationBuilder.CreateIndex(
                name: "IX_Conectividade_IdPerfil",
                table: "Conectividade",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conectividade");

            migrationBuilder.UpdateData(
                table: "Perfil",
                keyColumn: "Genero",
                keyValue: null,
                column: "Genero",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Perfil",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
