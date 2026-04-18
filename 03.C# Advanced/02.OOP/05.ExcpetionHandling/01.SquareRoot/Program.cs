namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isNonNegative = a => a >= 0;
            Func<int, double> sqrRoot = a => isNonNegative(a) ? Math.Sqrt(a) : throw new ArgumentException("Invalid number.");

            int number = int.Parse(Console.ReadLine());

            try
            {
                double sqrRootofNum = sqrRoot(number);
                Console.WriteLine(sqrRootofNum);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
