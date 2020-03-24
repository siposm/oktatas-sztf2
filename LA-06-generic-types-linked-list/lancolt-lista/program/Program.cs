using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Ember
    {
        public string Nev { get; set; }
        public override string ToString()
        {
            return Nev;
        }
    }

    // - - - - - - - - - - - - - - - - -
    //
    // Nyílvántartás mondjuk személyi szám (mint azonosító)
    //      és a hozzá tartozó személy (ember)
    //
    // TKulcs = "ID", TErtek = Ember entitás
    //
    // Ahol a TErtek referencia típus kell, hogy legyen (osztály)
    //
    // - - - - - - - - - - - - - - - - -

    class EmberNyilvantartas<TKulcs,TErtek> where TErtek : class
    {
        TKulcs kulcs;
        TErtek ertek;

        public EmberNyilvantartas(TKulcs kulcs, TErtek ertek)
        {
            this.kulcs = kulcs;
            this.ertek = ertek;
        }
    }




    // - - - - - - - - - - - - - - - - -
    // Nested classes - egymásba ágyazott osztályok: https://msdn.microsoft.com/en-us/library/ms173120.aspx
    // - - - - - - - - - - - - - - - - -

    class LancoltLista<T>
    {

        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo; // nem kell getter & setter mert public
        }

        


        // #######################################
        //      BESZÚRÓ - TÖRLŐ METÓDUSOK
        // #######################################

        public void ElejereBeszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;

            fej = uj;
        }

        public void VegereBeszuras(T elem)
        {
            // to do implement #1
        }

        public void NHelyreBeszuras(T elem)
        {
            // to do implement #2
        }

        public void ElejerolTorles(T elem)
        {
            // to do implement #3
        }

        public void VegerolTorles(T elem)
        {
            // to do implement #4
        }

        public void NHelyrolTorles(T elem)
        {
            // to do implement #5
        }

        public void ListaFelszabaditasa()
        {
            // to do implement #6
        }



        // #######################################
        //      FELDOLGOZÓ METÓDUSOK
        // #######################################

        public void Bejaras()
        {
            View.HorizontalLine();

            ListaElem p = fej; // referencia mutató !
            while(p != null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }

            View.HorizontalLine();
        }

        
        private void Feldolgoz(ListaElem elem)
        {
            // Tetszőleges feldolgozó kód...
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(">\t{0} \t|" , elem.tartalom);
            Console.ResetColor();
        }
    }



    public static class View
    {
        public static void HorizontalLine()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(">---------------|");
            Console.ResetColor();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            LancoltLista<int> listam = new LancoltLista<int>();
            listam.ElejereBeszuras(10);
            listam.ElejereBeszuras(123);
            listam.ElejereBeszuras(99);
            listam.ElejereBeszuras(3);

            listam.Bejaras();


            Console.WriteLine("\n-----\n");


            LancoltLista<Ember> listam2 = new LancoltLista<Ember>();
            listam2.ElejereBeszuras(new Ember() { Nev = "Lajos" });
            listam2.ElejereBeszuras(new Ember() { Nev = "Péter" });
            listam2.ElejereBeszuras(new Ember() { Nev = "Tomi" });
            listam2.ElejereBeszuras(new Ember() { Nev = "Kinga" });

            listam2.Bejaras();







            LancoltLista<EmberNyilvantartas<string, Ember>> listam3
                = new LancoltLista<EmberNyilvantartas<string, Ember>>();
        }
    }
}
