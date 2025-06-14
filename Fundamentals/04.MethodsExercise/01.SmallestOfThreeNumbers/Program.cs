namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            PrintSmallest(num1, num2, num3);
        }

        static void PrintSmallest(int num1, int num2, int num3)
        {
            int[] nums = { num1, num2, num3 };
            int smallest = int.MaxValue;

            foreach (int i in nums)
            {
                if (i  < smallest)
                {
                    smallest = i;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
