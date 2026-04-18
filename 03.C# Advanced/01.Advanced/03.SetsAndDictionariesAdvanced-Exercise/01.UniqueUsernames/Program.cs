namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new();

            for (int i = 0; i < n; i++)
                usernames.Add(Console.ReadLine());

            foreach (string name in usernames)
                Console.WriteLine(name);
        }
    }
}
