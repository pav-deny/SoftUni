namespace _08.NumTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 to n
            int n = int.Parse(Console.ReadLine());
            int timesWritten = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = timesWritten; j > 0; j--)
                {
                    Console.Write(i + " ");  
                }
                timesWritten++;
                Console.WriteLine();
            }
        }
    }
}
