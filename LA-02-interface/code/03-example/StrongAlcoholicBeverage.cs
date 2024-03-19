namespace _03_example
{
    class StrongAlcoholicBeverage : AlcoholicBeverage, IAlcoholic
    {
        public bool AgeRestricted()
        {
            return true;
        }

        public double AlcoholLevel()
        {
            return 1.3104;
        }
    }
}