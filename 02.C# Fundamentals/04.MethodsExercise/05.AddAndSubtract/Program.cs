namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int addedNums = AddNums(num1, num2);
            int result = SubtractNums(addedNums, num3);

            Console.WriteLine(result);
        }

        static int AddNums(int num1, int num2)
        {
            return num1 + num2;
        }

        static int SubtractNums(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
