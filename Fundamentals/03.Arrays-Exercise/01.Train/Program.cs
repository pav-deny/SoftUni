namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] passangersInWagons = new int[n];
            int sumOfPassengers = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                passangersInWagons[i] = int.Parse(input);
                sumOfPassengers += int.Parse(input);
            }

            Console.WriteLine(string.Join(" ", passangersInWagons));
            Console.WriteLine(sumOfPassengers);
        }
    }
}
