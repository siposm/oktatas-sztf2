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

        // 1. delegált + esemény (név: NoSpaceForMoreGroupsEventHandler)
        // 2. FacebookGroup-okat tartalmazó tömb (+indexelő hozzá) + GET

        // CONSTRUCTOR
        
        public FacebookManager(int groupNumber)
        {
            
        }



        // METHODS

        public void CreateGroup(User user, string title)
        {
            // FBGroup létrehozása (paraméterek beállítása)
            // ha van még hely akkor hozzáadni a tömbhöz

            // ezt követően ha betelt akkor esemény formájában jelezzünk
        }

        protected virtual void OnNoMoreGroupsPossible()
        {
            // esemény elsütése
        }

        public void ListGroups()
        {
            // csoportok kilistázása / kiírása (tostringet alkalmazva)
        }
    }
}
