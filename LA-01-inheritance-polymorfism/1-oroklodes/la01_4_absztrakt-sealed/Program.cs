using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la01_4_absztrakt_sealed
{

    abstract class FoldLako { }

    abstract class Ember : FoldLako { }
    
    class Hallgato : Ember { }
    
    class Oktato : Ember { }

    sealed class MatekOktato : Oktato { }

    // class AltalanosIskolaiMatekOktato : MatekOktato { }
    // Hibásnak jelzi.

    

    class Program
    {
        static void Main(string[] args)
        {
            // FoldLako fl = new FoldLako();
            // Hibásnak jelzi.

            // Ember em = new Ember();
            // Szintén.

            Hallgato h = new Hallgato(); // OK
            Oktato o = new Oktato(); // OK

            // Lényegében:
            // abstract >> ne lehessen példányt létrehozni belőle
            // sealed >> ne lehessen származtatni belőle
        }
    }
}
