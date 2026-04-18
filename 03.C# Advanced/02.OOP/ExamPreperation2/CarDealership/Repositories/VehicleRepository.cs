using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> _vehicles;

        public VehicleRepository()
        {
            _vehicles = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models => _vehicles.AsReadOnly();


        public void Add(IVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public bool Exists(string model)
        {
           return _vehicles.Any(v => v.Model == model);
        }

        public IVehicle Get(string model)
        {
            return _vehicles.FirstOrDefault(v => v.Model == model);
        }

        public bool Remove(string model)
        {
            IVehicle vehicle = Get(model);

            return _vehicles.Remove(vehicle);//Remove() returns bool
        }
    }
}
