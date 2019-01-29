using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class ActorPage : Page
    {
        string name;

        public string Name
        {
            get { return name; }
            //set { name = value; }
        }
        public ActorPage(string id, string name) : base(id)
        {
            this.name = name;
        }
    }
}
