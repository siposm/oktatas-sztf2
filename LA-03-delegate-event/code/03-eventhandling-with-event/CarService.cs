namespace _03_eventhandling_with_event
{
    class CarService
    {
        public event RepairEventHandler Repaired;
        // event automatically adds sub/unsub methods, so it's safer to use this way then only the delegate

        public void RepairCar(Car car)
        {
            Console.WriteLine("Repairment in progress...");
            Thread.Sleep(3000);

            OnRepaired();
        }

        protected virtual void OnRepaired()
        {
            // null check is important!!!
            // ?.Invoke --> invoke event only if not null

            Repaired?.Invoke(this, EventArgs.Empty);
            
            // 1st param: the sender/source of the event -> this service class
            // 2nd param: event arguments, currently nothing (empty)
        }
    }
}