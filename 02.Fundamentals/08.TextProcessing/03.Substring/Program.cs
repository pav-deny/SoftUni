namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string substringToRemove = Console.ReadLine();
            string @string = Console.ReadLine();

            int length = substringToRemove.Length;

            while (@string.Contains(substringToRemove))
            {
                int index = @string.IndexOf(substringToRemove);
                
                @string = @string.Remove(index, length);
            }

            Console.WriteLine(@string);
        }
    }
}
