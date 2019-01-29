using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Telefon
    {
        public string Marka { get; set; }

        public override string ToString()
        {
            return this.Marka;
        }
    }
}
