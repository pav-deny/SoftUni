using static System.Net.Mime.MediaTypeNames;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> printSir = s => Console.WriteLine($"Sir {s}");

            foreach (string s in names)
                printSir(s);
        }
    }
}
