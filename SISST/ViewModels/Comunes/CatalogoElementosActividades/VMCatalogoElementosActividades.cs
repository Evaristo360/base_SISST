using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.CatalogoElementosActividades
{
    public class VMCatalogoElementosActividades
    {
        public List<VMRecursoElemento> Recursos { get; set; }
        public List<VMRecursoElemento> Evaluaciones { get; set; }
        public List<VMCatalogoElemento> Elementos { get; set; }
        public List<VMCatalogoActividad> Actividades { get; set; }

        public string EvaluacionesJson { get; set; }
        public string RecursosJson { get; set; }
        public string ElementosJson { get; set; }
        public string ActividadesJson { get; set; }
    }

    public class VMRecursoElemento
    {
        public int id { get; set; }
        public string descripcion { get; set; }
    }
    public class VMCatalogoElemento
    {
        public int clave { get; set; }
        public string descripcion { get; set; }
    }
    public class VMCatalogoActividad
    {
        public int clave { get; set; }
        public int claveElemento { get; set; }
        public string descripcion { get; set; }
    }
}
