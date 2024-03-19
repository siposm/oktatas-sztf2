using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    interface IOktatoFelulet
    {
        string Nev { get; }
        string NeptunKod { get; }
        int ProgJegy { get; set; }
    }
}
