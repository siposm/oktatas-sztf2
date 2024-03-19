namespace _02_multiple_exceptions
{
    internal class Program
    {
        static void ConsoleWrite(string param)
        {
            Console.WriteLine("-------------");
            Console.WriteLine("\t" + param);
            Console.WriteLine("-------------");
        }
        static void ArrayHandling()
        {
            ConsoleWrite("Size of the array: ");

            int[] array = new int[int.Parse(Console.ReadLine())];
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("> value: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            ConsoleWrite("Get this element: ");
            Console.WriteLine(array[int.Parse(Console.ReadLine())]);

            // in this example we can see that even a small example can have multiple exceptions
            //      format exception: int parse received invalid character
            //      index out of range exception: invalid number compared to the size of the array
            //      etc.
        }

        static void TestMethod(string param)
        {
            if (param == "index")
            {
                throw new IndexOutOfRangeException("Index problem happened!");
            }
            if (param == "stack")
            {
                throw new StackOverflowException("Some error message.");
            }
            if (param == "format")
            {
                throw new FormatException("Format problem...");
            }
            if (param == "zero")
            {
                throw new DivideByZeroException("You can't divide by zero!!!");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                TestMethod("index");
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine("[ERROR] " + exc.Message);
            }
            catch (StackOverflowException exc)
            {
                Console.WriteLine("[ERROR] " + exc.Message);
                Console.WriteLine("Visit stackoverflow.com.");
            }
            catch (FormatException exc)
            {
                Console.WriteLine("[ERROR] " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Runs in any case.");
            }
        }
    }
}