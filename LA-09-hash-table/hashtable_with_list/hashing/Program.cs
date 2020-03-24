using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableWithList<int, Student> ht = new HashTableWithList<int, Student>(10);

            ht.Insert(102, new Student("Test Student 1"));
            ht.Insert(102, new Student("Test Student 2"));
            ht.Insert(102, new Student("Test Student 3"));

            ht.Delete(102);
            ht.Delete(102);
            ht.Delete(102);

            try
            {
                Console.WriteLine(ht.Search(102));
            }
            catch (NoSuchKeyHashingException e)
            {
                Console.WriteLine("[ERR] " + e.Message);
            }
        }
    }
}
