namespace _01_delegate
{
    class SomeTestClass
    {
        public void SomeMethod(string param)
        {
            Console.WriteLine("**" + param);
        }
    }

    // the delegate must be created on class level
    
    delegate void DelegateForMethods(string param);
    
    delegate void SomeDelegate(int a, int b);

    internal class Program
    {
        static void Method_1(string param)
        {
            Console.WriteLine(">>" + param);
        }

        static void Method_2(string someParam)
        {
            Console.WriteLine("=>" + someParam);
        }

        static void Method_3(string input)
        {
            Console.WriteLine("::" + input);
        }

        static void Method_4(int szam1, int szam2)
        {
            Console.WriteLine(szam1 + szam2);
        }



        static void Main(string[] args)
        {
            DelegateForMethods dfm = new DelegateForMethods(Method_1);
            // some method must be passed as parameter at first

            dfm += Method_2; // note: there is no (), it's not a method call!
            dfm += Method_3;
            //dfm += Method_4; // not working, method signature differs!

            SomeTestClass stc = new SomeTestClass();
            dfm += stc.SomeMethod;

            dfm -= Method_1;

            dfm("some string parameter");
            // by calling the delegate, all registered methods will be called with the same parameter

            dfm -= Method_2;
            dfm -= Method_3;
            dfm -= stc.SomeMethod;
            dfm("test"); // no null check! -> exception if nothing is inside the delegate

            SomeDelegate sd = new SomeDelegate(Method_4);
            sd(100, 200);
        }
    }
}