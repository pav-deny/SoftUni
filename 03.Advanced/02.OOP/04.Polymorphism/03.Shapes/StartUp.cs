using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(3, 10);

            Console.WriteLine("P(r) = " + rectangle.CalculatePerimeter());
            Console.WriteLine("S(r) = " + rectangle.CalculateArea());

            Console.WriteLine();

            Shape circle = new Circle(3);

            Console.WriteLine("P(c) = " + circle.CalculatePerimeter());
            Console.WriteLine("S(c) = " + circle.CalculateArea());
        }
    }
}
