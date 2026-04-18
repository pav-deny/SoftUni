namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int digitSum = default;
                int number = i;

                while (number > 0)
                {
                    int digit = number % 10;
                    number /= 10;

                    digitSum += digit;
                }

                bool isSpecial = digitSum == 5 || digitSum == 7 || digitSum == 11;

                if (isSpecial)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
