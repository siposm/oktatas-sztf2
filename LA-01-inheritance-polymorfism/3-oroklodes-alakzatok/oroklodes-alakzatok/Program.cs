using System;

namespace oroklodesalakzatok
{
    public abstract class Sikidom
    {
        string szin;

        public string Szin
        {
            get { return szin; }
            set { szin = value; }
        }

        bool lyukas;

        public Sikidom(string szin)
        {
            this.szin = szin;
        }

        public void Kilyukaszt()
        {
            lyukas = true;
        }

        override public string ToString()
        {
            return "Szin: " + szin + "; Lyukas: " + lyukas + ";Terulet: " + Terulet() + "; Kerulet: " + Kerulet();
        }

        public abstract double Terulet();
        public abstract double Kerulet();
    }

    public class Kor : Sikidom
    {
        double sugar;

        public double Sugar
        {
            get { return sugar; }
            set { sugar = value; }
        }

        public Kor(string szin, double sugar)
            : base(szin)
        {
            this.sugar = sugar;
        }

        override public string ToString()
        {
            return base.ToString() + ";Sugar: " + sugar;
        }

        override public double Terulet()
        {
            return sugar * sugar * Math.PI;
        }

        override public double Kerulet()
        {
            return 2 * sugar * Math.PI;
        }
    }

    public class Teglalap : Sikidom
    {
        protected double szelesseg;

        virtual public double Szelesseg
        {
            get { return szelesseg; }
            set { szelesseg = value; }
        }

        protected double magassag;

        virtual public double Magassag
        {
            get { return magassag; }
            set { magassag = value; }
        }

        public Teglalap(string szin, double szelesseg, double magassag)
            : base(szin)
        {
            this.szelesseg = szelesseg;
            this.magassag = magassag;
        }

        override public string ToString()
        {
            return base.ToString() + ";Szelesseg: " + szelesseg + ";Magassag: " + magassag;
        }

        override public double Terulet()
        {
            return szelesseg * magassag;
        }

        override public double Kerulet()
        {
            return 2 * (szelesseg + magassag);
        }
    }

    public class Negyzet : Teglalap
    {
        public Negyzet(string szin, double oldalhossz)
            : base(szin, oldalhossz, oldalhossz)
        {
        }

        override public double Szelesseg
        {
            set
            {
                szelesseg = value;
                magassag = value;
            }
        }

        override public double Magassag
        {
            set
            {
                szelesseg = value;
                magassag = value;
            }
        }
    }

    class Program_1_1
    {
        static void LyukasztHaTeruletNagyobbMintKerulet(Sikidom vizsgalando)
        {
            if (vizsgalando.Terulet() > vizsgalando.Kerulet())
            {
                vizsgalando.Kilyukaszt();
            }
        }

        static Sikidom TeglalapVagyNegyzetLetrehozas(string szin, double szelesseg, double magassag)
        {
            if (szelesseg == magassag)
            {
                return new Negyzet(szin, szelesseg);
            }
            else
            {
                return new Teglalap(szin, szelesseg, magassag);
            }
        }

        static Sikidom LegnagyobbTeruletuSikidom(Sikidom[] elemek)
        {
            int max = 0;
            for (int i = 1; i < elemek.Length; i++)
            {
                if (elemek[i].Terulet() > elemek[max].Terulet())
                {
                    max = i;
                }
            }
            return elemek[max];
        }

        static void Main(string[] args)
        {
            Sikidom[] elemek = new Sikidom[5];

            Kor k1 = new Kor("piros", 10);
            Sikidom sikidom = k1;
            elemek[0] = sikidom;

            Teglalap t1 = new Teglalap("kék", 10, 20);
            elemek[1] = t1;

            elemek[2] = new Negyzet("sárga", 10);
            elemek[3] = new Kor("fekete", 5);
            elemek[4] = new Negyzet("fekete", 10);

            Console.WriteLine("Elemek listája:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(elemek[i]);
            }

            Console.WriteLine("Valami:");
            Sikidom valami = TeglalapVagyNegyzetLetrehozas("kék", 5, 5);
            LyukasztHaTeruletNagyobbMintKerulet(valami);
            Console.WriteLine(valami);

            Console.WriteLine("Legnagyobb területű:");
            Sikidom legnagyobb = LegnagyobbTeruletuSikidom(elemek);
            Console.WriteLine(legnagyobb);
        }
    }
}
