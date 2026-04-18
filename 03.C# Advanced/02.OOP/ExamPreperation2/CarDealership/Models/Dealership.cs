using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models
{
    public class Dealership : IDealership
    {
        private readonly IRepository<IVehicle> _vehicles;
        private readonly IRepository<ICustomer> _customers;

        public Dealership()
        {
            _vehicles = new VehicleRepository();
            _customers = new CustomerRepository();
        }

        public IRepository<IVehicle> Vehicles => _vehicles;

        public IRepository<ICustomer> Customers => _customers;
    }
}
