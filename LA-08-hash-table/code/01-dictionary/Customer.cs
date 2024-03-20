namespace _01_dictionary
{
    class Customer
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public List<Product>? OrderedProducts { get; set; }

		public override string ToString()
		{
			return $"[Customer: ID={ID}, Name={Name}]";
		}

	}
}