namespace _01_basics
{
    internal class Program
    {
        static int Division(int a, int b)
        {
            if (b == 0)
            {
                return -1;
                // return some special value if error happens
                // ok but -1 can be the real value
            }
            else
            {
                return a / b;
            }
        }

        static int Division_2(int a, int b, ref int result)
        {
            if (b == 0)
            {
                return -1; // error
            }
            else
            {
                result = a / b;
                return 1; // no error
            }
        }

        // more appropiate to use bool as error/no error flag
        // result: too complicated code even in a small example as division
        static bool Division_3(int a, int b, ref int result)
        {
            if (b == 0)
            {
                return true; // error
            }
            else
            {
                result = a / b;
                return false; // no error
            }
        }

        static int Division_4(int a, int b)
        {
            return a / b;
        }


        static void Main(string[] args)
        {
            int result = 0;
            Division_2(10, 5, ref result);

            Console.WriteLine(result);

            try
            {
                Division_4(10, 0);
            }
            catch (Exception)
            {
                Console.WriteLine("Error happened...");
                Console.WriteLine("But at least, the program hasn't crashed...");
            }

            Console.WriteLine("And the program runs flawlessly after the exception as well!");
        }
    }
}