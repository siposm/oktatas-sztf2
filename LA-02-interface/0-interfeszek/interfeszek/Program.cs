using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 01.

namespace interfeszek
{
    interface IAlkohol
    {
        double AlkoholTartalom();
        bool Korhataros();
    }

    abstract class Alkohol
    {
        string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public Alkohol(string nev)
        {
            this.nev = nev;
        }
    }

    class SzensavasAlkohol : Alkohol , IAlkohol // sorrend fontos!!!
    {
        public SzensavasAlkohol(string nev)
            : base(nev)
        {
        }

        public double AlkoholTartalom(){return 0.53;}

        public bool Korhataros(){return false;}
    }

    class TomenyAlkohol : Alkohol, IAlkohol
    {
        public TomenyAlkohol(string nev)
            : base(nev)
        {
        }


        public double AlkoholTartalom(){return 0.789;}

        public bool Korhataros(){return false;}
    }

    class Narancsle : IAlkohol
    {
        public string Nev { get; set; }

        public double AlkoholTartalom()
        {
            return 0.0;
        }

        public bool Korhataros()
        {
            return false;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            // interface típusú gyűjteményt tudunk itt is létrehozni
            // csak úgy, mint (abs.) ősosztály esetén
            IAlkohol[] alkoholosItalok = new IAlkohol[4];
            alkoholosItalok[0] = new TomenyAlkohol("pálinka");
            alkoholosItalok[1] = new SzensavasAlkohol("somersby");
            alkoholosItalok[2] = new TomenyAlkohol("bartos ezerjó");
            alkoholosItalok[3] = new Narancsle() { Nev = "topjoy" };

            // polimorfizmus működik interface-k esetén is
            // hiszen ezen esetben CSAK késői kötéssel működnek a metódusok
            // (ha belegondolunk, korai kötés nem is működne, hiszen nincs az "ősben" kifejtve a metódus...)
            for (int i = 0; i < alkoholosItalok.Length; i++)
            {
                Console.WriteLine(alkoholosItalok[i].AlkoholTartalom());
                // figyeljük meg, hogy az i. elem NEVÉT pl. nem tudjuk elérni
                //      mert mindegyiket interface típusként kezeli!

                // ...de az IS és AS kulcsszavas varázslás itt is működik
                if( alkoholosItalok[i] is TomenyAlkohol )
                    Console.WriteLine((alkoholosItalok[i] as TomenyAlkohol).Nev);
            }

            Console.ReadLine();
        }
    }
}
