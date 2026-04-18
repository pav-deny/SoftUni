using System;
using System.Net.NetworkInformation;

namespace Shapes
{
    internal class Circle : Shape
    {
        private const double Pi = Math.PI;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }
        public override double CalculatePerimeter()
        {
            return 2 * Pi * Radius;
        }

        public override double CalculateArea()
        {
            return Pi * Radius * Radius;
        }

        public override string Draw()
        {
            return "Drawing Circle";
        }
    }
}
