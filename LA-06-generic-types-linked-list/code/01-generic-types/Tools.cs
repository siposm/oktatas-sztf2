namespace _01_generic_types
{
    class Tools
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public T FindMax<T>(T a, T b) where T : IComparable
        {
            //if (a > b)
            //    return a;
            //else if (a == b)
            //    return a;
            //else 
            //    return b;

            if (a.CompareTo(b) > 0)
                return a;
            else
                return b;
        }
        public T FindMin<T>(T a, T b) where T : IComparable
        {
            if (a.CompareTo(b) < 0)
                return a;
            else
                return b;
        }
        public bool CompareByValue<T, K>(T valueA, K valueB)
        {
            return valueA.Equals(valueB);
        }
        public bool CompareByType<T, K>()
        {
            return typeof(T).Equals(typeof(K));
        }
    }
}