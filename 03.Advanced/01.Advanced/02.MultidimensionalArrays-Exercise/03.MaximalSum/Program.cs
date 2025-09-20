using System.Collections.Immutable;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0], cols = dimensions[1];

            int[][] matrix = new int[rows][];
            matrix = ReadMatrix(matrix, rows, cols);

            int maxSum = int.MinValue, maxRow = -1, maxCol = -1;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int sum = SumInSubMatrix(matrix, i, j, 3, 3);
                    
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
        }

        static int SumInSubMatrix(int[][] matrix, int row, int col, int height, int width)
        {
            int sum = 0;

            for(int i = 0; i < height; i++)
            {
                for (int j =0; j < width; j++)
                {
                    sum+= matrix[row + i][col + j];
                }
            }

            return sum;
        }

        static int[][] ReadMatrix(int[][] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];

                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = input[j];
                }
            }
        }
    }
}
