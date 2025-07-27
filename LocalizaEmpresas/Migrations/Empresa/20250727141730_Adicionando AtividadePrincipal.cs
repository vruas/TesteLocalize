using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizaEmpresas.Migrations.Empresa
{
    /// <inheritdoc />
    public partial class AdicionandoAtividadePrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoAtividadePrincipal",
                table: "Empresas",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoAtividadePrincipal",
                table: "Empresas",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoAtividadePrincipal",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CodigoAtividadePrincipal",
                table: "Empresas");
        }
    }
}
