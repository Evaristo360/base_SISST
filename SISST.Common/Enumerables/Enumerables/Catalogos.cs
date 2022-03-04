using System;
using System.ComponentModel;
using System.Reflection;

namespace Comunes.Enumerables
{

    /// <summary>
    /// Enumeración de los catálogos
    /// 
    /// Su propósito es facilitar a los desarrolladores el obtener el catálogo deseado
    ///  Se emplea en el FRONT END, así como en las API.
    ///  
    /// Si se agregan catálogos, se debe agregar a este enum el nombre e identificador
    /// </summary>
    /// <remarks>
    /// Se obtiene con el query:
    ///		
    /// select REPLACE( Replace( Replace( Replace( Replace(Replace(Replace(Replace(nombre, '/',''), '-',''), 'é','e'), 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///			' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    /// from Catalogo.Catalogo
    /// where IdCatalogoSuperior = 0 ORDER BY Nombre
    ///		
    ///	 IMPORTANTE: si se reemplazan, asegurese de que la primera letra es mayúscula.
    /// </remarks>
    public enum enumCatalogos
    {
        Areasdemantenimiento = 3781, //  Áreas de Mantenimiento
        Actosubestandar = 1, // Acto subestándar
        Agenteextintor = 3565, // Agente extintor
        Ambitodeaplicacion = 3799, // Ámbito de aplicación
        AreasAdministrativas = 3793, // Áreas Administrativas
        Areasdeaccioncorrectiva = 2, // Áreas de acción correctiva
        Areasdealmacen = 3788, // Áreas de almacén 
        Areasdelportal = 786, // Áreas del portal
        AreasSistemasEquiposdeProceso = 3476, // Áreas/Sistemas/Equipos de Proceso 
        Categoriadelasfuentesdeabastecimiento = 3434, // Categoría de las fuentes de abastecimiento
        CategoriadeRequisitosLegales = 3641, // Categoría de Requisitos Legales
        Categoriadelaccidentado = 3, // Categoría del accidentado
        Condiciondelproceso = 4, // Condición del proceso
        Condicionsubestandar = 5, // Condición subestándar
        Confiabilidaddereddetuberia = 3470, // Confiabilidad de red de tubería
        Contrato = 6, // Contrato
        Costosfinancieros = 7, // Costos financieros
        Criteriodelesiondealtoimpacto = 8, // Criterio de lesión de alto impacto
        Danio = 9, // Daño
        Datosbasicosconcepto = 3289, // Datos básicos concepto
        Diametrosdecabezaldedescarga = 3458, // Diámetros de cabezal de descarga
        DictaminacionIMSS = 3909, // Calificación de dictaminación del IMSS enfermedades
        Diseniodeoperacion = 3538, // Diseño de operación
        Entidadesfederativas = 13, // Entidades federativas
        Equiposfijosdeextincion = 3558, // Equipos fijos de extinción
        Escolaridadterminada = 14, // Escolaridad terminada
        Estadodeoperacion = 3439, // Estado de operación
        Estadodeoperacion3 = 3442, // Estado de operación con tres opciones
        EstadosdelascorreccionesSST = 3350, // Estados de las correcciones SST
        EstadosparacuestionariosdeRL = 3824, // Estados para cuestionarios de RL
        Factordetrabajo = 15, // Factor de trabajo
        Factorpersonal = 16, // Factor personal
        Flujoderegistros = 3623, // Flujo de registros
        Formulas = 17, // Fórmulas
        Fuentedelalesionoenfermedad = 3399, // Fuente de la lesión o enfermedad
        GastoBoquilladelosequiposfijosdeextincion = 3575, // Gasto/Boquilla de los equipos fijos de extinción
        Impactopotencial = 18, // Impacto potencial
        ISO45001 = 19, // ISO 45001
        Magnitudpotencial = 20, // Magnitud potencial ESTA DESHABILITADO, Verificar su uso PRME
        Modulosdelsistema = 10, // Módulos del sistema
        Naturalezadelpuesto = 22, // Naturaleza del puesto
        Niveldeexposicion = 23, // Nivel de exposición
        Niveljerarquico = 789, // Nivel jerárquico
        Opcionesdeperiodicidad = 3598, // Opciones de periodicidad
        Origen = 3328, // Origen
        Origenpeligrointerno = 3356, // Origen del peligro
        Origenpeligroexterno = 3381, // Origen del peligro
        Partedelcuerpoafectada = 24, // Parte del cuerpo afectada
        Periodicidad = 3744, // Periodicidad
        PrioridadCentroTrabajo = 3295, // Prioridad de los centros de trabajo
        Probabilidadpotencial = 25, // Probabilidad potencial
        Procesos = 26, // Procesos
        Ramaactividad = 27, // Rama actividad
        Riesgopotencial = 34, // Riesgo potencial
        Sistemadedeteccion = 3530, // Sistema de detección
        Sistemasdeproteccionpasiva = 3587, // Sistemas de protección pasiva
        Sistemasdeproteccionportatiles = 11, // Sistemas de protección portátiles
        Sistemasfijosdeextincion = 3542, // Sistemas fijos de extinción
        Sitiodelaccidente = 28, // Sitio del accidente
        Situacionlaboral = 29, // Situación laboral
        Tipodeaccidente = 30, // Tipo de accidente
        Tipodeaccionactividadperiodica = 3616, // Tipo de acción-actividad periódica
        Tipodecontacto = 3410, // Tipo de contacto
        Tipodedocumento = 3671, // Tipo de documento
        Tipodegeneradordepresion = 3606, // Tipo de generador de presión
        Tipodeincapacidad = 31, // Tipo de incapacidad
        //Tipodeinstalacion = 12, // Tipo de instalación
        Tipodelesion = 32, // Tipo de lesión
        Tipodenecesidad = 33, // Tipo de necesidad
        Tipodepeligros = 3391, // Tipo de peligros
        Tipodereddetuberia = 3452, // Tipo de red de tubería
        Tipodeincidente = 3726, // Tipo incidente
        Tipoomododeoperacion = 3443, // Tipo o modo de operación
        Tiposdeevidencias = 3755, // Tipos de evidencias
        Tiposdefuentesdeabastecimiento = 3428, // Tipos de fuentes de abastecimiento
        Tiposdehidrantes = 3611, // Tipos de hidrantes
        Tiposdeobligacion = 3739, // Tipos de obligación
        Tiposderequisitos = 3730, // Tipos de requisitos
        RecomendacionCompaniaAsegurador = 3815, // RecomendacionComapniaAsegurador
        Tiposdeverificacion = 3750, // Tipos de verificación
        TiposdeEventoIncidentes = 3860, // Tipos de eventos incidentes
        Origendelanecesidad = 3299, //
        Niveldeinversion = 3304, //
        Origenderecursosfinancieros = 3481, //
        Tipodocumentosproyectosdeseguridad = 3485, //
        Riesgoasociadoconnecesidadesdeproyectos = 3309, //
        Estadodelasnecesidades = 3510, //       

