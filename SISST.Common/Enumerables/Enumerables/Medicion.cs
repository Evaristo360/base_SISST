using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Enumerables
{
    public enum enumOrigendelafuentededatos 
    {
        ExtraccionAutomatica = 3517,
        Calculado = 3518,
        Manual = 3519,
        SinOrigen = 3520,
        FaltaDatos = 3536,
        ExtraccionManual = 3537
    }

    /// <summary>
    /// Lista de procesos que no modifican datos en
    ///  medición y vigilancia
    /// </summary>
    public enum enumProcesosNoEditaMV
    {
        //Corporativo = 102, // AD Corporativo
        //Construccion = 103, // CT Construcción
        Distribucion = 104, // DD Distribución
        //DirFinanzas = 105, // DF Dir. Finanzas
        //Generacion = 106, // GN Generación
        //LagunaVerde = 107, // LV Laguna verde
        //SuministroBasico = 108, // SB Suministro básico
        //SeguridadFisica = 109, // SF Seguridad física
        //Transmision = 110, // TT Transmisión
        //Energeticos = 111, // TV Energéticos
        //Control = 112, // WT Control
        //MDE = 3288, // Para datos básicos.
    }

}
