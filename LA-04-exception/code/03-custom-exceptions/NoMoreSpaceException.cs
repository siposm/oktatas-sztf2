namespace _03_custom_exceptions
{
    class NoMoreSpaceException : BaseException
    {
        public YouTubeUser? User { get; set; }
    }
}