using System.ComponentModel;

namespace Comunes.Enumerables
{
    #region Relativos a actas

    /// <summary>
    /// Valores para los niveles de impacto aplicables al cálculo del riesgo potencial
    /// Catálogo superior enumCatalogos.Impactopotencial(18)
    /// </summary>
    public enum enumImpacto
    {
        Bajo = 57,
        Medio = 56,
        Alto = 55
    }

    /// <summary>
    /// Valores para los niveles de probabilidad aplicables al cálculo del riesgo potencial
    /// Catálogo superior enumCatalogos.Probabilidadpotencial(25)
    /// </summary>
    public enum enumProbabilidad
    {
        Bajo = 60,
        Medio = 59,
        Alto = 58
    }

    /// <summary>
    /// Valores para los niveles de riesgo potencial
    /// considerando Impacto * Probabilidad
    /// Catálogo superior enumCatalogos.Riesgopotencial(34)
    /// </summary>
    public enum enumRiesgoPotencial
    {
        Bajo = 3325,       //límite superior
        Medio = 3326,
        Alto = 3327
    }

    /// <summary>
    /// Nivel de antención.
    /// No se tiene referencia en catatalogo.catalogo
    /// </summary>
    public enum enumNivelAtencion
    {
        Primero = 1,
        Segundo = 2,
        Tercero = 3
    }

    /// <summary>
    /// Estados del flujo de actas
    /// Catálogo superior enumCatalogos.EstadoActa(4037)
    /// </summary>
    public enum enumEstadoActa
    {
        Incompleta = 4038,
        Cerrada = 4039
    }

    #endregion

    #region Relativos a la evaluación de programas, incluyendo la CSH
    public enum enumEstadoEvaluacionProgramasSST
    {
        Evaluada = 3522,
        Incompleta = 3523,
        SinEvaluacion = 3524,
        PendienteRevision = 3529
    }

    public enum enumEstadoEvaluacionEvidencia
    {
        Conforme = 3526,
        NoConforme = 3527,
        SinEvaluar = 3568
    }

    /// <summary>    
    /// Listado de procesos a los que se les evalúa por CSH
    /// Si no están en esta lista, entonces se evalúan por departamento o CT.
    /// </summary>
    public enum enumEvaluacionCSH
    {
        Distribucion = 104, // DD Distribución
        SuministroBasico = 108, // SB Suministro básico

        //Corporativo = 102, // AD Corporativo
        //Construccion = 103, // CT Construcción
        //DirFinanzas = 105, // DF Dir. Finanzas
        //Generacion = 106, // GN Generación
        //LagunaVerde = 107, // LV Laguna verde
        //SeguridadFisica = 109, // SF Seguridad física
        //Transmision = 110, // TT Transmisión
        //Energeticos = 111, // TV Energéticos
        //Control = 112, // WT Control
        //MDE = 3288, // Para datos básicos.
    }

    #endregion

}
