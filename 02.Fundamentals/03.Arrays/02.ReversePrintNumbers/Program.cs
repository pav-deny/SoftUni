namespace _02.ReversePrintNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            for (int j = n - 1; j >= 0; j--)
            {
                Console.Write(nums[j] + " ");
                
            }
        }
    }
}
