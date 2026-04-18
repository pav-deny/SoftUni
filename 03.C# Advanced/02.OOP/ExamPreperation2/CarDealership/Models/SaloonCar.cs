namespace CarDealership.Models
{
    public class SaloonCar : Vehicle
    {
        private const double PriceFactor = 1.10;//+10% (100 + 10 = 110; 110/ 100 = 1.1)

        public SaloonCar(string model, double price)
            : base(model, price * PriceFactor) { }
    }
}
