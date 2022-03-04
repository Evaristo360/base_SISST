using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.config
{
    public class AliasWeb
    {

        public AliasWeb(string alias)
        {
            Value = alias;
        }

        public readonly string Value;
    }

    public class urlSIPC
    {

        public urlSIPC(string alias)
        {
            Value = alias;
        }

        public readonly string Value;
    }
}
