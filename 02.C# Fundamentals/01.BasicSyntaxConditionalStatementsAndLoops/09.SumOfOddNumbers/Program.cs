namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int oddNumber = i * 2 + 1;

                Console.WriteLine(oddNumber);
                sum += oddNumber;
            }

            Console.WriteLine("Sum: " + sum);

        }
    }
}
