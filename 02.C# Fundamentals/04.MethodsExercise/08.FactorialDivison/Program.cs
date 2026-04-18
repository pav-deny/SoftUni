namespace _08.FactorialDivison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());

            double num1Factorial = GetFactorial(num1);
            double num2Factorial = GetFactorial(num2);

            double result = num1Factorial / num2Factorial;
            Console.WriteLine($"{result:f2}");
        }

        static double GetFactorial(long num)
        {
            double factorial = 1.0;
            for (int i = (int)num; i > 0; i--)
            {
                factorial *= i;
            }
        
            return factorial;
        }
    }
}
