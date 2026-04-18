namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        private const double RefuelDecreasePercent = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        public override double FuelConsumption => base.FuelConsumption + ConsumptionIncrease;

        public override string Refuel(double amount)
        {
            if (amount <= 0)
                return "Fuel must be a positive number";

            if (FuelQuantity + amount > TankCapacity)
                return $"Cannot fit {amount} fuel in the tank";

            return base.Refuel(amount * RefuelDecreasePercent);
        }
    }
}
