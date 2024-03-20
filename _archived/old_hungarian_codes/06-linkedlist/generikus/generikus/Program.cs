using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generikus
{

    // Nem összekeverendő: a gyári kivétel kis 'f'-el van. (StackOverflowException)
    class StackOverFlowException : Exception
    {
        public string Msg { get; set; }
        
    }

    class OsztalyTerem
    {
        public int OsztalyLetszam { get; set; }
        public string OsztalyNev { get; set; }

        public override string ToString()
        {
            return OsztalyNev;
        }
    }



    //  - - - - - - - - - - - - -
    //      Javaslom sima T/K/X helyett a következő elnevezési konvenciót alkalmazni: Ttipus vagy T_tipus, K_tipus
    //      Sokkal jobban olvashatóvá teszi a kódot és nem zavarodtok bele az egy-egy betűs jelölésbe (az elején).
    //  - - - - - - - - - - - - -
    //      Létezik beépített sor és verem adatszerkezet is, amelyek generikusak:
    //          - stack (FIFO)
    //          - queue (LIFO)
    //  - - - - - - - - - - - - -

    class GenVerem<T_tipus>
    {
        T_tipus[] elemek;
        int db;

        public GenVerem(int meret)
        {
            elemek = new T_tipus[meret];
            db = 0;
        }

        // egy elem betétele (mindig felülre tevődik be -> verem szerkezet)
        public void Push(T_tipus elem)
        {
            elemek[db++] = elem;
        }

        // elem kivétele (mindig a legfelső vevődik ki -> verem szerkezet)
        public T_tipus Pop()
        {
            T_tipus vissza = elemek[--db];
            return vissza;
        }

        // legfelső elem "megnézése"
        public T_tipus Top
        {
            get { return elemek[db - 1]; }
        }
    }




    class IntVerem
    {
        int[] elemek;
        int db;

        public IntVerem(int meret)
        {
            elemek = new int[meret];
            db = 0;
        }

        public void Push(int elem)
        {
            if (db == elemek.Length)
                throw new StackOverFlowException() { Msg = "Stack Overflow Happened... =(" };
            else
                elemek[db++] = elem;
        }

        public int Pop()
        {
            return elemek[--db];
        }

        public int Top
        {
            get { return elemek[db-1]; }
        }
    }




    class Eszkozok
    {
        public int Osszead(int a, int b)
        {
            return a + b;
        }

        
        public T Maximum<T>(T a, T b) where T : IComparable
        {
            //if (a > b)
            //    return a;
            //else if (a == b)
            //    return a;
            //else 
            //    return b;

            if (a.CompareTo(b) > 0)
                return a;
            else
                return b;
        }

        public T Minimum<T>(T a, T b) where T : IComparable
        {
            if (a.CompareTo(b) < 0)
                return a;
            else
                return b;
        }

        public bool OsszeHasonlitasErtekre<T, K>(T ertekA, K ertekB)
        {
            return ertekA.Equals(ertekB);
        }

        public bool OsszehasonlitasTipusra<T,K>(T tipusA, K tipusB)
        {
            return typeof(T).Equals(typeof(K));
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            // ################################################
            //          INT VEREM
            // ################################################

            IntVerem iverem = new IntVerem(3);
            iverem.Push(1);
            iverem.Push(2);
            iverem.Push(3);
            try
            {
                iverem.Push(10);
            }
            catch(StackOverFlowException e)
            {
                Console.WriteLine("Hiba történt! : " + e.Message);
            }

            Console.WriteLine("Legfelső elem: " + iverem.Top);

            iverem.Pop();
            iverem.Pop();

            Console.WriteLine(iverem.Pop());

            // ################################################
            //          GENERIKUS VEREM
            // ################################################


            GenVerem<int> gverem1 = new GenVerem<int>(3);

            GenVerem<string> gverem2 = new GenVerem<string>(3);

            GenVerem<OsztalyTerem> gverem3 = new GenVerem<OsztalyTerem>(3);

            gverem3.Push(new OsztalyTerem() { OsztalyNev = "9/b", OsztalyLetszam = 33 });

            Console.WriteLine("Legfelső elem: " + gverem3.Top);


        }
    }
}
