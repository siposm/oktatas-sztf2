using System;

namespace kivkez_4
{
    // Arra is van lehetőségünk, hogy nem közvetlenül az Exception ősosztályból
    //      származtatjuk le az osztályainkat, hanem mi magunk definiálunk egy 
    //      saját ősosztályt, és azt fogjuk kiterjeszteni szépen, ahogy itt is látjuk.
    //
    // A származtatott osztályokban pedig egyre jobban tudjuk specifikálni
    //      a hibákat és az azokhoz tartozó tulajdonságokat.       

    class SajatKivetel : Exception
    {
        public string Uzenet { get; set; }
    }

        class KiindexelesKivetel : SajatKivetel
        {
            public int KiindexelesHelye { get; set; }
        }

        class TeleTombKivetel : SajatKivetel
        {
            public int[] MelyikTombrolVanSzo { get; set; }
        }




    class Tombkezelo
    {
        private int tombIndex;
        private int[] tomb;
        private int tombMeret;

        public int TombMeret { get { return tombMeret; } }

        public Tombkezelo(int meret)
        {
            this.tombMeret = meret;
            tomb = new int[meret];
            tombIndex = 0;
        }

        public int GetTombElem(int tombIndex)
        {
            if (tombIndex < 0 || tombIndex > tomb.Length)
                throw new KiindexelesKivetel() { Uzenet = "Hiba keletkezett!", KiindexelesHelye = tombIndex };
            else
                return tomb[tombIndex];
        }

        public void AddTombElem(int elem)
        {
            if (tombIndex == tomb.Length)
                throw new TeleTombKivetel() { Uzenet = "Hiba keletkezett!", MelyikTombrolVanSzo = this.tomb };
            else
                tomb[tombIndex++] = elem;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Tombkezelo tk = new Tombkezelo(2);
            Random r = new Random();

            for (int i = 0; i < tk.TombMeret + 1; i++)
            {
                try
                {
                    tk.AddTombElem(r.Next(1000));
                    Console.WriteLine("»» [{0}]. elem: {1}", i, tk.GetTombElem(i));
                }
                catch (SajatKivetel ex)
                {
                    Console.WriteLine(ex.Uzenet);

                    // Mivel itt az ősosztályt kapjuk el, nem pedig a származtatottakat,
                    //      ezért nem is érünk el olyan dolgokat, amiket ott (a szárm.-ban) definiáltunk!
                    //
                    // Tehát itt is ugyan azok a feltételek igazak, mint a korábban megismert öröklődésnél.
                }
            }
        }
    }
}
