using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes
{
    public class UpdateIntField
    {
        public UpdateIntField(int valor)
        {
            NewValue = valor;
        }
        public int NewValue { get; set; }
    }
}