        Procesosdistribucion = 3491, // Para CSH
        EstadosExpedientesRL = 3831, // Estados Expedientes Requisitos Legales

        ElementosActividadesProgramasSST = 3919	,//	Elementos-Actividades Programas SST
        Liderazgo = 3920,//	Liderazgo
        Medidaspreventivocorrectivas = 3921,//	Medidas preventivo-correctivas
        Comisionesdeseguridadehigiene =3922,//	Comisiones de seguridad e higiene
        Supervisioneseinspecciones = 3923,//	Supervisiones e inspecciones
        Promociondelaseguridad = 3924,//	Promoción de la seguridad
        Reglasynormas = 3925,//	Reglas y normas
        Reunionesdegrupo = 3926,//	Reuniones de grupo
        Equiposdeproteccion = 3927,//	Equipos de protección
        Preparacionparaemergencias = 3928	,//	Preparación para emergencias
        Identificaciondepeligros = 3929,//	Identificación de peligros
        Contratistasyvisitantes = 3930,//	Contratistas y visitantes
        Higieneeneltrabajo = 3931,//	Higiene en el trabajo

        RecursosProgramasSST = 3505, // Recursos Programas SST
        Financieros = 3507, // Financieros
        Humanos = 3506, // Humanos
        Materiales = 3508, // Materiales
        Tecnologicos = 3509, // Tecnológicos
        ProgramasSST = 3999, // Programas SST

        EvaluacionProgramasSST = 4000, // Evaluación Programas SST
        CumpleNocumple = 4002, // Cumple / No cumple
        ProgramadoRealizado = 4001, // Programado / Realizado

        EstadosdelaevaluaciondeprogramasSST = 3521,
        Estadodelaevaluaciondelaevidencia = 3525,

        //Laboratorio
        Subrama = 4014, // Ruido / Iluminación
        Prioridad = 4017, // Alto / Normal
        Vigencia = 4020, // 2 años / No aplica
        EstadosServicio = 4023, // En proceso / Cerrado eficaz / Cerrado ineficaz / Vencido / Cancelado

        //Actas
        EstadoActa = 4037,       // En proceso / Cerrada /

        // Brigadas de los simulacros 
        Brigadas = 4041,  // Contra incendio // Evacuación // Primeros auxilios // Busqueda y rescate // otras

        // Medición y vigilancia
        Origendelafuentededatos = 3516, //Origen de la fuenta de datos

        // Objetivos de la observacion de tareas
        ObjetivosObservacion = 4047
    } 

    /// <summary>
    /// Enumeración de los procesos 
    /// 
    /// Un usuario debe tener asociado el proceso al que pertenece, siendo alguna de las opciones de este enum, 
    /// exceptuando Todos; al Administrador tampoco le aplica.
    /// Su propósito es facilitar a los desarrolladores el obtener el catálogo deseado.
    /// Se emplea en el FRONT END, así como en las API
    /// 
    /// Son opciones que pertenecen a un catálogo y potencialmente pueden ser 
    /// modificados por el usuario. En caso de que se agreguen opciones a esté catálogo desde el Front End
    /// se debe modificar este enum agregando la opción
    /// </summary>
    public enum enumProcesos
    {
        Todos = 0, // Opción requerida para indicar que aplica a todos los procesos una opción de un catálogo
                   // VERIFICAR SI TIENE UTILIDAD al finalizar el desarrollo, en caso de que no eliminarlo.
        Corporativo = 102, // AD Corporativo
        Construccion = 103, // CT Construcción
        Distribucion = 104, // DD Distribución
        DirFinanzas = 105, // DF Dir. Finanzas
        Generacion = 106, // GN Generación
        LagunaVerde = 107, // LV Laguna verde
        SuministroBasico = 108, // SB Suministro básico
        SeguridadFisica = 109, // SF Seguridad física
        Transmision = 110, // TT Transmisión
        Energeticos = 111, // TV Energéticos
        Control = 112, // WT Control
        MDE = 3288, // Para datos básicos.
        
    }

