using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Enumerables
{
    public enum enumPrivilegios
    {
        PermisoEliminarPorUsuarioSuperiorF13 = 35,
        PermisoEliminarPorUsuarioElaboradorF13 = 49,
        PermisoCambiarResponsableF13 = 46,
        permisoEditarEjecutorCorreccionSST = 54,
        permisoEditarElaboradorCorreccionSST = 33,
        permisoAgregarCorreccionSST = 32,

        permisoEditarIncidentesConLesion = 87,
        permisoEliminarIncidentesConLesion = 88,
        permisoAgregarIncidentesConLesion = 85,
        permisoActualizarDictamenIncidentesConLesion = 388,
        permisoInformeInicialDetalle = 56,


        permisoEditarIncidentesSinLesion = 91,
        permisoEliminarIncidentesSinLesion = 92,
        permisoAgregarIncidentesSinLesion = 89,


        permisoEditarIncidentesDanio = 103,
        permisoEliminarIncidentesDanio = 104,
        permisoAgregarIncidentesConDanio = 101,

        permisoEditarIncidentesDeterioro= 99,
        permisoEliminarIncidentesDeterioro = 100,
        permisoAgregarIncidentesDeterioro = 97,
        permisoActualizarDictamenIncidentesDeterioro = 389,

        permisoEditarIncidentesContratista = 95,
        permisoEliminarIncidentesContratista = 96,
        permisoAgregarIncidentesContratista = 93,


    }
}
