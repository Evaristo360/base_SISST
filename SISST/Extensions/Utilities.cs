using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Extensions
{
    public static class Utilities
    {
        public static DateTime CalculateValidDate(this DateTime date) => (date == DateTime.MinValue || date < new DateTime(1900, 01, 01)) ? DateTime.MinValue : date;
        public static DateTime? CalculateValidDate(this DateTime? date) =>
            ((date == null) || (date == DateTime.MinValue) ||(date < new DateTime(1900, 01, 01))) ? DateTime.MinValue : date;
    }
}
