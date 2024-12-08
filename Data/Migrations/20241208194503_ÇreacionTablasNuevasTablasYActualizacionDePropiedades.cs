using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ÇreacionTablasNuevasTablasYActualizacionDePropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Votos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProyectoSocialId",
                table: "Votos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "LiderSocials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoSociales",
                columns: table => new
                {
                    ProyectoSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archivo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiderSocialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoSociales", x => x.ProyectoSocialId);
                    table.ForeignKey(
                        name: "FK_ProyectoSociales_AspNetUsers_LiderSocialId",
                        column: x => x.LiderSocialId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoSociales_LiderSocials_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "LiderSocials",
                        principalColumn: "LiderSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_ProyectoSocialId",
                table: "Votos",
                column: "ProyectoSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_LiderSocials_CiudadId",
                table: "LiderSocials",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoSociales_LiderSocialId",
                table: "ProyectoSociales",
                column: "LiderSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoSociales_PersonaId",
                table: "ProyectoSociales",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiderSocials_Ciudades_CiudadId",
                table: "LiderSocials",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_ProyectoSociales_ProyectoSocialId",
                table: "Votos",
                column: "ProyectoSocialId",
                principalTable: "ProyectoSociales",
                principalColumn: "ProyectoSocialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiderSocials_Ciudades_CiudadId",
                table: "LiderSocials");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_ProyectoSociales_ProyectoSocialId",
                table: "Votos");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "ProyectoSociales");

            migrationBuilder.DropIndex(
                name: "IX_Votos_ProyectoSocialId",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_LiderSocials_CiudadId",
                table: "LiderSocials");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Votos");

            migrationBuilder.DropColumn(
                name: "ProyectoSocialId",
                table: "Votos");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "LiderSocials");
        }
    }
}
