using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oroklodes
{
    // 
    // BTW: ne írjatok egy file-on belül hatvan osztályt, legyen mind külön-külön.
    // Csak az átláthatóság kedvéért tettük most egymás alá-fölé!
    // 


    class Ember
    {
        // int eletkor; + getter,setter
        public int Eletkor { get; set; }
        public string Nev { get; set; }

        // ha nincs paraméter nélküli konstruktor, a fordító tesz be magától!
        //public Ember()
        //{
        //}

        public void Bemutatkozas()
        {
            Console.WriteLine("Szia, én {0} vagyok.", Nev);
        }
    }

    class Hallgato : Ember
    {
        public string NeptunKod { get; set; }
    }

    class Oktato : Ember
    {
        public int OrakSzama { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Ember ember = new Ember();
            ember.Eletkor = 15;
            ember.Nev = "Tomi";

            Console.WriteLine(ember.Eletkor);

            // =======================================

            Hallgato hallgato = new Hallgato();
            hallgato.Nev = "Gipsz Lajos";
            hallgato.Eletkor = 11;
            hallgato.NeptunKod = "LOL123";
            Console.WriteLine(hallgato.Eletkor);
            hallgato.Bemutatkozas();
        }
    }
}
