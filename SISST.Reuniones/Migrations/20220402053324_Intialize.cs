using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISST.Reuniones.Migrations
{
    public partial class Intialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Reunion");

            migrationBuilder.CreateTable(
                name: "TReuniones",
                schema: "Reunion",
                columns: table => new
                {
                    ReunionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Horario = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    NoParticipantes = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    Tema = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Apoyo = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    Introduccion = table.Column<string>(type: "TEXT", nullable: false),
                    Desarrollo = table.Column<string>(type: "TEXT", nullable: false),
                    Conclusiones = table.Column<string>(type: "TEXT", nullable: false),
                    Retroalimentacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReuniones", x => x.ReunionId);
                });

            migrationBuilder.CreateTable(
                name: "TDocumentos",
                schema: "Reunion",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReunionId = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Ruta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDocumentos", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_TDocumentos_TReuniones_ReunionId",
                        column: x => x.ReunionId,
                        principalSchema: "Reunion",
                        principalTable: "TReuniones",
                        principalColumn: "ReunionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TParticipantes",
                schema: "Reunion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReunion = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    IdTrabajador = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    ReunionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TParticipantes_TReuniones_ReunionId",
                        column: x => x.ReunionId,
                        principalSchema: "Reunion",
                        principalTable: "TReuniones",
                        principalColumn: "ReunionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TDocumentos_DocumentoId",
                schema: "Reunion",
                table: "TDocumentos",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TDocumentos_ReunionId",
                schema: "Reunion",
                table: "TDocumentos",
                column: "ReunionId");

            migrationBuilder.CreateIndex(
                name: "IX_TParticipantes_Id",
                schema: "Reunion",
                table: "TParticipantes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TParticipantes_ReunionId",
                schema: "Reunion",
                table: "TParticipantes",
                column: "ReunionId");

            migrationBuilder.CreateIndex(
                name: "IX_TReuniones_ReunionId",
                schema: "Reunion",
                table: "TReuniones",
                column: "ReunionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDocumentos",
                schema: "Reunion");

            migrationBuilder.DropTable(
                name: "TParticipantes",
                schema: "Reunion");

            migrationBuilder.DropTable(
                name: "TReuniones",
                schema: "Reunion");
        }
    }
}
