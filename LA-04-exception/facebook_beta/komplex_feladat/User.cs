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
        public string Role { get; private set; };

        public override string ToString()
        {
            return string.Format(
                "{0} - ({1}) {2}",
                Name, BirthYear, Role
                );
        }

        public override bool Equals(object obj)
        {
            if ((obj as User).Id == this.Id)
                return true;
            else
                return false;
        }

        // gethashcode-ot felül lehet írni, ám jelen tudás szerint nem szükséges
        // így benne hagyunk mindent, csak a warning elkerülése végett rakjuk be

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public User(string name, string id, int byear, string role)
            : base(id)
        {
            this.Name = name;
            this.BirthYear = byear;
            this.Role = role;
        }
    }
}
