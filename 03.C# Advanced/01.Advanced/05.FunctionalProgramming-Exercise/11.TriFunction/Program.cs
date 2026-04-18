namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> checkSum = (n, s) => n.Sum(l => l) >= s;

            foreach (string name in names)
            {
                if (checkSum(name, n))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
