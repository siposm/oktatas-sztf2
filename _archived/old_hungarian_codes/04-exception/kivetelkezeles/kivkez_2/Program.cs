using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kivkez_2
{
    class Program
    {
        static void Kiiras(string x)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("   " + x);
            Console.WriteLine("----------------------------");
        }

        static void TombKezeles()
        {
            Kiiras("Add meg a tömb méretét:");
            int[] tomb = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write("> érték: ");
                tomb[i] = int.Parse(Console.ReadLine());
            }

            Kiiras("Add meg, hányadik elem érdekel:");
            Console.WriteLine(tomb[int.Parse(Console.ReadLine())]);
        }
        
        static void Main(string[] args)
        {
            // Exception osztálynak több leszármazottja van.
            // Ez ugyan olyan származtatás mint amit mi is tanultunk!
            // Ha tudjuk, hogy milyen hibák adódnak (dobódnak) jobb és szebb ha külön kezeljük le őket!


            // Feladat:
            /* 
             * a, felhasználótól bekérni egy számot -> ez lesz a tömb mérete
             * b, felhasználótól számokat bekérve, feltölteni a tömböt
             * c, felhasználó beírhat egy számot
             * 
             */


            try
            {
                TombKezeles();
            }
            catch (FormatException e)
            {
                Console.WriteLine("HIBA - formai hibát vétettél!");
                Console.WriteLine("\nrészletek: " + e.Message);
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("HIBA - kiindexeltél a tömbből.");
            }
            finally
            {
                Console.WriteLine("Ez az ág pedig mindig le fog futni...");
            }
        }
    }
}
