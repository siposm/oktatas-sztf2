using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    sealed class User : Entity
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        string role;

        public string Role
        {
            get { return role; }
        }
        

        public User(string name, string id, int byear, string role)
            : base(id)
        {
            this.Name = name;
            this.BirthYear = byear;
            this.role = role;
        }
    }
}
