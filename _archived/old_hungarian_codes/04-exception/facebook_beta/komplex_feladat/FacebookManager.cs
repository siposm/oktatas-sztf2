using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class FacebookManager
    {
        // FIELDS AND PROPERTIES

        public delegate void NoSpaceForMoreGroupsEventHandler(object source, EventArgs args);
        public event NoSpaceForMoreGroupsEventHandler NoMoreGroupsPossible;
        FacebookGroup[] groups;
        int groupIndex; // listát használva nem kéne ilyennel szórakozni
        public FacebookGroup[] Groups { get { return groups; } }



        // CONSTRUCTOR
        
        public FacebookManager(int groupNumber)
        {
            groups = new FacebookGroup[groupNumber];
            groupIndex = 0;
        }



        // METHODS

        public void CreateGroup(User user, string title)
        {
            FacebookGroup group = new FacebookGroup(user, title);
            group.StartYear = DateTime.Now.Year;
            if(groups.Length > groupIndex)
                groups[groupIndex++] = group;

            // esemény ha megtelik és nem lehet már több csoport!
            if(groupIndex == groups.Length)
                OnNoMoreGroupsPossible();
        }

        protected virtual void OnNoMoreGroupsPossible()
        {
            if (NoMoreGroupsPossible != null)
                NoMoreGroupsPossible(this, EventArgs.Empty);
        }

        public void ListGroups()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("====================================");
            Console.WriteLine("| FACEBOOK GROUPS");
            Console.WriteLine("====================================");

            for (int i = 0; i < groupIndex; i++)
            {
                Console.WriteLine("| "+groups[i]); // toString override (Y)
            }

            Console.WriteLine("====================================");
        }
    }
}
