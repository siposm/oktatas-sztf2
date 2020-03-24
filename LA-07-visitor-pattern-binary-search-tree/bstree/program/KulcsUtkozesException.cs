using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class KulcsUtkozesException : Exception
    {
        public string Msg { get; set; }
    }
}
