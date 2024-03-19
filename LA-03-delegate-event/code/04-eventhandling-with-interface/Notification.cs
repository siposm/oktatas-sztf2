namespace _04_eventhandling_with_interface
{
    class Notification : IFuelLevelIndicator
    {
        public void FuelLevelNotification(int amount)
        {
            Console.WriteLine("Current level: " + amount);
        }
    }
}