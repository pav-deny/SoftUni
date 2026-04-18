namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            
            for (int i = 0; i < n; i++)
            {
                string currentRow = Console.ReadLine();
            
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            char ch = char.Parse(Console.ReadLine());

            int row = -1, col = -1;
            bool isFound = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == ch)
                    {
                        row = i;
                        col = j; 
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                    break;
            }

            if (isFound)
            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }
        }
    }
}
