using System;
namespace mintazhresidentevilcodenamenik
{
    public class LLista <T>
    {
        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }


        public void ElejereBeszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;

            fej = uj;
        }

        public void VegereBeszuras(T elem)
        {
            // to do implement #1
        }

        public void NHelyreBeszuras(T elem)
        {
            // to do implement #2
        }

        public void ElejerolTorles(T elem)
        {
            // to do implement #3
        }

        public void VegerolTorles(T elem)
        {
            // to do implement #4
        }

        public void NHelyrolTorles(T elem)
        {
            // to do implement #5
        }

        public void ListaFelszabaditasa()
        {
            // to do implement #6
        }



        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }
        }


        private void Feldolgoz(ListaElem elem)
        {
            Console.WriteLine(">\t" +  elem.tartalom);
        }
    }
}
