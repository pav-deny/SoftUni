namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            PrintTriangle(1, end);
        }

        static void PrintTriangle(int start, int end)
        {
                int num = 1;

            for (int k = start; k <= end; k++)
            {
                for (int i = start; i <= num; i++)
                {
                    Console.Write(i + " ");

                }
                Console.WriteLine();
                num++;
            }

            num-= 2;

            for (int k = end; k > start; k--)
            {
                for (int i = start; i <= num; i++)
                {
                    Console.Write(i + " ");

                }
                Console.WriteLine();
                num--;
            }

        }
    }
}
