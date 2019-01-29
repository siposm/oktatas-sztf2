using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esemenyek
{
    // - delegáltat osztályszinten kell kezelni,
    //      tehát azzal megegyező "mélységben" hozzuk létre!
    public delegate void Metodusok ( string x );

    class Program
    {

        static void MetodusEgy(string a)
        {
            Console.WriteLine(">>" + a);
        }

        static void MetodusKetto(string b)
        {
            Console.WriteLine("Bemenet: " + b);
        }

        static void MetodusHarom(string a)
        {
            Console.WriteLine("::::::" + a);
        }

        static void SokadikMetodus(int szam1, int szam2)
        {
            Console.WriteLine(szam1 + szam2);
        }




        static void Main(string[] args)
        {
            // - egyszerűen egyesével tudunk metódusokat hívogatni
            MetodusEgy("alma");
            MetodusKetto("körte");

            // - példányt ebből is lehet létrehozni
            // - viszont fontos, hogy alapból egy metódust paraméterként át kell adni neki
            // - figyeljünk, hogy az átadott metódus (és a később feliratkoztatott metódusok)
            //      mind egyforma szignatúrával kell rendelkezzenek!
            Metodusok metodusok = new Metodusok(MetodusEgy);
            metodusok += MetodusKetto; // feliratkoztatás, "gyűjtőbe belerakás"
            metodusok += MetodusHarom;
            metodusok -= MetodusEgy; // leiratkoztatás, "gyűjtőből kivétel"


            // - erre már problémázna, mert a szignatúra nem egyezik meg
            // metodusok += SokadikMetodus;


            metodusok("barack");
            // - lefuttatva látható, hogy tulajdonképpen minden metódust "lefuttathatunk"
            //      amelyet előzetesen a "gyűjtőbe" belerakunk
        }

    }
}
