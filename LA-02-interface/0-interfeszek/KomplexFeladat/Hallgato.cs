using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexFeladat
{
    class Hallgato : IHallgatoFelulet, ITOFelulet, IOktatoFelulet
    {
        string telefonSzam;
        string neptunKod; 
        string nev;
        Targy[] targyak;
        int targyDb;

        public Targy[] Targyak
        {
            get { return targyak; }
            set { targyak = value; }
        }
        public int TargyDb
        {
            get { return targyDb; }
            //set { targyDb = value; }
        }
        public string TelefonSzam
        {
            get { return telefonSzam; }
            set { telefonSzam = value; }
        }
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }        
        public string NeptunKod
        {
            get { return neptunKod; }
            set { neptunKod = value; }
        }

        public int ProgJegy
        {
            get
            {
                return Jegykeres(new Targy() { Nev = "Programozás II." });
            }
            set
            {
                targyak[IndexKeres(new Targy() { Nev = "Programozás II." })].Jegy = value;
            }
        }

        private int IndexKeres(Targy targy)
        {
            for (int i = 0; i < targyDb; i++)
                if (targyak[i].Nev == targy.Nev)
                    return i;
            return -1;
        }

        private int Jegykeres(Targy prog)
        {
            for (int i = 0; i < Targyak.Length; i++)
            {
                if(Targyak[i].Nev == prog.Nev)
                {
                    return Targyak[i].Jegy;
                }
            }
            return -1;
        }

        public Hallgato(int targydarabszam)
        {
            targyak = new Targy[targydarabszam];
            targyDb = 0;
        }

        public void TargyFelvesz(Targy targy)
        {
            if (targyDb < targyak.Length)
            {
                targyak[targyDb++] = targy;
            }
        }

        public void TargyListazas()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("\tTÁRGYAK");
            Console.WriteLine("--------------------");

            for (int i = 0; i < targyak.Length; i++)
            {
                targyak[i].AdatLeker();
            }
        }
    }
}
