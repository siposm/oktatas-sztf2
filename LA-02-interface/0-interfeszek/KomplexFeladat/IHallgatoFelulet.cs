using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    interface IHallgatoFelulet
    {
        string TelefonSzam { get; set; }
        string Nev { get; }
        string NeptunKod { get; }

        void TargyListazas();
    }
}
