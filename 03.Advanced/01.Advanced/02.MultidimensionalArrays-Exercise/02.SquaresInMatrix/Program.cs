namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parameters[0], cols = parameters[1];

            char[,] matrix = new char[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];   
                }
            }

            int equalSquaresCount = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (CheckForEqualSquare(matrix, i, j))
                    {
                        equalSquaresCount++;
                    }
                }
            }

                Console.WriteLine(equalSquaresCount);
        }

        private static bool CheckForEqualSquare(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
            {
                return true;
            }

            return false;
        }
    }
}
