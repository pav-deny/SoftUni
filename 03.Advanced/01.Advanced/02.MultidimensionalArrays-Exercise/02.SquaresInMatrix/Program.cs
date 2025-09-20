namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0], cols = dimensions[1];

            string[,] matrix = new string[rows, cols];
            matrix = ReadMatrix(matrix);

            int count = 0;
            
            for (int i = 0; i < (rows - 1); i++)
            {
                for (int j = 0; j < (cols - 1);  j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j +1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static string[,] ReadMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            return matrix;
        }
    }
}
