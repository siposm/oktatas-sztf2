namespace _05_custom_eventargs
{
    class FacebookNotification
    {
        public void FacebookPushNotification(object source, CarEventArgs args)
        {
            Console.WriteLine($"[PUSH] - Car {args?.Car?.LicensePlate} has been repaired.");
        }
    }
}