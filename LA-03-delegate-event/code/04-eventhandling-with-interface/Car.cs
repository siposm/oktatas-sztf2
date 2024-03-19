namespace _04_eventhandling_with_interface
{
    class Car
    {
        private IFuelLevelIndicator fuelLevelIndicator;

        public int FuelLevel { get; set; }

        public Car(IFuelLevelIndicator fuelLevelIndicator)
        {
            this.fuelLevelIndicator = fuelLevelIndicator;
        }

        public void Race()
        {
            this.FuelLevel -= 10;

            if(this.FuelLevel < 30)
            {
                this.fuelLevelIndicator.FuelLevelNotification(this.FuelLevel);
                // by using interface reference I can BE SURE that this method will be available on the object, whatever it is, it MUST have this method implemented
            }
        }
    }
}