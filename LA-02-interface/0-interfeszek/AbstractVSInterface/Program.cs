using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 02.

namespace AbstractVSInterface
{

    // Megvalósítás abstract ősosztállyal
    // -------------------------------------------------------------------------
    abstract class Alkohol
    {
        public abstract double AlkoholTartalom();

        public abstract bool Korhataros();
    }

    class TomenyAlkohol : Alkohol
    {
        public override double AlkoholTartalom()
        {
            return 0.768;
        }
        public override bool Korhataros()
        {
            return true;
        }
    }








    // Megvalósítás interface-szel
    // -------------------------------------------------------------------------

    interface IAlkohol
    {
        double AlkoholTartalom();
        bool Korhataros();
    }

    public class SzensavasAlkohol : IAlkohol
    {

        public double AlkoholTartalom()
        {
            return 0.912;
        }

        public bool Korhataros()
        {
            return true;
        }
    }








    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
