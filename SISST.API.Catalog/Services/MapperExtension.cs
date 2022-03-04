using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public static class MapperExtension
    {
        public static T MapearA<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
            );
        }
    }
}
