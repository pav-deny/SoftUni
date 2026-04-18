using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private readonly List<ICustomer> _customers;

        public CustomerRepository()
        {
            _customers = new List<ICustomer>();
        }

        public IReadOnlyCollection<ICustomer> Models => _customers.AsReadOnly();


        public void Add(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public bool Exists(string name)
        {
            return _customers.Any(v => v.Name == name);
        }

        public ICustomer Get(string text)
        {
            return _customers.FirstOrDefault(v => v.Name == text);
        }

        public bool Remove(string name)
        {
            ICustomer customer = Get(name);

            return _customers.Remove(customer);//Remove() returns bool
        }
    }
}
