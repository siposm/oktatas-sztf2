namespace _02_hashtable
{
    class NoSpaceHashException : HashException
    {
        public NoSpaceHashException(string message) : base(message)
        {

        }
        public NoSpaceHashException()
        {

        }
    }
}