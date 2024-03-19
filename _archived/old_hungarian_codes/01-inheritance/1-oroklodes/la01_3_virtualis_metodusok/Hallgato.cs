using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la01_3_virtualis_metodusok
{
    public class Hallgato : Ember
    {
        public string Neptunkod { get; set; }

        public Hallgato(int eletkor, string nev, string neptunKod)
            : base(eletkor, nev)
        {
            this.Neptunkod = neptunKod;
        }

        public void Beiratkozas()
        {
            Neptunkod = NeptunKodGeneral();
        }

        private string NeptunKodGeneral()
        {
            // TODO: kód generálásának kidolgozása
            return "ABC123";
        }

        public override void Bemutatkozas()
        {
            Console.WriteLine(
                "Szia, én {0} ({1}) vagyok és {2} éves, hallgató.",
                              this.Nev,
                              Neptunkod,
                              this.Eletkor
                             );
        }


        public new void Udvozles()
        {
            Console.WriteLine("Szia, HALLGATÓ vagyok.");
        }

        public void Kiiratkozas()
        {
            Console.WriteLine("Kiiratkozom. :(");
        }
    }
}
