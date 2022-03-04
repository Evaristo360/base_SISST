using SISST.Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models
{
    [Serializable]
    public class DepartamentoDet
    {
        public int Id { get; set; }        
        
        [ForeignKey("Area")]
        public int IdArea { get; set; }
        
      
        public string ClaveDepto { get; set; }        

        public string Descripcion { get; set; }

        public string id_rama_actividad { get; set; }

    }
}