    /// <summary>
    /// Enumeración de los origenes de Incidentes automáticos, que no se usan en la lista desplegable
    /// 
    /// Se obtiene con:
    ///		select REPLACE( Replace( Replace( Replace( Replace(nombre, 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///				' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    ///		from Catalogo.Catalogo
    ///		where IdCatalogoSuperior = 3328 
    ///		AND Estado = 0 ORDER BY Nombre
    /// </summary>
    public enum enumOrigenAutomaticos
    {
        Actosubestandardedanioenequipomaterialomedioambiente = 3843, // Acto subestándar de daño en equipo, material o medioambiente
        Actosubestandardeincidentecondeteriorodelasalud = 3837, // Acto subestándar de incidente con deterioro de la salud
        Actosubestandardeincidenteconlesion = 3804, // Acto subestándar de incidente con lesión
        Actosubestandardeincidenteconlesionacontratista = 3849, // Acto subestándar de incidente con lesión a contratista
        Actosubestandardeincidentesinlesion = 3810, // Acto subestándar de incidente sin lesión
        Analisisdelastareascriticas = 3622, // Análisis de las tareas críticas
        areadeaccioncorrectivapordanioenequipomaterialomedioambiente = 3847, // Área de acción correctiva por daño en equipo, material o medioambiente
        areadeaccioncorrectivaporincidentecondeteriorodelasalud = 3841, // Área de acción correctiva por incidente con deterioro de la salud
        areadeaccioncorrectivaporincidenteconlesion = 3808, // Área de acción correctiva por incidente con lesión
        areadeaccioncorrectivaporincidenteconlesionacontratista = 3853, // Área de acción correctiva por incidente con lesión a contratista
        areadeaccioncorrectivaporincidentesinlesion = 3814, // Área de acción correctiva por incidente sin lesión
        Condicionsubestandardedanioenequipomaterialomedioambiente = 3842, // Condición subestándar de daño en equipo, material o medioambiente
        Condicionsubestandardeincidentecondeteriorodelasalud = 3836, // Condición subestándar de incidente con deterioro de la salud
        Condicionsubestandardeincidenteconlesion = 3803, // Condición subestándar de incidente con lesión
        Condicionsubestandardeincidenteconlesionacontratista = 3848, // Condición subestándar de incidente con lesión a contratista
        Condicionsubestandardeincidentesinlesion = 3809, // Condición subestándar de incidente sin lesión
        Danioaequipomaterialomedioambiente = 3339, // Daño a equipo, material o medioambiente
        Evaluaciondesimulacros = 3340, // Evaluación de simulacros
        Factordetrabajodedanioenequipomaterialomedioambiente = 3844, // Factor de trabajo de daño en equipo, material o medioambiente
        Factordetrabajodeincidentecondeteriorodelasalud = 3838, // Factor de trabajo de incidente con deterioro de la salud
        Factordetrabajodeincidenteconlesion = 3805, // Factor de trabajo de incidente con lesión
        Factordetrabajodeincidenteconlesionacontratista = 3850, // Factor de trabajo de incidente con lesión a contratista
        Factordetrabajodeincidentesinlesion = 3811, // Factor de trabajo de incidente sin lesión
        Factorpersonaldedanioenequipomaterialomedioambiente = 3845, // Factor personal de daño en equipo, material o medioambiente
        Factorpersonaldeincidentecondeteriorodelasalud = 3839, // Factor personal de incidente con deterioro de la salud
        Factorpersonaldeincidenteconlesion = 3806, // Factor personal de incidente con lesión
        Factorpersonaldeincidenteconlesionacontratista = 3851, // Factor personal de incidente con lesión a contratista
        Factorpersonaldeincidentesinlesion = 3812, // Factor personal de incidente sin lesión
        Identificaciondepeligros = 3341, // Identificación de peligros
        Incidentescondeteriorodelasalud = 3342, // Incidentes con deterioro de la salud
        Incidentesconlesion = 3343, // Incidentes con lesión
        Incidentesconlesionapersonalcontratista = 3344, // Incidentes con lesión a personal contratista
        Incidentessinlesion = 3345, // Incidentes sin lesión
        Infraestructura = 3346, // Infraestructura
        Necesidadsistemapordanioenequipomaterialomedioambiente = 3846, // Necesidad sistema por daño en equipo, material o medioambiente
        Necesidadsistemaporincidentecondeteriorodelasalud = 3840, // Necesidad sistema por incidente con deterioro de la salud
        Necesidadsistemaporincidenteconlesion = 3807, // Necesidad sistema por incidente con lesión
        Necesidadsistemaporincidenteconlesionacontratista = 3852, // Necesidad sistema por incidente con lesión a contratista
        Necesidadsistemaporincidentesinlesion = 3813, // Necesidad sistema por incidente sin lesión
        Observaciondecomportamiento = 3347, // Observación de comportamiento
        Observaciondetareacritica = 3348, // Observación de tarea crítica
        Requisitoslegales = 3349, // Requisitos legales
        Reunionesdedifusion = 3620, // Reuniones de difusión
        Simulacrosdeplanesdeemergencia = 3621, // Simulacros de planes de emergencia

        RecorridoDeCSH = 3515, // enum para F13 en Programas.Actas
    }

