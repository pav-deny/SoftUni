using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    internal class Bus : Vehicle, ISpecialisedVehicle
    {
        private const double ConsumptionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        public override double FuelConsumption => base.FuelConsumption + ConsumptionIncrease;

        public string DriveEmpty(double distance)
        {
            base.FuelConsumption -= ConsumptionIncrease;
            return this.Drive(distance);
        }
    }
}
