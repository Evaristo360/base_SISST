using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SISST.Autenticacion.Models
{
    public class RolPrivilegio
    {
        //public int id { get; set; }

        //public int roleId { get; set; }

        //public ApplicationRol rol { get; set; }

        //public int privilegioId { get; set; }

        //public Privilegio privilegio { get; set; }


        public int id { get; set; }
        
        public int rolId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("rolId")]
        public virtual ApplicationRol rol { get; set; }
       
        public int privilegioId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("privilegioId")]
        public virtual Privilegio privilegio { get; set; }



    }
}
