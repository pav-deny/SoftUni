namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];
            pascalTriangle[0] = new long[] {1};

            for (int i = 1; i < rows; i++)
            {
                pascalTriangle[i] = new long[i + 1];

                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }

                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < pascalTriangle[i].Length; j++)
                {
                    Console.Write($"{pascalTriangle[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
