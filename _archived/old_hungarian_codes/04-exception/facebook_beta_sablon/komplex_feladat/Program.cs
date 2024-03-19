using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            FacebookManager fbmanager = new FacebookManager(3);
            FacebookService fbservice = new FacebookService();


        // TODO ********** userek létrehozása!...


            fbmanager.CreateGroup(user1, "#Programming");
            
            // már van csoport, lehet feliratkozni
            fbmanager.Groups[0].MembersAreFull += fbservice.OnMembersAreFull;
            fbmanager.NoMoreGroupsPossible += fbservice.OnNoMoreGroupsPossible;
            
            fbmanager.CreateGroup(user2, "I <3 cars");
            fbmanager.CreateGroup(user1, "Matek orrvérzésig");
            fbmanager.CreateGroup(user1, "Ez már sok lesz csoportnak"); // -> esemény
            

        // TODO ********** addmembernél hiba adódhat!...
                
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3); // ***
                
                // *** -> itt fog exception dobódni, kommentezd ki és akkor jön a következő utasítás
                // aminél member adding exc. fog dobódni
                

                fbmanager.Groups[0].AddMember(user3, user1); // member adding exception



            fbmanager.ListGroups();



            Console.ReadLine();
        }
    }
}
