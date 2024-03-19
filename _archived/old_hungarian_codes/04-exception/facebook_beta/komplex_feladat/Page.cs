using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    abstract class Page : Entity
    {
        public string Topic { get; set; }

        public Page(string id) : base(id)
        {

        }

        public Page(string id, string topic) : base(id)
        {
            this.Topic = topic;
        }
    }
}
