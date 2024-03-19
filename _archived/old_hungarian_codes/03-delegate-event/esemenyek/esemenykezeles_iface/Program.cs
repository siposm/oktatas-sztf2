using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esemenykezeles_iface
{
    

    // = = = = = = = = = = = = = = = = = = = = = = = =
    // Első lépés:
    //      Megírjuk az autó osztályt, viszont tudjuk, hogy kell majd biztosítani 
    //      közös pontot. Emiatt csinálunk egy interface-t is.
    //
    // = = = = = = = = = = = = = = = = = = = = = = = =

    interface IUzemanyagHelyzet
    {
        void UzemanyagVisszajelzo(int mennyiseg);
    }


    class Auto
    {
        private IUzemanyagHelyzet uzemanyagHelyzet;
        
        public int Uzemanyag { get; set; }
        
        public Auto(int uzemanyag, IUzemanyagHelyzet uh)
        {
            this.Uzemanyag = uzemanyag;
            this.uzemanyagHelyzet = uh;
        }
        
        public void Verseny()
        {
            if (Uzemanyag > 0)
            {
                this.Uzemanyag -= 10;

                // visszajelzés...
                uzemanyagHelyzet.UzemanyagVisszajelzo(this.Uzemanyag);
            }
        }
    }




    // = = = = = = = = = = = = = = = = = = = = = = = =
    //
    // Sokkal sokkal később, egy másik galaxisban...
    // Csinálunk egy jelző osztályt, ami az interface-t felhasználva fogja majd elvégezni a dolgot.
    //
    // <!> Ez gyakorlatilag csak azért kell, hogy az interface problémáját,
    // miszerint nem lehet belőle példányt létrehozni, ki tudjuk kerülni.
    //
    // = = = = = = = = = = = = = = = = = = = = = = = =

    class Jelzo : IUzemanyagHelyzet
    {
        public void UzemanyagVisszajelzo(int mennyiseg)
        {
            Console.WriteLine("Az aktuális mennyiség: " + mennyiseg);
        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            IUzemanyagHelyzet jelzo = new Jelzo();
            Auto nissangtr = new Auto(80, jelzo);

            // F11-el debuggoljátok végig, és nézzétek meg, hogy mikor nem fog már "kiszólni az esemény".
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();
        }
    }
}
