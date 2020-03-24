using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class LancoltLista<T>
    {

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

        private ListaElem fej;


        public void ElejereBeszuras(T elem)
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
                Console.WriteLine(p.tartalom);
                p = p.kovetkezo;
            }
        }

    }
}
