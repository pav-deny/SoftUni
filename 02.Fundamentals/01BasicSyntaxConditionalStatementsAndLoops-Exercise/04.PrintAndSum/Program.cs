namespace _04.PrintAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }

            Console.WriteLine($"\nSum: {sum}"); //\n puts it on a new line
        }
    }
}
