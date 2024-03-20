namespace _01_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// using the inbuilt dictionary (which is a key-value pair datastructure)

			Dictionary<int, Customer> buyers = new Dictionary<int, Customer>();

			Customer c1 = new Customer() { ID = 993, Name = "John Doe", OrderedProducts = new List<Product>() };
			Customer c2 = new Customer() { ID = 713, Name = "Jane Doe", OrderedProducts = new List<Product>() };

			buyers.Add(c1.ID, c1);
			buyers.Add(c2.ID, c2);

			buyers[c1.ID].OrderedProducts?.Add(new Product()
			{
				ID = 32,
				Name = "HotDog",
				Price = 550
			});

			buyers[c2.ID].OrderedProducts?.Add(new Product()
			{
				ID = 2,
				Name = "Pizza",
				Price = 850
			});

			buyers[c2.ID].OrderedProducts?.Add(new Product()
			{
				ID = 19,
				Name = "Apple",
				Price = 120
			});

			foreach (KeyValuePair<int, Customer> customer in buyers)
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