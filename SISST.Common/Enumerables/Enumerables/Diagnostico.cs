using System.ComponentModel;

namespace Comunes.Enumerables
{

    public enum enumTipoCentroTrabajo
    {
        NoAsignado = 15
    }

    /// <summary>
    /// Tipos de instalación
    /// 
    /// </summary>
    /// <remarks>
    ///  20210603 PRME
    ///  Se cambiaron por los que se tiene en la Diagnostico.TipoInstalacion,
    ///  con la idea de que Catalogo.TipoInstalacion y Catalogo.SubTipoInstalacion
    ///  se mudarán a Diagnostico.TipoCentroTrabajo y Diagnistico.TipoInstalacion
    /// </remarks>
    public enum enumTipoInstalacion
    {
        //CentraldeTurbogas = 3288, // Central  de Turbo gas
        //CentralCarboelectrica = 3289, // Central Carboeléctrica
        //CentraldeCicloCombinado = 3290, // Central de Ciclo Combinado
        //CentraldeCombustionInterna = 3291, // Central de Combustión Interna
        //CentralEolica = 3292, // Central Eólica
        //CentralGeotermoelectrica = 3293, // Central Geotermoeléctrica
        //CentralHidroelectrica = 3294, // Central Hidroeléctrica
        //CentralNucleoelectrica = 3295, // Central Nucleoeléctrica
        //CentralSolarfotovoltaica = 3296, // Central Solar fotovoltaica
        //CentralTermoelectrica = 3297, // Central Termoélectrica

        //CentraldeTurbogas = 22, // Central  de Turbo gas
        //CentralCarboelectrica = 23, // Central Carboeléctrica
        //CentraldeCicloCombinado = 24, // Central de Ciclo Combinado
        //CentraldeCombustionInterna = 25, // Central de Combustión Interna
        //CentralEolica = 26, // Central Eólica
        //CentralGeotermoelectrica = 27, // Central Geotermoeléctrica
        //CentralHidroelectrica = 28, // Central Hidroeléctrica
        //CentralNucleoelectrica = 29, // Central Nucleoeléctrica
        //CentralSolarfotovoltaica = 30, // Central Solar fotovoltaica
        //CentralTermoelectrica = 31, // Central Termoélectrica

        CentraldeTurbogas = 6, // Central  de Turbo gas
        CentralCarboelectrica = 7, // Central Carboeléctrica
        CentraldeCicloCombinado = 8, // Central de Ciclo Combinado
        CentraldeCombustionInterna = 9, // Central de Combustión Interna
        CentralEolica = 10, // Central Eólica
        CentralGeotermoelectrica = 11, // Central Geotermoeléctrica
        CentralHidroelectrica = 12, // Central Hidroeléctrica
        CentralNucleoelectrica = 13, // Central Nucleoeléctrica
        CentralSolarfotovoltaica = 14, // Central Solar fotovoltaica
        CentralTermoelectrica = 15, // Central Termoélectrica
    }

    /// <summary>
    /// Tipos de sistemas contra incendios, módulo DIPCI
    /// Importante, se debe mantener el orden, para que coincida en la UI
    /// </summary>
    public enum enumSistemasContraIncendios
    {
        [Description("Sistemas de detección")]
        Sistemadedeteccion = 3530, //3816, // Sistema de detección
        [Description("Sistemas fijos de extinción")]
        Sistemasfijosdeextincion = 3542,// 3817, // Sistemas fijos de extinción
        [Description("Equipos fijos de extinción")]
        Equiposfijosdeextincion = 3558, //3818, // Equipos fijos de extinción
        [Description("Hidrantes")]
        Tiposdehidrantes = 3611, //3819, // Hidrantes fijos de extinción
        [Description("Sistemas móviles")]
        Sistemasdeproteccionportatiles = 11, //3820, // Sistemas móviles
        [Description("Protecciones pasivas")]
        Protecciondepasiva = 3587, //3821, // Protección de pasiva
        [Description("Recomendaciones")]
        Recomendacion = 3816, // Recomendación por la inspección de la aseguradora o entidad de inspección
        [Description("Pruebas, inspecciones, mantenimientos")]
        Tipodeaccionactividadperiodica = 3616, //3823, // Pruebas, inspecciones, mantenimientos periódicos
    }

    /// <summary>
    /// Protección pasiva, empleado para identificarlos y poder asignar sus datos particulares
    /// </summary>
    /// <remarks>
    /// Importante:
    ///     De ajustar o cambiar los valores del enumerable, estos se deben de replicar a los métodos de validación en 
    ///     customValidation.js
    /// </remarks>
    public enum enumProteccionPasiva
    {
        Cablesdematerialretardantealfuego = 3592, // Cables de material retardante al fuego
        Charolasdecableadoconbarreraantiflama = 3594, // Charolas de cableado con barrera antiflama
        Diquedecontencion = 3588, // Dique de contención
        ExtractoresdeAire = 3595, // Extractores de Aire
        Fosacaptadoradehidrocarburo = 3589, // Fosa captadora de hidrocarburo
        MamparaMuroseparador = 3590, // Mampara/Muro separador
        Selladodepasamurosconmaterialcontrafuego = 3593, // Sellado de pasamuros con material contrafuego
        Trincheraconbarreraantiflama = 3591, // Trinchera con barrera antiflama
    }

