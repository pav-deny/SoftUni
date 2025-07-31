using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new();

            foreach (string @string in strings)
            {
                for (int i = 0; i < @string.Length; i++)
                {
                    result.Append(@string);
                }
            }

            Console.WriteLine(result);
        }
    }
}
