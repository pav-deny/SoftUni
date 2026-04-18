namespace _06.JaggedArrayModification
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

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandArgs[1]), col = int.Parse(commandArgs[2]), value = int.Parse(commandArgs[3]);

                if (!CheckIndex(jaggedArr, row, col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (commandArgs[0] == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else if (commandArgs[0] == "Subtract")
                {
                    jaggedArr[row][col] -= value;
                }
            }


            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write($"{jaggedArr[i][j]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool CheckIndex(int[][] jaggedArr, int row, int col)
        {
            if (row >= jaggedArr.Length || row < 0)
            {
                return false;
            }

            if (col >= jaggedArr[0].Length || col < 0)
            {
                return false;
            }

            return true;
        }
    }
}
