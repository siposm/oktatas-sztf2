namespace _03_eventhandling_with_event
{
    class FacebookNotification
    {
        public void FacebookPushNotification(object source, EventArgs e)
        {
            Console.WriteLine("[PUSH] - Car has been repaired.");
        }
    }
}