using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la01_3_virtualis_metodusok
{
    class Program
    {
        public static void Main(string[] args)
        {
            Ember[] emberek = new Ember[3];

            emberek[0] = new Hallgato(19, "Gipsz Jakab", "ASD123");
            emberek[1] = new Hallgato(20, "Fülöp Tomi", "OPWE23");
            emberek[2] = new Oktato(19, "Sima Dezső");


            // ========================================================================================
            // Polimorfizmus bemutatása virtuális metódusokkal

            Console.WriteLine("\n=== BEMUTATKOZÁS\n");
            for (int i = 0; i < emberek.Length; i++)
            {
                emberek[i].Bemutatkozas();
            }

            // ========================================================================================
            // Polimorfizmus nem virtuális metódusokkal (így nincs polimorfizmus!)

            // Látható lefuttatva, hogy mindenkinek az Ember osztályban létrehozott metódus fut le.

            Console.WriteLine("\n=== ÜDVÖZLÉS\n");
            for (int i = 0; i < emberek.Length; i++)
            {
                emberek[i].Udvozles();
            }

            // ========================================================================================
            // virtual vs non virtual

            Console.WriteLine("\n---------------\n");
            // Nem virtuális metódusok használata.
            // 1.
            Ember e = new Ember(40, "Első Ember");
            e.Udvozles();
            // 2. a Hallgato-ban a 'new' kulcsszóval elrejtem az ős metódusát (elrejtés ~ felüldefiniálás)
            Hallgato h = new Hallgato(30, "Első Hallgató", "ASD123");
            h.Udvozles();


            // ========================================================================================
            // Típusok kezelése

            Console.WriteLine("\n---------------\n");

            int szamlalo = 0;
            for (int i = 0; i < emberek.Length; i++)
            {
                if (emberek[i] is Hallgato)
                {
                    szamlalo++;
                    (emberek[i] as Hallgato).Kiiratkozas();
                }
            }
            Console.WriteLine(szamlalo + " db hallgató volt.");


            Console.ReadLine();
        }
    }
}
