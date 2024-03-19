namespace _01_abstract_vs_interface
{
    abstract class AlcoholicBeverage
    {
        public abstract double AlcoholLevel();

        public abstract bool AgeRestricted();
    }

    class StrongDrink : AlcoholicBeverage
    {
        public override double AlcoholLevel()
        {
            return 0.768;
        }
        public override bool AgeRestricted()
        {
            return true;
        }
    }



    // Achieving the same result using abstract class (above) and by using interface (below).



    interface IAlcoholicBeverage
    {
        double AlcoholLevel();
        bool AgeRestricted();
    }

    public class LightDrink : IAlcoholicBeverage
    {

        public double AlcoholLevel()
        {
            return 0.052;
        }

        public bool AgeRestricted()
        {
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}