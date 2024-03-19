using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace esemenykezeles_dgate
{
    class Auto
    {
        public string Rendszam { get; set; }
    }

    class Szerviz
    {
        // = = = = = = = = = = = = = = = = = = = = = = = = //
        // A 3 LÉPÉS:                                      //
        //      1. delegált definiálása                    //
        //      2. esemény a delegált alapján              //
        //      3. esemény elsütése ahol szükséges         //
        // = = = = = = = = = = = = = = = = = = = = = = = = //

        public delegate void JavitasEventHandler(object source, EventArgs args);

        public event JavitasEventHandler Javitva;
        // - a háttérben az 'event' kiváltja a fel és leiratkozást,
        //      valamint, hogy private-ként vesszük a delegáltat!
        // - lásd esemenykezeles_dgate példa projekt!



        public void Javitas(Auto auto)
        {
            Console.WriteLine("Autó javítás folyamatban...");
            Thread.Sleep(3000); // hogy szimbolizáljuk a javítás idejét...

            OnJavitva(); // esemény elsütése
        }

        protected virtual void OnJavitva()
        {
            if (Javitva != null) // vizsgálat azért kell, hogy ha nincs semmi sem feliratkozva, ne haljon meg
                Javitva(this, EventArgs.Empty);

            // source = a szervíz osztály fogja az eseményt küldeni
            // üres argumentumokkal/paraméterekkel
        }
    }


    // A fenti részt megírtuk 5 éve, vagy megírták nekünk másik dolgozók egy másik cégben.
    // Mi ahhoz nem férünk hozzá, de ettől függetlenül szeretnénk, ha a javítást elvégezve értesítsenek minket több platformon is.
    // Ha a facebook és a sima email mellé később szeretnénk twitter, vagy bármi egyéb új dolgot integrálni, gond nélkül meg tudjuk tenni!
    class MailService
    {
        public void OnJavitva(object source, EventArgs e)
        {
            Console.WriteLine("[MAIL] - Az autó javítása kész, lehet érte jönni...");
        }
    }

    class FacebookService
    {
        public void OnJavitva(object source, EventArgs e)
        {
            Console.WriteLine("[FB] - Az autó javítása kész, lehet érte jönni...");
        }
    }







    class Program
    {
        
        static void Main(string[] args)
        {
            Szerviz szerviz = new Szerviz(); // publisher

            Auto bmw = new Auto { Rendszam = "ASD-123" };

            MailService ms = new MailService(); // subscriber
            FacebookService fs = new FacebookService(); // subscriber

            // feliratkozás a szervíz-re:
            szerviz.Javitva += ms.OnJavitva;
            szerviz.Javitva += fs.OnJavitva;


            szerviz.Javitas(bmw);
        }
    }
}
