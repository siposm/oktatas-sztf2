using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bts_baratokkozt_oop
{

    enum Feladatkorok
    {
        Tervezés,
        Irányítás,
        Beszerzés,
        Ellenőrzés,
        Engedélyezés,
        Érékesítés
    }

    class Ember
    {
        public string Nev { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Ember).Nev.Equals(this.Nev);
        }

        public override string ToString()
        {
            return string.Format("{0}", Nev);
        }
    }

    class Program
    {
        static bool Ft(int szint, Ember xEmber)
        { return true; }

        static bool Fk(Ember[] eredmenyek, int szint, Ember xEmber)
        {
            for (int i = 0; i < szint; i++)
                //if (eredmenyek[i].Nev == xEmber.Nev)
                if (eredmenyek[i].Equals(xEmber))
                    return false;

            return true;
        }

        static void BTS(int szint, ref Ember[] E, ref bool van, int[] M, Ember[,] R)
        {
            int i = -1;
            while (!van && i < M[szint])
            {
                i++;
                if (Ft(szint, R[szint, i]))
                {
                    if (Fk(E, szint, R[szint, i]))
                    {
                        E[szint] = R[szint, i];
                        if (szint == R.GetLength(0) - 1)
                            van = true;
                        else
                            BTS(szint + 1, ref E, ref van, M, R);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Ember[,] R = new Ember[6, 3];

            // feladatkör 1
            R[0, 0] = new Ember() { Nev = "Miklós" };
            R[0, 1] = new Ember() { Nev = "Klaudia" };

            // feladatkör 2
            R[1, 0] = new Ember() { Nev = "Zsolt" };
            R[1, 1] = new Ember() { Nev = "Miklós" };

            // feladatkör 3
            R[2, 0] = new Ember() { Nev = "András" };

            // feladatkör 4
            R[3, 0] = new Ember() { Nev = "András" };
            R[3, 1] = new Ember() { Nev = "Pál" };
            R[3, 2] = new Ember() { Nev = "Zsolt" };

            // feladatkör 5
            R[4, 0] = new Ember() { Nev = "András" };
            R[4, 1] = new Ember() { Nev = "Géza" };

            // feladatkör 6
            R[5, 0] = new Ember() { Nev = "Géza" };
            R[5, 1] = new Ember() { Nev = "Miklós" };

            int[] M = { 1, 1, 0, 2, 1, 1 };

            Ember[] E = new Ember[6];

            bool van = false;

            BTS(0, ref E, ref van, M, R);

            

            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine("{0}. szint: {1}", i, E[i]);
            }

            string[] feladatkorok = Enum.GetNames(typeof(Feladatkorok));

            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine("FELADATKÖR: {0} \tEMBER: {1}",
                    feladatkorok[i], E[i]
                    );
            }
        }
    }
}
