using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new(150, 100);

            car.Drive(50);
            Console.WriteLine(car.Fuel);
        }
    }
}