    /// <summary>
    /// Enumeración unicamente de los origenes de Incidentes
    /// </summary>
    public enum enumOrigenIncidentes
    {
        Actosubestandardedanioenequipomaterialomedioambiente = 3843, // Acto subestándar de daño en equipo, material o medioambiente
        Actosubestandardeincidentecondeteriorodelasalud = 3837, // Acto subestándar de incidente con deterioro de la salud
        Actosubestandardeincidenteconlesion = 3804, // Acto subestándar de incidente con lesión
        Actosubestandardeincidenteconlesionacontratista = 3849, // Acto subestándar de incidente con lesión a contratista
        Actosubestandardeincidentesinlesion = 3810, // Acto subestándar de incidente sin lesión
        //Analisisdelastareascriticas = 3622, // Análisis de las tareas críticas
        areadeaccioncorrectivapordanioenequipomaterialomedioambiente = 3847, // Área de acción correctiva por daño en equipo, material o medioambiente
        areadeaccioncorrectivaporincidentecondeteriorodelasalud = 3841, // Área de acción correctiva por incidente con deterioro de la salud
        areadeaccioncorrectivaporincidenteconlesion = 3808, // Área de acción correctiva por incidente con lesión
        areadeaccioncorrectivaporincidenteconlesionacontratista = 3853, // Área de acción correctiva por incidente con lesión a contratista
        areadeaccioncorrectivaporincidentesinlesion = 3814, // Área de acción correctiva por incidente sin lesión
        Condicionsubestandardedanioenequipomaterialomedioambiente = 3842, // Condición subestándar de daño en equipo, material o medioambiente
        Condicionsubestandardeincidentecondeteriorodelasalud = 3836, // Condición subestándar de incidente con deterioro de la salud
        Condicionsubestandardeincidenteconlesion = 3803, // Condición subestándar de incidente con lesión
        Condicionsubestandardeincidenteconlesionacontratista = 3848, // Condición subestándar de incidente con lesión a contratista
        Condicionsubestandardeincidentesinlesion = 3809, // Condición subestándar de incidente sin lesión
        Danioaequipomaterialomedioambiente = 3339, // Daño a equipo, material o medioambiente
        //Evaluaciondesimulacros = 3340, // Evaluación de simulacros
        Factordetrabajodedanioenequipomaterialomedioambiente = 3844, // Factor de trabajo de daño en equipo, material o medioambiente
        Factordetrabajodeincidentecondeteriorodelasalud = 3838, // Factor de trabajo de incidente con deterioro de la salud
        Factordetrabajodeincidenteconlesion = 3805, // Factor de trabajo de incidente con lesión
        Factordetrabajodeincidenteconlesionacontratista = 3850, // Factor de trabajo de incidente con lesión a contratista
        Factordetrabajodeincidentesinlesion = 3811, // Factor de trabajo de incidente sin lesión
        Factorpersonaldedanioenequipomaterialomedioambiente = 3845, // Factor personal de daño en equipo, material o medioambiente
        Factorpersonaldeincidentecondeteriorodelasalud = 3839, // Factor personal de incidente con deterioro de la salud
        Factorpersonaldeincidenteconlesion = 3806, // Factor personal de incidente con lesión
        Factorpersonaldeincidenteconlesionacontratista = 3851, // Factor personal de incidente con lesión a contratista
        Factorpersonaldeincidentesinlesion = 3812, // Factor personal de incidente sin lesión
        //Identificaciondepeligros = 3341, // Identificación de peligros
        Incidentescondeteriorodelasalud = 3342, // Incidentes con deterioro de la salud
        Incidentesconlesion = 3343, // Incidentes con lesión
        Incidentesconlesionapersonalcontratista = 3344, // Incidentes con lesión a personal contratista
        Incidentessinlesion = 3345, // Incidentes sin lesión
        //Infraestructura = 3346, // Infraestructura
        Necesidadsistemapordanioenequipomaterialomedioambiente = 3846, // Necesidad sistema por daño en equipo, material o medioambiente
        Necesidadsistemaporincidentecondeteriorodelasalud = 3840, // Necesidad sistema por incidente con deterioro de la salud
        Necesidadsistemaporincidenteconlesion = 3807, // Necesidad sistema por incidente con lesión
        Necesidadsistemaporincidenteconlesionacontratista = 3852, // Necesidad sistema por incidente con lesión a contratista
        Necesidadsistemaporincidentesinlesion = 3813, // Necesidad sistema por incidente sin lesión
        //Observaciondecomportamiento = 3347, // Observación de comportamiento
        //Observaciondetareacritica = 3348, // Observación de tarea crítica
        ////Requisitoslegales = 3349, // Requisitos legales
        //Reunionesdedifusion = 3620, // Reuniones de difusión
        //Simulacrosdeplanesdeemergencia = 3621, // Simulacros de planes de emergencia
    }


    public enum enumPathFile1 : int
    {
        [Description("Gestion\\F13")]
        GestionF13 = 1,
        [Description("Gestion\\IdenPeligros")]
        GesttionIdenPeligros = 2,
        [Description("Gestion\\EvalRiesGrupal")]
        GesttionEvalRiesGrupal = 3,
        [Description("Incidentes\\ConLesion")]
        IncidentesConLesion = 4,
        [Description("Gestion\\RL")]
        RequisitosLegales = 5,
        [Description("Gestion\\UI")]
        EvaluacionUI = 6,
        [Description("Gestion\\Programas")]
        ProgramasSST = 7,
        [Description("Gestion\\Difusion")]
        Difusion = 8,
    }

    /// <summary>
    /// Se refiere a los estados que se tienen en los flujos de procesos
    /// 
    /// Son opciones que pertenecen a un catálogo y potencialmente pueden ser 
    /// modificados por el usuario. En caso de que se agreguen opciones a esté catálogo desde el Front End
    /// se debe modificar este enum agregando la opción.
    /// 
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// 
    /// </summary>
    public enum enumFlujoRegistro
    {
        Borrador = 3624, // Borrador
        Pendienteaprobacion = 3626, // Pendiente aprobación
        Pendienterevision = 3625, // Pendiente revisión
        Sustituido = 3628, // Sustituido
        Vigente = 3627, // Vigente
        Sincoordinador = 3636 // Sin coordinador
    }

    /// <summary>
    /// Se refiere a los estados que se tienen las correciones SST
    /// 
    /// Son opciones que pertenecen a un catálogo y potencialmente pueden ser 
    /// modificados por el usuario. En caso de que se agreguen opciones a esté catálogo desde el Front End
    /// se debe modificar este enum agregando la opción.
    /// 
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// 
    /// </summary>
    public enum enumEstadoCorreccionesSST
    {
        Cerrada = 3354, // Cerrada
        Ejecutada = 3353, // Ejecutada
        Enelaboracion = 3725, // En elaboración
        Enproceso = 3352, // En proceso
        Elaborada = 3351, // Pendiente programar
        Vencida = 3355, // Vencida
    }

    /// <summary>
    /// Se refiere a los estados que se tienen en los cuestionarios de Req Legales
    /// 
    /// Son opciones que pertenecen a un catálogo y potencialmente pueden ser 
    /// modificados por el usuario. En caso de que se agreguen opciones a esté catálogo desde el Front End
    /// se debe modificar este enum agregando la opción.
    /// 
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// 
    /// </summary>
    public enum enumEstadoCuestionariosRL
    {
        EnElaboracion = 3825,
        Publicado = 3826, 
        NoPublicado = 3827,         
    }

