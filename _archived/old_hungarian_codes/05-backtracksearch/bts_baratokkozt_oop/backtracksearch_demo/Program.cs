using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backtracksearch
{
    class Program
    {

        static bool Ft(int szint, string xEmber)
        {
            // A mi esetünkben mindig igazat ad vissza, mondván: X ember alkalmas Y feladatra
            return true;
        }

        static bool Fk(string[] eredmenyek, string ember, int szint)
        {
            for (int i = 0; i < szint; i++)  // szint fontos, hogy csak eddig nézzük az eredményeket is
                if (eredmenyek[i] == ember)
                    return false;

            return true;
        }

        static void BTS(int szint, ref string[] E, ref bool van, int[] M, string[,] R)
        {
            int i = -1;
            while ( !van && i < M[szint] )
            {

                i++;

                if ( Ft(szint, R[szint,i]) ) // adott szinten i. ember alkalmas-e a szerepre
                {
                    if ( Fk(E, R[szint,i], szint) ) // adott ember foglalt-e már
                    {

                        E[szint] = R[szint, i];

                        if (szint == (R.GetLength(0)-1))
                            van = true;
                        else
                            BTS(szint + 1, ref E, ref van, M, R);

                    }
                }

            }
        }

        static void Main(string[] args)
        {

            /*
             * 
             * Ez a feladat a Programozás II. hivatalos jegyzetben található feladat megvalósítása.
             * 
             * Oldalamon a "Hivatalos Jegyzetek" menü alatt elérhető:
             *      http://users.nik.uni-obuda.hu/siposm/
             * 
             * Javasolt azt átnézni segédletként.
             *
             */


            string[,] R = new string[6, 3]; // ez reprezentálja magát a teljes "táblázatot"

            // FELADATKÖR 1
            R[0, 0] = "Miklós";
            R[0, 1] = "Klaudia";

            // FELADATKÖR 2
            R[1, 0] = "Zsolt";
            R[1, 1] = "Miklós";

            // FELADATKÖR 3
            R[2, 0] = "András";

            // FELADATKÖR 4
            R[3, 0] = "András";
            R[3, 1] = "Pál";
            R[3, 2] = "Zsolt";

            // FELADATKÖR 5
            R[4, 0] = "András";
            R[4, 1] = "Géza";

            // FELADATKÖR 6
            R[5, 0] = "Géza";
            R[5, 1] = "Miklós";


            // Mszint - egyes szinthez (feladatkörhöz) tartozó részmegoldások száma
            // megjegyzés: az indexelés miatt, itt eggyel kevesebb a számok értéke
            int[] M = { 1, 1, 0, 2, 1, 1 };

            // Eredmények tömb (mérete megegyezik a szintek számával, hiszen minden szinthez találhatunk 1 megoldást)
            string[] E = new string[6];

            bool van = false;

            BTS(0, ref E, ref van, M, R);

            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine(E[i]);
            }

            Console.ReadLine();

        }
    }
}
