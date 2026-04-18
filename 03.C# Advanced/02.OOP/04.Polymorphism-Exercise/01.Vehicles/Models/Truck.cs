namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        private const double RefuelDecreasePercent = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption) { }

        public override double FuelConsumption => base.FuelConsumption + ConsumptionIncrease;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * RefuelDecreasePercent);
        }
    }
}
