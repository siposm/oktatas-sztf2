using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComperableTeszt
{


    class BoltiTermek : IComparable
    {
        public int Ar { get; set; }

        public int CompareTo(object masikTermek)
        {
            // compareto-n belül ÉN tudom megmondani, hogy MI ALAPJÁN legyen a hasonlítás!
            // FYI: assembly-ben az összehasonlítás hogy van

            if ((masikTermek as BoltiTermek).Ar > this.Ar)
            {
                return -1;
            }
            else if ((masikTermek as BoltiTermek).Ar < this.Ar)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("[BoltiTermek: Ar={0}]", Ar);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BoltiTermek ATermek = new BoltiTermek(); ATermek.Ar = 1000;
            BoltiTermek BTermek = new BoltiTermek(); BTermek.Ar = 80;

            Console.WriteLine(ATermek.CompareTo(BTermek)); // A-hoz viszonyítok B-t
            Console.WriteLine(BTermek.CompareTo(ATermek)); // B-hez viszonyítok A-t
            ATermek.Ar = 80;
            Console.WriteLine(ATermek.CompareTo(BTermek)); // A-hoz viszonyítok B-t

            // ezen felül, miért jó még a compareto? --> beépített függvények ezt használják, pl array.sort
            BoltiTermek[] termekek = new BoltiTermek[10];
            Random r = new Random();
            
            // feltöltés
            for (int i = 0; i < termekek.Length; i++)
            {
                termekek[i] = new BoltiTermek
                {
                    Ar = r.Next(10000)
                };
            }

            Console.WriteLine("----- ALAP LISTA\n");
            for (int i = 0; i < termekek.Length; i++)
            {
                //Console.WriteLine(termekek[i].Ar); // toString nélkül
                Console.WriteLine(termekek[i]); // toString-gel
            }
            
            Console.WriteLine("----- RENDEZETT LISTA\n");
            Array.Sort(termekek);
            for (int i = 0; i < termekek.Length; i++)
            {
                //Console.WriteLine(termekek[i].Ar); // toString nélkül
                Console.WriteLine(termekek[i]); // toString-gel
            }
        }
    }
}
