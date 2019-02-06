using System;

namespace mintazhresidentevilcodenamenik
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO RE CODENAME NIK");

            Random r = new Random();

            // 1. --------------------------------------------------------------
            // ellenségek generálása

            Zombi[] ellensegek = new Zombi[4];
            ellensegek[0] = new FutoZombi(100);
            ellensegek[1] = new FutoZombi(100);
            ellensegek[2] = new BioZombi(100);
            ellensegek[3] = new BioZombi(100);

            try
            {
                (ellensegek[2] as BioZombi).ModellGeneralas();
                (ellensegek[3] as BioZombi).ModellGeneralas();
            }
            catch (ZombiModellBetoltesException e)
            {
                Console.WriteLine(e.HibaUzenet);
                Console.WriteLine(e.Zombi);
            }
            catch (AlapException e)
            {
                Console.WriteLine(e.HibaUzenet);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < ellensegek.Length; i++)
            {
                ellensegek[i].Sebzes = r.Next(10);

                if (ellensegek[i] is FutoZombi)
                    (ellensegek[i] as FutoZombi).Stamina = r.Next(100);

                if (ellensegek[i] is BioZombi)
                    (ellensegek[i] as BioZombi).Sugarzas = r.Next(100);
            }

            // 2. --------------------------------------------------------------
            // ellenségek ellenőrzése

            for (int i = 0; i < ellensegek.Length; i++)
            {
                ellensegek[i].LogZombi();
            }

            // 3. --------------------------------------------------------------
            // játék létrehozása

            Jatek jatek = new Jatek(2)
            {
                Jatekos = new Jatekos()
                {
                    Nev = "Leon S. Kennedy",
                    Eletero = 100,
                    Sebzes = 20,
                    Karakter = JatekosKarakter.Leon
                }
            };

            try
            {
                // ha a tömb mérete kisebb, mint ahány ellenfelet akarunk belerakni
                // akkor abból saját kivétel fog dobódni

                for (int i = 0; i < ellensegek.Length; i++)
                {
                    jatek.EllenfelHozzaadas(ellensegek[i]);
                }
            }
            catch ( EllenfelekTeleException e )
            {
                Console.WriteLine( e.HibaUzenet );
            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
            }

            jatek.EllenfelekListazasa();

            // 4. --------------------------------------------------------------
            // tesztelés

            jatek.EsemenyFeliratkoztatas();
            jatek.Tamadas(jatek.Ellenfelek[0]); // 100 - 20 = 80
            jatek.Tamadas(jatek.Ellenfelek[0]); // 80 - 20 = 60
            jatek.Jatekos.Sebzes = 61;
            jatek.Tamadas(jatek.Ellenfelek[0]); // 60 - 60 = 0 >>  trigger event (meghalt + támadás)












            // =================================================================
            // =================================================================
            // 2. zh rész
            // =================================================================
            // =================================================================











            // 5. --------------------------------------------------------------
            // adatszerkezetek tesztelése

            TSor<int> sor = new TSor<int>(4);

            sor.ElemBerak(5);
            sor.ElemBerak(7);
            sor.ElemBerak(3);
            sor.ElemBerak(2);

            sor.ElemKivesz();
            sor.ElemKivesz();

            sor.ElemBerak(30);
            sor.ElemBerak(40);

            Console.WriteLine(sor.ElemMegtekint());

            try
            {
                sor.ElemBerak(90);
            }
            catch (NincsHelyException e)
            {
                Console.WriteLine(e.HibaUzenet);
            }
        }
    }
}