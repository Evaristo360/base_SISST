using System.ComponentModel.DataAnnotations.Schema;

namespace SISST.Autenticacion.Models
{
    public class AreaAdministrada
    {
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("Area")]
        public int IdArea { get; set; }
        [ForeignKey("Rol")]
        public int IdRol { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
        public virtual Area Area { get; set; }
        public virtual ApplicationRol Rol { get; set; }
    }
}
