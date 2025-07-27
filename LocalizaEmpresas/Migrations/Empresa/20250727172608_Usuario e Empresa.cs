using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizaEmpresas.Migrations.Empresa
{
    /// <inheritdoc />
    public partial class UsuarioeEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Empresas",
                type: "varchar(255)",
                nullable: true,  // <-- tornar nullable para evitar erro de FK
                defaultValue: null)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Empresas");
        }
    }
}
