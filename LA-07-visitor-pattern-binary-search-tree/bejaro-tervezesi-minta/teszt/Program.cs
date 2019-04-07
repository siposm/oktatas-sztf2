using System;
using System.Collections;

namespace visitor_pattern
{
    class NemElerhetoElemException : Exception
    {
        public string Uzenet { get; set; }
    }

    class LancoltLista<T> : IEnumerator , IEnumerable
    {
        private ListaElem fej;
        private ListaElem bejaroMutato;

        public LancoltLista()
        {
            fej = null;
            bejaroMutato = fej;
        }

        class ListaElem
        {  
            public T tartalom;
            public ListaElem kovetkezo;
            public override string ToString()
            { return this.tartalom.ToString(); }
        }

        public T this[int i]
        {
            get { return ElemKereses(i); }
            set { ElemModositas(i,value); }
        }


        private T ElemKereses(int index)
        {
            ListaElem p = fej;
            int count = 0;
            while ( p!=null && count < index )
            {
                p = p.kovetkezo;
                count++;
            }

            if ( p != null && count == index)
                return p.tartalom;
            else
                throw new NemElerhetoElemException()
                { Uzenet = "[ERR] - Nincs ilyen indexű elem." };
        }

        private void ElemModositas(int index, T ujErtek)
        {
            ListaElem p = fej;
            int count = 0;
            while (p != null && count < index)
            {
                p = p.kovetkezo;
                count++;
            }

            if (p != null && count == index)
                p.tartalom = ujErtek;
            else
                throw new NemElerhetoElemException()
                { Uzenet = "[ERR] - Nincs ilyen indexű elem." };
        }

        public void Beszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;
            fej = uj;
        }

        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.kovetkezo;
            }
        }

        public object Current { get { return bejaroMutato.tartalom; } }

        public bool MoveNext()
        {
            if (bejaroMutato == null)
            {
                // első hívás
                bejaroMutato = fej;
                return true;
            }
            else if (bejaroMutato.kovetkezo != null)
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

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }

    class Ember
    {
        public string Nev { get; set; }
        public override string ToString()
        {
            return this.Nev;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {

            LancoltLista<Ember> lista = new LancoltLista<Ember>();
            lista.Beszuras(new Ember() { Nev = "Első Lajos" });
            lista.Beszuras(new Ember() { Nev = "Második Márton" });
            lista.Beszuras(new Ember() { Nev = "Harmadik Hedvig" });
            lista.Beszuras(new Ember() { Nev = "Negyedik Norbert" });

            lista.Bejaras();

            Console.WriteLine("\n----\n");

            foreach (Ember item in lista)
                Console.WriteLine(item);

            Console.WriteLine("\n----\n");

            try
            {
                Console.WriteLine(lista[0]);
                Console.WriteLine(lista[1]);
                Console.WriteLine(lista[2]);
                Console.WriteLine(lista[3]);
                Console.WriteLine(lista[40]); // hiba
            }
            catch (NemElerhetoElemException ex)
            {
                Console.WriteLine(ex.Uzenet);
            }

            Console.WriteLine("\n----\n");

            lista[3] = new Ember() { Nev = "ELSŐ EDVÁRD" };

            foreach (Ember item in lista)
                Console.WriteLine(item);

            try
            {
                lista[30] = new Ember() { Nev = "XY ZX" };
            }
            catch (NemElerhetoElemException ex)
            {
                Console.WriteLine(ex.Uzenet);
            }
        }
    }
}
