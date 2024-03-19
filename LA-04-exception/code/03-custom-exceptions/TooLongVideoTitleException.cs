namespace _03_custom_exceptions
{
    class TooLongVideoTitleException : BaseException // naming convention
    {
        public Video Video { get; set; }

        public TooLongVideoTitleException(string message, Video video)
        {
            this.ErrorMessage = message;
            this.Video = video;
        }
    }
}