    /// <summary>
    /// Se refiere a los estados que se tienen al contestar cuestionarios de Req Legales    
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// </summary>
    public enum enumEstadoContestaCuestionariosRL
    {
        Iniciado = 3829,
        Terminado = 3830,        
    }

    /// <summary>
    /// Se refiere a los estados que se tienen al contestar cuestionarios de Req Legales    
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// </summary>
    public enum enumEstadoExpedienteRL
    {
        //Borrador = 3832,
        EnElaboracion = 3832,
        Elaborado = 3833,
        Vigente = 3834,
        Sustituido = 3835
    }

    /// <summary>
    /// Se refiere al id del valor de tipo de respuesta que se tomará como válido para que la respuesta considere los requisitos aplicables de la pregunta contestada en los cuestionarios de Req Legales    
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// </summary>
    public enum enumIdValorTipoRespuestaParaGenerarAplicabilidadRL
    {
        Si = 5,
        No = 6,        
    }

    /// <summary>
    /// Roles en el sistema
    /// 
    /// Se obtiene con 
    ///		SELECT [NormalizedName] + ' = ' + CONVERT(VARCHAR,[Id]) +', // ' + [Descripcion]
    ///		from[Autenticacion].[Rol]
    ///		Order BY[NormalizedName]
    /// </summary>
    public enum enumRol
    {
        ADMIN = 1, // El Administrador tiene acceso al Panel de control general del sistema.
        AP = 6, // Aprobador 
        CSH = 5, // Integrante de la CSH 
        Invitado = 3, // Usuario invitado
        JDT = 4, // Jefe de Departamento Técnico 
        RSA = 2, // Responsable de Seguridad del Área
        RSN = 8, // Responsable de seguridad nacional
        RSR = 7, // Responsable de seguridad regional
        GERLAB = 10, // Gerente Laboratorio
        METLAB = 11 // Metrólogo Laboratorio
    }

    public enum enumConfiguracion
    {
        RutaFisicaArchivos = 1,
        MaxMegasParaArchivos = 2,
        maxMegasArchivosModuloIncidentes = 3,
        urlFrontEnd = 4,
        RutaFisicaArchviosDatosBasicos = 5,
        RutaFisicaArchviosEvidencias = 6,
        maxMegasArchivosEvidencias = 7,

    }

    public enum enumCatalogoSuperiorRL
    {
        TiposDeRequisitos = 3730, //Lista de tipos de requisitos para Norma
        TiposDeObligacion = 3739, //Lista de tipos de obligación para punto Norma
        Periodicidad = 3744, //Periodicidad para punto Norma
        TiposDeVerificacion = 3750, //Tipos de verificación para punto Norma
        TiposDeEvidencia = 3755, //Tipos de evidencia para punto Norma
       // PeriodicidadNoAplica = 3745,//Id de periodicidad No aplica
       // TipoEvidenciaNoAplica = 3756, //Id del tipo de evidencia No aplica
       // TipoVerificacionNoAplica = 3751, //Id del tipo de verificación No aplica
        Ambitos = 3799,//Ámbito de aplicación
        SubModulosSistema = 3854,//Para el módulo de bitácora
    }

    public enum enumTiposDeVerificacion
    {
        NoAplica = 3751,
        Documental = 3752,
        Entrevista = 3753,
        Registral = 3754,
        Fisica = 3899
    }

    

    public enum enumAmbitosRL
    {
        AmbitoFederal = 3800,
        AmbitoEstatal = 3801,
        AmbitoMunicipal = 3802
    }

    public enum enumSubmodulosBitacora
    {
        Incidentes = 3855,
        CorreccionesSST = 3856,
        RequisitosLegales = 3857,
        DatosBasicos = 3858,
        DiagnosticoInfraestructura = 3822,
        ProyectosSeguridad = 3823
    }

    /// <summary>
    /// Se refiere a los estados que se tienen los servicios de Laboratorio
    /// 
    /// Son opciones que pertenecen a un catálogo y potencialmente pueden ser 
    /// modificados por el usuario. En caso de que se agreguen opciones a esté catálogo desde el Front End
    /// se debe modificar este enum agregando la opción.
    /// 
    /// Los nombres de los enum no deben cambiar, dado que son los que se utilizan en el flujo de proceso
    /// 
    /// </summary>
    public enum enumEstadosServicio
    {
        EnElaboracion = 4034, // En elaboración
        EnProceso = 4024, // En proceso
        CerradoEficaz = 4025, // Cerrado eficaz
        CerradoIneficaz = 4026, // Cerrado ineficaz
        Vencido = 4027, // Vencido
        Cancelado = 4028, // Cancelado
    }

    public enum enumTipoArchivosServicio
    {
        Archivo = 1, // Archivo
        Informe = 2, // Informe
    }

    public enum enumMessageCorreo : int
    {
        #region Correcciones SST 0 - 200
        //Message Correcciones SST 0-200
        //Asunto // Message // Segundo Mensaje
        [Description("Asignación de nueva corrección de SST//Tiene asignada la ejecución de la corrección con id: //Favor de programar la fecha de ejecución")]
        Ejecutor = 1,

        [Description("Aviso de vencimiento de corrección de SST//Se le notifica que ha vencido el plazo programado de atención de la corrección con id: //Favor de programar la nueva fecha de ejecución")]
        Vencida = 2,

        [Description("Ejecución de corrección de SST//Se le notifica que ha sido ejecutada la corrección con id: //Favor de realizar el cierre y validar la efectividad")]
        Ejecutada = 3,

        #endregion

