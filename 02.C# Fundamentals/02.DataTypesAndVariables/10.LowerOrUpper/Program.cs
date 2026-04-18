namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if (character >= 'A' && character <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else if (character >= 'a' && character <= 'z')
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
