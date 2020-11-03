using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionElectronica.UI.Migrations
{
    public partial class TipoDeIdentificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Canton",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtrasSenas",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeIdentificacion",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canton",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtrasSenas",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoDeIdentificacion",
                table: "AspNetUsers");
        }
    }
}
