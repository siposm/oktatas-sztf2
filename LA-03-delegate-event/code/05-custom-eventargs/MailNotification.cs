namespace _05_custom_eventargs
{
    class MailNotification
    {
        public void EMailNotification(object source, CarEventArgs args)
        {
            Console.WriteLine($"[EMAIL] - Car {args?.Car?.LicensePlate} has been repaired.");
        }
    }
}