namespace _01.SignOfIntNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Sign(num);
        }

        static void Sign(int num)
        {
            if(num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else if(num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");

            }
            else
            {
                Console.WriteLine($"The number {num} is zero.");
            }
        }
    }
}
