using System;
using System.Threading;

namespace sajat_eventargs
{

    // = = = = = = = = = = = = = = = = = = = = = = = =
    // SAJÁT EVENTARGS TÍPUS SZÁRMAZTATÁSA

    class AutoEventArgs : EventArgs
    {
        public Auto Auto { get; set; }
    }



    class Auto
    {
        public string Rendszam { get; set; }
    }



    class Szerviz
    {
        // A 3 LÉPÉS:
        //      1. delegált definiálása
        //      2. esemény a delegált alapján
        //      3. esemény elsütése ahol szükséges

        public delegate void JavitasEventHandler(object source, AutoEventArgs args);

        // Ez a delegáltas forma egyszerűsíthető ezzel:
        //
        //          public event EventHandler<VideoEventArgs> nev;
        //          vagy, saját eventargs típus nélkül
        //          public event EventHandler nev;
        //
        // <!> FIGYELEM: zh-ban a delegáltas formát kell tudni! <!>


        public event JavitasEventHandler Javitva;

        public void Javitas(Auto auto)
        {
            Console.WriteLine("Autó javítás folyamatban...");
            Thread.Sleep(3000);

            OnJavitva(auto); // esemény elsütése
        }

        protected virtual void OnJavitva(Auto auto)
        {
            if (Javitva != null)
                Javitva(this, new AutoEventArgs() { Auto = auto });
        }
    }


    // = = = = = = = = = = = = = = = = = = = = = = = =
    // ÉRTESÍTŐ SZOLGÁLTATÁSOK

    class MailService
    {
        public void OnJavitva(object source, AutoEventArgs e)
        {
            Console.WriteLine("[MAIL] - A {0} frsz. autó javítása kész, lehet érte jönni!", e.Auto.Rendszam);
        }
    }

    class FacebookService
    {
        public void OnJavitva(object source, AutoEventArgs e)
        {
            Console.WriteLine("[MAIL] - A {0} frsz. autó javítása kész, lehet érte jönni!", e.Auto.Rendszam);
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
