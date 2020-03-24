using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{

    class LancoltLista<T> : IEnumerable<T>, IEnumerator<T>
    {
        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

        ListaElem fej;
        ListaElem bejaroMutato;

        public void BeszurElejere(T ujelem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = ujelem;
            uj.kovetkezo = fej;
            fej = uj;
        }

        public void BeszurVegere(T ujelem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = ujelem;
            uj.kovetkezo = null;

            if (fej == null)
                fej = uj;
            else
            {
                ListaElem p = new ListaElem();
                p = fej;
                while (p.kovetkezo != null)
                {
                    p = p.kovetkezo;
                }
                p.kovetkezo = uj;
            }
        }

        public void ListaTorles()
        {
            ListaElem p = new ListaElem();
            while (fej != null)
            {
                p = fej;
                fej = fej.kovetkezo;
                p = null; // Felszabadít(p) és a GC majd elintézi mivel elveszti a referencia hivatkozást rá
            }
        }

        public void Bejaras()
        {
            ListaElem p = new ListaElem();
            p = fej;
            while (p != null)
            {
                Console.WriteLine(p.tartalom);
                p = p.kovetkezo;
            }
        }





        // IENUMBERABLE MEGVALÓSÍTÁSA ESETÉN EZEK KERÜLNEK BE:
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException(); // nem piszkáljuk
        }


        // IENUMERATOR MEGVALÓSÍTÁSA ESETÉN EZEK KERÜLNEK BE:
        public T Current
        {
            get { return bejaroMutato.tartalom; }
        }

        public void Dispose()
        {
            // legyen üres
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); } // nem piszkáljuk
        }

        public bool MoveNext()
        {
            if(bejaroMutato == null)
            {
                // első hívás
                bejaroMutato = fej;
                return true;
            }
            else if(bejaroMutato.kovetkezo != null)
            {
                // n. hívás
                bejaroMutato = bejaroMutato.kovetkezo;
                return true;
            }
            else
            {
                // lista vége
                this.Reset();
                return false;
            }
        }

        public void Reset()
        {
            bejaroMutato = null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LancoltLista<int> lista = new LancoltLista<int>();
            lista.BeszurElejere(133);
            lista.BeszurElejere(2);
            lista.ListaTorles();
            lista.BeszurVegere(99);
            lista.BeszurVegere(12);

            Console.WriteLine("\n-- BEJÁRÁS METÓDUSSAL\n");
            lista.Bejaras();


            Console.WriteLine("\n-- BEJÁRÁS FOREACH-CSEL\n");
            foreach (int item in lista)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}
