using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes
{
    public class UpdateBoolField
    {
        public UpdateBoolField(bool valor)
        {
            NewValue = valor;
        }
        public bool NewValue { get; set; }
    }
}
