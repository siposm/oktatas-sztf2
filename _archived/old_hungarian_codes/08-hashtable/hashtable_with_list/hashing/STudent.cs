using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