        #region Incidentes 201- 400
        //Message Incidentes 201- 400
        // Titulo superior // Asunto Mensaje // Segundo Mensaje
        [Description("Incidentes con lesión//Ocurrió un incidente con lesión//Favor de revisar la información correspondiente")]
        incidenteconlesion = 201,
        [Description("Incidentes sin lesión//Ocurrió un incidente sin lesión//Favor de revisar la información correspondiente")]
        incidentedinlesion = 202,
        [Description("Daños a equipo, material o medio ambiente//Ocurrió un daño a equipo, material o medio ambiente//Favor de revisar la información correspondiente")]
        daniosMateriales = 203,
        [Description("Incidentes con lesión a personal contratista//Ocurrió un incidente con lesión a personal contratista//Favor de revisar la información correspondiente")]
        contratista = 204,
        [Description("Incidentes con deterioro de la salud//Ocurrió un incidente con deterioro de la salud//Favor de revisar la información correspondiente")]
        deterioroSalud = 205,
        //Requisitos legales
        [Description("Revisar Expediente de Requisitos Legales//Se le solicita la revisión y en su caso aprobación del expediente de cumplimiento de requisitos legales con id: //Favor de revisar los requisitos aplicables")]
        revisionExpediente = 206,

        [Description("Expediente aprobado de Requisitos Legales//Se le notifica la aprobación del expediente de cumplimiento de requisitos legales con id: //Favor de revisar los requisitos aplicables")]
        aprobacionExpediente = 207,


        [Description("Expediente rechazado de Requisitos Legales//Se le notifica que ha sido rechazado el expediente de cumplimiento de requisitos legales con id: //Favor de revisar los requisitos aplicables")]
        rechazoExpediente = 208,
        
        
        [Description("Expediente creado/modificado de Requisitos Legales//Se le notifica la integración de nuevos elementos al expediente de cumplimiento de requisitos legales con id: //Favor de revisar los requisitos aplicables")]
        modificacionExpediente = 209,

        #endregion

        #region IPsy EGR 401- 450
        //Message IPsy EGR 401- 450
        // Titulo superior // Asunto Mensaje // Segundo Mensaje
        [Description("Identificación de peligros//Ha sido asignado como aprobador de la identificación de peligros con id: //Favor de dar seguimiento a la identificación de peligros")]
        Aprobador = 401,
        [Description("Identificación de peligros//Se le notifica que ha sido rechazada la identificación de peligros con id: //Favor de atender los motivos del rechazo de la identificación de peligros")]
        Elaborador = 402,
        [Description("Evaluación de riesgo grupal//Ha sido asignado como aprobador de la evaluación de riesgo grupal con id: //Favor de dar seguimiento a la evaluación de riesgo grupal")]
        AprobadorEGR = 403,
        [Description("Evaluación de riesgo grupal//Se le notifica que ha sido rechazada la evaluación de riesgo grupal con id: //Favor de atender los motivos del rechazo de la evaluación de riesgo grupal")]
        CoordinadorEGR = 404,
        [Description("Tareas críticas//Ha sido asignado como aprobador de la tarea crítica con id: //Favor de dar seguimiento a la tarea crítica")]
        AprobadorTC = 405,
        [Description("Tareas críticas//Se le notifica que ha sido rechazada la tarea crítica con id: //Favor de atender los motivos del rechazo de la tarea crítica")]
        ElaboradorTC = 406,

        #endregion


        #region DIPCI 501 - 600
        /*
         * Messages for Diágnstico Infraestructura Contra Incendio
         * 501 - 600
         * Tituloo superior // Asunto mensaje // Segundo mensaje
         * 
         */
        [Description("Diagnóstico de infraestructura//Tiene pendiente la aprobación de un diagnóstico de infraestructura// ")]
        DiagnosticoPendienteAprobacion = 501,  // enumFlujoRegistro.Pendienteaprobacion
        [Description("Diagnóstico de infraestructura//Se le notifica que ha sido rechazado el diagnóstico de infraestructura// ")]
        DiagnosticoRechazado = 502,             // enumFlujoRegistro.Borrador

        #endregion


        #region Evaluación UI
        /*
         * Messages for Evaluación UI
         * 701 - 720
         * Titulo superior // Asunto mensaje // Segundo mensaje
         * 
         */
        [Description("Asignación de nuevo servicio de evaluación UI//Se le ha asignado un nuevo servicio para su atención con id://Favor de dar acuse e iniciar su atención")]        
        ServicioAsignado = 701,
        [Description("Inicio de servicio de evaluación UI//Se le notifica que se ha iniciado el servicio con id://Favor de revisar y completar los expedientes para cada componente de la solicitud")]
        ServicioIniciado = 702,
        #endregion

        #region Laboratorio 601-700 
        //Message Correcciones SST 0-200
        //Asunto // Message // Segundo Mensaje
        [Description("Asignación de nuevo servicio//Tiene asignado el servicio con número: //Favor de cargar el informe")]
        ServicioEnProceso = 601,

        [Description("Aviso de vencimiento del servicio//Se le notifica que ha vencido el plazo programado del servicio: // ")]
        ServicioVencido = 602,

        [Description("Carga de informe del servicio//Se le notifica que ha sido cargado el informe del servicio: //Favor de realizar el cierre")]
        ServicioEstudioCargado = 603,

        [Description("Cierre de servicio//Se le notifica que ha sido cerrado el servicio: //Favor de responder la encuesta")]
        ServicioCierre = 604
        #endregion
    }

    public enum enumNivelJerarquico
    {
        noAsignado = 3287,
        CFE = 3632,
        Direccion = 3633,
        Gerencia = 3634,
        CentroTrabajo = 3635,        
    }

    public enum enumEventoIncidentes
    {
        conLesion = 3861, // Incidentes con Lesión
        sinLesion = 3862, // Incidentes sin Lesión
        DanioEquipo = 3863, //Daños en equipo, material o medioambiente
        DeterioroSalud = 3864, // Incidentes con deterioro de la Salud
        Contratista = 3865, // Incidentes con lesión a contratistas


    }

    public enum enumEstadoDatosBasicos
    {
        Nuevo,
        Completo,
        Cargado,
        Trayecto,
        Operativo,
        Exento,
        Recalculo
    }

