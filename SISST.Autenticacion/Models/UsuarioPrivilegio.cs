using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SISST.Autenticacion.Models
{
    public class UsuarioPrivilegio
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public ApplicationUser usuario { get; set; }
        public int privilegioId { get; set; }
        public Privilegio privilegio { get; set; }
    }
}
