namespace BombsMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string[] bombsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var bomb in bombsInput)
            {
                int[] coords = bomb.Split(',').Select(int.Parse).ToArray();
                int row = coords[0];
                int col = coords[1];
                int bombValue = matrix[row, col];

                if (bombValue > 0)
                {
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if (r >= 0 && r < n && c >= 0 && c < n && matrix[r, c] > 0)
                            {
                                matrix[r, c] -= bombValue;
                            }
                        }
                    }
                    matrix[row, col] = 0;
                }
            }

            int aliveCells = 0;
            int sumAlive = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sumAlive += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAlive}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j != n - 1)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
