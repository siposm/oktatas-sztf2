namespace _01_recursion
{
    internal class Program
    {
        public static int Summation(int[] A, int N)
        {
            if (N == 0)
                return 0;
            else
                return A[N - 1] + Summation(A, N - 1);
        }

        public static bool Decision(int[] A, int N)
        {
            if (N == 0)
                return false;
            else
                return (A[N - 1] % 15 == 0) || Decision(A, N - 1);
        }

        public static int FindMax(int[] A, int N)
        {
            if (N == 1)
                return 0;
            else
            {
                return A[N - 1] > A[FindMax(A, N - 1)] ? N - 1 : FindMax(A, N - 1);
            }
        }

        public static int LogSearch(int[] A, int lookFor, int bottomIndex, int topIndex)
        {
            if (bottomIndex > topIndex) return -1;

            int center = (bottomIndex + topIndex) / 2;
            if (A[center] > lookFor) return LogSearch(A, lookFor, bottomIndex, center - 1);
            else
                if (A[center] < lookFor) return LogSearch(A, lookFor, center + 1, topIndex);
            else
                return center;
        }
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 4, 5, 7, 9, 10, 11, 14, 16, 20, 25, 30, 46, 54 };

            //1. question - 252
            Console.WriteLine("1. Question: What is the sum of the numbers?");
            Console.WriteLine(Summation(A, A.Length));

            //2. question - True
            Console.WriteLine("2. Question: Is there any number which is divisible by 15?");
            Console.WriteLine(Decision(A, A.Length));

            //3. question - 13
            Console.WriteLine("3. Question: Where can the biggest number be found?");
            Console.WriteLine(FindMax(A, A.Length));

            //4. question - 10
            Console.WriteLine("4. Question: Where is number 25?");
            Console.WriteLine(LogSearch(A, 25, 0, A.Length - 1));
        }
    }
}