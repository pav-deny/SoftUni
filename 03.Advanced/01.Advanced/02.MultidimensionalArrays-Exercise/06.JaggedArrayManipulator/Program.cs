using System.Numerics;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArr[i] = new int[currentRow.Length];

                for (int j = 0; j < currentRow.Length; j++)
                {
                    jaggedArr[i][j] = currentRow[j];
                }
            }

            for (int i = 0; i < rows - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    ModifyMatrix(jaggedArr, i, 2);
                    ModifyMatrix(jaggedArr, i + 1, 2);
                }
                else
                {
                    ModifyMatrix(jaggedArr, i, 0.5);
                    ModifyMatrix(jaggedArr, i + 1, 0.5);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandArgs[1]), col = int.Parse(commandArgs[2]), value = int.Parse(commandArgs[3]);

                if (!CheckValidity(jaggedArr, row, col))
                    continue;

                if (commandArgs[0] == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else if (commandArgs[0] == "Subtract")
                {
                    jaggedArr[row][col] -= value;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write(jaggedArr[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[][] ModifyMatrix(int[][] jagged, int row, double modifier)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                jagged[row][i] = (int)(jagged[row][i] * modifier);
            }

            return jagged;
        }

        private static bool CheckValidity(int[][] jaggedArr, int row, int col)
        {
            if (row < 0 || row >= jaggedArr.Length)
                return false;

            if (col < 0 || col >= jaggedArr[row].Length)
                return false;

            return true;
        }
    }
}
