using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateEncuestaAndRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Encuestas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Encuestas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Encuestas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnfoqueDiferencialId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Encuestas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FormulacionPorOrganizacion",
                table: "Encuestas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Encuestas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroIdentificacion",
                table: "Encuestas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefonico",
                table: "Encuestas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ocupacion",
                table: "Encuestas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RangoEdadId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoIdentificacionId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UbicacionProyectoId",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ciudades",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Barrios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "EnfoquesDiferenciales",
                columns: table => new
                {
                    EnfoqueDiferencialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfoquesDiferenciales", x => x.EnfoqueDiferencialId);
                });

            migrationBuilder.CreateTable(
                name: "RangosEdad",
                columns: table => new
                {
                    RangoEdadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangosEdad", x => x.RangoEdadId);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposIdentificacion",
                columns: table => new
                {
                    TipoIdentificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposIdentificacion", x => x.TipoIdentificacionId);
                });

            migrationBuilder.CreateTable(
                name: "UbicacionesProyecto",
                columns: table => new
                {
                    UbicacionProyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UbicacionesProyecto", x => x.UbicacionProyectoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_EnfoqueDiferencialId",
                table: "Encuestas",
                column: "EnfoqueDiferencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_RangoEdadId",
                table: "Encuestas",
                column: "RangoEdadId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_SectorId",
                table: "Encuestas",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_SexoId",
                table: "Encuestas",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_TipoIdentificacionId",
                table: "Encuestas",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UbicacionProyectoId",
                table: "Encuestas",
                column: "UbicacionProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Nombre",
                table: "Ciudades",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_Nombre",
                table: "Barrios",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_EnfoquesDiferenciales_EnfoqueDiferencialId",
                table: "Encuestas",
                column: "EnfoqueDiferencialId",
                principalTable: "EnfoquesDiferenciales",
                principalColumn: "EnfoqueDiferencialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_RangosEdad_RangoEdadId",
                table: "Encuestas",
                column: "RangoEdadId",
                principalTable: "RangosEdad",
                principalColumn: "RangoEdadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_Sectores_SectorId",
                table: "Encuestas",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_Sexos_SexoId",
                table: "Encuestas",
                column: "SexoId",
                principalTable: "Sexos",
                principalColumn: "SexoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_TiposIdentificacion_TipoIdentificacionId",
                table: "Encuestas",
                column: "TipoIdentificacionId",
                principalTable: "TiposIdentificacion",
                principalColumn: "TipoIdentificacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_UbicacionesProyecto_UbicacionProyectoId",
                table: "Encuestas",
                column: "UbicacionProyectoId",
                principalTable: "UbicacionesProyecto",
                principalColumn: "UbicacionProyectoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_EnfoquesDiferenciales_EnfoqueDiferencialId",
                table: "Encuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_RangosEdad_RangoEdadId",
                table: "Encuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_Sectores_SectorId",
                table: "Encuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_Sexos_SexoId",
                table: "Encuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_TiposIdentificacion_TipoIdentificacionId",
                table: "Encuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_UbicacionesProyecto_UbicacionProyectoId",
                table: "Encuestas");

            migrationBuilder.DropTable(
                name: "EnfoquesDiferenciales");

            migrationBuilder.DropTable(
                name: "RangosEdad");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "TiposIdentificacion");

            migrationBuilder.DropTable(
                name: "UbicacionesProyecto");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_EnfoqueDiferencialId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_RangoEdadId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_SectorId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_SexoId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_TipoIdentificacionId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_UbicacionProyectoId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_Nombre",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_Nombre",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "EnfoqueDiferencialId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "FormulacionPorOrganizacion",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "NumeroIdentificacion",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "NumeroTelefonico",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "Ocupacion",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "RangoEdadId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "TipoIdentificacionId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "UbicacionProyectoId",
                table: "Encuestas");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Encuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ciudades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Barrios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
