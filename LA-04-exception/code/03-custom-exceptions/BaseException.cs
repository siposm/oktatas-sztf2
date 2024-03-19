namespace _03_custom_exceptions
{
    class BaseException : Exception
    {
        public string? ErrorMessage { get; set; }
    }
}