namespace _03_custom_exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YouTubeManager ytm = new YouTubeManager();
            YouTubeUser user = new YouTubeUser() { Name = "Neumann Janos" };

            ytm.Users = new YouTubeUser[3];
            ytm.ActiveUsersCount = 0;

            try
            {
                ytm.AddUser(user);
                ytm.AddUser(user);
                ytm.AddUser(user);
                ytm.AddUser(user);
            }
            catch (NoMoreSpaceException e)
            {
                Console.WriteLine("ERROR - " + e.ErrorMessage);
                Console.WriteLine("User: " + e.User.Name);
            }

            try
            {
                ytm.AddVideoToUser(user, new Video() { Title = "Die Hard" });   // exception
                // ytm.AddVideoToUser(user, new Video() { Title = "Die" });     // no exception
            }
            catch (TooLongVideoTitleException e)
            {
                Console.WriteLine("ERROR - " + e.ErrorMessage);
                Console.WriteLine("> Problematic title: " + e.Video.Title);
            }
        }
    }
}