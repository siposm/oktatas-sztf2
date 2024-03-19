using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfesz_oroklodes
{


    interface IEladhato
    {
        int Ar { get; set; }
    }


    interface IAkciozhato
    {
        int Akcio { get; set; }
    }

        interface IExtraAkciozhato : IAkciozhato
        {
            int ExtraAkcio { get; set; }
        }






    // többszörös öröklődés (-szerű!) is megvalósítható interfészekkel
    class BoltiTermek : IEladhato , IAkciozhato
    {
        int ar;
        int akcio;

        // ár tulajdonságot az eladhatóság (IEladhato) miatt kell megvalósítani
        public int Ar
        {
            get { return this.ar; }
            set { this.ar = value; }
        }

        // akció tulajdonságot az akciózás/leértékelés (IAkciozhato) miatt kell megvalósítani
        public int Akcio
        {
            get { return akcio; }
            set { this.akcio = value; }
        }
    }



    // implementáljuk az interfészt és látható, hogy a saját (ExtraAkcio)
    //      illetve az ős tulajdonságát is beteszi (Akcio)
    class XYTermek : IExtraAkciozhato
    {
        public int ExtraAkcio
        {
            get;
            set;
        }

        public int Akcio
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BoltiTermek bt = new BoltiTermek();
            bt.Akcio = 10;
            bt.Ar = 999;
            Console.WriteLine("ár: {0}.- (-{1}%)", bt.Ar, bt.Akcio);
        }
    }
}
