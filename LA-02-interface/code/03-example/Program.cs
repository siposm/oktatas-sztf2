namespace _03_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // interface can be used as reference, but cannot create instance with interface type
            // IAlcoholic x = new IAlcoholic(); // not working

            IAlcoholic[] drinks = new IAlcoholic[4];
            drinks[0] = new StrongAlcoholicBeverage() { Name = "X" };
            drinks[1] = new LightlyAlcoholicBeverage() { Name = "Y" };
            drinks[2] = new StrongAlcoholicBeverage() { Name = "Z" };
            drinks[3] = new OrangeJuice() { Brand = "MyBrand" };

            // Polymorphism can be achieved using interfaces.
            // In this case there is ONLY late binding.
            // Early binding is not even possible, since there is nothing in the "base" (interface).
            
            for (int i = 0; i < drinks.Length; i++)
            {
                Console.WriteLine(drinks[i].AlcoholLevel());
                // Name property can't be retrieved since we are using it through the interface reference,
                //      and that does not contain Name property

                // ...but we can still use the 'is-as' keywords!
                if (drinks[i] is AlcoholicBeverage)
                {
                    Console.WriteLine((drinks[i] as AlcoholicBeverage)?.Name);
                }
            }
        }
    }
}