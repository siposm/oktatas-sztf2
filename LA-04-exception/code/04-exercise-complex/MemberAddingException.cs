namespace _04_exercise_complex
{
    class MemberAddingException : Exception
    {
        string exceptionMessage;

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public MemberAddingException(string msg)
        {
            this.exceptionMessage = msg;
        }
    }
}