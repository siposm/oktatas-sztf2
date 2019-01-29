using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kivkez_3
{
    class TooLongVideoTitleException : Exception // elnevezési konvenció!
    {
        string exceptionMessage;
        Video video;

        public Video Video
        {
            get { return video; }
            //set { video = value; }
        }

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public TooLongVideoTitleException(string message, Video video)
        {
            this.exceptionMessage = message;
            this.video = video;
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

            try
            {
                ytm.AddVideoToUser(user, new Video() { Title = "Die Hard" });   // dob kivételt
                // ytm.AddVideoToUser(user, new Video() { Title = "Die" });     // nem dob kivételt 
            }
            catch (TooLongVideoTitleException e)
            {
                Console.WriteLine("ERROR - " + e.ExceptionMessage);
                Console.WriteLine("> Problematic title: " + e.Video.Title);
            }

        }
    }
}
