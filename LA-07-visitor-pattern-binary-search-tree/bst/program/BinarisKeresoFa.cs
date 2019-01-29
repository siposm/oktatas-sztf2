using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{

    enum BejarasTipus { preorder, inorder, postorder }


    class BinarisKeresoFa <T>
    {

        class FaElem 
        {
            public int kulcs;
            public T tartalom;
            public FaElem bal;
            public FaElem jobb;

            public FaElem(int kulcs, T tartalom)
            {
                this.kulcs = kulcs;
                this.tartalom = tartalom;
            }

            public override string ToString()
            {
                return "[" + this.kulcs.ToString() + "] " + this.tartalom.ToString();
            }
        }


        FaElem gyoker;


        public BinarisKeresoFa()
        {
            this.gyoker = null; // üres a fa
        }

        




        // METÓDUSOK --------------------------------------------------------

        // kívülről látható, beszúró metódus...
        public void Beszuras(int kulcs, T tartalom) 
        {
            // ...amely hívja a belső beszúró metódust
            // de miért így?
            // => a gyökértől kell indulnunk mindig (lásd jegyzet), ezt viszont kívülről nem érjük el
            // => a rekurzív függvényhívásokkor pedig változtatnunk kell a hivatkozott csúcsot, ezért a belső metódus
            
            Beszuras(ref gyoker, kulcs, tartalom);
        }

        // metódus túlterheléssel a nevét nem kell megváltoztatni, de ha úgy kevésbé zavaró akkor nyugodtan
        private void Beszuras(ref FaElem p, int kulcs, T tartalom)
        {
            if (p == null)

                p = new FaElem(kulcs, tartalom);

            else if (p.kulcs < kulcs)

                Beszuras(ref p.jobb, kulcs, tartalom);

            else if (p.kulcs > kulcs)

                Beszuras(ref p.bal, kulcs, tartalom);

            else

                throw new KulcsUtkozesException() { Msg = "Van már ilyen kulcsú elem!" };
        }



        public void Bejaras(BejarasTipus tipus)
        {
            if(tipus == BejarasTipus.preorder)
                
                PreOrder(this.gyoker);
            
            else if (tipus == BejarasTipus.inorder)
                
                InOrder(this.gyoker);
            
            else if (tipus == BejarasTipus.postorder)
                
                PostOrder(this.gyoker);
        }



        private void PreOrder(FaElem p)
        {
            if (p != null)
            {
                Console.WriteLine(p);
                PreOrder(p.bal);
                PreOrder(p.jobb);
            }
        }
        
        private void InOrder(FaElem p)
        {
            if (p != null)
            {
                InOrder(p.bal);
                Console.WriteLine( p );
                InOrder(p.jobb);
            }
        }

        private void PostOrder(FaElem p)
        {
            if (p != null)
            {
                PostOrder(p.bal);
                PostOrder(p.jobb);
                Console.WriteLine(p);
            }
        }
        
    }
}
