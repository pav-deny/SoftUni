    namespace RecursiveFactorial
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());

                int result = Factorial(n);
                Console.WriteLine(result);
            }

            static int Factorial(int n)
            {
                if (n == 1) 
                    return 1;

                return n * Factorial(n - 1);
            }
        }
    }
