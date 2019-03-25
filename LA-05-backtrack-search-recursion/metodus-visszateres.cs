using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Program
    {
        static void Method(ref int a)
        {
            if( a != 10 ) 
            {
                Console.WriteLine(a);
                a++;
                Method(ref );
            }
        }
        static void Main(string[] args)
        {
            int a = 1;
            Method(ref a);
        }
    }
}
