using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reporteros.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatosPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Competiciones",
                columns: new[] { "Id", "Ambito", "DeporteId", "Formato", "JuegoId", "Nombre" },
                values: new object[,]
                {
                    { 1L, "nacional", 1L, "liga", null, "Campeonato Uruguayo" },
                    { 2L, "nacional", 2L, "liga", null, "Liga Uruguaya de Básquetbol" }
                });

            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "Id", "Nombre", "Region", "Slug", "UrlLogo" },
                values: new object[,]
                {
                    { 1L, "Peñarol", "Montevideo", "penarol", null },
                    { 2L, "Nacional", "Montevideo", "nacional", null },
                    { 3L, "Defensor Sporting", "Montevideo", "defensor-sporting", null },
                    { 4L, "Liverpool", "Montevideo", "liverpool", null },
                    { 5L, "Aguada", "Montevideo", "aguada", null },
                    { 6L, "Malvín", "Montevideo", "malvin", null },
                    { 7L, "Team Alpha", "Montevideo", "team-alpha", null },
                    { 8L, "Team Beta", "Montevideo", "team-beta", null }
                });

            migrationBuilder.InsertData(
                table: "Fuentes",
                columns: new[] { "Id", "Atribucion", "CapturadoEn", "Confianza", "Titulo", "Url" },
                values: new object[,]
                {
                    { 1L, "AUF", null, "alta", "Acta oficial AUF", "https://auf.org.uy" },
                    { 2L, "Equipo editorial", null, "media", "Carga manual editor", null }
                });

            migrationBuilder.InsertData(
                table: "Juegos",
                columns: new[] { "Id", "DeporteId", "Nombre", "Slug" },
                values: new object[] { 1L, 3L, "League of Legends", "league-of-legends" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Correo", "NombreMostrado", "Rol" },
                values: new object[,]
                {
                    { 1L, "admin@reporteros.uy", "Admin", "admin" },
                    { 2L, "editor@reporteros.uy", "Editor", "editor" },
                    { 3L, "revisor@reporteros.uy", "Revisor", "revisor" },
                    { 4L, "visitante@reporteros.uy", "Visitante", "visitante" }
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "ActualizadoEn", "AutorUsuarioId", "Cuerpo", "Estado", "PublicadoEn", "Resumen", "Slug", "Titulo" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 8, 1, 12, 0, 0, 0, DateTimeKind.Utc), 2L, "Contenido de bienvenida.", "publicado", new DateTime(2026, 8, 1, 12, 0, 0, 0, DateTimeKind.Utc), "El deporte uruguayo tiene quien lo cuente.", "bienvenida-reporteros", "Bienvenidos a REPORTEROS" },
                    { 2L, new DateTime(2026, 8, 2, 12, 0, 0, 0, DateTimeKind.Utc), 2L, "Cuerpo borrador.", "borrador", null, "Resumen borrador.", "borrador-noticia", "Borrador de noticia" }
                });

            migrationBuilder.InsertData(
                table: "Competiciones",
                columns: new[] { "Id", "Ambito", "DeporteId", "Formato", "JuegoId", "Nombre" },
                values: new object[] { 3L, "nacional", 3L, "liga", 1L, "Liga Uruguaya de LoL" });

            migrationBuilder.InsertData(
                table: "Temporadas",
                columns: new[] { "Id", "CompeticionId", "Estado", "Etiqueta", "Fin", "Inicio", "ReglasJson" },
                values: new object[,]
                {
                    { 1L, 1L, "en_curso", "2026", new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 2L, 2L, "en_curso", "2026", new DateTime(2026, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "ArticulosDeporte",
                columns: new[] { "ArticuloId", "DeporteId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "EquiposTemporada",
                columns: new[] { "Id", "EquipoId", "TemporadaId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 1L },
                    { 3L, 3L, 1L },
                    { 4L, 4L, 1L },
                    { 5L, 5L, 2L },
                    { 6L, 6L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Partidos",
                columns: new[] { "Id", "ActualizadoEn", "EquipoLocalId", "EquipoVisitanteId", "Estado", "FuenteId", "MejorDe", "ProgramadoEn", "PublicadoEn", "PuntosLocal", "PuntosVisitante", "TemporadaId", "Version" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1L, 2L, "programado", null, null, new DateTime(2026, 9, 10, 20, 0, 0, 0, DateTimeKind.Utc), null, null, null, 1L, 1 },
                    { 2L, new DateTime(2026, 8, 20, 21, 0, 0, 0, DateTimeKind.Utc), 3L, 4L, "finalizado", 1L, null, new DateTime(2026, 8, 20, 19, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 20, 21, 0, 0, 0, DateTimeKind.Utc), 2, 1, 1L, 2 },
                    { 3L, new DateTime(2026, 8, 27, 22, 0, 0, 0, DateTimeKind.Utc), 1L, 3L, "finalizado", 1L, null, new DateTime(2026, 8, 27, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 27, 22, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1L, 1 },
                    { 4L, new DateTime(2026, 9, 3, 16, 30, 0, 0, DateTimeKind.Utc), 2L, 4L, "suspendido", null, null, new DateTime(2026, 9, 3, 16, 0, 0, 0, DateTimeKind.Utc), null, null, null, 1L, 1 },
                    { 5L, new DateTime(2026, 9, 17, 22, 0, 0, 0, DateTimeKind.Utc), 1L, 4L, "provisional", 2L, null, new DateTime(2026, 9, 17, 20, 0, 0, 0, DateTimeKind.Utc), null, 2, 0, 1L, 1 },
                    { 6L, new DateTime(2026, 9, 5, 23, 0, 0, 0, DateTimeKind.Utc), 5L, 6L, "finalizado", 1L, null, new DateTime(2026, 9, 5, 21, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 9, 5, 23, 0, 0, 0, DateTimeKind.Utc), 85, 80, 2L, 1 },
                    { 7L, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6L, 5L, "programado", null, null, new DateTime(2026, 9, 12, 21, 0, 0, 0, DateTimeKind.Utc), null, null, null, 2L, 1 }
                });

            migrationBuilder.InsertData(
                table: "Temporadas",
                columns: new[] { "Id", "CompeticionId", "Estado", "Etiqueta", "Fin", "Inicio", "ReglasJson" },
                values: new object[] { 3L, 3L, "en_curso", "2026 Split 1", new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null });

            migrationBuilder.InsertData(
                table: "EquiposTemporada",
                columns: new[] { "Id", "EquipoId", "TemporadaId" },
                values: new object[,]
                {
                    { 7L, 7L, 3L },
                    { 8L, 8L, 3L }
                });

            migrationBuilder.InsertData(
                table: "Partidos",
                columns: new[] { "Id", "ActualizadoEn", "EquipoLocalId", "EquipoVisitanteId", "Estado", "FuenteId", "MejorDe", "ProgramadoEn", "PublicadoEn", "PuntosLocal", "PuntosVisitante", "TemporadaId", "Version" },
                values: new object[,]
                {
                    { 8L, new DateTime(2026, 6, 10, 20, 0, 0, 0, DateTimeKind.Utc), 7L, 8L, "finalizado", 1L, 3, new DateTime(2026, 6, 10, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 20, 0, 0, 0, DateTimeKind.Utc), 2, 1, 3L, 1 },
                    { 9L, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8L, 7L, "programado", null, 3, new DateTime(2026, 6, 17, 18, 0, 0, 0, DateTimeKind.Utc), null, null, null, 3L, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ArticulosDeporte",
                keyColumns: new[] { "ArticuloId", "DeporteId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "EquiposTemporada",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Fuentes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Fuentes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Temporadas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Temporadas",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Temporadas",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Competiciones",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Competiciones",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Competiciones",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Juegos",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
