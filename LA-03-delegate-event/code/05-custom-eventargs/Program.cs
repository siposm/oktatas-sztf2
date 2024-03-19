namespace _05_custom_eventargs
{
    delegate void RepairEventHandler(object sender, CarEventArgs args);

    internal class Program
    {
        static void XNotification(object source, CarEventArgs args)
        {
            Console.WriteLine($"[X] - Car {args?.Car?.LicensePlate} has been repaired.");
        }
        static void YNotification(object source, CarEventArgs args)
        {
            Console.WriteLine($"[Y] - Car {args?.Car?.LicensePlate} has been repaired.");
        }

        static void Main(string[] args)
        {
            Car car = new Car();
            car.LicensePlate = "ASD-123";

            CarService service = new CarService();

            service.Repaired += XNotification;
            service.Repaired += YNotification;
            service.Repaired += new FacebookNotification().FacebookPushNotification;
            service.Repaired += new MailNotification().EMailNotification;

            //service.Repaired.Invoke
            // safety feature: event can't be invoked outside it's class, while the delegate can be

            service.RepairCar(car);
        }
    }
}