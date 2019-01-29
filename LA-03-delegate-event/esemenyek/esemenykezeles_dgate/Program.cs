using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esemenykezeles_dgate
{

    public delegate void HelyzetJelentesEventHandler(int uzemanyagSzint);

    class Auto
    {
        // ======================
        //      BASIC STUFF
        // ======================

        public int Uzemanyag { get; set; }

        public Auto(int uzemanyag)
        {
            this.Uzemanyag = uzemanyag;
        }




        // ======================
        //      EVENT STUFF
        // ======================

        // 1. eset
        //public HelyzetJelentesEventHandler helyzet; 

        // 2. eset (ettől)
        private HelyzetJelentesEventHandler helyzet;
        public void FeliratkozasHelyzetre(HelyzetJelentesEventHandler metodus)
        {
            helyzet += metodus;
        }
        public void LeiratkozasHelyzetrol(HelyzetJelentesEventHandler metodus)
        {
            helyzet -= metodus;
        }
        // ------- (eddig)
        



        // ======================
        //      METHOD STUFF
        // ======================

        public void Verseny()
        {
            if (Uzemanyag > 0)
            {
                this.Uzemanyag -= 10;

                // visszajelzés...
                helyzet(this.Uzemanyag);

                // Itt hívom meg a "gyűjtőt", amiben minden metódus benne van
                //      és ahogy a sima delegáltas példában láttuk, 
                //      minden metódust meghív az adott paraméterrel!
            }
        }
    }




    class Ertesito
    {
        public void HelyzetJelentes(int uzemanyag)
        {
            Console.WriteLine("Maradék üzemanyag: " + uzemanyag);
        }
    }





    class Program
    {
        // 1. esethez
        /*static void HelyzetJelentes(int uzemanyag)
        {
            Console.WriteLine("Maradék üzemanyag: " + uzemanyag);
        }*/


        static void Main(string[] args)
        {
            Auto auto = new Auto(40);
            
            // FELIRATÁS (1. eset)
            //auto.helyzet += HelyzetJelentes;

            // FELIRATÁS (2. eset)
            Ertesito ert = new Ertesito();
            auto.FeliratkozasHelyzetre(ert.HelyzetJelentes);


            // versenyeztetés
            auto.Verseny();
            auto.Verseny();
            auto.Verseny();
            auto.Verseny();


            // Probléma adódik viszont (1. esetben), ha publikus a delegált, mert ez esetben innen kívülről meghívhatom
            //      tetszőlegesen, ezáltalá fals programot készítve.
            // Ekkor tehát, minden feliratkozott metódus, ahogy néztük is lefut a 100-as paraméterrel.
            //auto.helyzet(100);

            // Ezt kiküszöbölve, csinálunk feliratkozás és leiratkozás metódusokat az auto osztályban!



        }
    }
}
