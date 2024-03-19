using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class FacebookService
    {
        public string GenerateID()
        {
            // TODO: jól működő ID generáló algoritmust fejleszteni :)

            Random r = new Random();
            return r.Next(10000, 90000).ToString();
        }

        public void OnMembersAreFull(object source, FacebookGroupEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("[FB-EVENT] : this group is full with members, no more can fit.");
            Console.WriteLine("\t> Group: " + args.FBGroup.Title + " (owner: " + args.FBGroup.Owner.Name + ")");
            Console.WriteLine();
        }

        public void OnNoMoreGroupsPossible(object source, EventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("[FB-EVENT] : can't create more groups! We are limited.");
            Console.WriteLine();
        }
    }
}
