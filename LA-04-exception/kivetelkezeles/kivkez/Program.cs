using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kivkez
{
    class Program
    {

        static int Osztas(int osztando, int oszto)
        {
            if (oszto == 0)
            {
                // probléma jelzése, de hogyan?

                return -1;
            }
            else
            {
                return osztando / oszto;
                // igen ám, de mi van, ha az osztás eredménye -1? 
                // nem tudjuk eldönteni, hogy probléma van vagy ez az eredmény...
                // megoldás, osztás2 metódussal bemutatva
            }
        }

        static int Osztas2(int osztando, int oszto, ref int eredmeny)
        {
            if (oszto == 0)
            {
                return -1; // innen tudjuk, hogy gubanc van
            }
            else
            {
                eredmeny = osztando / oszto;
                return 0; // innen tudjuk, hogy nincs gubanc
            }
        }
        // ez a megvalósítás működőképes, de sok problémát felvethet továbbra is
        // mindezek mellett pedig kényelmetlen, és bonyolulttá tud tenni alap dolgokat is, mint az osztás metódus

        static int Osztas3(int osztando, int oszto)
        {
            return osztando / oszto;
            // itt megírjuk a részproblémát megoldó metódustörzsünket
            // függetlenül attól, hogy okozhat problémát...
        }

        static void Main(string[] args)
        {

            // ------------------
            //  ( 1. ) PÉLDA
            // ------------------

            Osztas(10, 2); // ok
            // Osztas(10, 0); // nem ok


            // ------------------
            //  ( 2. ) PÉLDA
            // ------------------

            int eredmeny = 0;
            Osztas2(10, 2, ref eredmeny);

            Console.WriteLine(eredmeny);


            // ------------------
            //  ( 3. ) PÉLDA
            // ------------------


            try // try, azaz próbáljuk meg
            {
                // az olyan kódrészt, amely problematikus lehet, try blokkba tesszük
                Osztas3(10, 0);
            }
            catch (Exception) // catch, azaz kapjuk el
            {
                // az adódó hibát (amit már tudunk, hogy exception objektumként kapjuk)
                //      a .net rendszeren belül
                //      itt szépen tudunk kezelni

                Console.WriteLine("Hiba adódott!");
            }
        }
    }
}
