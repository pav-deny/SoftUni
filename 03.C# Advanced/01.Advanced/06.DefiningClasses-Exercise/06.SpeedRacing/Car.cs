namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            private set { this.travelledDistance = value; }
        }

        public bool Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption;

            if (fuelNeeded > this.fuelAmount)
            {
                return false;
            }
            
            this.FuelAmount -= fuelNeeded;
            this.TravelledDistance += distance;

            return true;
        }
    }
}
