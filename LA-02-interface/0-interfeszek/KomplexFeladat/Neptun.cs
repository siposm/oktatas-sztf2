using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    class Neptun
    {
        public Hallgato[] Hallgatok { get; set; }
        private int hallgatoIndex;
        public int HallgatoIndex { get; } // külső lekérdezés esetén jó tudni, hogy hány értékes elemünk van

        public Neptun(int hallgatoDbSzam)
        {
            this.Hallgatok = new Hallgato[hallgatoDbSzam];
            hallgatoIndex = 0;
        }




        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -





        public void HallgatoFelvitele(Hallgato hallgato)
        {
            this.Hallgatok[hallgatoIndex++] = hallgato;
        }

        public void Jegybeiras(IOktatoFelulet hallgato, int jegy)
        {
            // Interfész referencia miatt CSAK az tehető meg, ami az interfész miatt megengedett!
            // - - - - - - - - - - - - - - -
            // Úgy is gondolhatunk erre, hogy a jegybeírás metódus megkapja az egész alapértelmezett hallgató objektumot,
            //      de mivel mi szeretnénk bizonyos dolgokat elrejteni / megszorításokat tenni, ezért 
            //      egy interfészen keresztül kezeljük a hallgatót.

            for (int i = 0; i < Hallgatok.Length; i++)
                if(Hallgatok[i].NeptunKod == hallgato.NeptunKod)
                    hallgato.ProgJegy = jegy;
                    // hallgato.Nev = "Tamás"; // erre már panaszkodik, hogy nem írható
            


        }

        public void AdatLekeres(ITOFelulet hallgato)
        {
            Console.WriteLine(">> Név: {0} [{1}]", hallgato.Nev, hallgato.NeptunKod);

            for (int i = 0; i < hallgato.TargyDb; i++)
                Console.WriteLine("\t | {0}", hallgato.Targyak[i].Nev);
        }

        public void TargyLekerdezes(IHallgatoFelulet hallgato)
        {
            hallgato.TargyListazas();
        }


        public void TelefonszamModositas(IHallgatoFelulet hallgato, string ujtelszam)
        {
            hallgato.TelefonSzam = ujtelszam;
        }

    }
}
