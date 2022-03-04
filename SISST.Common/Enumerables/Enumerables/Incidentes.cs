using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Enumerables
{
    public enum IncidentesTablaDB
    {
        CondicionSubestandar,
        ActoSubestandar,
        FactorPersonal,
        FactorTrabajo,
        ISO45001,
        AreaAccion,
    }

    public static class IncidentesEsquema
    {
        private static string Esquema = "Incidentes";

        public static string GetTablaSubOrigen(IncidentesTablaDB tabla) => $"{Esquema}.{tabla}";

        public static IncidentesTablaDB GetTabla(enumCatalogos catalogo)
        {
            switch (catalogo)
            {
                case enumCatalogos.Actosubestandar:
                    return IncidentesTablaDB.ActoSubestandar;
                case enumCatalogos.Factordetrabajo:
                    return IncidentesTablaDB.FactorTrabajo;
                case enumCatalogos.Factorpersonal:
                    return IncidentesTablaDB.FactorPersonal;
                case enumCatalogos.ISO45001:
                    return IncidentesTablaDB.ISO45001;
                case enumCatalogos.Areasdeaccioncorrectiva:
                   return IncidentesTablaDB.AreaAccion;
                default:
                case enumCatalogos.Condicionsubestandar:
                    return IncidentesTablaDB.CondicionSubestandar;
            }
        }
    }


}
