using System;

namespace oroklodesteszt
{
    abstract class Ember
    {
        public string Nev { get; set; }

        public Ember(string nev)
        {
            this.Nev = nev;
        }

        // Mivel egy ember ősosztályban még nem tudom eldönteni,
        //  hogy ő majd hogyan s mi alapján fog köszönni
        //  ezért itt ezt a metódust absztrakttá teszem.
        // Majd a leszármazottakban (ld. lentebb) kifejtem.
        public abstract void Koszon();
    }

    class Hallgato : Ember
    {
        public string Neptunkod { get; set; }

        public Hallgato(string nev) : base(nev) { }

        // Itt a leszármazottban az öröklődés miatt
        //  már biztosan meg lesz az a metódus, amit az ősben definiáltam
        //  és itt már ki is fogom fejteni.
        public override void Koszon()
        {
            Console.WriteLine("Szia, Hallgató vagyok.");
        }
    }

    class Oktato : Ember
    {
        public int OktatottOrakSzama { get; set; }

        public Oktato(string nev) : base(nev) { }

        public override void Koszon()
        {
            Console.WriteLine("Üdvözlet, Oktató vagyok.");
        }
    }




    class MainClass
    {
        public static void Main(string[] args)
        {
            Oktato oktato = new Oktato("Frank Einstein")
            {
                OktatottOrakSzama = 10
            };
        }
    }
}
