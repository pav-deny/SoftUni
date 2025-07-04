using System.Numerics;

namespace _02.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger result = Factorial(num);

            Console.WriteLine(result);
        }

        static BigInteger Factorial(int num)
        {
            BigInteger result = 1;

            for (int i = num; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
