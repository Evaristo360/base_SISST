using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Exceptions
{
    [Serializable]
    public class NegativeResultAPIException : Exception
    {
        public NegativeResultAPIException()
        {

        }

        public NegativeResultAPIException(string message)
            : base(message)
        {

        }
    }
}
