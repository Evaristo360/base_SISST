using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Enumerables
{
    public enum enumEstadoNecesidades
    {
        EnElaboracion = 3511,
        Cerrado = 3512,
        Seguimiento = 3513,
        Eliminado = 3514
    }

    public enum enumTipoCosto // Presupuesto
    {
        Multianual = 1,
        Anual = 2
    }

    public enum enumTipoDocumentoNecesidad
    {
        Avance = 3486,
        Cierre = 3487,
        Eliminado = 3488,
        Necesidades = 3489,
        Costos = 3490
    }
}
