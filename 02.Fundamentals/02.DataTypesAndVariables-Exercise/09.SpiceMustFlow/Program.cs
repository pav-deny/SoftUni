namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int total = 0;
            int days = 0;

            while (yield >= 100)
            {
                int extracted = yield;
                total += extracted - 26;
                days++;

                yield -= 10;
            }

            if (total >= 26)
            {
                total -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(total);
        }
    }
}
