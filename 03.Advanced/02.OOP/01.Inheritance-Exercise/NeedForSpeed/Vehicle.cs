namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double VehicleFuelConsumption = 1.25;

        protected Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption { get { return VehicleFuelConsumption; } }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
