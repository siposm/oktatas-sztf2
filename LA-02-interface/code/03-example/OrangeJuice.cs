namespace _03_example
{
    class OrangeJuice : IAlcoholic
    {
        public string? Brand { get; set; }

        public bool AgeRestricted()
        {
            return false;
        }

        public double AlcoholLevel()
        {
            return 0.0;
        }
    }
}