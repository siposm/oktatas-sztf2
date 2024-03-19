namespace _03_example
{
    class LightlyAlcoholicBeverage : AlcoholicBeverage, IAlcoholic // order is important! First: base class, then interface(s)
    {
        public bool AgeRestricted()
        {
            return false;
        }

        public double AlcoholLevel()
        {
            return 0.0053;
        }
    }
}