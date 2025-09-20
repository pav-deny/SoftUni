using System.Numerics;
using System.Reflection;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            matrix = ReadMatrix(matrix);

            int primarySet = 0, secondarySet = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarySet += matrix[i, i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                secondarySet += matrix[i, (matrixSize - i - 1)];
            }

            int result = Math.Abs(primarySet - secondarySet);

            Console.WriteLine(result);
        }

        private static int[,] ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int coll = 0; coll < matrix.GetLength(1); coll++)
                {
                    matrix[row, coll] = rowNums[coll];
                }
            }

            return matrix;
        }
    }
}
