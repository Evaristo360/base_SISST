using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Pagination
{
    public class VMPagination
    {
        public bool hasFilter { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public Dictionary <string, string> search { get; set; }
        public string columnaName { get; set; }
        public string columnaOrden { get; set; }
    }
}
