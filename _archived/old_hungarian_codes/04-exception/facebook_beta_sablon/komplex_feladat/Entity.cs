using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    abstract class Entity
    {
        string id;
        int regDate;

        public string Id
        {
            get { return id; }
            //set { Id = value; }
        }
        
        public int RegDate
        {
            get { return regDate; }
            //set { regDate = value; }
        }


        public Entity(string id)
        {
            this.id = id;
            this.regDate = DateTime.Now.Year;
        }

    }
}
