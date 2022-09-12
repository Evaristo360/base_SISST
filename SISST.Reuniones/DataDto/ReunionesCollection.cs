using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.DataDto
{
    // se usa una clase generica
    public class ReunionesCollection<T>
    {
        public bool HasItem
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        //datos que se desean saber como el total de id, pagina por id y paginas totales y mas o coleecion pues
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
