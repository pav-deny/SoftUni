namespace _02.EnterNumbers
{
    internal class Program
    {
        private const int start = 1;

        static void Main(string[] args)
        {
            List<int> nums = new();
            int currentStart = start;

            while (nums.Count != 10)
            {
                try
                {
                    int num = ReadNumber(currentStart, 100);
                    nums.Add(num);
                    currentStart = num;
                }
                catch(FormatException fEx)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch(ArgumentException aEx)
                {
                    Console.WriteLine(aEx.Message);
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }

        static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > start && num < end)
                return num;

            throw new ArgumentException($"Your number is not in range {start} - {end}!");
        }
    }
}
