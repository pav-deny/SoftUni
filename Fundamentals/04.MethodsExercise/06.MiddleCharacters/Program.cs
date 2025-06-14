namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleChar(input);
        }

        static void PrintMiddleChar(string input)
        {
            int middleIndex = input.Length / 2;
            string middle = "";
            

            if ((input.Length) % 2 == 0)
            {
                middle += input[middleIndex - 1];
                middle += input[middleIndex];
            }
            else
            {
                middle += input[middleIndex];
            }

            Console.WriteLine(middle);
        }
    }
}
