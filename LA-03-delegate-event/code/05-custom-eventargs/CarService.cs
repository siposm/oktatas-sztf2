namespace _05_custom_eventargs
{
    class CarService
    {
        public event RepairEventHandler Repaired;
        // event automatically adds sub/unsub methods, so it's safer to use this way then only the delegate

        public void RepairCar(Car car)
        {
            Console.WriteLine("Repairment in progress...");
            Thread.Sleep(3000);

            OnRepaired(car);
        }

        protected virtual void OnRepaired(Car car)
        {
            // null check is important!!!
            // ?.Invoke --> invoke event only if not null

            Repaired?.Invoke(this, new CarEventArgs()
            {
                Car = car
            });

            // 1st param: the sender/source of the event -> this service class
            // 2nd param: event arguments, custom event args class using inheritance
        }
    }
}