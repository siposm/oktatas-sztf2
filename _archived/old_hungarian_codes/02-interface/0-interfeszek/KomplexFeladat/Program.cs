using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            Hallgato h1 = new Hallgato(2);
            h1.NeptunKod = "ASD123L";
            h1.Nev = "Kiss Lajos";
 
            // tárgyak feltöltése
            h1.TargyFelvesz(new Targy
            {
                Nev = "Programozás I.",
                Kredit = 6,
                Jegy = 0
            });
            h1.TargyFelvesz(new Targy
            {
                Nev = "Analízis I.",
                Kredit = 5,
                Jegy = 0
            });



            Neptun neptun = new Neptun(10);
            neptun.AdatLekeres(h1);



            neptun.TargyLekerdezes(h1);
        }
    }
}
