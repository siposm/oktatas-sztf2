using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
	class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
	}

	class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<Product> OrderedProducts { get; set; }

		public override string ToString()
		{
			return string.Format("[Customer: ID={0}, Name={1}]", ID, Name);
		}

	}

    class Program
    {
        static void Main(string[] args)
        {

			Dictionary<int, Customer> vasarlok = new Dictionary<int, Customer>();

			Customer bela = new Customer() { ID = 993, Name = "Bélóka", OrderedProducts = new List<Product>() };
			Customer vivi = new Customer() { ID = 713, Name = "Vivien", OrderedProducts = new List<Product>() };

			// az objektum saját id-jával határozzuk meg a kulcsot
			vasarlok.Add(bela.ID, bela);
			vasarlok.Add(vivi.ID, vivi);

			// kivétel kulcs alapjánn
			vasarlok[bela.ID].OrderedProducts.Add(new Product()
				{
					ID = 32,
					Name = "HotDog",
					Price = 550 
				});
			
			vasarlok[vivi.ID].OrderedProducts.Add(new Product()
				{
					ID = 2,
					Name = "Pizza",
					Price = 850
				});
			
			vasarlok[vivi.ID].OrderedProducts.Add(new Product()
				{
					ID = 19,
					Name = "Apple",
					Price = 120
				});

			// sima kiíráatás
			//Console.WriteLine(vasarlok[bela.ID].Name);

			foreach (KeyValuePair<int, Customer> customer in vasarlok)
			{
				Console.WriteLine("BUYER: " + customer.Value);

				foreach (Product product in customer.Value.OrderedProducts)
				{
					Console.WriteLine("\t" + product.Name + " (" + product.Price + ")");
				}
				Console.WriteLine();
			}
		}
    }
}
