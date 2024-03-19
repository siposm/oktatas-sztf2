using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kivkez_3
{
    class BaseException : Exception
    {
        public string ErrorMessage { get; set; }
    }

    class NoMoreSpaceException : BaseException
    {
        public YouTubeUser User { get; set; }
    }

    class TooLongVideoTitleException : BaseException // elnevezési konvenció!
    {
        public Video Video { get; set; }

        public TooLongVideoTitleException(string message, Video video)
        {
            this.ErrorMessage = message;
            this.Video = video;
        }
    }

    class YouTubeUser
    {
        public string Name { get; set; }
    }
    
    class Video
    {
        public string Title { get; set; }
    }

    class YouTubeManager
    {
        public YouTubeUser[] Users { get; set; }
        public int ActiveUsersCount { get; set; }

        public bool AddUser(YouTubeUser user)
        {
            if (ActiveUsersCount < Users.Length)
            {
                Users[ActiveUsersCount++] = user;
                return true;
            }
            else
                // metódus visszatérése lehet kivétel IS
                throw new NoMoreSpaceException()
                {
                    User = user,
                    ErrorMessage = "The array is full."
                };
        }

        public void AddVideoToUser(YouTubeUser user, Video video)
        {
            // megkeressük egy képzeletbeli adatbázisban ezt a user-t...
            // és az ő "tömbjéhez" hozzáadjuk a videót...
            
            // a probléma viszont abból adódik, hogy a videó címe nem lehet hosszabb mint 5 karakter (tegyük fel...)
            if (video.Title.Length > 5)
            {
                throw new TooLongVideoTitleException("You tried to give too long title to your video!", video);
            }
            else
            {
                // minden oké, feltöltjük a videót...
            }
        }
    }


    class Program
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
            catch( NoMoreSpaceException e )
            {
                Console.WriteLine("ERROR - " + e.ErrorMessage);
                Console.WriteLine("User: " + e.User.Name);
            }

            try
            {
                ytm.AddVideoToUser(user, new Video() { Title = "Die Hard" });   // dob kivételt
                // ytm.AddVideoToUser(user, new Video() { Title = "Die" });     // nem dob kivételt 
            }
            catch (TooLongVideoTitleException e)
            {
                Console.WriteLine("ERROR - " + e.ErrorMessage);
                Console.WriteLine("> Problematic title: " + e.Video.Title);
            }

        }
    }
}
