using System.Numerics;

namespace _08.BeerKegs2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string bestModel = default;
            BigInteger bestVolume = default;

            for (int i = 0; i < count; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                BigInteger volume =(BigInteger)(Math.PI * (radius * radius) * height);

                if (volume > bestVolume)
                {
                    bestVolume = volume;
                    bestModel = model;
                }
            }

            Console.WriteLine(bestModel);
        }
    }
}
