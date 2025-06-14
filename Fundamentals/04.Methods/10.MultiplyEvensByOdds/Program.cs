namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultipleOfEvensAndOdds(num));
        }

        static int GetMultipleOfEvensAndOdds(int num)
        {
            return GetSumOfEvenDigits(num) * GetSumOfOddDigits(num);
        }
            
        static int GetSumOfEvenDigits(int num)
        {
            int sumOfEven = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;
                if (currentDigit % 2 == 0)
                {
                    sumOfEven += currentDigit;
                }
                num /= 10;
            }

            return sumOfEven;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sumOfOdd = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;
                if (currentDigit % 2 != 0)
                {
                    sumOfOdd += currentDigit;
                }
                num /= 10;
            }

            return sumOfOdd;
        }
    }
}
