namespace _12.RefractorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());


            for (int i = 1; i <= count; i++)
            {
                int number = i;
                int digitSum = 0;

                while (number > 0)
                {
                    digitSum += number % 10;
                    number = number / 10;
                }

                bool isSpecial = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);

                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}
