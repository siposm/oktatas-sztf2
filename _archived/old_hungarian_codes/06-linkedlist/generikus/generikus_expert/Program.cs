using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generikus_expert
{
    public interface IEladhato
    {
        string Nev  { get; set; }
        int Ar      { get; set; }
    }

    public class Kalapacs : IEladhato
    {
        public string Nev   { get; set; }
        public int Ar       { get; set; }
    }
    

    public class Bolt<T> where T : IEladhato
    {
        T[] termekek;

        public Bolt()
        {
            termekek = new T[10];
        }

        public IEladhato LekerdezesTermek(int hanyadik)
        {
            return termekek[hanyadik];
        }

        public string LekerdezesTermekNev(int hanyadik)
        {
            return termekek[hanyadik].Nev;
        }

        public T Eladas(int hanyadik)
        {
            return termekek[hanyadik];
        }


    }

    // https://msdn.microsoft.com/hu-hu/library/sz6zd40f.aspx
    public class SarkiKisBolt<T> : Bolt<T> // where T : IEladhato // ha szeretnénk, akkor meg kell ismételni
    { /* do nothing */ }

    public class KalapacsBolt : Bolt<Kalapacs>
    { /* do nothing */ }

    


    public class KulcsErtekPar<TKulcs, TErtek>
    {
        public TKulcs kulcs;
        public TErtek ertek;

        public KulcsErtekPar(TKulcs kulcs, TErtek ertek)
        {
            this.kulcs = kulcs;
            this.ertek = ertek;
        }

        public override string ToString()
        {
            return this.kulcs + " - " + this.ertek;
        }
    }

    class Ember
    {
        public string Nev { get; set; }
        public DateTime SzuletesiDatum { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Bolt<Kalapacs> kbolt = new Bolt<Kalapacs>();


            KulcsErtekPar<string, Ember>[] nyilvantartas = new KulcsErtekPar<string, Ember>[3];
            nyilvantartas[0] = new KulcsErtekPar<string, Ember>("PA-123444-KA", new Ember() { Nev = "Lajoska" });
            
        }
    }
}
