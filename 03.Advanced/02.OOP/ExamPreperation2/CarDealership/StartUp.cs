using CarDealership.Core;
using CarDealership.Core.Contracts;
using CarDealership.Models;

namespace CarDealership
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
