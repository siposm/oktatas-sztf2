namespace _04_exercise_complex
{
    internal class Program
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
                "John Doe",
                fbservice.GenerateID(),
                1990,
                "ROLE_USER");


            fbmanager.CreateGroup(user1, "#Programming");

            fbmanager.Groups[0].MembersAreFull += fbservice.OnMembersAreFull;
            fbmanager.NoMoreGroupsPossible += fbservice.OnNoMoreGroupsPossible;

            fbmanager.CreateGroup(user2, "Food lovers");
            fbmanager.CreateGroup(user1, "Programming fanclub");
            fbmanager.CreateGroup(user1, "Science club"); // -> event


            try
            {

                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3);
                fbmanager.Groups[0].AddMember(user1, user3); // exception

                fbmanager.Groups[0].AddMember(user3, user1); // member adding exception
            }
            catch (NoMoreMemberException e)
            {
                Console.WriteLine(">>> " + e.ExceptionMessage);
            }
            catch (MemberAddingException e)
            {
                Console.WriteLine(">>> " + e.ExceptionMessage);
            }


            fbmanager.ListGroups();
        }
    }
}