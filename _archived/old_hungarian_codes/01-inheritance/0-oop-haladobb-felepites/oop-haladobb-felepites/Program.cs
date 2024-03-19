using System;

namespace oophaladobbfelepites
{

    class Ember
    {

        public int Eletkor { get; set; }

        public string Nev { get; private set; }

        public string ID { get; }


        public Ember()
        {
            this.ID = "ASD123";
            // csak get-es prop-nak ctor-ból lehet értéket adni
        }

        private void NevbenModositas()
        {
            this.Nev += "____";
            // innen megy, mert van private set


            //this.ID = "BCD456";
            // innen nem megy, csak a konstruktorból
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {

            Ember ember = new Ember();

            //ember.Nev = "lajos";
            // nem engedi mert csak private set van!


            ember.Eletkor = 9;

            Console.WriteLine(ember.ID);
        }
    }
}