    public enum enumTipoAccionPeriodica
    {
        Inspecciones = 3618, // Inspecciones
        Mantenimientos = 3619, // Mantenimientos
        Pruebasperiodicas = 3617, // Pruebas periódicas
    }
    public enum enumPatrones
    {
        NoASignado = 0, // 
        Redgeneraldeagua = 1, // 1 Red general de agua
        Fuentedeabastecimiento = 2, // 1.1 Fuente de abastecimiento.
        Sistemadebombeo = 3, // 1.2 Sistema de bombeo
        Bombamantenedoradepresion = 4, // 1.2.1 Bomba mantenedora de presión (bomba jockey)
        Bombaelectrica = 5, // 1.2.2 Bomba eléctrica
        Bombadecombustioninterna = 6, // 1.2.3 Bomba de combustión interna
        Indicadorinfraestructura = 7, // Indicador infraestructura de seguridad
        Tanqueelevado = 8, // 1.2.5 Tanque elevado
        Bombaparatanqueelevado = 9, // 1.2.6 Bomba para tanque elevado
        Interconexionentrelasbombas = 10, // 1.2.7 Interconexión entre las bombas de servicios generales y sistema contra incendio
        Reddetuberia = 11, // 1.3 Red de tubería
        Tieneproteccioncatodica = 12, // 1.3.1 ¿Tiene protección catódica?
        Presentalaredfugasdeconsideracion = 13, // 1.3.2 ¿Presenta la red fugas de consideración?
        Latuberiasuestadoesconfiable = 14, // 1.3.3 ¿La tubería, su estado es confiable?
        Valvulasseccionadoras = 15, // 1.4 Válvulas seccionadoras
        Porcentajedevalvulasseccionadorasenoperacion = 16, // 1.4.1 Porcentaje de valvulas seccionadoras en operación
        Totaldehidrantes = 17, // 1.5 Total de hidrantes (1.5.1. hasta 1.5.3.)
        Porcentajehidrantes = 18, // 1.5.1 Porcentaje de gabinetes en buen estado
        Porcentajedemanguerasdisponibles = 19, // 1.5.2 Porcentaje de mangueras disponibles
        Porcentajedeboquillasdisponible = 20, // 1.5.3 Porcentaje de boquillas disponible
        AreaSistemaEquipoProteger = 21, // 2 Áreas, sistemas, equipos
        AreaEspecifica = 22, // 2.1 Área especifica        
        Sistemasdedeteccion = 23, // 2.1 Sistemas de detección
        Sistemasfijosdeextencion = 24, // 2.2 Sistemas fijos de extención
        Equiposfijosdeextincion = 25, // 2.3 Equipos fijos de extinción
        Hidrantes = 26, // 2.4 Hidrantes
        Sistemasportatiles = 27, // 2.5 Sistemas pórtatiles
        Sistemasdeproteccionpasiva = 28, // 2.6 Sistemas de protección pasiva
    }

    public enum enumCondicionesDIPCI
    {
        NoAsignado = 0, // No está en Base de datos
        Volumendisponible = 1, // Volumen disponible
        Maximoflujo = 2, // Máximo flujo
        Presion = 3, // Presión
        Estadodeoperacion = 4, // Estado de operación
        Mododeoperacion = 5, // Modo de operación
        Tieneproteccion = 6, // Tiene protección
        Funcionalaproteccion = 7, // Funciona la protección
        Tienefugasdeconsideracion = 8, // Tiene fugas de consideración
        Confiabilidaddelatuberia = 9, // Confiabilidad de la tubería
        Porcentaje = 10, // Relación entre dos valores, por ejemplo: válvulas en operación/Total de válvulas 
        Diseniodeoperacion = 11, // Diseño de operación
        ManguerayBoquilla = 12, // Manguera y Boquilla
        HidrantesOperables = 13, // Gabinete en buen estado
        HidrantesParcialmenteOperables = 14, // Mangueras disponibles
        HidrantesFueraServicio = 15, // Boquillas disponibles
    }

    public enum enumTipoGeneradorPresion
    {
        Bombadecombustioninterna = 3609, // Bomba de combustión interna
        Bombaelectrica = 3608, // Bomba eléctrica
        Bombamantenedoradepresion = 3607, // Bomba mantenedora de presión (bomba jockey)
        Tanqueelevadocontraincendio = 3610, // Tanque elevado contra incendio
    }

    public enum enumTipoEvaluacionSCI
    {
        [Description ("Exacto")]
        Exacto = 3291,
        [Description("Cualquiera de los seleccionados")]
        CualquieraSeleccion = 3292,
        [Description("Cualquiera de la lista")]
        CualquieraLista = 3293,
        [Description("No aplica")]
        NoAplica = 3294
    }

    public enum enumPropiedadAEvaluarSCI
    {
        [Description ("Ponderación")]
        Ponderacion,
        [Description ("Selección")]
        Seleccion
    }
}
