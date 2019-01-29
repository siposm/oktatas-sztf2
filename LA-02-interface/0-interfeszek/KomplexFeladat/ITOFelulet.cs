using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    interface ITOFelulet
    {
        string TelefonSzam  { get; set; }
        string Nev          { get; set; }
        string NeptunKod    { get; set; }
        Targy[] Targyak     { get; set; }
        int TargyDb         { get; }
    }
}
