namespace _02_eventhandling_with_delegate
{
    public delegate void FuelLevelIndicatorHandler(int fuelLevel);
    class Car
    {
        public int Fuel { get; set; }
        //public FuelLevelIndicatorHandler indicator;
        // can be public, but better (safety...) to use as private and have Subscribe/Unsubscribe methods
        private FuelLevelIndicatorHandler indicator;

        public void SubscribeForEvent(FuelLevelIndicatorHandler method)
        {
            this.indicator += method;
        }
        public void UnsubscribeFromEvent(FuelLevelIndicatorHandler method)
        {
            this.indicator -= method;
        }

        public void Race()
        {
            this.Fuel -= 10;

            if (this.Fuel < 30)
            {
                // fire event, send notification that fuel level is too low
                indicator?.Invoke(this.Fuel);
            }
        }
    }

    internal class Program
    {
        static void EmailNotification(int param)
        {
            Console.WriteLine("[EMAIL] Fuel level: " + param);
        }
        static void PushNotification(int param)
        {
            Console.WriteLine("[PUSH] Fuel level: " + param);
        }

        static void Main(string[] args)
        {
            Car car = new Car();
            car.Fuel = 100;

            // if public...
            //car.indicator += EmailNotification;
            //car.indicator += PushNotification;

            // if not public...
            car.SubscribeForEvent(EmailNotification);
            car.SubscribeForEvent(PushNotification);
            car.UnsubscribeFromEvent(PushNotification);

            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race();
            car.Race(); // event is fired
            car.Race(); // event is fired
        }
    }
}