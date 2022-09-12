using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Dto
{
    public class TrabajadorCollection<T>
    {
        //retorna los valores por medio de un get
        public bool HasItem
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        //modelo de retornacion de datos globales 
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }

    }
}
