namespace _03_eventhandling_with_event
{
    class MailNotification
    {
        public void MailNotification(object source, EventArgs e)
        {
            Console.WriteLine("[MAIL] - Car has been repaired.");
        }
    }
}