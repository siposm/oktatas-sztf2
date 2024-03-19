namespace _03_eventhandling_with_event
{
    // STEPS:
    //      1. define and create delegate
    //      2. create event based on delegate
    //      3. fire the event whenever needed

    delegate void RepairEventHandler(object sender, EventArgs e);

    internal class Program
    {
        static void XNotification(object source, EventArgs e)
        {
            Console.WriteLine("[X] - Car has been repaired.");
        }
        static void YNotification(object source, EventArgs e)
        {
            Console.WriteLine("[Y] - Car has been repaired.");
        }

        static void Main(string[] args)
        {
            Car car = new Car();
            car.LicensePlate = "ASD-123";

            CarService service = new CarService();

            service.Repaired += XNotification;
            service.Repaired += YNotification;
            service.Repaired += new FacebookNotification().FacebookPushNotification;
            service.Repaired += new MailNotification().MailNotification;

            //service.Repaired.Invoke
            // safety feature: event can't be invoked outside it's class, while the delegate can be

            service.RepairCar(car);
        }
    }
}