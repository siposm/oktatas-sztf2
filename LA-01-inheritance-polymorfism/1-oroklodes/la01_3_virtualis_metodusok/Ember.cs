using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la01_3_virtualis_metodusok
{
    public class Ember
    {

        public int Eletkor { get; set; }
        public string Nev { get; set; }

        public Ember(int eletkor, string nev)
        {
            this.Eletkor = eletkor;
            this.Nev = nev;
        }

        public virtual void Bemutatkozas()
        {
            Console.WriteLine("Szia, én {0} vagyok és {1} éves.", Nev, Eletkor);
        }

        public void Udvozles()
        {
            Console.WriteLine("Üdvözöllek EMBER vagyok!");
        }
    }

}
