using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class HasitoKivetel : Exception
    {

    }

    class NincsHelyHasitoKivetel : HasitoKivetel
    {

    }

    class NincsIlyenKulcsHasitoKivetel : HasitoKivetel
    {

    }

    public abstract class HasitoTablazat<K,T>
    {
        protected int m;

        public HasitoTablazat(int m)
        {
            this.m = m;
        }

        protected virtual int h(K kulcs)
        {
            return Math.Abs(kulcs.GetHashCode() % m);
        }

        abstract public void Beszuras(K kulcs, T ertek);
        abstract public T Kereses(K kulcs);
        abstract public void Torles(K kulcs);
    }

    public class HasitoTablazatLancoltListaval<K, T> : HasitoTablazat<K, T>
    {
        class HasitoElem
        {
            public K kulcs;
            public T tart;
            public HasitoElem kov;
        }

        HasitoElem[] A;

        public HasitoTablazatLancoltListaval(int m) : base(m)
        {
            A = new HasitoElem[m];
        }

        public override void Beszuras(K kulcs, T ertek)
        {
            HasitoElem uj = new HasitoElem();
            uj.kulcs = kulcs;
            uj.tart = ertek;
            uj.kov = A[h(kulcs)];
            A[h(kulcs)] = uj;
        }

        public override T Kereses(K kulcs)
        {
            HasitoElem p = A[h(kulcs)];
            while (p != null && !p.kulcs.Equals(kulcs)) p = p.kov;
            if (p != null)
                return p.tart;
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }

        public override void Torles(K kulcs)
        {
            HasitoElem p = A[h(kulcs)];
            HasitoElem e = null;
            while (p != null && !p.kulcs.Equals(kulcs))
            {
                e = p;
                p = p.kov;
            }

            if (p != null)
                if (e == null)
                    A[h(kulcs)] = p.kov;
                else
                    e.kov = p.kov;
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }
    }

    public class HasitoTablazatNyiltCimzessel <K,T> : HasitoTablazat <K,T>
    {
        class HasitoElem
        {
            public K kulcs;
            public T tart;
            public bool torolt = false;
        }

        HasitoElem[] A;

        public HasitoTablazatNyiltCimzessel(int m) : base(m)
        {
            A = new HasitoElem[m];
            for (int i = 0; i < m; i++)
                A[i] = new HasitoElem();
        }

        protected virtual int h(K kulcs, int j)
        {
            return (base.h(kulcs) + j * 31) % m;
        }

        public override void Beszuras(K kulcs, T ertek)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !A[h(kulcs, j)].torolt) j++;

            if (j < m)
            {
                A[h(kulcs, j)].kulcs = kulcs;
                A[h(kulcs, j)].tart = ertek;
                A[h(kulcs, j)].torolt = false;
            }
            else throw new NincsHelyHasitoKivetel();
        }

        public override T Kereses(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !(A[h(kulcs, j)].kulcs.Equals(kulcs) && !A[h(kulcs, j)].torolt)) j++;

            if (j < m && A[h(kulcs, j)].kulcs != null)
            {
                return A[h(kulcs, j)].tart;
            }
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }

        public override void Torles(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !(A[h(kulcs, j)].kulcs.Equals(kulcs) && !A[h(kulcs, j)].torolt)) j++;

            if (j < m && A[h(kulcs, j)].kulcs != null)
            {
                A[h(kulcs, j)].torolt = true;
            }
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }
    }

    class Hallgato
    {
        public string Nev { get; set; }

        public Hallgato(string nev)
        {
            this.Nev = nev;
        }

        public override int GetHashCode()
        {
            return Nev.GetHashCode();
        }
    }








    class Program
    {
        static void HashHiba()
        {
            Dictionary<Hallgato, int> a = new Dictionary<Hallgato, int>();
            Hallgato h1 = new Hallgato("Bela");
            a.Add(h1, 1000);

            Hallgato h2 = new Hallgato("Jozsi");
            a.Add(h2, 1500);

            Console.WriteLine(a[h1]);
            Console.WriteLine(a[h2]);

            h2.Nev = "Kelemen";
            Console.WriteLine(a[h1]);
            Console.WriteLine(a[h2]);
        }

        static void SajatHashTeszt()
        {
            HasitoTablazat<string, int> htc = new HasitoTablazatLancoltListaval<string, int>(200);
            htc.Beszuras("Peti", 1000);
            htc.Beszuras("Laci", 500);
            htc.Beszuras("Klari", 1500);
            htc.Beszuras("Bela", 800);
            htc.Beszuras("Csilla", 1800);

            Console.WriteLine(htc.Kereses("Peti"));
            Console.WriteLine(htc.Kereses("Laci"));
            Console.WriteLine(htc.Kereses("Klari"));
            Console.WriteLine(htc.Kereses("Bela"));
            Console.WriteLine(htc.Kereses("Csilla"));
        }

        static void Main(string[] args)
        {
            //HashHiba();
            SajatHashTeszt();
        }
    }
}
