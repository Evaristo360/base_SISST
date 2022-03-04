using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISST.Autenticacion.Migrations
{
    public partial class initAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Autenticacion");

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProceso = table.Column<int>(type: "int", nullable: false),
                    IdAreaSuperior = table.Column<int>(type: "int", nullable: true),
                    IdAreaVerificacion = table.Column<int>(type: "int", nullable: true),
                    Clave = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(175)", maxLength: 175, nullable: false),
                    CentroGestor = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: true),
                    ClaveControlGestion = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: true),
                    IdNivelJerarquico = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    IdEntidadFederativa = table.Column<int>(type: "int", nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    GeneraDatosBasicos = table.Column<bool>(type: "bit", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Area_IdAreaSuperior",
                        column: x => x.IdAreaSuperior,
                        principalSchema: "Autenticacion",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Area_IdAreaVerificacion",
                        column: x => x.IdAreaVerificacion,
                        principalSchema: "Autenticacion",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoDet",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    ClaveDepto = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    id_rama_actividad = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoDet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilegio",
                schema: "Autenticacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePrivilegio = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    url = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: false),
                    modulo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    moduloMenu = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: true),
                    seccion = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    area = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    icono = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    porOmision = table.Column<bool>(type: "bit", nullable: false),
                    orden = table.Column<float>(type: "real", nullable: false),
                    ocultarParaIdRol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ocultarParaIdProceso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilegio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    IdNivelJerarquico = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCT = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdDepartamentoSicacyp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Area_IdCT",
                        column: x => x.IdCT,
                        principalSchema: "Autenticacion",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RPE = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: false),
                    Domicilio = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: true),
                    RFC = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "VARCHAR(75)", maxLength: 75, nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: true),
                    AfiliacionIMSS = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    FechaIngresoCFE = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaIngresoPuestoActual = table.Column<DateTime>(type: "Date", nullable: true),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    IdSituacionLaboral = table.Column<int>(type: "int", nullable: false),
                    SalarioDiarioActual = table.Column<double>(type: "float", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    NombreCompleto = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabajador_Area_IdArea",
                        column: x => x.IdArea,
                        principalSchema: "Autenticacion",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolClaims",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolClaims_Rol_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Autenticacion",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPrivilegio",
                schema: "Autenticacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    privilegioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPrivilegio", x => x.id);
                    table.ForeignKey(
                        name: "FK_RolPrivilegio_Privilegio_privilegioId",
                        column: x => x.privilegioId,
                        principalSchema: "Autenticacion",
                        principalTable: "Privilegio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPrivilegio_Rol_rolId",
                        column: x => x.rolId,
                        principalSchema: "Autenticacion",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TrabajadorId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalSchema: "Autenticacion",
                        principalTable: "Trabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaAdministrada",
                schema: "Autenticacion",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAdministrada", x => new { x.IdUsuario, x.IdRol, x.IdArea });
                    table.ForeignKey(
                        name: "FK_AreaAdministrada_Area_IdArea",
                        column: x => x.IdArea,
                        principalSchema: "Autenticacion",
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AreaAdministrada_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Autenticacion",
                        principalTable: "Rol",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AreaAdministrada_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioClaims",
                schema: "Autenticacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioClaims_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLogins",
                schema: "Autenticacion",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UsuarioLogins_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPrivilegio",
                schema: "Autenticacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    privilegioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPrivilegio", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsuarioPrivilegio_Privilegio_privilegioId",
                        column: x => x.privilegioId,
                        principalSchema: "Autenticacion",
                        principalTable: "Privilegio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPrivilegio_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                schema: "Autenticacion",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Rol_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Autenticacion",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTokens",
                schema: "Autenticacion",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsuarioTokens_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "Autenticacion",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Area",
                columns: new[] { "Id", "Activo", "CentroGestor", "Clave", "ClaveControlGestion", "Direccion", "GeneraDatosBasicos", "IdAreaSuperior", "IdAreaVerificacion", "IdEntidadFederativa", "IdMunicipio", "IdNivelJerarquico", "IdProceso", "Nombre", "Prioridad", "Telefono" },
                values: new object[] { 1, true, "", "A0000", null, "", false, null, null, 1, 1, 3287, 102, "Comisión Federal de Electricidad", 0, "" });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 294, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones Local Detalle", null, null, 10f, false, "Detalle instlación", "/ConfiguracionLocal/Details" },
                    { 398, true, "Gestion", "", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Evaluaciones Requisitos", null, null, 44269f, true, "Evaluaciones requisitos", "/ConsultasRL/EvaluacionesRequisitos" },
                    { 399, true, "Gestion", "", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Expediente CT", null, null, 44300f, true, "Expedientes CT", "/ConsultasRL/ExpedientesCT" },
                    { 400, true, "Gestion", "", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Expediente Consolidado", null, null, 44330f, true, "Expedientes Consolidado", "/ConsultasRL/ExpedientesConsolidado" },
                    { 401, true, "Gestion", "", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Expediente Requisitos", null, null, 44361f, true, "Expedientes Requisitos", "/ConsultasRL/ExpedientesRequisitos" },
                    { 402, true, "Incidentes", "fas fa-list-ul", "Incidentes", "", "Lista CLEM22", null, null, 0f, true, "CLEM22", "/CLEM22/Index" },
                    { 403, true, "Incidentes", "", "Incidentes", "", "Crear CLEM22", null, null, 0f, false, "Crear CLEM22", "/CLEM22/Create" },
                    { 397, true, "Gestion", "", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Evaluaciones Consolidado", null, null, 44241f, true, "Evaluaciones consolidado", "/ConsultasRL/EvaluacionesConsolidado" },
                    { 404, true, "Incidentes", "", "Incidentes", "", "Editar CLEM22", null, null, 0f, false, "Editar CLEM22", "/CLEM22/Edit" },
                    { 406, true, "Incidentes", "", "Incidentes", "", "Crear registro patronal", null, null, 0f, false, "Crear registro patronal", "/RegistroPatronal/Create" },
                    { 407, true, "Incidentes", "", "Incidentes", "", "Detalle registro patronal", null, null, 0f, false, "Detalle registro patronal", "/RegistroPatronal/Details" },
                    { 408, true, "Incidentes", "", "Incidentes", "", "Editar registro patronal", null, null, 0f, false, "Editar registro patronal", "/RegistroPatronal/Edit" },
                    { 409, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Comisiones Consultar", null, null, 5.01f, true, "CSH", "/ProgramasSST/IndexComision" },
                    { 410, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Actas Consultar", null, null, 5.03f, true, "Actas", "/ProgramasSST/IndexActa" },
                    { 411, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Programa Prototipo", null, null, 5.02f, true, "Programa prototipo", "/ProgramasSST/IndexProgramaPrototipo" },
                    { 412, true, "Gestion", "fas fa-project-diagram", "Gestión de seguridad", "Programas SST", "Programas SST Programa", null, null, 5.02f, true, "Programa", "/ProgramasSST/IndexPrograma" },
                    { 405, true, "Incidentes", "fas fa-book", "Incidentes", "", "Lista registro patronal", null, null, 0f, true, "Registro patronal", "/RegistroPatronal/Index" },
                    { 396, true, "Gestion", "fas fa-search", "Gestión de seguridad", "Consultas de Requisitos Legales", "Requisitos Legales Consultar Evaluaciones CT", null, null, 44210f, true, "Evaluaciones CT", "/ConsultasRL/EvaluacionesCT" },
                    { 395, true, "Gestion", "", "Gestion de seguridad", "Requisitos legales", "Requisitos Legales Generar Reporte", null, null, 0f, false, "Generar reporte", "/ReportesRL/ReporteExpediente" },
                    { 394, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Archivo de Evidencia", null, null, 0f, false, "Evidencia de requisito aplicable", "/Expediente/Evidencia" },
                    { 379, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Listar centro trabajo Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/ListaCentrosTarea" },
                    { 380, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Eliminar centro trabajo Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/EliminaCentroTrabajo" },
                    { 381, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Agregar Requisito a Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/AgregaRequisitoTarea" },
                    { 382, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Listar Requisitos Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/ListaRequisitosTarea" },
                    { 383, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Eliminar Requisitos Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/EliminaRequisitoTarea" },
                    { 384, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Lista Requisitos Norma", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/ListaRequisitosNorma" },
                    { 385, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Publicar", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/PublicaTarea" },
                    { 386, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Cancela Publicación", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/CancelaPublicacion" },
                    { 387, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Recupera Bitácora", null, null, 0f, false, "Agrega Requisitos", "/AgregaRequisitos/GetDatosBitacora" },
                    { 388, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Asignar Calificación Dictamen IMSS", null, null, 0f, false, "Actualiza dictamen", "/Incidentes/IncidenteConLesionUpdateDictamen" },
                    { 389, true, "Incidentes", "", "Incidentes", "", "Incidentes Deterioro Salud Asignar Calificación Dictamen IMSS", null, null, 0f, false, "Actualiza dictamen", "/Incidentes/IncidenteDeterioroSaludUpdateDictamen" },
                    { 390, true, "ProteccionCivil", "fas fa-bomb", "Protección Civil Integral", "", "Protección Civil Integral Monitor de Emergencias", null, null, 1f, true, "Monitor emergencias", "/ProteccionCivil/Index" },
                    { 391, true, "ProteccionCivil", "fas fa-house-damage", "Protección Civil Integral", "", "Protección Civil Integral Sistema Integral de Protección Civil", null, null, 2f, true, "Protección civil", "/ProteccionCivil/IndexPCI" },
                    { 392, true, "Diagnostico", "", "Gestión de seguridad", "Consultas ejecutivas", "Protección Contra Incendios Consultar Resultados", null, null, 13.5f, true, "Indicador infraestructura seguridad", "/ConsultaEjecutivaDiag/IndexResultados" },
                    { 393, true, "Diagnostico", "", "Gestión de seguridad", "Consultas ejecutivas", "Protección Contra Incendios Consultar Desviaciones", null, null, 13.6f, true, "Desviaciones infraestructura seguridad", "/ConsultaEjecutivaDiag/IndexDesviaciones" },
                    { 413, true, "GestionRL", "", "Gestion de seguridad", "Requisitos legales", "Requisitos legales Puntos Norma Registrar importancia a requisito legal", null, null, 0f, false, "Registrar importancia a requisito legal", "/PuntoNorma/CreateImportancia" },
                    { 414, true, "GestionRL", "", "Gestion de seguridad", "Requisitos legales", "Requisitos legales Puntos Norma Actualizar importancia a requisito legal", null, null, 0f, false, "Actualizar importancia a requisito legal", "/PuntoNorma/UpdateImportancia" },
                    { 415, true, "GestionRL", "", "Gestion de seguridad", "Requisitos legales", "Requisitos legales Puntos Norma Eliminar importancia a requisito legal", null, null, 0f, false, "Actualizar importancia a requisito legal", "/PuntoNorma/DeleteImportancia" },
                    { 416, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear CSH", null, null, 5.05f, false, "Crear CSH", "/ProgramasSST/CreateComision" },
                    { 436, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Evidencias del programa en evaluación", null, null, 5.25f, false, "Consultar evaluación evidencias", "/ProgramasSST/EvaluacionEvidencias" },
                    { 437, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Evalución Actualizar conformidad", null, null, 5.26f, false, "Actualizar evaluación evidencias", "/ProgramasSST/UpdateEvaluacionEvidencias" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 438, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "", "Proyectos de Seguridad Consultar Reaseguradoras", null, null, 1f, true, "Reaseguradoras", "/ProyectosSeguridad/IndexReaseguradora" },
                    { 439, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "", "Proyectos de Seguridad Consultar Normas", null, null, 1.01f, true, "Normas", "/ProyectosSeguridad/IndexNormas" },
                    { 440, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "", "Proyectos de Seguridad Consultar Necesidades", null, null, 1.02f, true, "Necesidades", "/ProyectosSeguridad/IndexNecesidades" },
                    { 441, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Planeación", "Proyectos de Seguridad Consultar Proyectos Activos", null, null, 1.03f, true, "Proyectos activo", "/ProyectosSeguridad/IndexPlaneacionActivos" },
                    { 442, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Planeación", "Proyectos de Seguridad Consultar Proyectos Cerrados", null, null, 1.04f, true, "Proyectos cerrados", "/ProyectosSeguridad/IndexPlaneacionCerrados" },
                    { 443, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Consultas ejecutivas", "Proyectos de Seguridad Consultar Ejecutiva Necesidades ", null, null, 1.05f, true, "Necesidades", "/ProyectosSeguridad/IndexConsultaNecesidades" },
                    { 444, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Evaluación Obtener requisitos del expediente a evaluar", null, null, 0f, false, "Obtener requisitos de evaluación", "/EvaluacionExpediente/GetRequisitosDeExpediente" },
                    { 445, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Lista Requisitos Norma paginado", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/ListaRequisitosNormaPaginado" },
                    { 446, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Agregar todos centros trabajo a Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/AgregaTodosCentrosTarea" },
                    { 447, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar actas", null, null, 5.27f, false, "Guardar actas", "/ProgramasSST/SaveActa" },
                    { 448, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar - actualizar actas", null, null, 5.28f, false, "Guardar - actualizar actas", "/ProgramasSST/SaveUpdateActa" },
                    { 449, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar actas", null, null, 5.29f, false, "Eliminar actas", "/ProgramasSST/DeleteActa" },
                    { 450, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener acta", null, null, 5.3f, false, "Obtener acta", "/ProgramasSST/GetActa" },
                    { 435, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Actividades del programa en evaluación", null, null, 5.25f, false, "Consultar evaluación actividades", "/ProgramasSST/EvaluacionActividades" },
                    { 378, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Agregar centro trabajo a Tarea", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/AgregaCentrosTarea" },
                    { 434, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Elementos del programa en evaluación", null, null, 5.23f, false, "Consultar evaluación elemento", "/ProgramasSST/EvaluacionElementos" },
                    { 432, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Seleccionar programa a evaluar", null, null, 5.21f, false, "Seleccionar programa", "/ProgramasSST/IndexSelectPrograma" },
                    { 417, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Editar CSH", null, null, 5.06f, false, "Editar CSH", "/ProgramasSST/EditComision" },
                    { 418, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Cambiar estado el Acta (regresar a incompleta)", null, null, 5.08f, false, "Actas PDF", "/Gestion/ProgramasSST/GetActaPdf" },
                    { 419, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Desactivar CSH", null, null, 5.08f, false, "Desactivar CSH", "/ProgramasSST/ToogleComision" },
                    { 420, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear programa prototipo", null, null, 5.09f, false, "Crear prototipo", "/ProgramasSST/CreateProgramaPrototipo" },
                    { 421, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Editar programa prototipo", null, null, 5.1f, false, "Editar prototipo", "/ProgramasSST/UpdateProgramaPrototipo" },
                    { 422, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar programa prototipo", null, null, 5.11f, false, "Eliminar prototipo", "/ProgramasSST/DeleteProgramaPrototipo" },
                    { 423, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear programa", null, null, 5.12f, false, "Crear programa", "/ProgramasSST/CreatePrograma" },
                    { 424, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Agregar evidencias", null, null, 5.13f, false, "Agregar evidencia", "/ProgramasSST/CreateEvidencia" },
                    { 425, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar evidencias", null, null, 5.14f, false, "Eliminar evidencia", "/ProgramasSST/DeleteEvidencia" },
                    { 426, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Consultar evaluaciones Local y JDA", null, null, 5.04f, true, "Evaluaciones", "/ProgramasSST/IndexEvaluacion" },
                    { 427, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear evaluación", null, null, 5.16f, false, "Crear evaluación ", "/ProgramasSST/CreateEvaluacion" },
                    { 428, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar evaluación", null, null, 5.17f, false, "Eliminar evaluación", "/ProgramasSST/DeleteEvaluacion" },
                    { 429, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Consultar evaluaciones RSN y RSR", null, null, 5.04f, true, "Evaluaciones", "/ProgramasSST/IndexEvaluacionRN" },
                    { 430, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST", null, null, 5.19f, false, "Obtener evaluaciones RN", "/ProgramasSST/GetEvaluacionesRN" },
                    { 431, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST", null, null, 5.2f, false, "Recargar evaluaciones RN", "/ProgramasSST/ReloadEvaluacionesRN" },
                    { 433, true, "Gestion", "fas fa-project-diagram", "Gestión de seguridad", "Programas SST", "Programas SST Programa Regional", null, null, 5.02f, true, "Programa", "/ProgramasSST/IndexProgramaRegional" },
                    { 377, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Crear Area", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/CreateArea" },
                    { 376, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Eliminar", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/Delete" },
                    { 375, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Detalles", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/Details" },
                    { 316, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador RGA Editar", null, null, 10f, false, "Editar indicador RGA", "/Patrones/EditRedGeneralAgua" },
                    { 317, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador ASE Consultar", null, null, 10f, false, "Consultar ponderación ASE", "/Patrones/IndexAreaSistemaEquipo" },
                    { 318, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador ASE Detalle", null, null, 10f, false, "Detalle indicador ASE", "/Patrones/DetailsAreaSistemaEquipo" },
                    { 319, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador ASE Editar", null, null, 10f, false, "Editar indicador ASE", "/Patrones/EditAreaSistemaEquipo" },
                    { 320, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Sistemas contra incendios Detalle", null, null, 10f, false, "Detalle sistemas contra incendio", "/Protecciones/DetailsInstalacionBandeja" },
                    { 321, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Sistemas contra incendios Editar", null, null, 10f, false, "Editar sistemas contra incendio", "/Protecciones/EditASExEvaluacion" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 322, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas de Detección Detalle", null, null, 10f, false, "Detalle sistemas detección", "/Protecciones/DetailsEditSistemasDeteccion" },
                    { 323, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas de Detección Editar", null, null, 10f, false, "Editar sistemas detección", "/Protecciones/EditSistemasDeteccion" },
                    { 324, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas de Detección Eliminar", null, null, 10f, false, "Eliminar sistemas detección", "/Protecciones/DeleteSistemasDeteccion" },
                    { 325, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas Fijos de Extinción Detalle", null, null, 10f, false, "Detalle sistemas fijos", "/Protecciones/DetailsEditSistemasFijosExtincion" },
                    { 326, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas Fijos de Extinción Editar", null, null, 10f, false, "Editar sistemas fijos", "/Protecciones/EditSistemasFijosExtincion" },
                    { 327, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Sistemas Fijos de Extinción Eliminar", null, null, 10f, false, "Eliminar sistemas fijos", "/Protecciones/DeleteSistemasFijosExtincion" },
                    { 328, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Equipos Fijos de Extinción Detalle", null, null, 10f, false, "Detalle equipos fijos", "/Protecciones/DetailsEditEquiposFijosExtincion" },
                    { 329, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Equipos Fijos de Extinción Editar", null, null, 10f, false, "Editar equipos fijos", "/Protecciones/EditEquiposFijosExtincion" },
                    { 330, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Equipos Fijos de Extinción Eliminar", null, null, 10f, false, "Eliminar equipos fijos", "/Protecciones/DeleteEquiposFijosExtincion" },
                    { 315, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador RGA Detalle", null, null, 10f, false, "Detalle indicador RGA", "/Patrones/DetailsRedGeneralAgua" },
                    { 331, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Hidrantes Detalle", null, null, 10f, false, "Detalle hidrantes", "/Protecciones/DetailsEditHidrantesProtecciones" },
                    { 314, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Ponderación Indicador RGA Consultar", null, null, 10f, false, "Consultar ponderación RGA", "/Patrones/IndexRedGeneralAgua" },
                    { 312, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Informe", null, null, 10f, false, "Generar informe", "/Evaluacion/DiagnosticoPDF" },
                    { 297, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones Local Nombre Editar", null, null, 10f, false, "Editar nombre de instalación", "/ConfiguracionLocal/EditNombre" },
                    { 298, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones Local Eliminar", null, null, 10f, false, "Eliminar instalación", "/ConfiguracionLocal/EliminarASEProteger" },
                    { 299, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Unidades de generación Detalle", null, null, 10f, false, "Detalle unidades de generación", "/ConfiguracionLocal/DetailsUnidadesGeneracion" },
                    { 300, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Unidades de generación Editar", null, null, 10f, false, "Editar unidades de generación", "/ConfiguracionLocal/EditUnidadesGeneracion" },
                    { 301, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Unidades de generación Eliminar", null, null, 10f, false, "Eliminar unidades de generación", "/ConfiguracionLocal/DeleteUnidadesGeneracion" },
                    { 302, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones-Centros de trabajo Detalle", null, null, 10f, false, "Detalle instalaciones - centro trabajo", "/ConfiguracionRegional/Details" },
                    { 303, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones-Centros de trabajo Editar", null, null, 10f, false, "Editar instalaciones -centro trabajo", "/ConfiguracionRegional/EditCentroTrabajo" },
                    { 304, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones-Centros de trabajo Instalación Editar", null, null, 10f, false, "Editar instalación", "/ConfiguracionRegional/EditInstalacion" },
                    { 305, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones-Centros de trabajo Instalación Eliminar", null, null, 10f, false, "Eliminar instalación", "/ConfiguracionRegional/DeleteInstalacion" },
                    { 306, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Detalle", null, null, 10f, false, "Detalle diagnóstico", "/Evaluacion/Details" },
                    { 307, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Eliminar", null, null, 10f, false, "Eliminar diagnóstico", "/Evaluacion/Delete" },
                    { 308, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Editar", null, null, 10f, false, "Editar diagnóstico", "/Evaluacion/Edit" },
                    { 309, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diganóstico Colaboradores Detalle", null, null, 10f, false, "Detalle colaboradores", "/Evaluacion/DetailsColaboradores/" },
                    { 310, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Colaboradores Editar", null, null, 10f, false, "Editar colaboradores", "/Evaluacion/EditColaboradores/" },
                    { 311, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Cambio estado", null, null, 10f, false, "Cambia estado diagnóstico", "/Evaluacion/CambioEstado" },
                    { 313, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Diagnóstico Copiar", null, null, 10f, false, "Copiar diagnóstico", "/Evaluacion/Copiar" },
                    { 332, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Hidrantes Editar", null, null, 10f, false, "Editar hidrantes", "/Protecciones/EditHidrantesProtecciones" },
                    { 333, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Hidrantes Eliminar", null, null, 10f, false, "Eliminar hidrantes", "/Protecciones/DeleteHidrantesProtecciones" },
                    { 334, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Móviles Detalle", null, null, 10f, false, "Detalle protecciones móviles", "/Protecciones/DetailsEditSistemasMoviles" },
                    { 355, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Cumplimiento Nivel Riesgo", null, null, 0f, false, "Cumplimiento Nivel Riesgo", "/Expediente/CumplimientoNivelRiesgo" },
                    { 356, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Nivel Riesgo", null, null, 0f, false, "Set NivelRiesgo", "/Expediente/SetNivelRiesgo" },
                    { 357, true, "Gestion", "fas fa-user-friends", "Gestión de seguridad", "Cambio de responsables", "Identificación de Peligros Cambio de Responsables Consulta", null, null, 11.1f, true, "Identificación de peligros", "/IdenPeligros/CambiarResponsables" },
                    { 358, true, "Gestion", "fas fa-user-friends", "Gestión de seguridad", "Cambio de responsables", "Evaluación de Riesgo Grupal Cambio de responsables Consulta", null, null, 11.2f, true, "Evaluación riesgo grupal", "/EvaluacionRiesgoGrupal/CambiarResponsables" },
                    { 359, true, "Gestion", "fas fa-user-friends", "Gestión de seguridad", "Cambio de responsables", "Tareas Críticas Cambio de Responsables Consulta", null, null, 11.3f, true, "Tareas críticas", "/TareasCriticas/CambiarResponsables" },
                    { 363, true, "Gestion", "fas fa-file-signature", "Gestión de seguridad", "Consultas ejecutivas", "Identificación de Peligros Consulta Ejecutiva Consulta", null, null, 13.2f, true, "Identificación de peligros", "/ConsultaEjecutiva/IdenPeligros" },
                    { 364, true, "Gestion", "fas fa-file-signature", "Gestión de seguridad", "Consultas ejecutivas", "Evaluación de Riesgo Grupal Consulta Ejecutiva Consulta", null, null, 13.3f, true, "Evaluación riesgo grupal", "/ConsultaEjecutiva/EGR" },
                    { 365, true, "Gestion", "fas fa-file-signature", "Gestión de seguridad", "Consultas ejecutivas", "Tareas Críticas Consulta Ejecutiva Consulta", null, null, 13.4f, true, "Tareas críticas", "/ConsultaEjecutiva/TareasCriticas" },
                    { 368, true, "Gestion", "fa-file-invoice", "Gestión de seguridad", "", "Correcciones SST Consulta Regional", null, null, 1f, true, "Correcciones de SST", "/Formato13/Index?regional=true" },
                    { 369, true, "Gestion", "fa-file-invoice", "Gestión de seguridad", "", "Correcciones SST Consulta Nacional", null, null, 1f, true, "Correcciones de SST", "/Formato13/Index?nacional=true" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 370, true, "Gestion", "fa fa-search", "Gestión de seguridad", "Consultas ejecutivas", "Correcciones SST Consulta Ejecutiva", null, null, 13.1f, true, "Correcciones SST", "/ConsultaEjecutiva/F13" },
                    { 371, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Detalles Norma", null, null, 0f, false, "Detalle Norma PDF", "/EvaluacionExpediente/DetalleNormaPdf" },
                    { 372, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Consulta Normativa", null, null, 3.1f, true, "Consulta normativa", "/Norma/ConsultaNormativa" },
                    { 373, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Lista", null, null, 3.7f, true, "Agrega Requisitos", "/AgregaRequisitos/Index" },
                    { 374, true, "GestionRL", "", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Agregar Nuevos Requisitos Crear", null, null, 3.7f, false, "Agrega Requisitos", "/AgregaRequisitos/Create" },
                    { 354, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Hidrantes Editar", null, null, 10f, false, "Editar hidrantes", "/RedAgua/DetailsEditHidrantes" },
                    { 353, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Válvulas Seccionadoras Editar", null, null, 10f, false, "Editar válvulas seccionadoras", "/RedAgua/DetailsEditValvulasSeccionadoras" },
                    { 352, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Red de Tuberías Editar", null, null, 10f, false, "Editar red de tuberías", "/RedAgua/DetailsEditTuberias" },
                    { 351, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Sistema de Bombas Editar", null, null, 10f, false, "Editar sistema de bombas", "/RedAgua/DetailsEditGeneradorPresion" },
                    { 335, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Móviles Editar", null, null, 10f, false, "Editar protecciones móviles", "/Protecciones/EditSistemasMoviles" },
                    { 336, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Móviles Eliminar", null, null, 10f, false, "Eliminar protecciones móviles", "/Protecciones/DeleteSistemasMoviles" },
                    { 337, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Pasivas Detalle", null, null, 10f, false, "Detalle protecciones pasivas", "/Protecciones/DetailsEditProteccionesPasivas" },
                    { 338, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Pasivas Editar", null, null, 10f, false, "Editar protecciones pasivas", "/Protecciones/EditProteccionesPasivas" },
                    { 339, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Protecciones Pasivas Eliminar", null, null, 10f, false, "Eliminar protecciones pasivas", "/Protecciones/DeleteProteccionesPasivas" },
                    { 340, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Recomendaciones Detalle", null, null, 10f, false, "Detalle recomendaciones", "/Protecciones/DetailsEditRecomendaciones" },
                    { 341, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Recomendaciones Editar", null, null, 10f, false, "Editar recomendaciones", "/Protecciones/EditRecomendaciones" },
                    { 451, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Consultas ejecutivas", "Proyectos de Seguridad Consultar Ejecutiva Ranking", null, null, 1.06f, true, "Ranking", "/ProyectosSeguridad/IndexConsultaRanking" },
                    { 342, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Recomendaciones Eliminar", null, null, 10f, false, "Eliminar recomendaciones", "/Protecciones/DeleteRecomendaciones" },
                    { 344, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Acciones Periódicas Editar", null, null, 10f, false, "Editar acciones periódicas", "/Protecciones/EditAccionesPeriodicas" },
                    { 345, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Acciones Periódicas Eliminar", null, null, 10f, false, "Eliminar acciones periódicas", "/Protecciones/DeleteAccionesPeriodicas" },
                    { 346, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Red General de Agua Detalle", null, null, 10f, false, "Detalle red general de agua", "/RedAgua/EditRedAgua" },
                    { 347, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Fuente de Abastecimiento Editar", null, null, 10f, false, "Editar fuente de abastecimiento", "/RedAgua/EditFuenteAbastecimiento" },
                    { 348, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Fuente de Abastecimiento Eliminar", null, null, 10f, false, "Eliminar fuente de abastecimiento", "/RedAgua/DeleteFuenteAbastecimiento" },
                    { 349, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Sistema de Bombeo Editar", null, null, 10f, false, "Editar sistema de bombeo", "/RedAgua/DetailsEditSistemaBombeo" },
                    { 350, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Sistema de Bombeo Eliminar", null, null, 10f, false, "Eliminar sistema de bombeo", "/RedAgua/DeleteSistemaBombeo" },
                    { 343, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios SCI Acciones Periódicas Detalle", null, null, 10f, false, "Detalles acciones periódicas", "/Protecciones/DetailsEditAccionesPeriodicas" },
                    { 452, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Consultas ejecutivas", "Proyectos de Seguridad Consultar Ejecutiva Origen", null, null, 1.07f, true, "Origen", "/ProyectosSeguridad/IndexConsultaOrigen" },
                    { 453, true, "Proyectos", "fas fa-shield-alt", "Proyectos de Seguridad", "Consultas ejecutivas", "Proyectos de Seguridad Consultar Ejecutiva Eliminados", null, null, 1.08f, true, "Proyectos eliminados", "/ProyectosSeguridad/IndexConsultaEliminados" },
                    { 454, true, "GestionUI", "fas fa-shield-alt", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Consultar solicitudes del CT", null, null, 1.01f, true, "Solicitudes de evaluación", "/Solicitud/Index" },
                    { 551, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Consulta simple", null, null, 0f, false, "Detalle simple de expediente", "/ExpedienteUI/DetailsSimple" },
                    { 552, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Aprobador Expediente", null, null, 0f, false, "Establecer aprobador", "/ExpedienteUI/AprobadorExpediente" },
                    { 553, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Enviar Revision", null, null, 0f, false, "Enviar expediente a revisiiójn", "/ExpedienteUI/EnviarRevision" },
                    { 554, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Aprobar ", null, null, 0f, false, "Aprobar expediente", "/ExpedienteUI/Aprobar" },
                    { 555, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Rechazar", null, null, 0f, false, "Rechazar expediente", "/ExpedienteUI/Rechazar" },
                    { 556, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Iniciar servicio", null, null, 0f, false, "Iniciar servicio de evaluación por parte del verificador", "/Servicio/IniciaServicio" },
                    { 557, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Recupera Bitacora", null, null, 0f, false, "Recupera la bitácora del expediente", "/ExpedienteUI/GetDatosBitacora" },
                    { 558, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Consultar desempeño", null, null, 6.01f, true, "Desempeño", "/Medicion/IndexDesempenio" },
                    { 559, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Consultar desempeño RN", null, null, 6.02f, true, "Desempeño", "/Medicion/IndexDesempenioRN" },
                    { 560, true, "Gestion", "fa-solid fa-fire-extinguisher", "Gestión de seguridad", "", "Simulacros Index simulacros", null, null, 1f, true, "Simulacros", "/Simulacros/Index" },
                    { 561, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Detalle del simulacro", null, null, 0f, false, "Detalle del Simulacro", "/Simulacros/Details" },
                    { 562, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Crear Simulacro", null, null, 0f, false, "Crear Simulacro", "/Simulacros/Create" },
                    { 563, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Editar Simulacro", null, null, 0f, false, "Editar Simulacro", "/Simulacros/Edit" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 564, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Borrar Simulacro", null, null, 0f, false, "Borrar Simulacros", "/Simulacros/Delete" },
                    { 565, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Crear Reporte Ejecutivo", null, null, 0f, false, "Crear Reporte Ejecutivo", "/Simulacros/CreateReporte" },
                    { 550, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Lista de Archivo de Evidencia disponibles", null, null, 0f, false, "Lista de evidencias disponibles", "/ExpedienteUI/ListaArchivoEvidenciaDisponibles" },
                    { 566, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Editar Reporte Ejecutivo", null, null, 0f, false, "Editar Reporte Ejecutivo", "/Simulacros/EditReporte" },
                    { 549, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Elimina de Archivo de Evidencia Compartida", null, null, 0f, false, "Eliminar evidencia compartida", "/ExpedienteUI/DeleteEvidenciaCompartida" },
                    { 547, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Archivo de Evidencia Compartida", null, null, 0f, false, "Agregar evidencia compartida", "/ExpedienteUI/ArchivoEvidenciaCompartida" },
                    { 532, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guarda elemento prototipo", null, null, 5.85f, false, "Guarda elemento prototipo", "/ProgramasSST/GuardaElementoPrototipo" },
                    { 533, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guarda programa prototipo", null, null, 5.86f, false, "Guarda programa prototipo", "/ProgramasSST/GuardaProgramaPrototipo" },
                    { 534, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guarda actividad prototipo", null, null, 5.87f, false, "Guarda actividad prototipo", "/ProgramasSST/GuardaActividadPrototipo" },
                    { 535, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Elimina elemento prototipo", null, null, 5.88f, false, "Elimina elemento prototipo", "/ProgramasSST/EliminaElementoPrototipo " },
                    { 536, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Elimina actividad prototipo", null, null, 5.89f, false, "Elimina actividad prototipo", "/ProgramasSST/EliminaActividadPrototipo" },
                    { 537, true, "GestionUI", "fas fa-shield-alt", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Lista Por CT", null, null, 1f, true, "Lista de expedientes del CT", "/ExpedienteUI/Index" },
                    { 538, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Consulta", null, null, 0f, false, "Consulta de expediente del CT", "/ExpedienteUI/Details" },
                    { 539, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Actualiza Cumplimiento", null, null, 0f, false, "Actualiza cumplimiento", "/ExpedienteUI/CumplimientoRequisito" },
                    { 540, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Ayuda Requisito Aplicable", null, null, 0f, false, "Ayuda de requisito legal", "/ExpedienteUI/CumplimientoAyuda" },
                    { 541, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Archivo de Evidencia", null, null, 0f, false, "Adjuntar evidencia de requisito aplicable", "/ExpedienteUI/ArchivoEvidencia" },
                    { 542, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Abrir archivo de evidencia", null, null, 0f, false, "Abrir evidencia de requisito aplicable", "/ExpedienteUI/OpenFile" },
                    { 543, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Lista de Archivo de Evidencia", null, null, 0f, false, "Lista de Archivos de evidencia", "/ExpedienteUI/ListaArchivoEvidencia" },
                    { 544, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Descargar Archivo de Evidencia", null, null, 0f, false, "Descarga de archivo de evidencia", "/ExpedienteUI/DownloadFile" },
                    { 545, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Eliminar Archivo de Evidencia", null, null, 0f, false, "Eliminar archivo de evidencia", "/ExpedienteUI/DeleteUploadedFile" },
                    { 546, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Detalle por Norma", null, null, 0f, false, "Detalle de requisitos por Norma", "/ExpedienteUI/DetalleExpedienteNorma" },
                    { 548, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Expediente Lista de Archivo de Evidencia", null, null, 0f, false, "Lista evidencias compartidas", "/ExpedienteUI/ListaArchivoEvidenciaCompartida" },
                    { 531, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Elimina elemento prototipo recurso", null, null, 5.84f, false, "Elimina elemento prototipo recurso", "/ProgramasSST/EliminaElementoPrototipoRecurso" },
                    { 567, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Borrar Reporte Ejecutivo", null, null, 0f, false, "Borrar Reporte Ejecutivo", "/Simulacros/DeleteReporte" },
                    { 569, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Crear Documento", null, null, 0f, false, "Crear Documentos Simulacro", "/Simulacros/CreateDocumentos" },
                    { 589, true, "Gestion", "", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Editar Valor satisfactorio", null, null, 6.13f, false, "Modificar valor satisfactorio", "/Medicion/UpdateCreateValorSatisfactorio" },
                    { 590, true, "Gestion", "", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Editar Indicador real", null, null, 6.14f, false, "Modificar indicador", "/Medicion/UpdateCreateIndicador" },
                    { 591, true, "Gestion", "", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Editar Fuerza de trabajo", null, null, 6.15f, false, "Modificar fuerza de trabajo", "/Medicion/UpdateCreateFuerzaTrabajo" },
                    { 592, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Consultar Indicador real", null, null, 6.16f, true, "Indicador", "/Medicion/IndexIndicador" },
                    { 593, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI modificar ficha técnica", null, null, 0f, false, "Modificar ficha técnica", "/Componente/EditFichaTecnica" },
                    { 594, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Evaluar requisito", null, null, 0f, false, "Evaluar requisito de expediente de componente", "/ExpedienteUI/EvaluaRequisito" },
                    { 595, true, "Gestion", "fa-solid fa-eye", "Gestión de Seguridad", "", "Observacion de Tareas Index", null, null, 1f, true, "Observación de tareas", "/ObservacionTareas/Index" },
                    { 596, true, "Gestion", "fas fa-chalkboard-teacher", "Gestión de Seguridad", "", "Gestión Lista Reuniones de Difusión", null, null, 7f, true, "Reuniones de difusión", "/Difusion/Index" },
                    { 597, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Detalle Reuniones de Difusión", null, null, 0f, false, "Detalle Reunión Difusión", "/Difusion/Details" },
                    { 598, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Crear Reuniones de Difusión", null, null, 0f, false, "Crear Reunión Difusión", "/Difusion/Create" },
                    { 599, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Editar Reuniones de Difusión", null, null, 0f, false, "Editar Reunión Difusión", "/Difusion/Edit" },
                    { 600, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Eliminar Reuniones de Difusión", null, null, 0f, false, "Eliminar Reunión Difusión", "/Difusion/Delete" },
                    { 601, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Lista Documentos Reuniones de Difusión", null, null, 0f, false, "Documentos Reunión Difusión", "/DocumentosDifusion/Index" },
                    { 602, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Crear Documentos Reuniones de Difusión", null, null, 0f, false, "Crear Documento Reunión Difusión", "/DocumentosDifusion/Create" },
                    { 603, true, "Gestion", "", "Gestión de Seguridad", "", "Gestión Eliminar Documentos Reuniones de Difusión", null, null, 0f, false, "Eliminar Reunión Difusión", "/DocumentosDifusion/Delete" },
                    { 588, true, "Gestion", "", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Editar Metas", null, null, 6.12f, false, "Modificar metas", "/Medicion/UpdateCreateMeta" },
                    { 568, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Index Documentos", null, null, 0f, false, "Index Documentos Simulacro", "/Simulacros/IndexDocumentos" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 587, true, "Gestion", "", "Gestión de Seguridad", "Medición y vigilancia", "Medición y vigilancia Editar Desempeño", null, null, 6.11f, false, "Modificar desempeño", "/Medicion/UpdateCreateDesempenio" },
                    { 585, true, "GestionUI", "fas fa-shield-alt", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Consultar unidad de verificación", null, null, 2.02f, true, "Unidades de verificación", "/UnidadVerificacion/Index" },
                    { 570, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Guardar Documento", null, null, 0f, false, "Guardar Documento Simulacro", "/Simulacros/DocumentosSave" },
                    { 571, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Descargar Archivo", null, null, 0f, false, "Download Archivo Simulacro", "/Simulacros/DownloadFile" },
                    { 572, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Abrir Archivo", null, null, 0f, false, "Abrir Archivo Simulacro", "/Simulacros/OpenFile" },
                    { 573, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Obtener Thumbnail Image", null, null, 0f, false, "Obtener Thumbnail Image", "/Simulacros/GetThumbnailImage" },
                    { 574, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Obtener Thumbnail ImagePdf", null, null, 0f, false, "Obtener Thumbnail ImagePdf", "/Simulacros/GetThumbnailImagePdf" },
                    { 575, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Borrar Archivo", null, null, 0f, false, "Borrar Archivo Simulacro", "/Simulacros/DeleteArchivo" },
                    { 576, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Reporte PDF Simulacro", null, null, 0f, false, "Reporte PDF Simulacro", "/Simulacros/ReporteSimulacro" },
                    { 577, true, "Gestion", "", "Gestión de seguridad", "Consultas ejecutivas", "Simulacros Consulta Ejecutiva Consultar Simulacros", null, null, 13.8f, true, "Simulacros", "/ConsultaEjecutiva/Simulacros" },
                    { 578, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Consulta Ejecutiva Obtener Simulacros", null, null, 0f, false, "Consulta Ejecutiva Obtener Simulacros", "/ConsultaEjecutiva/GetAllConsultaSimulacros" },
                    { 579, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Consulta Ejectuvia Detalles del Simulacro", null, null, 0f, false, "Consulta Ejecutiva Detalle del Simulacro", "/ConsultaEjecutiva/DetailsSimulacro" },
                    { 580, true, "Gestion", "", "Gestión de seguridad", "", "Simulacros Consulta Ejecutiva Cargar Simulacro", null, null, 0f, false, "Consulta Ejecutiva Cargar Simulacro", "/ConsultaEjecutiva/LoadConsultaSimulacro" },
                    { 581, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Nueva unidad de verificación", null, null, 0f, false, "Nueva unidad de verificación", "/UnidadVerificacion/Create" },
                    { 582, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI modificar unidad de verificación", null, null, 0f, false, "Modificar unidad de verificación", "/UnidadVerificacion/Edit" },
                    { 583, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI consultar unidad de verificación", null, null, 0f, false, "Consultar unidad de verificación", "/UnidadVerificacion/Details" },
                    { 584, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI eliminar unidad de verificación", null, null, 0f, false, "Eliminar unidad de verificación", "/UnidadVerificacion/Delete" },
                    { 586, true, "Gestion", "", "Gestión de Seguridad", "", "Progamas SST Elementos catálogos (CSH)", null, null, 5.4f, false, "Catálogos CSH", "/Gestion/ProgramasSST/GetItemsCatalogo" },
                    { 530, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guarda elemento prototipo recurso", null, null, 5.83f, false, "Guarda elemento prototipo recurso", "/ProgramasSST/GuardaElementoPrototipoRecurso" },
                    { 529, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar elemento prototipo recursos", null, null, 5.82f, false, "Guardar elemento prototipo recursos", "/ProgramasSST/GuardaElementoPrototipoRecursos" },
                    { 528, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner borrador prog prototipo", null, null, 5.81f, false, "Poner borrador prog prototipo", "/ProgramasSST/SetBorradorProgramaPrototipo" },
                    { 474, true, "Laboratorio", "", "Laboratorio", "", "Detalle Servicio  de Laboratorio", null, null, 0f, false, "Detalle Servicio", "/Servicio/Details" },
                    { 475, true, "Laboratorio", "fas fa-book", "Laboratorio", "", "Lista de Encuestas de Laboratorio", null, null, 2f, true, "Encuestas", "/Encuesta/Index" },
                    { 476, true, "Laboratorio", "", "Laboratorio", "", "Detalle de Encuesta de Laboratorio", null, null, 0f, false, "Detalle de Encuesta", "/Encuesta/Details" },
                    { 477, true, "Laboratorio", "", "Laboratorio", "", "Responder Encuesta de Laboratorio", null, null, 0f, false, "Responder Encuesta", "/Encuesta/Answer" },
                    { 478, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Editar acta", null, null, 5.31f, false, "Editar acta", "/ProgramasSST/EditActa" },
                    { 479, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear acta", null, null, 5.32f, false, "Crear acta", "/ProgramasSST/CreateActa" },
                    { 480, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Iniciar Correccion SST", null, null, 5.33f, false, "Iniciar Correccion SST", "/ProgramasSST/InicializarCorreccionSST" },
                    { 481, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Cambiar estado el Acta (regresar a incompleta)", null, null, 5.34f, false, "Cambiar estado acta", "/Gestion/ProgramasSST/CambiarEstadoActa" },
                    { 482, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Index programas", null, null, 5.35f, false, "Index programas", "/ProgramasSST/Index" },
                    { 483, true, "Gestion", "fas fa-project-diagram", "Gestión de Seguridad", "Programas SST", "Programas SST Consultar informes", null, null, 5.36f, true, "Informes", "/ProgramasSST/IndexReportes" },
                    { 484, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y Vigilancia Consultar Metas", null, null, 6.03f, true, "Metas", "/Medicion/IndexMetas" },
                    { 485, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y Vigilancia Consultar Valores satisfacción", null, null, 6.04f, true, "Valores satisfacción", "/Medicion/IndexValorSatisfactorio" },
                    { 486, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y Vigilancia Consultar Fuerza de trabajo", null, null, 6.05f, true, "Fuerza de trabajo", "/Medicion/IndexFuerzaTrabajo" },
                    { 487, true, "Gestion", "far fa-chart-bar", "Gestión de Seguridad", "Medición y vigilancia", "Medición y Vigilancia Calcular Desempeño", null, null, 6.06f, true, "Calculo desempeño", "/Medicion/IndexDesempenioAdmin" },
                    { 488, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Programa ¿?", null, null, 5.41f, false, "Programa ¿?", "/ProgramasSST/Programa" },
                    { 473, true, "Laboratorio", "", "Laboratorio", "", "Editar Servicio  de Laboratorio", null, null, 0f, false, "Editar Servicio", "/Servicio/Edit" },
                    { 489, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Programa Json ¿?", null, null, 5.42f, false, "Programa Json ¿?", "/ProgramasSST/ProgramaJson" },
                    { 472, true, "Laboratorio", "", "Laboratorio", "", "Crear Servicio de Laboratorio", null, null, 0f, false, "Crear Servicio", "/Servicio/Create" },
                    { 470, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI eliminar componente del CT", null, null, 0f, false, "Eliminar componente", "/Componente/Delete" },
                    { 455, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Nueva solicitud de evaluación del CT", null, null, 0f, false, "Nueva solicitud de evaluación", "/Solicitud/Create" },
                    { 456, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI modificar solicitud de evaluación del CT", null, null, 0f, false, "Modificar solicitudes de evaluación", "/Solicitud/Edit" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 457, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI consultar solicitud del CT", null, null, 0f, false, "Consultar solicitudes de evaluación", "/Solicitud/Details" },
                    { 458, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI eliminar solicitud del CT", null, null, 0f, false, "Eliminar solicitud de evaluación", "/Solicitud/Delete" },
                    { 459, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Obtener Componentes para la solicitud de evaluación del CT", null, null, 0f, false, "Obtener componentes para la solicitud de evaluación", "/Solicitud/GetComponentes" },
                    { 460, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI descargar archivo del oficio de solicitud", null, null, 0f, false, "Descargar archivo del oficio de solicitud de evaluación", "/Solicitud/DownloadFile" },
                    { 461, true, "GestionUI", "fas fa-shield-alt", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Lista de solicitudes de verificación para perfiles de la UI", null, null, 1f, true, "Solicitudes de evaluación", "/Solicitud/IndexUI" },
                    { 462, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Crear servicio de evaluación", null, null, 0f, false, "Crear servicio de evaluación", "/Solicitud/CreateServicio" },
                    { 463, true, "GestionUI", "fas fa-shield-alt", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Lista de servicios de evaluación para la UI", null, null, 1f, true, "Servicios de evaluación", "/Servicio/IndexUI" },
                    { 464, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Consultar servicio para la UI", null, null, 0f, false, "Consultar servicio para la UI", "/Servicio/DetailsUI" },
                    { 465, true, "GestionUI", "", "Gestión de Seguridad", "Evaluación UI", "Evaluación UI Consultar solicitud para la UI", null, null, 0f, false, "Consultar solicitud para la UI", "/Solicitud/DetailsUI" },
                    { 466, true, "GestionUI", "fas fa-shield-alt", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Consultar componentes del CT", null, null, 2.01f, true, "Catálogo de componentes", "/Componente/Index" },
                    { 467, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI Nuevo componente del CT", null, null, 0f, false, "Nuevo componente", "/Componente/Create" },
                    { 468, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI modificar componenten del CT", null, null, 0f, false, "Modificar componenten", "/Componente/Edit" },
                    { 469, true, "GestionUI", "", "Gestión de seguridad", "Evaluación UI", "Evaluación UI consultar componente del CT", null, null, 0f, false, "Consultar componente", "/Componente/Details" },
                    { 471, true, "Laboratorio", "fas fa-clipboard-list", "Laboratorio", "", "Lista de Servicios de Laboratorio", null, null, 1f, true, "Servicios", "/Servicio/Index" },
                    { 490, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener Programa API", null, null, 5.43f, false, "Obtener Programa API", "/ProgramasSST/GetProgramaAPI" },
                    { 491, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar Programa API", null, null, 5.44f, false, "Guardar Programa API", "/ProgramasSST/SaveProgramaJsonAPI" },
                    { 492, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Consultar evidencias", null, null, 5.45f, false, "Consultar evidencias", "/ProgramasSST/ListEvidencias" },
                    { 513, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar elemento", null, null, 5.66f, false, "Guardar elemento", "/ProgramasSST/GuardaElemento" },
                    { 514, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar programa", null, null, 5.67f, false, "Guardar programa", "/ProgramasSST/GuardaPrograma" },
                    { 515, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar actividad", null, null, 5.68f, false, "Guardar actividad", "/ProgramasSST/GuardaActividad" },
                    { 516, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar mes semana", null, null, 5.69f, false, "Guardar mes semana", "/ProgramasSST/GuardaMesSemana" },
                    { 517, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar elemento  ", null, null, 5.7f, false, "Eliminar elemento  ", "/ProgramasSST/EliminaElemento" },
                    { 518, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar actividad", null, null, 5.71f, false, "Eliminar actividad", "/ProgramasSST/EliminaActividad" },
                    { 519, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar elementos recursos", null, null, 5.72f, false, "Guardar elementos recursos", "/ProgramasSST/GuardaElementosRecursos" },
                    { 520, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar elemento recursos", null, null, 5.73f, false, "Guardar elemento recursos", "/ProgramasSST/GuardaElementoRecursos" },
                    { 521, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Elimina elementos recursos", null, null, 5.74f, false, "Elimina elementos recursos", "/ProgramasSST/EliminaElementosRecursos" },
                    { 522, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar programa prototipo", null, null, 5.75f, false, "Guardar programa prototipo", "/ProgramasSST/SaveProgramaPrototipo" },
                    { 523, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener programa prototipo", null, null, 5.76f, false, "Obtener programa prototipo", "/ProgramasSST/GetprogramaPrototipo" },
                    { 524, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Editar gantt prototipo", null, null, 5.77f, false, "Editar gantt prototipo", "/ProgramasSST/EditGanttPrototipo" },
                    { 525, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener prog prot gantt", null, null, 5.78f, false, "Obtener prog prot gantt", "/ProgramasSST/GetProgramaPrototipoGantt" },
                    { 526, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar actualizar prog prototipo", null, null, 5.79f, false, "Guardar actualizar prog prototipo", "/ProgramasSST/SaveUpdateProgramaPrototipo" },
                    { 527, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner vigente prog prototipo", null, null, 5.8f, false, "Poner vigente prog prototipo", "/ProgramasSST/SetVigenteProgramaPrototipo" },
                    { 512, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner programa sustituido", null, null, 5.65f, false, "Poner programa sustituido", "/ProgramasSST/SetSustituidoPrograma" },
                    { 511, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Reiniciar programa borrador", null, null, 5.64f, false, "Reiniciar programa borrador", "/ProgramasSST/ResetToBorradorPrograma" },
                    { 510, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner programa borrador", null, null, 5.63f, false, "Poner programa borrador", "/ProgramasSST/SetBorradorPrograma" },
                    { 509, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner programa vigente", null, null, 5.62f, false, "Poner programa vigente", "/ProgramasSST/SetVigentePrograma" },
                    { 493, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar evidencias", null, null, 5.46f, false, "Guardar evidencias", "/ProgramasSST/SaveEvidencias" },
                    { 494, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Descargar evidencia", null, null, 5.47f, false, "Descargar evidencia", "/ProgramasSST/DownloadEvidencia" },
                    { 495, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Abrir evidencia", null, null, 5.48f, false, "Abrir evidencia", "/ProgramasSST/OpenEvidencia" },
                    { 496, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener  thumbnail imagen", null, null, 5.49f, false, "Obtener  thumbnail imagen", "/ProgramasSST/GetThumbnailImage" },
                    { 497, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Consultar progrma prototipo distribución", null, null, 5.5f, false, "Consultar progrma prototipo distribución", "/ProgramasSST/ListaPrototipoDistribucion" },
                    { 498, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear programa distribución", null, null, 5.51f, false, "Crear programa distribución", "/ProgramasSST/CreateProgramaDistribucion" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 499, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar Programa", null, null, 5.52f, false, "Guardar Programa", "/ProgramasSST/Saveprograma" },
                    { 296, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones Local Número Editar", null, null, 10f, false, "Editar número de instalaciones", "/ConfiguracionLocal/EditNumero" },
                    { 500, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Obtener Programa", null, null, 5.53f, false, "Obtener Programa", "/ProgramasSST/GetPrograma" },
                    { 502, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Actualizar gantt", null, null, 5.55f, false, "Actualizar gantt", "/ProgramasSST/UpdatePrograma" },
                    { 503, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Guardar gantt", null, null, 5.56f, false, "Guardar gantt", "/ProgramasSST/SaveUpdatePrograma" },
                    { 504, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar programa", null, null, 5.57f, false, "Eliminar programa", "/ProgramasSST/DeletePrograma" },
                    { 505, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Eliminar programa gantt", null, null, 5.58f, false, "Eliminar programa gantt", "/ProgramasSST/GetProgramaGantt" },
                    { 506, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Editar gantt", null, null, 5.59f, false, "Editar gantt", "/ProgramasSST/EditGantt" },
                    { 507, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner programa pendiente", null, null, 5.6f, false, "Poner programa pendiente", "/ProgramasSST/SetPendienteRevisionPrograma" },
                    { 508, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Poner programa aprobación", null, null, 5.61f, false, "Poner programa aprobación", "/ProgramasSST/SetPendienteAprobacionPrograma" },
                    { 501, true, "Gestion", "", "Gestión de Seguridad", "", "Programas SST Crear gantt", null, null, 5.54f, false, "Crear gantt", "/ProgramasSST/CreateGantt" },
                    { 295, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones Local Editar", null, null, 10f, false, "Editar instalación", "/ConfiguracionLocal/Edit" },
                    { 605, true, "GestionUI", "", "Gestión de Seguridad", "", "Evaluación UI modificar dictamen", null, null, 0f, false, "Modificar dictamen", "/Dictamen/Edit" },
                    { 293, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Áreas - Tipo instalación SCI Editar", null, null, 10f, false, "Editar área - sistema contra incendio", "/ConfiguracionAdministrador/EditRelacionASExSCI" },
                    { 94, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Detalle", null, null, 0f, false, "Incidentes con Lesión a Personal Contratista", "/Incidentes/IncidenteContratistaRead" },
                    { 95, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Editar", null, null, 0f, false, "Incidentes con Lesión a Personal Contratista", "/Incidentes/IncidenteContratistaUpdate" },
                    { 96, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Eliminar", null, null, 0f, false, "Incidentes con Lesión a Personal Contratista", "/Incidentes/IncidenteContratistaDelete" },
                    { 97, true, "Incidentes", "", "Incidentes", "", "Incidentes con Deterioro de la Salud Crear", null, null, 0f, false, "Incidentes con Deterioro de la Salud", "/Incidentes/IncidenteDeterioroSaludCreate" },
                    { 98, true, "Incidentes", "", "Incidentes", "", "Incidentes con Deterioro de la Salud Detalle", null, null, 0f, false, "Incidentes con Deterioro de la Salud", "/Incidentes/IncidenteDeterioroSaludRead" },
                    { 99, true, "Incidentes", "", "Incidentes", "", "Incidentes con Deterioro de la Salud Editar", null, null, 0f, false, "Incidentes con Deterioro de la Salud", "/Incidentes/IncidenteDeterioroSaludUpdate" },
                    { 93, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Crear", null, null, 0f, false, "Incidentes con Lesión a Personal Contratista", "/Incidentes/IncidenteContratistaCreate" },
                    { 100, true, "Incidentes", "", "Incidentes", "", "Incidentes con Deterioro de la Salud Eliminar", null, null, 0f, false, "Incidentes con Deterioro de la Salud", "/Incidentes/IncidenteDeterioroSaludDelete" },
                    { 102, true, "Incidentes", "", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Detalle", null, null, 0f, false, "Daños a Equipo, Material o Medioambiente", "/Incidentes/DanioEquipoMaterialRead" },
                    { 103, true, "Incidentes", "", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Editar", null, null, 0f, false, "Daños a Equipo, Material o Medioambiente", "/Incidentes/DanioEquipoMaterialUpdate" },
                    { 104, true, "Incidentes", "", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Eliminar", null, null, 0f, false, "Daños a Equipo, Material o Medioambiente", "/Incidentes/DanioEquipoMaterialDelete" },
                    { 105, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Correcciones SST Consulta", null, null, 0f, false, "Correcciones SST", "/Acciones/ListadoCorrecciones" },
                    { 106, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Correcciones SST Detalle", null, null, 0f, false, "Correcciones SST", "/Acciones/CorrecionSSTRead" },
                    { 107, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Reingreso Crear", null, null, 0f, false, "Alta ST2", "/Acciones/AltaST2" },
                    { 101, true, "Incidentes", "", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Crear", null, null, 0f, false, "Daños a Equipo, Material o Medioambiente", "/Incidentes/DanioEquipoMaterialCreate" },
                    { 92, true, "Incidentes", "", "Incidentes", "", "Incidentes sin Lesión Eliminar", null, null, 0f, false, "Incidentes sin lesión", "/Incidentes/IncidenteSinLesionDelete" },
                    { 91, true, "Incidentes", "", "Incidentes", "", "Incidentes sin Lesión Editar", null, null, 0f, false, "Incidentes sin lesión", "/Incidentes/IncidenteSinLesionUpdate" },
                    { 90, true, "Incidentes", "", "Incidentes", "", "Incidentes sin Lesión Detalle", null, null, 0f, false, "Incidentes sin lesión", "/Incidentes/IncidenteSinLesionRead" },
                    { 75, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Detalles de la Identificación de peligros en sus estados", null, null, 0f, false, "Detalles de la identificación de peligros (estados)", "/IdenPeligros/DetailsIPElaborada" },
                    { 76, true, "Gestion", "fa-list-alt", "Gestión de seguridad", "Identificación de peligros", "Identificación de Peligros Categorías Consulta", null, null, 2.4f, true, "Categorías", "/IdenPeligros/IndexCategorias" },
                    { 77, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Categorías Crear", null, null, 0f, false, "Editar categorías", "/IdenPeligros/AddOrEditCat" },
                    { 78, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Categorías Eliminar", null, null, 0f, false, "Eliminar categorías", "/IdenPeligros/DeleteCategorias" },
                    { 79, true, "Gestion", "fa-users-cog", "Gestión de seguridad", "Identificación de peligros", "Identificación de Peligros Evaluación de Riesgo Grupal Consulta", null, null, 2.2f, true, "Evaluación riesgo grupal", "/EvaluacionRiesgoGrupal/Listado" },
                    { 80, true, "Comunes", "", "Panel de control", "", "Catálogos Opción Crear", null, null, 0f, false, "Crear opción de catálogo", "/Catalogos/CreateOpcion" },
                    { 81, true, "Comunes", "", "Panel de control", "", "Catálogos Opción Eliminar", null, null, 0f, false, "Eliminar opción de catálogo", "/Catalogos/DeleteOpcion" },
                    { 82, true, "Comunes", "", "Panel de control", "", "Catálogos Opción Editar", null, null, 0f, false, "Editar opción de catálogo", "/Catalogos/EditOpcion" },
                    { 83, true, "Comunes", "", "Panel de control", "", "Catálogos Opción Consulta", null, null, 0f, false, "Obtener opción de catálogo", "/Catalogos/GetOpciones" },
                    { 84, true, "Incidentes", "", "Incidentes", "", "Informe Inicial Crear", null, null, 0f, false, "Incidentes con Lesión", "/Incidentes/InformeInicialCreate" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 85, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Crear", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/IncidenteConLesionCreate" },
                    { 86, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Detalles", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/IncidenteConLesionRead" },
                    { 87, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Editar", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/IncidenteConLesionUpdate" },
                    { 88, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Eliminar", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/IncidenteConLesionDelete" },
                    { 89, true, "Incidentes", "", "Incidentes", "", "Incidentes sin Lesión Crear", null, null, 0f, false, "Incidentes sin lesión", "/Incidentes/IncidenteSinLesionCreate" },
                    { 108, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Reingreso Detalle", null, null, 0f, false, "Alta ST2", "/Acciones/AltaST2Details" },
                    { 74, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Eliminar preocupación peligro", null, null, 0f, false, "Eliminar preocupación peligro", "/IdenPeligros/DeleteIPDetalle" },
                    { 109, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Reingreso Editar", null, null, 0f, false, "Alta ST2", "/Acciones/AltaST2Update" },
                    { 111, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Recaidas Crear", null, null, 0f, false, "Recaidas", "/Acciones/Recaida" },
                    { 131, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Documentos Cargar", null, null, 0f, false, "Cargar archivo de documentos oficiales de la norma", "/Norma/FileUpload" },
                    { 132, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Documentos Abrir", null, null, 0f, false, "Abrir archivo de documentos oficiales  de la norma", "/Norma/OpenFile" },
                    { 133, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Documentos Descargar", null, null, 0f, false, "Descargar archivo documentos oficiales de la norma", "/Norma/DownloadFile" },
                    { 134, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Activar", null, null, 0f, false, "Activar norma", "/Norma/Activar" },
                    { 135, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Desactivar", null, null, 0f, false, "Desactivar norma", "/Norma/Desactivar" },
                    { 136, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Ayudas Consulta", null, null, 0f, false, "Lista archivos de ayuda de la norma", "/Norma/ListaArchivos" },
                    { 130, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Documentos Eliminar", null, null, 0f, false, "Eliminar archivo documentos oficiales  de la norma", "/Norma/DeleteUploadedFile" },
                    { 137, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Tipos de Respuesta Consulta", null, null, 3.2f, true, "Tipos de respuesta", "/TipoRespuesta/Index" },
                    { 139, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Editar", null, null, 0f, false, "Editar  tipo de respuesta", "/TipoRespuesta/Edit" },
                    { 140, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Detalle", null, null, 0f, false, "Consultar  tipo de respuesta", "/TipoRespuesta/Details" },
                    { 604, true, "Gestion", "fa fa-search", "Gestión de seguridad", "Consultas ejecutivas", "Gestión Consulta Ejecutiva Reuniones de Difusión", null, null, 13.9f, true, "Reuniones de Difusión", "/ConsultaEjecutiva/Reunion" },
                    { 142, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Valores Editar", null, null, 0f, false, "Actualizar valor de  tipo de respuesta", "/TipoRespuesta/UpdateValorTR" },
                    { 143, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Valores Consulta", null, null, 0f, false, "Obtener valores del tipo de respuesta", "/TipoRespuesta/GetValoresTipoRespuesta" },
                    { 144, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Valores Eliminar", null, null, 0f, false, "Eliminar valor del tipo de respuesta", "/TipoRespuesta/DeleteValorTipoRespuesta" },
                    { 138, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Crear", null, null, 0f, false, "Nuevo tipo de respuesta", "/TipoRespuesta/Create" },
                    { 129, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Eliminar Revertir", null, null, 0f, false, "Revertir eliminado lógico de norma", "/Norma/UndoDeleteLogic" },
                    { 128, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Eliminar Lógico", null, null, 0f, false, "Eliminado lógico de norma", "/Norma/DeleteLogic" },
                    { 127, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Eliminar", null, null, 0f, false, "Eliminado físico de norma", "/Norma/Delete" },
                    { 112, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Recaidas Editar", null, null, 0f, false, "Recaidas", "/Acciones/RecaidaUpdate" },
                    { 113, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Recaidas Eliminar", null, null, 0f, false, "Recaidas", "/Acciones/RecaidaDelete" },
                    { 114, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión IPP Consulta", null, null, 0f, false, "IPP", "/Acciones/ListadoIPP" },
                    { 115, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión IPP Crear", null, null, 0f, false, "IPP", "/Acciones/IPPCreate" },
                    { 116, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión IPP Editar", null, null, 0f, false, "IPP", "/Acciones/IPPUpdate" },
                    { 117, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión IPP Eliminar", null, null, 0f, false, "IPP", "/Acciones/DeleteIPP" },
                    { 118, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Documentos Consulta", null, null, 0f, false, "Documentos", "/Acciones/ListadoDocumentos" },
                    { 119, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Documentos Crear", null, null, 0f, false, "Documentos", "/Acciones/Documentos" },
                    { 120, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Salario Consulta", null, null, 0f, false, "Cambio de Salario", "/Acciones/ListadoCambioSalario" },
                    { 121, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Salario Crear", null, null, 0f, false, "Cambio de Salario", "/Acciones/CambioSalario" },
                    { 122, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Salario Editar", null, null, 0f, false, "Cambio de Salario", "/Acciones/CambioSalarioUpdate" },
                    { 123, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Salario Eliminar", null, null, 0f, false, "Cambio de Salario", "/Acciones/CambioSalarioDelete" },
                    { 124, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Crear", null, null, 0f, false, "Nueva norma", "/Norma/Create" },
                    { 125, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Editar", null, null, 0f, false, "Editar norma", "/Norma/Edit" },
                    { 126, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Normas Detalle", null, null, 0f, false, "Consultar norma", "/Norma/Details" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 110, true, "Incidentes", "", "Incidentes", "", "Incidentes con Lesión Recaidas Consulta", null, null, 0f, false, "Recaidas", "/Acciones/ListadoRecaida" },
                    { 145, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Consulta", null, null, 0f, false, "Listado de requisitos de la norma", "/PuntoNorma/Index" },
                    { 73, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Editar preocupación peligro", null, null, 0f, false, "Editar preocupación peligro", "/IdenPeligros/EditIPD" },
                    { 71, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Eliminar", null, null, 0f, false, "Eliminar identificación de peligros", "/IdenPeligros/Delete" },
                    { 20, true, "Comunes", "", "Panel de control", "", "Catálogos Eliminar", null, null, 0f, false, "Eliminar Catálogo", "/Catalogo/Delete" },
                    { 21, true, "Comunes", "fa-users", "Panel de control", "", "Trabajadores Consultar", null, null, 1f, true, "Trabajadores", "/Trabajadores/Index" },
                    { 22, true, "Comunes", "", "Panel de control", "", "Trabajadores Detalle", null, null, 0f, false, "Detalle Trabajador", "/Trabajadores/Details" },
                    { 23, true, "Comunes", "", "Panel de control", "", "Trabajadores Crear", null, null, 0f, false, "Crear Trabajador", "/Trabajadores/Create" },
                    { 24, true, "Comunes", "", "Panel de control", "", "Trabajadores Editar", null, null, 0f, false, "Editar Trabajador", "/Trabajadores/Edit" },
                    { 25, true, "Comunes", "", "Panel de control", "", "Trabajadores Eliminar", null, null, 0f, false, "Eliminar Trabajador", "/Trabajadores/Delete" },
                    { 19, true, "Comunes", "", "Panel de control", "", "Catálogos Editar", null, null, 0f, false, "Editar Catálogo", "/Catalogos/Edit" },
                    { 26, true, "Comunes", "fa-city", "Panel de control", "", "Centros de Trabajo Consulta", null, null, 1f, true, "Centros de trabajo", "/Centros/Index" },
                    { 28, true, "Comunes", "", "Panel de control", "", "Centros de Trabajo Crear", null, null, 0f, false, "Crear Centro de Trabajo", "/Centros/Create" },
                    { 29, true, "Comunes", "", "Panel de control", "", "Centros de Trabajo Editar", null, null, 0f, false, "Editar Centro de Trabajo", "/Centros/Edit" },
                    { 30, true, "Comunes", "", "Panel de control", "", "Centros de Trabajo Eliminar", null, null, 0f, false, "Eliminar Centro de Trabajo", "/Centros/Delete" },
                    { 31, true, "Gestion", "fa-file-invoice", "Gestión de seguridad", "", "Correcciones SST Consulta", null, null, 1f, true, "Correcciones de SST", "/Formato13/Index" },
                    { 32, true, "Nueva corrección de SST", "", "Gestión de seguridad", "", "Correcciones SST Crear", null, null, 0f, false, "Gestión de Seguridad", "/Formato13/Create" },
                    { 33, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Editar (elaborador)", null, null, 0f, false, "Modificar corrección de SST (elaborador)", "/Formato13/Edit" },
                    { 27, true, "Comunes", "", "Panel de control", "", "Centros de Trabajo Detalle", null, null, 0f, false, "Detalle Centro de Trabajo", "/Centros/Details" },
                    { 18, true, "Comunes", "", "Panel de control", "", "Catálogos Crear", null, null, 0f, false, "Crear Catálogo", "/Catalogos/Create" },
                    { 17, true, "Comunes", "", "Panel de control", "", "Catálogos Detalle", null, null, 0f, false, "Consultar Catálogo", "/Catalogos/Details" },
                    { 16, true, "Comunes", "fa-align-justify", "Panel de control", "", "Catálogos Consultar", null, null, 1f, true, "Catálogos", "/Catalogos/Index" },
                    { 1, true, "Comunes", "fa-user-shield", "Panel de control", "", "Usuarios Consultar", null, null, 1f, true, "Usuarios", "/Usuarios/Index" },
                    { 2, true, "Comunes", "fa-check", "Panel de control", "", "Privilegios Consulta", null, null, 1f, true, "Privilegios", "/Privilegios/Index" },
                    { 3, true, "Comunes", "", "Panel de control", "", "Privilegios Detalle", null, null, 0f, false, "Detalle Privilegio", "/Privilegios/Details" },
                    { 4, true, "Comunes", "", "Panel de control", "", "Privilegios Editar", null, null, 0f, false, "Editar Privilegio", "/Privilegios/Edit" },
                    { 5, true, "Comunes", "", "Panel de control", "", "Privilegios Eliminar", null, null, 0f, false, "Eliminar Privilegio", "/Privilegios/Delete" },
                    { 6, true, "Comunes", "", "Panel de control", "", "Privilegios Crear", null, null, 0f, false, "Crear Privilegio", "/Privilegios/Create" },
                    { 7, true, "Comunes", "", "Panel de control", "", "Usuarios Crear", null, null, 0f, false, "Registrar Usuario", "/Usuarios/Create" },
                    { 8, true, "Comunes", "", "Panel de control", "", "Usuarios Editar", null, null, 0f, false, "Editar Usuario", "/Usuarios/Edit" },
                    { 9, true, "Comunes", "", "Panel de control", "", "Usuarios Detalle", null, null, 0f, false, "Detalle Usuario", "/Usuarios/Details" },
                    { 10, true, "Comunes", "", "Panel de control", "", "Usuarios Eliminar", null, null, 0f, false, "Eliminar Usuario", "/Usuario/Delete" },
                    { 11, true, "Comunes", "fa-address-card", "Panel de control", "", "Roles Consulta", null, null, 1f, true, "Roles", "/Roles/Index" },
                    { 12, true, "Comunes", "", "Panel de control", "", "Roles Detalle", null, null, 0f, false, "Roles", "/Roles/Details" },
                    { 13, true, "Comunes", "", "Panel de control", "", "Roles Editar", null, null, 0f, false, "Actualizar Rol", "/Roles/Edit" },
                    { 14, true, "Comunes", "", "Panel de control", "", "Roles Crear", null, null, 0f, false, "Crear Rol", "/Roles/Create" },
                    { 15, true, "Comunes", "", "Panel de control", "", "Roles Eliminar", null, null, 0f, false, "Eliminar Rol", "/Roles/Delete" },
                    { 34, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Detalle", null, null, 0f, false, "Consultar el detalle de la corrección de SST", "/Formato13/Details" },
                    { 72, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Nueva preocupación peligro", null, null, 0f, false, "Crear preocupación peligro", "/IdenPeligros/CreateIPD" },
                    { 35, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Eliminar (para cualquier rol)", null, null, 0f, false, "Eliminar corrección de SST", "/Formato13/Delete" },
                    { 37, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Consulta", null, null, 0f, false, "Archivos Correciones SST", "/ArchivoAdjuntoF13/Index" },
                    { 57, true, "Incidentes", "fa fa-user", "Incidentes", "", "Incidentes sin Lesión Consulta", null, null, 1.3f, true, "Incidentes sin lesión", "/Incidentes/sinlesion" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 58, true, "Incidentes", "fas fa-procedures", "Incidentes", "", "Incidentes con Deterioro de la Salud Consulta", null, null, 1.5f, true, "Deterioro de la salud", "/Incidentes/IncidenteDeterioroSalud" },
                    { 59, true, "Incidentes", "fas fa-user-cog", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Consulta", null, null, 1.6f, true, "Personal contratista", "/Incidentes/IncidenteContratista" },
                    { 60, true, "Incidentes", "fas fa-desktop", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Consulta", null, null, 1.4f, true, "Daños a equipo", "/Incidentes/DanioEquipoMaterial" },
                    { 61, true, "Incidentes", "", "Incidentes", "", "Informe Inicial Editar", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/InformeInicialUpdate" },
                    { 62, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Normas Consulta", null, null, 3.3f, true, "Normas", "/Norma/Index" },
                    { 56, true, "Incidentes", "", "Incidentes", "", "Informe Inicial Detalle", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/InformeInicialRead" },
                    { 63, true, "Comunes", "fas fa-key", "Panel de control", "", "Usuarios Cambiar Password", null, null, 1f, true, "Cambiar contraseña", "/Usuarios/ChangePassword" },
                    { 65, true, "Comunes", "", "Panel de control", "", "Usuarios Reset Password", null, null, 0f, false, "Reiniciar contraseña a usuario", "/Usuarios/ResetPassword" },
                    { 66, true, "Comunes", "", "Panel de Control", "", "Catálogos Detalle Opción", null, null, 0f, false, "Consultar opción catálogo", "/Catalogos/DetailsOpcion" },
                    { 67, true, "Gestion", "fa-exclamation-triangle", "Gestión de seguridad", "Identificación de peligros", "Identificación de Peligros Consulta", null, null, 2.1f, true, "Identificación de peligros", "/IdenPeligros/Listado" },
                    { 68, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Crear", null, null, 0f, false, "Crear identificación de peligros", "/IdenPeligros/Create" },
                    { 69, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Detalle", null, null, 0f, false, "Detalles de la identificación de peligros", "/IdenPeligros/CreateIPDetalles" },
                    { 70, true, "Gestion", "", "Gestión de seguridad", "", "Identificación de Peligros Editar identificación de peligros", null, null, 0f, false, "Editar identificación de peligros", "/IdenPeligros/EditIPeligro" },
                    { 64, true, "Comunes", "", "Panel de control", "", "Usuarios Activar/desactivar", null, null, 0f, false, "Activar / desactivar usuario", "/Usuarios/Deactivate" },
                    { 55, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendio Instalaciones Consulta", null, null, 8.7f, true, "Instalaciones centro trabajo", "/ConfiguracionLocal/Index" },
                    { 54, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Editar (responsable de ejecución)", null, null, 0f, false, "Modificar corrección de SST (responsable de ejecución)", "/Formato13/EditRE" },
                    { 53, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Proceso Cierre", null, null, 0f, false, "Avanzar en proceso cierre", "/Formato13/AvanzaCierre" },
                    { 38, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Eliminar", null, null, 0f, false, "Eliminar Archivo Correciones SST", "/ArchivoAdjuntoF13/Delete" },
                    { 39, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Crear", null, null, 0f, false, "Crear archivo adjunto", "/ArchivoAdjuntoF13/Create" },
                    { 40, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Abrir", null, null, 0f, false, "Abrir archivo adjunto", "/ArchivoAdjuntoF13/OpenFile" },
                    { 41, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Vista previa", null, null, 0f, false, "Vista previa de archivo adjunto", "/ArchivoAdjuntoF13/GetThumbnailImage" },
                    { 42, true, "Comunes", "fa-boxes", "Panel de control", "", "Áreas Administradas Consultar", null, null, 1f, true, "Centros administrados", "/AreasAdministradas/Index" },
                    { 43, true, "Comunes", "", "Panel de control", "", "Áreas Administradas Crear", null, null, 0f, false, "Agregar Centro de Trabajo", "/AreasAdministradas/Create" },
                    { 44, true, "Comunes", "", "Panel de control", "", "Áreas Administradas Eliminar", null, null, 0f, false, "Eliminar Centro de Trabajo", "/AreasAdministradas/Delete" },
                    { 45, true, "Incidentes", "fa-file-alt", "Incidentes", "", "Incidentes Asistente de Registro", null, null, 1.1f, true, "Asistente de registro", "/Incidentes/Index" },
                    { 46, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Responsables Editar", null, null, 0f, false, "Cambiar responsables de corrección de SST", "/Formato13/CambiaResponsables" },
                    { 47, true, "Incidentes", "fas fa-user-injured", "Incidentes", "", "Incidentes con Lesión Consulta", null, null, 1.2f, true, "Incidentes con lesión", "/Incidentes/Listado" },
                    { 48, true, "Incidentes", "", "Incidentes", "", "Informe Inicial Eliminar", null, null, 0f, false, "Incidentes con lesión", "/Incidentes/InformeInicialDelete" },
                    { 49, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Eliminar (para usuario elaborador)", null, null, 0f, false, "Eliminar corrección de SST", "/Formato13/Delete" },
                    { 50, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Proceso Programación", null, null, 0f, false, "Avanzar en proceso fecha programada", "/Formato13/AvanzaProcesoProgramado" },
                    { 51, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendio Diagnóstico Consulta", null, null, 8.8f, true, "Diagnóstico infraestructura", "/Evaluacion/Index" },
                    { 52, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Proceso Ejecución", null, null, 0f, false, "Avanzar en proceso fecha real", "/Formato13/AvanzaProcesoReal" },
                    { 36, true, "Gestion", "", "Gestión de seguridad", "", "Correcciones SST Adjuntos Descargar", null, null, 0f, false, "Descargar Archivo Correciones SST", "/ArchivoAdjuntoF13/DownloadFile" },
                    { 146, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Crear", null, null, 0f, false, "Nuevo requisito de la norma", "/PuntoNorma/Create" },
                    { 141, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Tipos de Respuesta Eliminar", null, null, 0f, false, "Eliminar  tipo de respuesta", "/TipoRespuesta/Delete" },
                    { 148, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Detalle", null, null, 0f, false, "Consultar requisito de la norma", "/PuntoNorma/Details" },
                    { 242, true, "Incidentes", "fa-file-alt", "Incidentes", "", "Datos Básicos Consultar (RSR)", null, null, 1f, true, "Datos básicos", "/DatosBasicos/IndexRegional" },
                    { 243, true, "Incidentes", "fa-file-alt", "Incidentes", "", "Datos Básicos Consultar (RSN)", null, null, 1f, true, "Datos básicos", "/DatosBasicos/IndexNacional" },
                    { 244, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente  Genera Nueva Version", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/GeneraRevisionNueva" },
                    { 245, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Aprobar Version", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/Aprobar" },
                    { 246, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Rechazar Version", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/Rechazar" },
                    { 247, true, "GestionRL", "fa-file-alt", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Lista", null, null, 3.8f, true, "Evaluaciones", "/EvaluacionExpediente/Index" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 241, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Recupera Bitacora", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/GetDatosBitacora" },
                    { 248, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Crear", null, null, 0f, false, "Nueva evaluación de expediente", "/EvaluacionExpediente/Create" },
                    { 250, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes expediente bitácora", null, null, 0f, false, "Mostrar bitácora de evaluaciones", "/EvaluacionExpediente/GetDatosBitacora" },
                    { 251, true, "Comunes", "", "Panel de control", "", "Trabajadores Activar/desactivar", null, null, 0f, false, "Activar / desactivar usuario", "/Trabajadores/DeleteLogic" },
                    { 252, true, "Incidentes", "fas fa-file-signature", "Incidentes", "Boleta de control", "Incidentes Reportes de boletas de control", null, null, 1.8f, true, "Incidentes con lesión", "/Incidentes/Boleta" },
                    { 253, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes evaluar requisito", null, null, 0f, false, "Evaluar requisito", "/EvaluacionExpediente/EvaluarCRA" },
                    { 254, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes guardar comentarios", null, null, 0f, false, "Guardar comentarios", "/EvaluacionExpediente/GuardarComentarios" },
                    { 255, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Si aplica requisito", null, null, 0f, false, "Si aplica requisito", "/EvaluacionExpediente/SiAplicaCRA" },
                    { 249, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes consultar", null, null, 0f, false, "Consultar evaluación de expediente", "/EvaluacionExpediente/Details" },
                    { 240, true, "Incidentes", "fas fa-file-signature", "Incidentes", "", "Consulta Ejecutiva", null, null, 1.9f, true, "Consulta ejecutiva", "/ConsultaEjecutiva/Index" },
                    { 239, true, "Incidentes", "fas fa-desktop", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Consulta", null, null, 3.4f, true, "Daños a equipo, material o medioambiente", "/Incidentes/DanioEquipoMaterial?nacional=true" },
                    { 238, true, "Incidentes", "fas fa-user-cog", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Consulta", null, null, 3.6f, true, "Incidentes con lesión a personal contratista", "/Incidentes/IncidenteContratista?nacional=true" },
                    { 223, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Lista de Archivo de Evidencia disponibles", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/ListaArchivoEvidenciaDisponibles" },
                    { 224, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Consulta simple", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/DetailsSimple" },
                    { 225, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Aprobador Expediente", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/AprobadorExpediente" },
                    { 147, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Editar", null, null, 0f, false, "Editar  requisito de la norma", "/PuntoNorma/Edit" },
                    { 227, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Agregar requisitos", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/AgregarRequisitos" },
                    { 228, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Lista Requisitos Norma", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/ListaRequisitosNorma" },
                    { 229, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Eliminar Requisito Manual", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/DeleteRequisitoManual" },
                    { 230, true, "Incidentes", "fas fa-user-injured", "Incidentes", "", "Incidentes con Lesión Consulta", null, null, 2.2f, true, "Incidentes con lesión", "/Incidentes/Listado?regional=true" },
                    { 231, true, "Incidentes", "fa fa-user", "Incidentes", "", "Incidentes sin Lesión Consulta", null, null, 2.3f, true, "Incidentes sin lesión", "/Incidentes/sinlesion?regional=true" },
                    { 232, true, "Incidentes", "fas fa-procedures", "Incidentes", "", "Incidentes con Deterioro de la Salud Consulta", null, null, 2.5f, true, "Incidentes con deterioro de la salud", "/Incidentes/IncidenteDeterioroSalud?regional=true" },
                    { 233, true, "Incidentes", "fas fa-user-cog", "Incidentes", "", "Incidentes con Lesión a Personal Contratista Consulta", null, null, 2.6f, true, "Incidentes con lesión a personal contratista", "/Incidentes/IncidenteContratista?regional=true" },
                    { 234, true, "Incidentes", "fas fa-desktop", "Incidentes", "", "Daños a Equipo, Material o Medioambiente Consulta", null, null, 2.47f, true, "Daños a equipo, material o medioambiente", "/Incidentes/DanioEquipoMaterial?regional=true" },
                    { 235, true, "Incidentes", "fas fa-user-injured", "Incidentes", "", "Incidentes con Lesión Consulta", null, null, 3.2f, true, "Incidentes con lesión", "/Incidentes/Listado?nacional=true" },
                    { 236, true, "Incidentes", "fa fa-user", "Incidentes", "", "Incidentes sin lesión Consulta", null, null, 3.3f, true, "Incidentes sin lesión", "/Incidentes/sinlesion?nacional=true" },
                    { 237, true, "Incidentes", "fas fa-procedures", "Incidentes", "", "Incidentes con Deterioro de la Salud Consulta", null, null, 3.5f, true, "Incidentes con deterioro de la salud", "/Incidentes/IncidenteDeterioroSalud?nacional=true" },
                    { 256, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes No aplica requisito", null, null, 0f, false, "No aplica requisito", "/EvaluacionExpediente/NoAplicaCRA" },
                    { 222, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Elimina de Archivo de Evidencia Compartida", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/DeleteEvidenciaCompartida" },
                    { 257, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Terminar", null, null, 0f, false, "Terminar evaluación", "/EvaluacionExpediente/TerminarEvaluacion" },
                    { 259, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Impacto", null, null, 0f, false, "Set Impacto", "/Expediente/SetImpacto" },
                    { 279, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Sugerencia Crear/Editar", null, null, 0f, false, "Tareas Críticas", "/IMSugerencias/AddOrEditSugerencias" },
                    { 280, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Proceso Estados Consutar", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/DetailsTareaCritica" },
                    { 281, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Estados Cambiar", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/CambiaEstadoActividad" },
                    { 282, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Aspectos Generales Detalle", null, null, 10f, false, "Detalles de aspecto generales", "/AspectosGenerales/Details" },
                    { 283, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Aspectos Generales Editar", null, null, 10f, false, "Editar aspecto generales", "/AspectosGenerales/Edit" },
                    { 284, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Tipos de centro de trabajo Editar", null, null, 10f, false, "Editar tipo de centro de trabajo", "/ConfiguracionAdministrador/EditTipoCentroTrabajo" },
                    { 278, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Paso Tarea Editar", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/EditPasoTarea" },
                    { 285, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Tipos de centro de trabajo Eliminar", null, null, 10f, false, "Eliminar tipo de centro de trabajo", "/ConfiguracionAdministrador/DeleteTipoCentroTrabajo" },
                    { 287, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Tipos de instalación Eliminar", null, null, 10f, false, "Eliminar tipo de instalación", "/ConfiguracionAdministrador/DeleteTipoInstalacion" },
                    { 288, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalaciones -Centro de trabajo Editar", null, null, 10f, false, "Editar tipo centro trabajo- tipo instalación", "/ConfiguracionAdministrador/EditRelacionTCTxTI" },
                    { 289, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Áreas a proteger Editar", null, null, 10f, false, "Editar área a proteger", "/ConfiguracionAdministrador/EditASEProteger" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 290, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Áreas a proteger Eliminar", null, null, 10f, false, "Eliminar área a proteger", "/ConfiguracionAdministrador/DeleteASEProteger" },
                    { 291, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Áreas a proteger Detalle", null, null, 10f, false, "Detalle área a proteger", "/ConfiguracionAdministrador/DetailsASEProteger" },
                    { 292, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Áreas - Tipo instalación Editar", null, null, 10f, false, "Editar área - tipo instalación", "/ConfiguracionAdministrador/EditRelacionASExTI" },
                    { 286, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Tipos de instalación Editar", null, null, 10f, false, "Editar tipo de instalación", "/ConfiguracionAdministrador/EditTipoInstalacion" },
                    { 277, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Paso Tarea Crear", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/CreatePasoTarea" },
                    { 276, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Valida Existe Actividad", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/validaExisteActividad" },
                    { 275, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Participante Eliminar", null, null, 0f, false, "Tareas Críticas", "/IMSugerencias/DeleteParticipante" },
                    { 260, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Probabilidad", null, null, 0f, false, "Set Probabilidad", "/Expediente/SetProbabilidad" },
                    { 261, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Crear", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/Create" },
                    { 262, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Consulta", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/Details" },
                    { 263, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Crear Componente", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/CreateComponente" },
                    { 264, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Editar Componente", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/EditComponente" },
                    { 265, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Valida Existe Componente", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/ValidaExisteComponente" },
                    { 266, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Cambia Estado", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/CambiaEstadoEGR" },
                    { 267, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Crear Participante", null, null, 0f, false, "Evaluación de riesgo grupal", "/IMIPControlesEGR/CreateParticipante" },
                    { 268, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Elimina Participante", null, null, 0f, false, "Evaluación de riesgo grupal", "/IMIPControlesEGR/DeleteParticipante" },
                    { 269, true, "Gestion", "", "Gestión de seguridad", "", "Evaluación de Riesgo Grupal Consulta Proceso de Estados", null, null, 0f, false, "Evaluación de riesgo grupal", "/EvaluacionRiesgoGrupal/LecturaDetallesIPEGR" },
                    { 270, true, "Gestion", "", "Gestión de seguridad", "Identificación de peligros", "Tareas Críticas Lista", null, null, 2.3f, false, "Tareas críticas", "/TareasCriticas/Listado" },
                    { 271, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Consulta", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/ListaActividadesTC" },
                    { 272, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Eliminar", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/Delete" },
                    { 273, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Editar", null, null, 0f, false, "Tareas Críticas", "/TareasCriticas/EditTarea" },
                    { 274, true, "Gestion", "", "Gestión de seguridad", "", "Tareas Críticas Participante Crear", null, null, 0f, false, "Tareas Críticas", "/IMSugerencias/CreateParticipante" },
                    { 258, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Evaluación de Expedientes Confirma que no aplica", null, null, 0f, false, "Confirma que no aplica el requisito", "/EvaluacionExpediente/ConfirmaNoAplicaCRA" },
                    { 221, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Lista de Archivo de Evidencia", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/ListaArchivoEvidenciaCompartida" },
                    { 226, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Enviar Revision", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/EnviarRevision" },
                    { 219, false, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Patrones Indicador RGA", null, null, 1.1f, true, "Indicador-Patrón RGA", "/Patrones/IndexRedGeneralAgua" },
                    { 168, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Archivos Cargar", null, null, 0f, false, "Cargar archivo de ayuda de pregunta", "/Pregunta/FileUpload" },
                    { 169, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Archivos Abrir", null, null, 0f, false, "Abrir archivo de ayuda de pregunta", "/Pregunta/OpenFile" },
                    { 170, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Archivos Descargar", null, null, 0f, false, "Descargar archivo de ayuda de pregunta", "/Pregunta/DownloadFile" },
                    { 171, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Consulta", null, null, 0f, false, "Obtener requisitos de la norma", "/Pregunta/GetRequisitosDeLaNorma" },
                    { 172, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Crear", null, null, 0f, false, "Eliminar requisito aplicable a la pregunta", "/Pregunta/DeleteRequisitoAplicable" },
                    { 173, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Tipos Centrto Trabajo", null, null, 8.1f, true, "Tipos centros de trabajo", "/ConfiguracionAdministrador/IndexTipoCentroTrabajo" },
                    { 167, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Archivos Eliminar", null, null, 0f, false, "Eliminar archivo de ayuda de pregunta", "/Pregunta/DeleteUploadedFile" },
                    { 174, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Tipos de Instalación", null, null, 8.1f, true, "Tipos de instalación", "/ConfiguracionAdministrador/IndexTipoInstalacion" },
                    { 176, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Tipos Centro Trabajo - Tipos Instalación", null, null, 8.4f, true, "Instalaciones-Centro de trabajo", "/ConfiguracionAdministrador/IndexRelacionTCTxTI" },
                    { 177, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Áreas a proteger - Tipo Instalación", null, null, 8.5f, true, "Áreas-Tipo de instalación ", "/ConfiguracionAdministrador/IndexRelacionASExTI" },
                    { 220, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Archivo de Evidencia Compartida", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/ArchivoEvidenciaCompartida" },
                    { 179, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "", "Protección Contra Incendios Instalación Detalles", null, null, 0f, false, "Instalaciones-Centro de trabajo", "/ConfiguracionRegional/Details" },
                    { 180, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "", "Protección Contra Incendios Instalación Agregar", null, null, 0f, false, "Agregar-editar instalaciones", "/ConfiguracionRegional/UpdateCreate" },
                    { 181, true, "Diagnostico", "", "Gestión de seguridad", "", "Protección Contra Incendios Instalación Eliminar", null, null, 0f, false, "Eliminar instalación", "/ConfiguracionRegional/Delete" },
                    { 175, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios SAEs a proteger", null, null, 8.3f, true, "SAEs a proteger", "/ConfiguracionAdministrador/IndexASEsProteger" },
                    { 166, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Subpreguntas Eliminar", null, null, 0f, false, "Eliminar subpregunta", "/Pregunta/DeleteSubPregunta" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 165, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Eliminar", null, null, 0f, false, "Eliminar pregunta", "/Pregunta/Delete" },
                    { 164, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Requisitos Aplicables Agregar", null, null, 0f, false, "Agregar requisitos aplicables pregunta", "/Pregunta/AgregaRequisitosAplicables" },
                    { 149, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Eliminar", null, null, 0f, false, "Eliminado físico  requisito de la norma", "/PuntoNorma/Delete" },
                    { 150, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Eliminar Revertir", null, null, 0f, false, "Revertir eliminado lógico de requisito de la norma", "/PuntoNorma/UndoDelete" },
                    { 151, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Archivo Eliminar", null, null, 0f, false, "Eliminar archivo de ayuda de requisito la norma", "/PuntoNorma/DeleteUploadedFile" },
                    { 152, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Archivo Cargar", null, null, 0f, false, "Cargar archivo de ayuda de requisito la norma", "/PuntoNorma/FileUpload" },
                    { 153, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Archivo Abrir", null, null, 0f, false, "Abrir archivo de ayuda de requisito la norma", "/PuntoNorma/OpenFile" },
                    { 154, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Archivo Descargar", null, null, 0f, false, "Descargar archivo de ayuda de requisito la norma", "/PuntoNorma/DownloadFile" },
                    { 155, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Consulta (JSON)", null, null, 0f, false, "Lista de requisitos de la norma (JSON)", "/PuntoNorma/DatosPuntosNorma" },
                    { 156, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Archivos Consulta", null, null, 0f, false, "Lista de archivos de ayuda requisitos de la norma", "/PuntoNorma/ListaArchivosAyuda" },
                    { 157, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Puntos Norma Ayuda Consulta", null, null, 0f, false, "Obtener texto de ayuda", "/PuntoNorma/getTextoAyuda" },
                    { 158, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Preguntas Consulta", null, null, 3.4f, true, "Preguntas", "/Pregunta/Index" },
                    { 159, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Crear", null, null, 0f, false, "Nueva pregunta", "/Pregunta/Create" },
                    { 160, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Editar", null, null, 0f, false, "Editar pregunta", "/Pregunta/Edit" },
                    { 161, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Detalle", null, null, 0f, false, "Consultar pregunta", "/Pregunta/Details" },
                    { 162, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Archivos Consulta", null, null, 0f, false, "Lista de archivos de ayuda de pregunta", "/Pregunta/ListaArchivos" },
                    { 163, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Preguntas Requisitos Aplicables Consulta", null, null, 0f, false, "Lista de requisitos aplicables pregunta", "/Pregunta/ListaRequisitosAplicables" },
                    { 182, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Cuestionarios Lista", null, null, 3.5f, true, "Cuestionarios", "/Cuestionario/Index" },
                    { 183, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Crear", null, null, 0f, false, "Nuevo cuestionario", "/Cuestionario/Create" },
                    { 178, true, "Diagnostico", "fa fa-fire-extinguisher", "Gestión de seguridad", "Infraestructura seguridad", "Protección Contra Incendios Instalaciones por Centro Trabajo (RSR)", null, null, 8.6f, true, "Instalaciones-Centros de trabajo", "/ConfiguracionRegional/Index" },
                    { 185, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Consultar", null, null, 0f, false, "Consultar cuestionario", "/Cuestionario/Details" },
                    { 205, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Aplica Cumplimiento", null, null, 0f, false, "Aplica cumplimiento de requisito", "/Expediente/AplicaCumplimientoRequisito" },
                    { 206, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Actualiza Cumplimiento", null, null, 0f, false, "Actualiza cumplimiento", "/Expediente/CumplimientoRequisito" },
                    { 184, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Editar", null, null, 0f, false, "Editar cuestionario", "/Cuestionario/Edit" },
                    { 208, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Coordinador Cumplimiento", null, null, 0f, false, "Coordinador de cumplimiento", "/Expediente/CumplimientoCoordinador" },
                    { 209, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Archivo de Evidencia", null, null, 0f, false, "Adjuntar evidencia de requisito aplicable", "/Expediente/ArchivoEvidencia" },
                    { 210, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Abrir archivo de evidencia", null, null, 0f, false, "Abrir evidencia de requisito aplicable", "/Expediente/OpenFile" },
                    { 204, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Guarda No Aplica", null, null, 0f, false, "Indica que no aplica el requisito", "/Expediente/NoAplicaCumplimientoRequisito" },
                    { 211, true, "Comunes", "fa-align-justify", "Panel de control", "", "Bitácora de Movimientos Lista", null, null, 1f, true, "Bitácora de movimientos", "/Bitacora/Index" },
                    { 213, true, "Comunes", "", "Panel de control", "", "Bitácora de Movimientos Eliminar", null, null, 0f, false, "Eliminar movimiento de la bitácora", "/Bitacora/Delete" },
                    { 214, true, "Incidentes", "fa-file-alt", "Incidentes", "", "Incidentes Datos Básicos", null, null, 1.7f, true, "Datos básicos", "/DatosBasicos/DatosBasicos" },
                    { 215, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Lista de Archivo de Evidencia", null, null, 0f, false, "Lista de Archivos de evidencia", "/Expediente/ListaArchivoEvidencia" },
                    { 216, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Descargar Archivo de Evidencia", null, null, 0f, false, "Descarga de archivo de evidencia", "/Expediente/DownloadFile" },
                    { 217, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Eliminar Archivo de Evidencia", null, null, 0f, false, "Eliminar archivo de evidencia", "/Expediente/DeleteUploadedFile" },
                    { 218, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Detalle por Norma", null, null, 0f, false, "Detalle de requisitos por Norma", "/Expediente/DetalleExpedienteNorma" },
                    { 212, true, "Comunes", "", "Panel de control", "", "Bitácora de Movimientos Consulta", null, null, 0f, false, "Detalle de un movimiento de la bitácora", "/Bitacora/Details" },
                    { 203, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Guarda Aplica", null, null, 0f, false, "Indica que si aplica el requisito", "/Expediente/DetalleCRANormaSetNoAplica" },
                    { 207, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Ayuda Requisito Aplicable", null, null, 0f, false, "Ayuda de requisito legal", "/Expediente/CumplimientoAyuda" },
                    { 201, true, "GestionRL", "fas fa-balance-scale", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Expediente Lista Por CT", null, null, 3.7f, true, "Expedientes", "/Expediente/Index" },
                    { 186, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Eiminar", null, null, 0f, false, "Eliminar cuestionario", "/Cuestionario/Delete" },
                    { 187, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Publicar", null, null, 0f, false, "Publicar cuestionario", "/Cuestionario/Publicar" },
                    { 202, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Expediente Consulta", null, null, 0f, false, "Consulta de expediente del CT", "/Expediente/Details" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Privilegio",
                columns: new[] { "id", "activo", "area", "icono", "modulo", "moduloMenu", "nombrePrivilegio", "ocultarParaIdProceso", "ocultarParaIdRol", "orden", "porOmision", "seccion", "url" },
                values: new object[,]
                {
                    { 189, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Preguntas Obtener", null, null, 0f, false, "Obtener preguntas cuestionario", "/Cuestionario/GetPreguntas" },
                    { 190, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios SubPreguntas Obtener", null, null, 0f, false, "Obtener subpreguntas cuestionario", "/Cuestionario/GetSubPreguntas" },
                    { 191, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Preguntas Lista", null, null, 0f, false, "Lista de preguntas cuestionario", "/Cuestionario/ListaPreguntas" },
                    { 192, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Preguntas Agregar", null, null, 0f, false, "Agregar preguntas cuestionario", "/Cuestionario/AgregarPreguntas" },
                    { 188, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Despublicar", null, null, 0f, false, "Despublicar cuestionario", "/Cuestionario/Despublicar" },
                    { 194, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Preguntas Cambiar Orden", null, null, 0f, false, "Cambiar orden de pregunta cuestionario", "/Cuestionario/CambiarOrdenPregunta" },
                    { 195, true, "GestionRL", "fas fa-desktop", "Gestión de seguridad", "Requisitos legales", "Requisitos Legales Cuestionarios Lista Contestar", null, null, 3.6f, true, "Contestar cuestionario", "/ContestaCuestionario/Index" },
                    { 196, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Contestar", null, null, 0f, false, "Inicar contestar cuestionario", "/ContestaCuestionario/Create" },
                    { 197, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Presentar", null, null, 0f, false, "Presentar cuestionario", "/ContestaCuestionario/PreguntasCuestionario" },
                    { 198, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Eliminar Contestado", null, null, 0f, false, "Eliminar cuestionario contestado", "/ContestaCuestionario/Delete" },
                    { 199, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Guardar Contestado", null, null, 0f, false, "Guardar cuestionario contestado", "/ContestaCuestionario/GuardaCuestionario" },
                    { 200, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios lista de preguntas parcial", null, null, 0f, false, "Obtener lista de preguntas parcial", "/Cuestionario/ListaPreguntasPartial" },
                    { 193, true, "GestionRL", "", "Gestión de seguridad", "", "Requisitos Legales Cuestionarios Preguntas Eliminar", null, null, 0f, false, "Eliminar pregunta cuestionario", "/Cuestionario/DeletePregunta" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Rol",
                columns: new[] { "Id", "Activo", "ConcurrencyStamp", "Descripcion", "IdNivelJerarquico", "Name", "NormalizedName", "Prioridad" },
                values: new object[,]
                {
                    { 2, true, "d055fef4-ec00-4919-afff-a43bf1f6bc1f", "Responsable local de SST", 3635, "Responsable local de SST", "RSA", 2 },
                    { 3, true, "c9e7c307-284d-4aa5-af7a-ea86c35ecc08", "Usuario que consulta información", 3635, "Consulta", "consulta", 1 },
                    { 4, true, "cbc42e7e-b367-4f5b-bab0-6ba55c73f000", "Responsable de proceso / área", 3635, "Responsable de proceso / área", "JDT", 1 },
                    { 5, true, "00ec0be0-0ac0-40c3-b25b-5f81ce230ab7", "Integrante de la CSH ", 3635, "Integrante de la CSH", "CSH", 1 },
                    { 9, true, "05cbd25b-33d2-407d-88b3-4bc086f7aa36", "GestionRL", 3632, "GestionRL", "GESTIONRL", 1 },
                    { 7, true, "6f55ca01-db06-4da2-93e4-820168c5cf45", "Responsable regional de SST", 3634, "Responsable regional de SST", "RSR", 3 },
                    { 8, true, "1a0005f7-f56b-457b-b431-323f1ac210d7", "Responsable nacional de SST", 3633, "Responsable nacional de SST", "RSN", 4 },
                    { 10, true, "1ad13af5-8e34-43b2-9bc9-cec060936b38", "Gerente Laboratorio", 3635, "Gerente Laboratorio", "GERLAB", 2 },
                    { 11, true, "0897019a-c347-4b56-be8a-c4172e9b7471", "Metrólogo Laboratorio", 3635, "Metrólogo", "Metrólogo", 2 },
                    { 6, true, "226fe549-4155-486f-b199-a1a610146d3b", "Aprobador ", 3635, "Aprobador", "AP", 1 },
                    { 1, true, "45fc77b1-26b8-4c62-924b-9ebdb6e4f559", "El Administrador tiene acceso al Panel de control general del sistema.", 3632, "Administrador", "ADMIN", 5 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Departamento",
                columns: new[] { "Id", "Clave", "Descripcion", "IdCT", "IdDepartamentoSicacyp" },
                values: new object[,]
                {
                    { 1, "AAA", "Asesores", 1, 0 },
                    { 2, "PPP", "Publicidad", 1, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1870, 370, 2 },
                    { 1888, 388, 2 },
                    { 1889, 389, 2 },
                    { 390, 390, 1 },
                    { 890, 390, 8 },
                    { 1390, 390, 7 },
                    { 1890, 390, 2 },
                    { 2390, 390, 4 },
                    { 2890, 390, 5 },
                    { 3390, 390, 6 },
                    { 391, 391, 1 },
                    { 891, 391, 8 },
                    { 1391, 391, 7 },
                    { 1891, 391, 2 },
                    { 2391, 391, 4 },
                    { 2891, 391, 5 },
                    { 3391, 391, 6 },
                    { 392, 392, 1 },
                    { 1370, 370, 7 },
                    { 870, 370, 8 },
                    { 370, 370, 1 },
                    { 869, 369, 8 },
                    { 1853, 353, 2 },
                    { 1854, 354, 2 },
                    { 758, 357, 8 },
                    { 1306, 357, 7 },
                    { 759, 358, 8 },
                    { 1307, 358, 7 },
                    { 760, 359, 8 },
                    { 1308, 359, 7 },
                    { 892, 392, 8 },
                    { 755, 363, 8 },
                    { 1858, 363, 2 },
                    { 756, 364, 8 },
                    { 1310, 364, 7 },
                    { 1859, 364, 2 },
                    { 757, 365, 8 },
                    { 1311, 365, 7 },
                    { 1860, 365, 2 },
                    { 1368, 368, 7 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1309, 363, 7 },
                    { 1392, 392, 7 },
                    { 1892, 392, 2 },
                    { 2392, 392, 4 },
                    { 1897, 397, 2 },
                    { 2397, 397, 4 },
                    { 2897, 397, 5 },
                    { 3397, 397, 6 },
                    { 398, 398, 1 },
                    { 898, 398, 8 },
                    { 1398, 398, 7 },
                    { 1898, 398, 2 },
                    { 1397, 397, 7 },
                    { 2398, 398, 4 },
                    { 3398, 398, 6 },
                    { 399, 399, 1 },
                    { 899, 399, 8 },
                    { 1399, 399, 7 },
                    { 1899, 399, 2 },
                    { 2399, 399, 4 },
                    { 2899, 399, 5 },
                    { 3399, 399, 6 },
                    { 2898, 398, 5 },
                    { 1852, 352, 2 },
                    { 897, 397, 8 },
                    { 3396, 396, 6 },
                    { 2892, 392, 5 },
                    { 3392, 392, 6 },
                    { 393, 393, 1 },
                    { 893, 393, 8 },
                    { 1393, 393, 7 },
                    { 1893, 393, 2 },
                    { 2393, 393, 4 },
                    { 2893, 393, 5 },
                    { 397, 397, 1 },
                    { 3393, 393, 6 },
                    { 1395, 395, 7 },
                    { 1895, 395, 2 },
                    { 396, 396, 1 },
                    { 896, 396, 8 },
                    { 1396, 396, 7 },
                    { 1896, 396, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 2396, 396, 4 },
                    { 2896, 396, 5 },
                    { 895, 395, 8 },
                    { 1851, 351, 2 },
                    { 1850, 350, 2 },
                    { 1849, 349, 2 },
                    { 287, 287, 1 },
                    { 288, 288, 1 },
                    { 289, 289, 1 },
                    { 290, 290, 1 },
                    { 291, 291, 1 },
                    { 292, 292, 1 },
                    { 293, 293, 1 },
                    { 1794, 294, 2 },
                    { 286, 286, 1 },
                    { 1795, 295, 2 },
                    { 1797, 297, 2 },
                    { 1798, 298, 2 },
                    { 1799, 299, 2 },
                    { 1800, 300, 2 },
                    { 1801, 301, 2 },
                    { 1302, 302, 7 },
                    { 1303, 303, 7 },
                    { 1304, 304, 7 },
                    { 1796, 296, 2 },
                    { 1305, 305, 7 },
                    { 285, 285, 1 },
                    { 1783, 283, 2 },
                    { 1765, 265, 2 },
                    { 1766, 266, 2 },
                    { 1767, 267, 2 },
                    { 1768, 268, 2 },
                    { 1769, 269, 2 },
                    { 1770, 270, 2 },
                    { 1771, 271, 2 },
                    { 1772, 272, 2 },
                    { 284, 284, 1 },
                    { 1773, 273, 2 },
                    { 1775, 275, 2 },
                    { 1776, 276, 2 },
                    { 1777, 277, 2 },
                    { 1778, 278, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1779, 279, 2 },
                    { 1780, 280, 2 },
                    { 1781, 281, 2 },
                    { 1782, 282, 2 },
                    { 1774, 274, 2 },
                    { 400, 400, 1 },
                    { 1806, 306, 2 },
                    { 1808, 308, 2 },
                    { 1831, 331, 2 },
                    { 1832, 332, 2 },
                    { 1833, 333, 2 },
                    { 1834, 334, 2 },
                    { 1835, 335, 2 },
                    { 1836, 336, 2 },
                    { 1837, 337, 2 },
                    { 1838, 338, 2 },
                    { 1830, 330, 2 },
                    { 1839, 339, 2 },
                    { 1841, 341, 2 },
                    { 1842, 342, 2 },
                    { 1843, 343, 2 },
                    { 1844, 344, 2 },
                    { 1845, 345, 2 },
                    { 1846, 346, 2 },
                    { 1847, 347, 2 },
                    { 1848, 348, 2 },
                    { 1840, 340, 2 },
                    { 1807, 307, 2 },
                    { 1829, 329, 2 },
                    { 1827, 327, 2 },
                    { 1809, 309, 2 },
                    { 1810, 310, 2 },
                    { 1811, 311, 2 },
                    { 1812, 312, 2 },
                    { 1813, 313, 2 },
                    { 1814, 314, 2 },
                    { 1815, 315, 2 },
                    { 1816, 316, 2 },
                    { 1828, 328, 2 },
                    { 1817, 317, 2 },
                    { 1819, 319, 2 },
                    { 1820, 320, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1821, 321, 2 },
                    { 1822, 322, 2 },
                    { 1823, 323, 2 },
                    { 1824, 324, 2 },
                    { 1825, 325, 2 },
                    { 1826, 326, 2 },
                    { 1818, 318, 2 },
                    { 900, 400, 8 },
                    { 1400, 400, 7 },
                    { 1900, 400, 2 },
                    { 484, 484, 1 },
                    { 984, 484, 8 },
                    { 1484, 484, 7 },
                    { 485, 485, 1 },
                    { 985, 485, 8 },
                    { 1485, 485, 7 },
                    { 486, 486, 1 },
                    { 986, 486, 8 },
                    { 7305, 477, 11 },
                    { 1486, 486, 7 },
                    { 11558, 558, 2 },
                    { 10559, 559, 8 },
                    { 11059, 559, 7 },
                    { 11560, 560, 2 },
                    { 11561, 561, 2 },
                    { 11562, 562, 2 },
                    { 11563, 563, 2 },
                    { 11564, 564, 2 },
                    { 487, 487, 1 },
                    { 11565, 565, 2 },
                    { 7007, 477, 10 },
                    { 7006, 476, 10 },
                    { 1950, 450, 2 },
                    { 951, 451, 8 },
                    { 1451, 451, 7 },
                    { 1951, 451, 2 },
                    { 952, 452, 8 },
                    { 1452, 452, 7 },
                    { 1952, 452, 2 },
                    { 953, 453, 8 },
                    { 7304, 476, 11 },
                    { 1453, 453, 7 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 7001, 471, 10 },
                    { 7301, 471, 11 },
                    { 7002, 472, 10 },
                    { 7003, 473, 10 },
                    { 7004, 474, 10 },
                    { 7302, 474, 11 },
                    { 7005, 475, 10 },
                    { 7303, 475, 11 },
                    { 1953, 453, 2 },
                    { 1450, 450, 7 },
                    { 11566, 566, 2 },
                    { 11568, 568, 2 },
                    { 11093, 589, 7 },
                    { 10594, 590, 8 },
                    { 11094, 590, 7 },
                    { 10595, 591, 8 },
                    { 11095, 591, 7 },
                    { 10096, 592, 1 },
                    { 10596, 592, 8 },
                    { 11096, 592, 7 },
                    { 10593, 589, 8 },
                    { 11596, 592, 2 },
                    { 11600, 596, 2 },
                    { 11601, 597, 2 },
                    { 11602, 598, 2 },
                    { 11603, 599, 2 },
                    { 11604, 600, 2 },
                    { 11605, 601, 2 },
                    { 11606, 602, 2 },
                    { 11607, 603, 2 },
                    { 11599, 595, 2 },
                    { 11567, 567, 2 },
                    { 11092, 588, 7 },
                    { 11591, 587, 2 },
                    { 11572, 568, 2 },
                    { 11569, 569, 2 },
                    { 11573, 569, 2 },
                    { 11570, 570, 2 },
                    { 11574, 570, 2 },
                    { 11571, 571, 2 },
                    { 11575, 571, 2 },
                    { 11576, 572, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 10592, 588, 8 },
                    { 11577, 573, 2 },
                    { 11579, 575, 2 },
                    { 11580, 576, 2 },
                    { 11581, 577, 2 },
                    { 11582, 578, 2 },
                    { 11583, 579, 2 },
                    { 11584, 580, 2 },
                    { 10591, 587, 8 },
                    { 11091, 587, 7 },
                    { 11578, 574, 2 },
                    { 950, 450, 8 },
                    { 1949, 449, 2 },
                    { 1449, 449, 7 },
                    { 1410, 410, 7 },
                    { 1910, 410, 2 },
                    { 2410, 410, 4 },
                    { 1411, 411, 7 },
                    { 1912, 412, 2 },
                    { 1916, 416, 2 },
                    { 1917, 417, 2 },
                    { 1918, 418, 2 },
                    { 910, 410, 8 },
                    { 1919, 419, 2 },
                    { 1921, 421, 2 },
                    { 1922, 422, 2 },
                    { 1923, 423, 2 },
                    { 1924, 424, 2 },
                    { 1925, 425, 2 },
                    { 1926, 426, 2 },
                    { 2426, 426, 4 },
                    { 927, 427, 8 },
                    { 1920, 420, 2 },
                    { 1427, 427, 7 },
                    { 2409, 409, 4 },
                    { 1409, 409, 7 },
                    { 2400, 400, 4 },
                    { 2900, 400, 5 },
                    { 3400, 400, 6 },
                    { 401, 401, 1 },
                    { 901, 401, 8 },
                    { 1401, 401, 7 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1901, 401, 2 },
                    { 2401, 401, 4 },
                    { 1909, 409, 2 },
                    { 2901, 401, 5 },
                    { 1902, 402, 2 },
                    { 1903, 403, 2 },
                    { 1904, 404, 2 },
                    { 905, 405, 8 },
                    { 906, 406, 8 },
                    { 907, 407, 8 },
                    { 908, 408, 8 },
                    { 909, 409, 8 },
                    { 3401, 401, 6 },
                    { 1927, 427, 2 },
                    { 2427, 427, 4 },
                    { 928, 428, 8 },
                    { 1936, 436, 2 },
                    { 2436, 436, 4 },
                    { 937, 437, 8 },
                    { 1437, 437, 7 },
                    { 1937, 437, 2 },
                    { 2437, 437, 4 },
                    { 438, 438, 1 },
                    { 938, 438, 8 },
                    { 1436, 436, 7 },
                    { 439, 439, 1 },
                    { 1940, 440, 2 },
                    { 1941, 441, 2 },
                    { 1942, 442, 2 },
                    { 1943, 443, 2 },
                    { 1447, 447, 7 },
                    { 1947, 447, 2 },
                    { 1448, 448, 7 },
                    { 1948, 448, 2 },
                    { 939, 439, 8 },
                    { 936, 436, 8 },
                    { 2435, 435, 4 },
                    { 1935, 435, 2 },
                    { 1428, 428, 7 },
                    { 1928, 428, 2 },
                    { 2428, 428, 4 },
                    { 929, 429, 8 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1429, 429, 7 },
                    { 930, 430, 8 },
                    { 1430, 430, 7 },
                    { 931, 431, 8 },
                    { 1431, 431, 7 },
                    { 1932, 432, 2 },
                    { 2432, 432, 4 },
                    { 933, 433, 8 },
                    { 1433, 433, 7 },
                    { 934, 434, 8 },
                    { 1434, 434, 7 },
                    { 1934, 434, 2 },
                    { 2434, 434, 4 },
                    { 935, 435, 8 },
                    { 1435, 435, 7 },
                    { 1764, 264, 2 },
                    { 1763, 263, 2 },
                    { 1762, 262, 2 },
                    { 1761, 261, 2 },
                    { 2002, 44, 4 },
                    { 1575, 45, 2 },
                    { 2075, 45, 4 },
                    { 1549, 46, 2 },
                    { 2049, 46, 4 },
                    { 2549, 46, 5 },
                    { 1576, 47, 2 },
                    { 1580, 48, 2 },
                    { 1551, 49, 2 },
                    { 2051, 49, 4 },
                    { 2551, 49, 5 },
                    { 1547, 50, 2 },
                    { 2047, 50, 4 },
                    { 2547, 50, 5 },
                    { 1038, 51, 7 },
                    { 1538, 51, 2 },
                    { 1548, 52, 2 },
                    { 1502, 44, 2 },
                    { 2048, 52, 4 },
                    { 1002, 44, 7 },
                    { 2, 44, 1 },
                    { 2540, 39, 5 },
                    { 1545, 40, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 2045, 40, 4 },
                    { 2545, 40, 5 },
                    { 1543, 41, 2 },
                    { 2043, 41, 4 },
                    { 2543, 41, 5 },
                    { 3, 42, 1 },
                    { 503, 42, 8 },
                    { 1003, 42, 7 },
                    { 1503, 42, 2 },
                    { 2003, 42, 4 },
                    { 1, 43, 1 },
                    { 501, 43, 8 },
                    { 1001, 43, 7 },
                    { 1501, 43, 2 },
                    { 2001, 43, 4 },
                    { 502, 44, 8 },
                    { 2548, 52, 5 },
                    { 1546, 53, 2 },
                    { 2046, 53, 4 },
                    { 1533, 64, 2 },
                    { 37, 65, 1 },
                    { 537, 65, 8 },
                    { 1037, 65, 7 },
                    { 1537, 65, 2 },
                    { 7, 66, 1 },
                    { 1558, 67, 2 },
                    { 2058, 67, 4 },
                    { 3058, 67, 6 },
                    { 1559, 68, 2 },
                    { 2059, 68, 4 },
                    { 1560, 69, 2 },
                    { 2060, 69, 4 },
                    { 1561, 70, 2 },
                    { 10108, 604, 1 },
                    { 1562, 71, 2 },
                    { 2062, 71, 4 },
                    { 1033, 64, 7 },
                    { 533, 64, 8 },
                    { 33, 64, 1 },
                    { 2031, 63, 4 },
                    { 2546, 53, 5 },
                    { 1555, 54, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 2055, 54, 4 },
                    { 2555, 54, 5 },
                    { 1539, 55, 2 },
                    { 1578, 56, 2 },
                    { 1585, 57, 2 },
                    { 2085, 57, 4 },
                    { 2040, 39, 4 },
                    { 1595, 58, 2 },
                    { 1600, 60, 2 },
                    { 2100, 60, 4 },
                    { 1579, 61, 2 },
                    { 124, 62, 1 },
                    { 31, 63, 1 },
                    { 531, 63, 8 },
                    { 1031, 63, 7 },
                    { 1531, 63, 2 },
                    { 1590, 59, 2 },
                    { 1540, 39, 2 },
                    { 2541, 38, 5 },
                    { 2041, 38, 4 },
                    { 530, 10, 8 },
                    { 1030, 10, 7 },
                    { 1530, 10, 2 },
                    { 24, 11, 1 },
                    { 22, 12, 1 },
                    { 23, 13, 1 },
                    { 20, 14, 1 },
                    { 21, 15, 1 },
                    { 9, 16, 1 },
                    { 6, 17, 1 },
                    { 5, 18, 1 },
                    { 8, 19, 1 },
                    { 4, 20, 1 },
                    { 29, 21, 1 },
                    { 529, 21, 8 },
                    { 1029, 21, 7 },
                    { 1529, 21, 2 },
                    { 30, 10, 1 },
                    { 1534, 9, 2 },
                    { 1034, 9, 7 },
                    { 534, 9, 8 },
                    { 36, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 536, 1, 8 },
                    { 1036, 1, 7 },
                    { 1536, 1, 2 },
                    { 19, 2, 1 },
                    { 17, 3, 1 },
                    { 18, 4, 1 },
                    { 16, 5, 1 },
                    { 27, 22, 1 },
                    { 15, 6, 1 },
                    { 532, 7, 8 },
                    { 1032, 7, 7 },
                    { 1532, 7, 2 },
                    { 35, 8, 1 },
                    { 535, 8, 8 },
                    { 1035, 8, 7 },
                    { 1535, 8, 2 },
                    { 34, 9, 1 },
                    { 32, 7, 1 },
                    { 1563, 72, 2 },
                    { 527, 22, 8 },
                    { 1527, 22, 2 },
                    { 2557, 32, 5 },
                    { 1554, 33, 2 },
                    { 2054, 33, 4 },
                    { 2554, 33, 5 },
                    { 1553, 34, 2 },
                    { 2053, 34, 4 },
                    { 2553, 34, 5 },
                    { 1552, 35, 2 },
                    { 2052, 35, 4 },
                    { 2552, 35, 5 },
                    { 1542, 36, 2 },
                    { 2042, 36, 4 },
                    { 2542, 36, 5 },
                    { 1544, 37, 2 },
                    { 2044, 37, 4 },
                    { 2544, 37, 5 },
                    { 1541, 38, 2 },
                    { 2057, 32, 4 },
                    { 1557, 32, 2 },
                    { 2556, 31, 5 },
                    { 2056, 31, 4 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 25, 23, 1 },
                    { 525, 23, 8 },
                    { 1025, 23, 7 },
                    { 1525, 23, 2 },
                    { 28, 24, 1 },
                    { 528, 24, 8 },
                    { 1028, 24, 7 },
                    { 1528, 24, 2 },
                    { 1027, 22, 7 },
                    { 26, 25, 1 },
                    { 1026, 25, 7 },
                    { 1526, 25, 2 },
                    { 14, 26, 1 },
                    { 12, 27, 1 },
                    { 10, 28, 1 },
                    { 13, 29, 1 },
                    { 11, 30, 1 },
                    { 1556, 31, 2 },
                    { 526, 25, 8 },
                    { 2063, 72, 4 },
                    { 2061, 70, 4 },
                    { 2064, 73, 4 },
                    { 160, 159, 1 },
                    { 161, 160, 1 },
                    { 162, 161, 1 },
                    { 163, 162, 1 },
                    { 164, 163, 1 },
                    { 165, 164, 1 },
                    { 166, 165, 1 },
                    { 167, 166, 1 },
                    { 168, 167, 1 },
                    { 169, 168, 1 },
                    { 170, 169, 1 },
                    { 171, 170, 1 },
                    { 172, 171, 1 },
                    { 173, 173, 1 },
                    { 174, 174, 1 },
                    { 175, 175, 1 },
                    { 176, 176, 1 },
                    { 159, 158, 1 },
                    { 158, 157, 1 },
                    { 157, 156, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 156, 155, 1 },
                    { 138, 137, 1 },
                    { 139, 138, 1 },
                    { 140, 139, 1 },
                    { 1564, 73, 2 },
                    { 142, 141, 1 },
                    { 143, 142, 1 },
                    { 144, 143, 1 },
                    { 145, 144, 1 },
                    { 177, 177, 1 },
                    { 146, 145, 1 },
                    { 148, 147, 1 },
                    { 149, 148, 1 },
                    { 150, 149, 1 },
                    { 151, 150, 1 },
                    { 152, 151, 1 },
                    { 153, 152, 1 },
                    { 154, 153, 1 },
                    { 155, 154, 1 },
                    { 147, 146, 1 },
                    { 137, 136, 1 },
                    { 1178, 178, 7 },
                    { 1180, 180, 7 },
                    { 1745, 245, 2 },
                    { 1746, 246, 2 },
                    { 1747, 247, 2 },
                    { 1748, 248, 2 },
                    { 1749, 249, 2 },
                    { 1750, 250, 2 },
                    { 251, 251, 1 },
                    { 751, 251, 8 },
                    { 1251, 251, 7 },
                    { 1751, 251, 2 },
                    { 1752, 252, 2 },
                    { 1753, 253, 2 },
                    { 1754, 254, 2 },
                    { 1755, 255, 2 },
                    { 1756, 256, 2 },
                    { 1757, 257, 2 },
                    { 1758, 258, 2 },
                    { 1744, 244, 2 },
                    { 742, 243, 8 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1241, 242, 7 },
                    { 1741, 241, 2 },
                    { 1181, 181, 7 },
                    { 201, 201, 1 },
                    { 1701, 201, 2 },
                    { 202, 202, 1 },
                    { 1702, 202, 2 },
                    { 1206, 208, 7 },
                    { 1706, 208, 2 },
                    { 220, 211, 1 },
                    { 1179, 179, 7 },
                    { 1714, 214, 2 },
                    { 240, 240, 1 },
                    { 740, 240, 8 },
                    { 1240, 240, 7 },
                    { 1740, 240, 2 },
                    { 2240, 240, 4 },
                    { 2740, 240, 5 },
                    { 3240, 240, 6 },
                    { 3740, 240, 3 },
                    { 219, 219, 1 },
                    { 136, 135, 1 },
                    { 141, 140, 1 },
                    { 134, 133, 1 },
                    { 1581, 85, 2 },
                    { 1582, 86, 2 },
                    { 1583, 87, 2 },
                    { 1584, 88, 2 },
                    { 1586, 89, 2 },
                    { 1587, 90, 2 },
                    { 1588, 91, 2 },
                    { 1589, 92, 2 },
                    { 1591, 93, 2 },
                    { 1592, 94, 2 },
                    { 1593, 95, 2 },
                    { 1594, 96, 2 },
                    { 1596, 97, 2 },
                    { 135, 134, 1 },
                    { 1597, 98, 2 },
                    { 2097, 98, 4 },
                    { 1598, 99, 2 },
                    { 1577, 84, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 2574, 83, 5 },
                    { 2074, 83, 4 },
                    { 1574, 83, 2 },
                    { 1565, 74, 2 },
                    { 2065, 74, 4 },
                    { 1566, 75, 2 },
                    { 2066, 75, 4 },
                    { 1567, 76, 2 },
                    { 2067, 76, 4 },
                    { 1568, 77, 2 },
                    { 2068, 77, 4 },
                    { 2098, 99, 4 },
                    { 1569, 78, 2 },
                    { 1570, 79, 2 },
                    { 2070, 79, 4 },
                    { 71, 80, 1 },
                    { 72, 81, 1 },
                    { 73, 82, 1 },
                    { 74, 83, 1 },
                    { 574, 83, 8 },
                    { 1074, 83, 7 },
                    { 2069, 78, 4 },
                    { 1599, 100, 2 },
                    { 2096, 97, 4 },
                    { 1601, 101, 2 },
                    { 1616, 116, 2 },
                    { 1617, 117, 2 },
                    { 2099, 100, 4 },
                    { 1619, 119, 2 },
                    { 1620, 120, 2 },
                    { 1621, 121, 2 },
                    { 1622, 122, 2 },
                    { 1623, 123, 2 },
                    { 125, 124, 1 },
                    { 126, 125, 1 },
                    { 127, 126, 1 },
                    { 128, 127, 1 },
                    { 129, 128, 1 },
                    { 130, 129, 1 },
                    { 131, 130, 1 },
                    { 132, 131, 1 },
                    { 133, 132, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "RolPrivilegio",
                columns: new[] { "id", "privilegioId", "rolId" },
                values: new object[,]
                {
                    { 1615, 115, 2 },
                    { 1614, 114, 2 },
                    { 1618, 118, 2 },
                    { 1612, 112, 2 },
                    { 2101, 101, 4 },
                    { 2601, 101, 5 },
                    { 1602, 102, 2 },
                    { 1613, 113, 2 },
                    { 2602, 102, 5 },
                    { 1603, 103, 2 },
                    { 2103, 103, 4 },
                    { 2603, 103, 5 },
                    { 1604, 104, 2 },
                    { 2102, 102, 4 },
                    { 2604, 104, 5 },
                    { 2104, 104, 4 },
                    { 1611, 111, 2 },
                    { 1610, 110, 2 },
                    { 1609, 109, 2 },
                    { 11608, 604, 2 },
                    { 1607, 107, 2 },
                    { 1606, 106, 2 },
                    { 1605, 105, 2 },
                    { 1608, 108, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Trabajador",
                columns: new[] { "Id", "Activo", "AfiliacionIMSS", "ApellidoMaterno", "ApellidoPaterno", "CorreoElectronico", "Domicilio", "FechaIngresoCFE", "FechaIngresoPuestoActual", "FechaNacimiento", "IdArea", "IdContrato", "IdDepartamento", "IdSituacionLaboral", "Nombre", "NombreCompleto", "RFC", "RPE", "SalarioDiarioActual", "Sexo" },
                values: new object[,]
                {
                    { 10, true, "PENDIENTE", "Ramirez", "Martinez", "remr@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9608), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9613), new DateTime(1976, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Rogelio", null, "MARR7609258X6", "4589", 0.0, "M" },
                    { 8, true, "PENDIENTE", "Castro", "González", "jmgc@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9568), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9573), new DateTime(1976, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Juan Miguel", null, "JOCJ760823HX3", "04869", 0.0, "M" },
                    { 7, true, "PENDIENTE", "López", "Hernández", "ohernandez@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9546), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9550), new DateTime(1980, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Omar", null, "HELO800503", "50650", 0.0, "M" },
                    { 6, true, "PENDIENTE", "Escobar", "Mendoza", "pmendoza@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9526), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9531), new DateTime(1964, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Pedro Rafael", null, "MEEP640111", "3589", 0.0, "M" },
                    { 5, true, "PENDIENTE", "Mejia", "Honorato", "honorato@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9498), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9502), new DateTime(1982, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Alberto", null, "HOMA821031", "5071", 0.0, "M" },
                    { 4, true, "PENDIENTE", "Camacho", "Rodríguez", "srcamacho@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9477), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9482), new DateTime(1978, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Salvador", null, "CARS780303", "4867", 0.0, "M" },
                    { 3, true, "PENDIENTE", "Briones", "Escobedo", "gescobedo@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9448), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9453), new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Guillermo Flavio", null, "ESBG800303", "5163", 0.0, "M" },
                    { 2, true, "PENDIENTE", "Grajales", "Jácome", "nejacome@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9351), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9390), new DateTime(1978, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Norma Elena", null, "JAGN780605", "4385", 0.0, "F" },
                    { 1, true, "PENDIENTE", "ADMIN", "ADMIN", "sisstproyecto@gmail.com", "", new DateTime(2022, 3, 4, 14, 2, 0, 37, DateTimeKind.Local).AddTicks(6331), new DateTime(2022, 3, 4, 14, 2, 0, 37, DateTimeKind.Local).AddTicks(6634), new DateTime(2022, 3, 4, 14, 2, 0, 35, DateTimeKind.Local).AddTicks(5435), 1, 443, null, 556, "ADMIN", null, "PENDIENTE", "00000", 0.0, "M" },
                    { 9, true, "PENDIENTE", "Rodríguez", "Figueroa", "ivan@ineel.mx", "", new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9587), new DateTime(2022, 3, 4, 14, 2, 0, 48, DateTimeKind.Local).AddTicks(9592), new DateTime(1976, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 443, null, 556, "Iván", null, "FIRI800808", "GTI01", 0.0, "M" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "Usuario",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CreatedById", "Email", "EmailConfirmed", "IsActive", "LastLoginAt", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TrabajadorId", "TwoFactorEnabled", "UpdatedAt", "UpdatedById", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9c21e30c-ab8d-435e-a370-9f61e76819a8", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(8213), null, "sisstproyecto@gmail.com", false, true, null, false, null, "SISSTPROYECTO@GMAIL.COM", "00000", "AQAAAAEAACcQAAAAEGcRuguJpyW89jqY+u9U0KI02K0AIb4CXKv+nZOuWJ5sdYISusqNYa1FJPUpA0FYIw==", null, false, "IVJATBL6BCF73ZUWLQ45EO2UM7TE3OSQ", 1, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(8589), 1, "00000" },
                    { 2, 0, "dd1b73db-fece-4137-a173-401bb609c5b7", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9335), null, "nejacome@ineel.mx", false, true, null, false, null, "NEJACOME@INEEL.MX", "4385", "AQAAAAEAACcQAAAAEGHeihe95uQRBpgHXo1FuS8x7YOMhS/cJ3KVW7RlLhmspRlMvMIp6ER3GHpMTzCZfg==", null, false, "YJUNEA6CTHIGSOOEGYO65QRPKYSVPPEL", 2, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9346), 1, "4385" },
                    { 3, 0, "320252da-6a52-4c05-93a7-093da71846b5", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9361), null, "gescobedo@ineel.mx", false, true, null, false, null, "GESCOBEDO@INEEL.MX", "5163", "AQAAAAEAACcQAAAAEJXsmlDCv4zB2gY3l37OjaKNAN6qUKJpBEedYTGXnID+GAqPN5vvTm8Kfens0uFuHA==", null, false, "2UVTWXFBH6DM4ZISCHERKBRINTJA6DUS", 3, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9365), 1, "5163" },
                    { 4, 0, "09cf4154-927f-4996-9504-51f6817fc4b9", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9376), null, "sr.camacho.ti@gmail.com", false, true, null, false, null, "SR.CAMACHO.TI@GMAIL.COM", "4867", "AQAAAAEAACcQAAAAEGcRuguJpyW89jqY+u9U0KI02K0AIb4CXKv+nZOuWJ5sdYISusqNYa1FJPUpA0FYIw==", null, false, "B3PK7KVN5BLZN5JYONIMH7U5D7A72TTU", 4, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9379), 1, "4867" },
                    { 5, 0, "e5578642-b0c0-4a32-95cd-7998b08f1cf7", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9389), null, "honorato@ineel.mx", false, true, null, false, null, "HONORATO@INEEL.MX", "5071", "AQAAAAEAACcQAAAAEMF72WbX8s2qGciq30hjqN9yHAtlBS+/UqTUdEtPPxzVrPTHaYpQGER5U20I/0sccw==", null, false, "NOR7AX6JT4F57SU5D4EX7XOQFVQT72LS", 5, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9392), 1, "5071" },
                    { 6, 0, "358b6d68-f770-48b3-8861-6d40f380129e", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9406), null, "pmendoza@ineel.mx", false, true, null, false, null, "PMENDOZA@INEEL.MX", "3589", "AQAAAAEAACcQAAAAEGE1WSowI60zQBWloIWSstNidtNZOwKc7BrgeJM5ugzU3iAq2UVDupEZaJvZIr3sHw==", null, false, "UJIRHDBUCDLAHLSDMSB6H7C4G5L33OFY", 6, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9409), 1, "3589" },
                    { 7, 0, "358b6d68-f770-48b3-8861-6d40f380129e", new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9420), null, "ohernandez@ineel.mx", false, true, null, false, null, "OHERNANDEZ@INEEL.MX", "50650", "AQAAAAEAACcQAAAAEGE1WSowI60zQBWloIWSstNidtNZOwKc7BrgeJM5ugzU3iAq2UVDupEZaJvZIr3sHw==", null, false, "UJIRHDBUCDLAHLSDMSB6H7C4G5L33OFY", 7, false, new DateTime(2022, 3, 4, 14, 2, 0, 51, DateTimeKind.Local).AddTicks(9424), 1, "50650" }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "UsuarioPrivilegio",
                columns: new[] { "id", "privilegioId", "usuarioId" },
                values: new object[,]
                {
                    { 11, 64, 7 },
                    { 9, 16, 7 },
                    { 8, 64, 6 },
                    { 7, 55, 6 },
                    { 6, 51, 6 },
                    { 5, 44, 6 },
                    { 4, 43, 6 },
                    { 3, 42, 6 },
                    { 2, 17, 6 },
                    { 1, 16, 6 },
                    { 10, 17, 7 }
                });

            migrationBuilder.InsertData(
                schema: "Autenticacion",
                table: "UsuarioRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 7, 5 },
                    { 2, 5 },
                    { 8, 4 },
                    { 7, 4 },
                    { 2, 4 },
                    { 7, 3 },
                    { 2, 3 },
                    { 2, 2 },
                    { 8, 5 },
                    { 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_IdAreaSuperior",
                schema: "Autenticacion",
                table: "Area",
                column: "IdAreaSuperior");

            migrationBuilder.CreateIndex(
                name: "IX_Area_IdAreaVerificacion",
                schema: "Autenticacion",
                table: "Area",
                column: "IdAreaVerificacion");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAdministrada_IdArea",
                schema: "Autenticacion",
                table: "AreaAdministrada",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAdministrada_IdRol",
                schema: "Autenticacion",
                table: "AreaAdministrada",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdCT",
                schema: "Autenticacion",
                table: "Departamento",
                column: "IdCT");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Autenticacion",
                table: "Rol",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolClaims_RoleId",
                schema: "Autenticacion",
                table: "RolClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPrivilegio_privilegioId",
                schema: "Autenticacion",
                table: "RolPrivilegio",
                column: "privilegioId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPrivilegio_rolId",
                schema: "Autenticacion",
                table: "RolPrivilegio",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_IdArea",
                schema: "Autenticacion",
                table: "Trabajador",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_NombreCompleto_RPE",
                schema: "Autenticacion",
                table: "Trabajador",
                columns: new[] { "NombreCompleto", "RPE" });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Autenticacion",
                table: "Usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TrabajadorId",
                schema: "Autenticacion",
                table: "Usuario",
                column: "TrabajadorId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Autenticacion",
                table: "Usuario",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioClaims_UserId",
                schema: "Autenticacion",
                table: "UsuarioClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLogins_UserId",
                schema: "Autenticacion",
                table: "UsuarioLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPrivilegio_privilegioId",
                schema: "Autenticacion",
                table: "UsuarioPrivilegio",
                column: "privilegioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPrivilegio_usuarioId",
                schema: "Autenticacion",
                table: "UsuarioPrivilegio",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RoleId",
                schema: "Autenticacion",
                table: "UsuarioRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaAdministrada",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "DepartamentoDet",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "RolClaims",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "RolPrivilegio",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "UsuarioClaims",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "UsuarioLogins",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "UsuarioPrivilegio",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "UsuarioRoles",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "UsuarioTokens",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Privilegio",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Trabajador",
                schema: "Autenticacion");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "Autenticacion");
        }
    }
}
