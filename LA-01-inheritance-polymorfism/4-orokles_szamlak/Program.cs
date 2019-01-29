using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feladat_1_2
{
    public sealed class Tulajdonos
    {
        string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public Tulajdonos(string nev)
        {
            this.nev = nev;
        }
    }

    public abstract class BankiSzolgaltatas
    {
        Tulajdonos tulaj;

        public Tulajdonos Tulaj
        {
            get { return tulaj; }
        }

        public BankiSzolgaltatas(Tulajdonos tulaj)
        {
            this.tulaj = tulaj;
        }
    }

    public abstract class Szamla : BankiSzolgaltatas
    {
        public Szamla(Tulajdonos tulaj)
            : base(tulaj)
        {
        }

        protected int egyenleg;

        public int Egyenleg
        {
            get
            {
                return egyenleg;
            }
        }

        public void Befizet(int osszeg)
        {
            egyenleg += osszeg;
        }

        public abstract bool Kivesz(int osszeg);

        public Kartya KartyaIgenyles(string kartyaszam)
        {
            return new Kartya(Tulaj, this, kartyaszam);
        }
    }

    public class HitelSzamla : Szamla
    {
        int hitelkeret;

        public int HitelKeret
        {
            get { return hitelkeret; }
        }

        public HitelSzamla(Tulajdonos tulaj, int hitelkeret)
            : base(tulaj)
        {
            this.hitelkeret = hitelkeret;
        }

        public override bool Kivesz(int osszeg)
        {
            if (egyenleg - osszeg >= -hitelkeret)
            {
                egyenleg -= osszeg;
                return true;
            }
            else
                return false;
        }
    }

    public class MegtakaritasiSzamla : Szamla
    {
        public static double AlapKamat = 0.01;

        double kamat;

        public double Kamat
        {
            get { return kamat; }
            set { kamat = value; }
        }

        public MegtakaritasiSzamla(Tulajdonos tulaj)
            : base(tulaj)
        {
            this.kamat = AlapKamat;
        }

        public override bool Kivesz(int osszeg)
        {
            if (egyenleg - osszeg > 0)
            {
                egyenleg -= osszeg;
                return true;
            }
            else
                return false;
        }

        public void KamatJovaIras()
        {
            egyenleg = (int)((double)egyenleg * (1 + kamat));
        }
    }

    public class Kartya : BankiSzolgaltatas
    {
        public Kartya(Tulajdonos tulaj, Szamla szamla, string kartyaszam)
            : base(tulaj)
        {
            this.szamla = szamla;
            this.kartyaszam = kartyaszam;
        }

        string kartyaszam;

        public string Kartyaszam
        {
            get { return kartyaszam; }
        }

        Szamla szamla;

        public bool Vasarlas(int osszeg)
        {
            return szamla.Kivesz(osszeg);
        }
    }

    public class Bank
    {
        Szamla[] szamlak;
        int szamlaN;
        int szamlaMax;

        public Bank(int szamlaMax)
        {
            this.szamlaMax = szamlaMax;
            szamlak = new Szamla[szamlaMax];
        }

        public Szamla Szamlanyitas(Tulajdonos tulaj, int hitelkeret)
        {
            if (szamlaN == szamlaMax) return null;

            Szamla uj;
            if (hitelkeret > 0)
            {
                uj = new HitelSzamla(tulaj, hitelkeret);
            }
            else
            {
                uj = new MegtakaritasiSzamla(tulaj);
            }
            szamlak[szamlaN++] = uj;

            return uj;
        }

        public int Osszegyenleg(Tulajdonos tulaj)
        {
            int SZUM = 0;
            for (int i = 0; i < szamlaN; i++)
            {
                if (szamlak[i].Tulaj == tulaj)
                {
                    SZUM += szamlak[i].Egyenleg;
                }
            }
            return SZUM;
        }

        public Szamla LegnagyobbEgyenleguSzamla(Tulajdonos tulaj)
        {
            int MAX = -1;
            for (int i = 0; i < szamlaN; i++)
            {
                if (szamlak[i].Tulaj == tulaj && (MAX == -1 || szamlak[i].Egyenleg > szamlak[MAX].Egyenleg))
                {
                    MAX = i;
                }
            }
            return szamlak[MAX];
        }

        public int OsszHitelkeret()
        {
            int SZUM = 0;
            for (int i = 0; i < szamlaN; i++)
            {
                if (szamlak[i] is HitelSzamla)
                {
                    SZUM += (szamlak[i] as HitelSzamla).HitelKeret;
                }
            }
            return SZUM;
        }
    }

    class Program_1_2
    {
        static void Main(string[] args)
        {
            Bank UniobudaBank = new Bank(10);

            Tulajdonos bela = new Tulajdonos("Kovács Béla");
            Szamla szla1 = UniobudaBank.Szamlanyitas(bela, 1000);
            Szamla szla2 = UniobudaBank.Szamlanyitas(bela, 0);

            Tulajdonos manci = new Tulajdonos("Harkály Manci");
            UniobudaBank.Szamlanyitas(manci, 2000);

            szla1.Befizet(300);
            szla2.Befizet(200);
            ((MegtakaritasiSzamla)szla2).KamatJovaIras();

            szla1.Kivesz(500); // sikerul
            szla2.Kivesz(500); // nem sikerul

            Kartya kartya = szla1.KartyaIgenyles("12345");
            kartya.Vasarlas(500); // sikerul
            kartya.Vasarlas(500); // nem sikerul

            Console.WriteLine("Béla összegyenleg:" + UniobudaBank.Osszegyenleg(bela));
            Console.WriteLine("Béla legnagyobb egyenlegű számla egyenlege:" + UniobudaBank.LegnagyobbEgyenleguSzamla(bela).Egyenleg);
            Console.WriteLine("Összes hitelkeret:" + UniobudaBank.OsszHitelkeret());
        }
    }
}
