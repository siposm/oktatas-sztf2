using System;

namespace teszt
{

    class BoltiTermek
    {
        public string Nev { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj as BoltiTermek).Nev == this.Nev)
                return true;
            else
                return false;
        }

        // egyelőre a warning elkerülése végett overrideoljuk a gethashcode-ot is
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Hallgato
    {
        public string Nev { get; set; }

        // ha nem írjuk felül az equalst, attól még alapból elérhető
        // hiszen minden az object ősosztályból származik le
        // viszont meghívása esetén nem fog úgy működni, ahogy szeretnénk
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Hallgato h1 = new Hallgato() { Nev = "Timi" };
            Hallgato h2 = new Hallgato() { Nev = "Laci" };
            Hallgato h3 = h2;


            // a == referenciát néz objektumok esetén
            // példa 1. --------------------------------------------------------

            if (h1 == h2)
                Console.WriteLine("egyenlőek");
            else
                Console.WriteLine("nem egyenlőek");

            // példa 2. --------------------------------------------------------

            if (h2 == h3)
                Console.WriteLine("egyenlőek");
            else
                Console.WriteLine("nem egyenlőek");


            // a saját osztályainkon érdemes felüldefiniálni az equals metódust
            // és saját kedvünk szerint kifejteni, hogy mikor tekinthető két objektum
            // azonosnak illetve nem azonosnak
            // példa 3. --------------------------------------------------------
            if (h1.Equals(h2))
                Console.WriteLine("egyenlőek");
            else
                Console.WriteLine("nem egyenlőek");

            BoltiTermek b1 = new BoltiTermek() { Nev = "Alma" };
            BoltiTermek b2 = new BoltiTermek() { Nev = "Kiwi" };

            if (b1.Equals(b2))
                Console.WriteLine("egyenlőek");
            else
                Console.WriteLine("nem egyenlőek");

        }
    }
}
