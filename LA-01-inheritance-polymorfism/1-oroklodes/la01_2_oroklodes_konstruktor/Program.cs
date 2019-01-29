using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la01_2_oroklodes_konstruktor
{
    class Ember
    {
        public int Eletkor { get; set; }
        public string Nev { get; set; }

        public void Bemutatkozas()
        {
            Console.WriteLine("Szia, én {0} vagyok.", Nev);
        }

        public Ember(string nev, int eletkor)
        {
            this.Nev = nev;
            this.Eletkor = eletkor;
        }
    }

    class Hallgato : Ember
    {
        public string NeptunKod { get; set; }

        public Hallgato(string nev, int eletkor)
            : base(nev, eletkor)
        {
        }

        public Hallgato(string nev, int eletkor, string neptunkod)
            : base(nev, eletkor)
        {
            this.NeptunKod = neptunkod;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Hallgato h = new Hallgato("Lajoska", 12);
            h.NeptunKod = "WER123";
            Console.WriteLine(h.NeptunKod);
            Console.WriteLine(h.Nev);
        }
    }
}
