namespace _04_exercise_complex
{
    class NoMoreMemberException : Exception
    {
        string exceptionMessage;

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public NoMoreMemberException(string msg)
        {
            this.exceptionMessage = msg;
        }
    }
}