    public enum enumEstadoArchivo
    {
        Nuevo = 1,
        Creado,
        Enviado,
        Estancado,
    }

    /// <summary>
    /// Enumeración de los origenes de Datos Basicos automáticos
    /// 
    /// Se obtiene con:
    ///		select REPLACE( Replace( Replace( Replace( Replace(nombre, 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///				' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    ///		from Catalogo.Catalogo
    ///		where IdCatalogoSuperior = 3328 
    ///		AND Estado = 0 ORDER BY Nombre
    /// </summary>
    public enum enumDatosBasicos
    {
        DB126_CantidadAccidentes = 3880, // 126 Cantidad de accidentes
        DB127_CantidadAccidentesTrayecto = 3881, // 127 Cantidad de accidentes en trayecto
        DB128_CantidadAccidentesExentos = 3882, // 128 Cantidad de accidentes exentos
        DB133_CantidadDefuncionesPorEnfermedadProfesional = 3887, // 133 Cantidad de defunciones por enfermedad profesional
        DB124_CantidadDiasPerdidosAccidentesTrayecto = 3878, // 124 Cantidad de días perdidos por acc. de trayecto
        DB125_CantidadDiasPerdidosAccidentesExentos = 3879, // 125 Cantidad de días perdidos por acc. exentos
        DB122_CantidadDiasPerdidosAccidentes = 3876, // 122 Cantidad de días perdidos por accidentes
        DB123_CantidadDiasPerdidosEnfermedades = 3877, // 123 Cantidad de días perdidos por enfermedades
        DB136_CantidadDiasPerdidosPorIncidentesConLesionAltoImpacto = 3890, // 136 Cantidad de días perdidos por Incidentes con lesión de alto impacto
        DB132_CantidadEnfermedades = 3886, // 132 Cantidad de enfermedades
        DB135_CantidadIncidentesConLesionAltoImpacto = 3889, // 135 Cantidad de Incidentes con lesión de alto impacto
        DB129_DiasIndemnizacionPorIncidenteMortal = 3883, // 129 Días de indemnización por accidente mortal
        DB134_DiasIndemnizacionPorDefuncionPorEnfermedadProfesional = 3888, // 134 Días de indemnización por defunción por enfermedad profesional
        DB130_DiasIndemnizacionPorIPPAccidente = 3884, // 130 Días de indemnización por IPP por accidente
        DB131_DiasIndemnizacionPorIPPEnfermedad = 3885, // 131 Días de indemnización por IPP por enfermedad
        DB30_GastosPorAccidente = 3866, // 30 Gastos por Accidente (Repercusión económica)
        DB32_AccidentesConTiempoPerdido = 3868, // 32 No. de Accidentes con Tiempo Perdido
        DB31_AccidentesDeTrabajo = 3867, // 31 No. de Accidentes de Trabajo
        DB33_AccidentesTransito = 3869, // 33 No. de Accidentes en Tránsito
        DB36_CasosRiesgosTerminados = 3872, // 36 No. de Casos de Riesgos Terminados
        DB39_Defunciones = 3875, // 39 No. de Defunciones
        DB34_DiasPerdidosPorAccidente = 3870, // 34 No. de Días Perdidos por Accidentes
        DB35_DiasPerdidosPorAccidenteTrayecto = 3871, // 35 No. de Días Perdidos por Accidentes en trayecto
        DB37_DiasSubsidiadosPorIncapacidadTiempo = 3873, // 37 No. de Días Subsidiados por Incapacidad Tiempo
        DB38_SumaPorcentajeIncapacidadTemporalRiesgo = 3874, // 38 Suma en % de Incapacidad Temporal en Riesgo

        // Distribución - Suministros básicos
        DBCACTP_CantidadAccidentesConTiempoPerdidoConAccidentesEnTrayecto = 3891, // CACTP Cantidad de Accidentes con tiempo perdido con accidentes en trayecto
        DBCAMO_CantidadAccidentesMortales = 3892, // CAMO Cantidad de accidentes mortales
        DBCAEX_CantidadAccidentesExentos = 3893, // CAEX Cantidad de accidentes exentos
        DBCDEX_CantidadDiasPerdidosPorAccidentesExentos = 3894, // CDEX Cantidad de días perdidos por accidentes exentos
        DBCTDP_CantidadDiasPerdidosPorAccidentes = 3895, // CTDP Cantidad de días perdidos por accidentes
        DBDIA_DiasIndemnizacionPorAccidentes = 3896, // CTDP Cantidad de días perdidos por accidentes

    }

    /// <summary>
    /// Enumeración de los criterios de lesion
    /// 
    /// Se obtiene con:
    ///		select REPLACE( Replace( Replace( Replace( Replace(nombre, 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///				' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    ///		from Catalogo.Catalogo
    ///		where IdCatalogoSuperior = 8 
    ///		AND Estado = 0 ORDER BY Nombre
    /// </summary>
    public enum enumCriteriosLesion
    {
        AgotamientoPorCalorIntenso = 100, // Agotamiento por calor intenso y todos los casos de golpe de calor
        AmputacionesConHueso = 89, // Amputaciones (con hueso).
        ConmocionCerebralHemorragia = 90, // Conmoción cerebral y/o hemorragia cerebral.
        DislocacionAarticulacion= 101, // Dislocación de una articulación importante
        FracturasOseasCara = 93, // Fracturas óseas de la cara, el cráneo o la muñeca navicular.
        FracturasOseasDedos = 92, // Fracturas óseas en dedos de las manos o pies; si están expuestas, compuestas o trituradas (aplastamiento).
        HerniaDeDiscos = 95, // Hernia de discos 
        InyeccionDeMaterialesExtranios = 99, // Inyección de materiales extraños
        LaceracionesTendonesCortados = 96, // Laceraciones que resultan en tendones cortados y/o una herida profunda que requiere puntadas internas.
        Lesionotraumaalosorganosinternos = 91, // Lesión o trauma a los órganos internos.
        Lesionesenlosojosquecausandanioocularopérdidadelavision = 98, // Lesiones en los ojos que causan daño ocular o pérdida de la visión
        Muerte = 88, // Muerte
        Noaplica = 87, // No aplica
        QuemaduraSegundoGradoTercerGrado = 97, // Quemadura de segundo grado (> 10% de la superficie del cuerpo) o quemaduras de tercer grado.
        RoturaCompletaTendones = 94, // Rotura completa de los tendones, ligamentos y cartílagos de las articulaciones principales 
    }

