using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value <= TankCapacity)
                    fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (FuelQuantity < neededFuel)
                return $"{GetType().Name} needs refueling";

            FuelQuantity -= neededFuel;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual string Refuel(double amount)
        {
            if (amount <= 0)
                return "Fuel must be a positive number";

            if (FuelQuantity + amount > TankCapacity)
                return $"Cannot fit {amount} fuel in the tank";

            FuelQuantity += amount;
            return "Refueled";
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
