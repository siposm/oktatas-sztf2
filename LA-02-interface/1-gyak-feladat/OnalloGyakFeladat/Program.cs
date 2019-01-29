using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnalloGyakFeladat
{

    interface IVisszavalthato : IEladhato
    {
        int VisszavaltasErteke(int elteltNapokSzama);
    }

    interface IKarbantartando
    {
        bool KarbantartasSzukseges();
        string Karbantartas();
    }

    interface IEladhato
    {
        int Ar { get; set; }
    }

    abstract class Termek : IEladhato
    {
        string nev;
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
        public abstract int Ar { get; set; }
        public Termek(string nev) { this.nev = nev; }
    }

    class Huto : Termek, IKarbantartando
    {
        int ar;

        public Huto(string nev)
            : base(nev)
        {
        }

        public override int Ar
        {
            get { return this.ar; }
            set { this.ar = value; }
        }

        public bool KarbantartasSzukseges()
        {
            return true;
        }

        public string Karbantartas()
        {
            return "Tisztítás";
        }
    }

    class Cipo : Termek, IVisszavalthato
    {
        int meret;
        int ar;

        public int Meret
        {
            get { return meret; }
            set { meret = value; }
        }

        public Cipo(string nev, int meret)
            : base("Cipő")
        {
            this.meret = meret;
        }

        public override int Ar
        {
            get
            {
                if (meret > 40)
                    return 15000;
                else
                    return 14000;
            }
            set { this.ar = value; }
        }

        public int VisszavaltasErteke(int elteltNapokSzama)
        {
            if (elteltNapokSzama == 0)
                return ar;
            else if (elteltNapokSzama >= 50)
                return 0;
            else
            {
                int ertek = 0;
                /* insert magic here */
                return ertek;
            }
        }
    }

    class Virag : Termek, IKarbantartando
    {
        int kor;
        int ar;

        public int Kor
        {
            get { return kor; }
            set { kor = value; }
        }

        public Virag(string nev)
            : base(nev)
        {
            this.kor = 0;
        }

        public override int Ar
        {
            get { return 1000 + kor * 2; }
            set { this.kor = value; }
        }

        public bool KarbantartasSzukseges()
        {
            this.kor++;
            if (kor == 3) return true;
            else return false;
        }

        public string Karbantartas()
        {
            return "Öntözés";
        }
    }

    class EladoModul
    {
        IKarbantartando[] karbantarthatoEszkozok;
        int tombIndex;

        public IKarbantartando[] KarbantarthatoEszkozok
        {
            get { return karbantarthatoEszkozok; }
            set { karbantarthatoEszkozok = value; }
        }

        public EladoModul(int maxDarab)
        {
            karbantarthatoEszkozok = new IKarbantartando[maxDarab];
            tombIndex = 0;
        }

        public void UjKarbantartandoFelvetele(IKarbantartando ujeszkoz)
        {
            karbantarthatoEszkozok[tombIndex++] = ujeszkoz;
        }

        public void MindenKarbanTartas()
        {
            for (int i = 0; i < tombIndex; i++)
            {
                if (karbantarthatoEszkozok[i].KarbantartasSzukseges())
                    Console.WriteLine(karbantarthatoEszkozok[i].Karbantartas());
            }
        }
    }

    class VasarlasiUtalvany : IEladhato, IVisszavalthato
    {
        private int ar;

        public int Ar
        {
            get { return 1000; }
            set { this.ar = value; }
        }

        public int VisszavaltasErteke(int elteltNapokSzama)
        {
            return 1000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
