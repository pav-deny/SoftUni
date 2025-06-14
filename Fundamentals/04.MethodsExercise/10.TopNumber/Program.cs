namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sum D % 8 == 0
            //1 odd digit
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                bool isDivisibleBy8 = CheckIfDivisibleBy8(i);
                bool hasAnOddDigit = CheckForOddDigit(i);

                if (isDivisibleBy8 && hasAnOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool CheckIfDivisibleBy8(int tempNum)
        {
            int sumOfDigit = 0;

            while (tempNum > 0)
            {
                sumOfDigit += (tempNum % 10);
                tempNum = tempNum / 10;
            }

            if (sumOfDigit % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool CheckForOddDigit(int num)
        {
            while (num > 0)
            {
                int digit = num % 10;

                if (digit % 2 != 0)
                {
                    return true;
                }

                num /= 10;
            }

            return false;
        }
    }
}
