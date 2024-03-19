namespace _04_icomparable
{
    class Product : IComparable
    {
        public int Price { get; set; }
        public string? Name { get; set; }

        public int CompareTo(object? otherProduct)
        {
            // inside this method I can define the way of the comparison precisely

            // 1. long way if multiple properties should be considered...
            //if ((otherProduct as Product)?.Price > this.Price
            //    &&
            //    (otherProduct as Product)?.Name?.Length > this.Name?.Length)
            //{
            //    return -1;
            //}
            //else if ((otherProduct as Product)?.Price < this.Price
            //    &&
            //    (otherProduct as Product)?.Name?.Length < this.Name?.Length)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}

            // 2. short way if there is only 1 property as base of comparison
            return this.Price.CompareTo((otherProduct as Product)?.Price);
        }

        public override string ToString()
        {
            return $"{Name} - {Price} HUF";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product_A = new Product();
            product_A.Price = 1000;
            
            Product product_B = new Product();
            product_B.Price = 80;

            Console.WriteLine(product_A.CompareTo(product_B));
            Console.WriteLine(product_B.CompareTo(product_A));
            product_A.Price = 80;
            Console.WriteLine(product_A.CompareTo(product_B));

            
            
            
            // Prebuilt things also use CompareTo, like Array.Sort
            
            Product[] items = new Product[10];
            Random r = new Random();

            // upload
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Product
                {
                    Price = r.Next(10000),
                    Name = "noname"
                };
            }

            Console.WriteLine("\nBASE LIST\n");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }

            Console.WriteLine("\nORDERED LIST\n");
            Array.Sort(items);
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}