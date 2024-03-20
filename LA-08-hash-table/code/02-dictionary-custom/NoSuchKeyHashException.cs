namespace _02_hashtable
{
    class NoSuchKeyHashException : HashException
    {
        public NoSuchKeyHashException(string message) : base(message)
        {

        }
        public NoSuchKeyHashException()
        {

        }
    }
}