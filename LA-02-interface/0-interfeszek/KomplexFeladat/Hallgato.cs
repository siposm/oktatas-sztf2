using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    class Hallgato : IHallgatoFelulet, ITOFelulet, IOktatoFelulet
    {
        public Targy[] Targyak      { get; set; }
        public int TargyDb          { get; private set; } // a kötelező dolgon felül, plusz még lehet! (private set)
        public string TelefonSzam   { get; set; }
        public string Nev           { get; set; }        
        public string NeptunKod     { get; set; }

        public int ProgJegy
        {
            get
            {
                return Jegykeres(new Targy() { Nev = "Programozás II." });
            }
            set
            {
                Targyak[IndexKeres(new Targy() { Nev = "Programozás II." })].Jegy = value;
            }
        }

        private int IndexKeres(Targy targy)
        {
            for (int i = 0; i < TargyDb; i++)
                if (Targyak[i].Nev == targy.Nev)
                    return i;
            return -1;
        }

        private int Jegykeres(Targy prog)
        {
            for (int i = 0; i < Targyak.Length; i++)
            {
                if(Targyak[i].Nev == prog.Nev)
                    return Targyak[i].Jegy;
            }
            return -1;
        }

        public Hallgato(int targydarabszam)
        {
            Targyak = new Targy[targydarabszam];
            TargyDb = 0;
        }

        public void TargyFelvesz(Targy targy)
        {
            if (TargyDb < Targyak.Length)
                Targyak[TargyDb++] = targy;
        }

        public void TargyListazas()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("\tTÁRGYAK");
            Console.WriteLine("--------------------");

            for (int i = 0; i < Targyak.Length; i++)
                Targyak[i].AdatLeker();
        }
    }
}
