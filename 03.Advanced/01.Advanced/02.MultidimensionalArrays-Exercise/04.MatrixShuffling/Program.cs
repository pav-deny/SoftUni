namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parameters[0], cols = parameters[1];

            string[,] matrix = ReadMatrix(rows, cols);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(!CheckInputValidity(commandArgs))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(commandArgs[1]), col1 = int.Parse(commandArgs[2]);
                int row2 = int.Parse(commandArgs[3]), col2 = int.Parse(commandArgs[4]);

                if(!CheckCordsValidity(matrix, row1, col1) || !CheckCordsValidity(matrix, row2, col2))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                matrix = Swap(matrix, row1, col1, row2, col2);

                PrintMatrix(matrix);
            }
        }

        private static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            return matrix;
        }

        private static bool CheckInputValidity(string[] commandArgs)
        {
            if (commandArgs[0] != "swap")
                return false;

            if (commandArgs.Length != 5)
                return false;

            return true;
        }

        private static bool CheckCordsValidity(string[,] matrix, int row, int col)
        {
            if (row >=  matrix.GetLength(0) || row < 0)
               return false;

            if (col >= matrix.GetLength(1) || col < 0)
                return false;

            return true;
        }

        private static string[,] Swap(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            string oldVal = matrix[row1, col1];

            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = oldVal;

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
