using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    class Targy : IComparable
    {
        public string Nev   { get; set; }
        public int Jegy     { get; set; }
        public int Kredit   { get; set; }

        public void AdatLeker()
        {
            Console.WriteLine("NÉV: {0} - JEGY: {1} - KR: {2}", Nev,Jegy,Kredit);
        }

        public override string ToString()
        {
            return string.Format("[Targy: Nev={0}, Jegy={1}, Kredit={2}]", Nev, Jegy, Kredit);
        }

        public int CompareTo(object obj)
        {
            // kredit érték alapján rendezni
            return this.Kredit.CompareTo((obj as Targy).Kredit);
        }
    }
}
