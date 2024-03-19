namespace _03_custom_exceptions
{
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
                // the return of the method can be exception AS WELL
                throw new NoMoreSpaceException()
                {
                    User = user,
                    ErrorMessage = "The array is full."
                };
        }

        public void AddVideoToUser(YouTubeUser user, Video video)
        {
            if (video.Title.Length > 5)
            {
                throw new TooLongVideoTitleException("You tried to give too long title to your video!", video);
            }
            else
            {
                // all is good, upload the video
                // find the user in the database and add the video to his collection
            }
        }
    }
}