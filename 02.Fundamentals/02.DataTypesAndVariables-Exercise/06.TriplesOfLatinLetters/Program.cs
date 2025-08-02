namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char letter1 = 'a';

            for (int i = 0; i < n; i++)
            { 
                char letter2 = 'a';
                for (int j = 0; j < n; j++)
                {
                    char letter3 = 'a';
                    for (int k = 0; k < n; k++)
                    {
                        Console.WriteLine($"{letter1}{letter2}{letter3}");
                        letter3++;
                    }
                    letter2++;
                }
                letter1++;
            }
        }
    }
}
