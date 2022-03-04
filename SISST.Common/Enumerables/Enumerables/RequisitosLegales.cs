using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Enumerables
{
    public enum enumRequisitosLegales
    {
        CatalogoTipoRespuesta = 1,        
    }

    public enum enumTiposEvaluacionExpedienteRL : int
    {
        [Description("Documental")]
        Documental = 1,
        [Description("En sitio")]
        EnSitio = 2        
    }


    public enum enumEstadosEvaluacionRL : int
    {
        [Description("Completo")]
        Completo = 1,
        [Description("Incompleto")]
        Incompleto = 2
    }


}
