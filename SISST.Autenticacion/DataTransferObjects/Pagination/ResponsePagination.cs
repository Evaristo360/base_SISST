using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Pagination
{
    public class ResponsePagination <T> where T : class
    {
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public List<T> data { get; set; }
        
        public bool disabledPagination { get; set; }  // TODO: revisar
    }
}