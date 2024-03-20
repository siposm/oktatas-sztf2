using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
	class Graf <T>
	{
		List<List<T>> szomszedsagilista = new List<List<T>>();

		List<T> tartalom = new List<T>();

		public void CsucsHozzaadas(T csucs)
		{
			tartalom.Add(csucs);
			szomszedsagilista.Add(new List<T>());
		}

		public void ElFelvetel(T honnan, T hova)
		{
			int indexhonnan = tartalom.IndexOf(honnan);
			int indexhova = tartalom.IndexOf(hova);

			// mivel nem irányított ezért mind a két "oldalon" jelezni kell a kapcsolatot !!!
			szomszedsagilista[indexhonnan].Add(tartalom[indexhova]);
			szomszedsagilista[indexhova].Add(tartalom[indexhonnan]);

		}

		public bool VezetEl(T a, T b)
		{
			int indexhonnan = tartalom.IndexOf(a);
			int indexhova = tartalom.IndexOf(b);
			return szomszedsagilista[indexhonnan].Contains(tartalom[indexhova]);
		}

		public List<T> Szomszedai(T melyikcsucs)
		{
			// kihasználjuk azt, hogy hogyan tároljuk el alapból a szomszédokat
			// 	ugye ez a fenti beágyazott listában a belső lista!

			int index = tartalom.IndexOf(melyikcsucs);
			return szomszedsagilista[index];
		}



		public void SzelessegiBejaras(T startelem)
		{
			Queue<T> S = new Queue<T>();
			//Enqueue = elem berakás
			//Dequeue = legkorábban berakott elem kivétele és törlése

			List<T> F = new List<T>();

			S.Enqueue(startelem);
			F.Add(startelem);

			T k;

			while (S.Count != 0)
			{
				k = S.Dequeue();
				Console.WriteLine(k.ToString());  // ~ feldolgoz...
				foreach (T x in Szomszedai(k))
				{
					if (!F.Contains(x))
					{
						S.Enqueue(x);
						F.Add(x);
					}
				}
			}

		}

        private void MelysegiBejarasRek(T k, ref List<T> F)
        {
            F.Add(k);
            Console.WriteLine(k.ToString());

            foreach (T x in Szomszedai(k))
            {
                if (!F.Contains(x))
                    MelysegiBejarasRek( x , ref F);
            }

        }

        public void MelysegiBejarasStart(T startelem)
        {
            List<T> F = new List<T>();
            MelysegiBejarasRek(startelem, ref F);
        }


	}

	class Program
	{
		static void Main(string[] args)
		{

			Graf<string> g = new Graf<string>();

			g.CsucsHozzaadas("Józsi");
			g.CsucsHozzaadas("Sanyi");
			g.CsucsHozzaadas("Magdi");
			g.CsucsHozzaadas("Gizi");
			g.CsucsHozzaadas("Zoli");
			g.CsucsHozzaadas("Péter");
			g.CsucsHozzaadas("Jenő");

			g.ElFelvetel("Józsi", "Sanyi");
			g.ElFelvetel("Józsi", "Magdi");
			g.ElFelvetel("Magdi", "Sanyi");

			g.ElFelvetel("Józsi", "Zoli");
			g.ElFelvetel("Gizi", "Zoli");
			g.ElFelvetel("Józsi", "Gizi");

			g.ElFelvetel("Péter", "Zoli");
			g.ElFelvetel("Péter", "Jenő");

            Console.WriteLine("\n>>BFS\n");
			g.SzelessegiBejaras("Jenő");

            Console.WriteLine("\n>>DFS\n");
            g.MelysegiBejarasStart("Jenő");

            Console.WriteLine("\n\n");
            g.MelysegiBejarasStart("Gizi");

            
            Console.WriteLine("\n\n");
        }
	}
}
