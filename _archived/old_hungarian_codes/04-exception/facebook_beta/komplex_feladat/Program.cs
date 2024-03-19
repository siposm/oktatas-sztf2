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


            User user1 = new User(
                "Neumann Janos",
                fbservice.GenerateID(),
                1903,
                "ROLE_USER");

            User user2 = new User(
                "Nikola Tesla",
                fbservice.GenerateID(),
                1856,
                "ROLE_ADMIN");

            User user3 = new User(
                "Gipsz Jakab",
                fbservice.GenerateID(),
                1990,
                "ROLE_USER");


            fbmanager.CreateGroup(user1, "#Programming");
            
            // már van csoport, lehet feliratkozni
            fbmanager.Groups[0].MembersAreFull += fbservice.OnMembersAreFull;
            fbmanager.NoMoreGroupsPossible += fbservice.OnNoMoreGroupsPossible;
            
            fbmanager.CreateGroup(user2, "I <3 cars");
            fbmanager.CreateGroup(user1, "Matek orrvérzésig");
            fbmanager.CreateGroup(user1, "Ez már sok lesz csoportnak"); // -> esemény
            

            try
            {
                
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3); // ***
                
                // *** -> itt fog exception dobódni, kommentezd ki és akkor jön a következő utasítás
                // aminél member adding exc. fog dobódni
                

                fbmanager.Groups[0].AddMember(user3, user1); // member adding exception
            }
            catch(NoMoreMemberException e)
            {
                Console.WriteLine(">>> " + e.ExceptionMessage);
            }
            catch(MemberAddingException e)
            {
                Console.WriteLine(">>> " + e.ExceptionMessage);
            }


            fbmanager.ListGroups();



            Console.ReadLine();
        }
    }
}