    /// <summary>
    /// Enumeración de los tipos de incidente
    /// 
    /// Se obtiene con:
    ///		select REPLACE( Replace( Replace( Replace( Replace(nombre, 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///				' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    ///		from Catalogo.Catalogo
    ///		where IdCatalogoSuperior = 3726 
    ///		AND Estado = 0 ORDER BY Nombre
    /// </summary>
    public enum enumTipoIncidente
    {
        Enprocesodedictaminacion = 3906, // En proceso de dictaminación
        Exento = 3729, // Exento
        Nodetrabajo = 3907, // No de trabajo
        Nodetrayecto = 3908, // No de trayecto
        Operativo = 3727, // Operativo
        Trayecto = 3728, // Trayecto
        Incompleto = 3914, // Incompleto
    }

    /// <summary>
    /// Enumeración de los tipos de dictaminacion
    /// 
    /// Se obtiene con:
    ///		select REPLACE( Replace( Replace( Replace( Replace(nombre, 'ñ','ni'), 'ó','o'), 'í', 'i' ),'á','a') , ' ', '')  + 
    ///				' = ' + convert(varchar, IdCatalogo) + ', // ' + Nombre
    ///		from Catalogo.Catalogo
    ///		where IdCatalogoSuperior = 3909 
    ///		AND Estado = 0 ORDER BY Nombre
    /// </summary>
    public enum enumDictaminacion
    {
        Enprocesodedictaminacion = 3910, // En proceso de dictaminación
        EnfermedadProfesional = 3911, // Enfermedad Profesional
        Noenfermedad = 3912, // No enfermedad
        Incompleto = 3913, // Incompleto

    }
    /// <summary>
    /// Enum de opciones de un dictamen completo
    /// 
    /// </summary>
    public enum enumDictamenSI
    {
        //Incidente
        Exento = 3729, // Exento
        Nodetrabajo = 3907, // No de trabajo
        Nodetrayecto = 3908, // No de trayecto
        Operativo = 3727, // Operativo
        Trayecto = 3728, // Trayecto
        //Deterioro
        EnfermedadProfesional = 3911, // Enfermedad Profesional
        Noenfermedad = 3912, // No enfermedad

    }
    /// <summary>
    /// Enum de opciones de un dictamen incompleto
    /// 
    /// </summary>
    public enum enumDictamenNO
    {
        //Incidente
        Enprocesodedictaminacion = 3906, // En proceso de dictaminación
        Incompleto = 3914, // Incompleto
        //Deterioro
        EnprocesodedictaminacionDeterioro = 3910, // En proceso de dictaminación
        IncompletoDeterioro = 3913, // Incompleto

    }

    /// <summary>
    /// Enum de opciones para el checkbox de En proceso, No trayecto, No trabajo, No enfermedad,
    /// 
    /// </summary>
    public enum enumDictamenChecbox
    {
        //Incidente
        Enprocesodedictaminacion = 3906, // En proceso de dictaminación
        Nodetrabajo = 3907, // No de trabajo
        Nodetrayecto = 3908, // No de trayecto
        Incompleto = 3914, // Incompleto
        //Deterioro
        EnprocesodedictaminacionDeterioro = 3910, // En proceso de dictaminación
        Noenfermedad = 3912, // No enfermedad
        IncompletoDeterioro = 3913 // Incompleto
    }

    /// <summary>
    /// Enum para llenar las listas desplegables de meses mediante
    /// 
    /// </summary>
    public enum enumMeses
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3,
        Abril = 4,
        Mayo = 5,
        Junio = 6,
        Julio = 7,
        Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12
    }

    /// <summary>
    /// Estados para el proceso de Agregar Requisitos Legales a expedientes de manera masiva
    /// </summary>
    public enum enumEstadoAgregaRL
    {
        Nuevo = 3901,
        ListoProcesar = 3902,
        Procesando = 3903,
        Terminado = 3904,
        Error = 3905
    }

    /// <summary>
    /// Valor de importancia de los Requisitos Legales
    /// </summary>
    public enum enumImportanciaRL
    {
        CatalogoSuperior = 3915,
        Alto = 3916,
        Medio = 3917,
        Bajo = 3918,        
    }

    /// <summary>
    /// Estados de las solicitudes de evaluación UI
    /// </summary>
    public enum enumEstadosSolicitudEvalUI
    {
        CatalogoSuperior = 4003,
        Nueva = 4004,
        EnProceso = 4005,
        Atendida = 4006,
        Cancelada = 4007
    }

    /// <summary>
    /// Tipos de evaluación de solicitudes de evaluación UI
    /// </summary>
    public enum enumTiposDictamenUI
    {
        PorCentroTrabajo = 4008,
        PorComponente = 4009,        
    }

    /// <summary>
    /// Categorías de componentes para la evaluación UI
    /// </summary>
    public enum enumCategoriasComponentesUI
    {
        CatalogoSuperior = 4010,
        Categoria1 = 4011,
        Categoria2 = 4012,
        Categoria3 = 4013,
    }


    /// <summary>
    /// Estados del servicio de evaluación UI
    /// </summary>
    public enum enumEstadosServicioEvaluacionUI
    {
        CatalogoSuperior = 4029,
        Asignado = 4030,
        EnAtencion = 4031,
        Concluido = 4032,
        Cancelado = 4033
    }


}


