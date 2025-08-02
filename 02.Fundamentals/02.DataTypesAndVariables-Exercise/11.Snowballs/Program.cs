using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowbalCount = int.Parse(Console.ReadLine());

            //Theese are the best values
            BigInteger bestValue = 0;
            decimal bestSnow = 0;
            decimal bestTime = 0;
            decimal bestQuality = 0;
            //Untill here

            for (int i = 0; i < snowbalCount; i++)
            {
                //Theese are the values that will change each iteration of the loop (the current ones)
               int snow = int.Parse(Console.ReadLine());
               int time = int.Parse(Console.ReadLine());
               int quality = int.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow((BigInteger)snow / time, quality);

                if (bestValue < value)
                {
                    bestValue = value;
                    bestQuality = quality;
                    bestSnow = snow;
                    bestTime = time;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

        }
    }
}
