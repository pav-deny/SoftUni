namespace _01.ValidUsername
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length >= 3 && x.Length <= 16).ToArray();

            foreach (string name in usernames)
            {
                bool isValidUsername = name.All(c => char.IsLetterOrDigit(c) || c == '-' || c == '_');

               if (isValidUsername)
               {
                    Console.WriteLine(name);
               }
            }
        }
    }
}
