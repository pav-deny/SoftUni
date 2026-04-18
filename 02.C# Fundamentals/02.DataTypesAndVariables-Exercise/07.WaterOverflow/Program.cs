namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int totalLitres = 0;

                for (int i = 0; i < count; i++)
                {
                    int currentLitres = int.Parse(Console.ReadLine());

                    if (currentLitres + totalLitres > 255)
                    {
                        Console.WriteLine("Insufficient capacity!");
                        continue;
                    }

                    totalLitres += currentLitres;
                }

                Console.WriteLine(totalLitres);
            
        }
    }
}
