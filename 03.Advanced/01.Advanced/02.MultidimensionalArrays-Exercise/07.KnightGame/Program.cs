using System.ComponentModel.DataAnnotations;

namespace _07.KnightGame
{
    internal class Program
    {
        const char Knight = 'K';
        const char Empty = '0';
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = ReadMatrix(n);

            int removedKnights = 0;
            bool hasConflicts = true;

            while (hasConflicts)
            {
                int biggestConflict = 0;
                int conflictRow = -1, conflictCol = -1;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (chessBoard[i, j] == Knight)
                        {
                            int currentConflict = Conflicts(chessBoard, i, j);

                            if (currentConflict > biggestConflict)
                            {
                                biggestConflict = currentConflict;
                                conflictRow = i;
                                conflictCol = j;
                            }
                        }
                    }
                }

                if (biggestConflict == 0)
                {
                    hasConflicts = false;
                }
                else
                {
                    chessBoard[conflictRow, conflictCol] = Empty;
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static int Conflicts(char[,] matrix, int row, int col)
        {
            int conflictsCount = 0;

            int[] rowMovements = {2, 2, -2, -2, 1, 1, -1, -1};
            int[] colMovements = { 1, -1, 1, -1, 2, -2, 2, -2 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + rowMovements[i];
                int newCol = col + colMovements[i];

                if (newRow < 0 || newRow >= matrix.GetLength(0) || newCol < 0 || newCol >= matrix.GetLength(1))
                    continue;

                if (matrix[newRow, newCol] == Knight)
                {
                    conflictsCount++;
                }
            }

            return conflictsCount;
        }

        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }   

            return matrix;
        }
    }
}
