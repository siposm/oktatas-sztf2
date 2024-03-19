namespace _04_eventhandling_with_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFuelLevelIndicator notification = new Notification();
            Car car = new Car(notification);
            car.FuelLevel = 100;

            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race(); // "event"
            car.Race(); // "event"
        }
    }
}