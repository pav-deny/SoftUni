namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int primaryDiagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];

                    if (i == j)
                    {
                        primaryDiagonalSum += currentRow[j];
                    }
                }
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
