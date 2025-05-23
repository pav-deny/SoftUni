namespace _10.Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine()); //n
            int distance = int.Parse(Console.ReadLine()); //m
            int exhaustionFactor = int.Parse(Console.ReadLine()); //y

            int pokeCount = 0;
            double halfOfPower = power * 0.5d;

            while (power >= distance)
            {
                power -= distance;
                pokeCount++;

                if (power == halfOfPower && exhaustionFactor != 0)
                {
                    power /= exhaustionFactor;
                }
            }


            Console.WriteLine(power);
            Console.WriteLine(pokeCount);
        }
    }
}
